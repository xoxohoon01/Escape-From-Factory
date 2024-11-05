using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    private Camera camera;
    public GameObject currentInteractGameObject;
    private IInteractable currentInteractable;

    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;

    private void Start()
    {
        camera = Camera.main;
    }

    private void Update()
    {
        RayCheck();
    }
    
    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && currentInteractable != null)
        {
            currentInteractable.Interact();
            currentInteractGameObject = null;
            currentInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }

    private void RayCheck()
    {
        if (Time.time - lastCheckTime > checkRate)
        {
            lastCheckTime = Time.time;
            Ray ray = camera.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, maxCheckDistance, layerMask))
            {
                if (hit.collider.gameObject != currentInteractGameObject)
                {
                    currentInteractGameObject = hit.collider.gameObject;
                    currentInteractable = hit.collider.GetComponent<IInteractable>();
                    SetPromptText();
                }
            }
            else
            {
                currentInteractGameObject = null;
                currentInteractable = null;
                promptText.gameObject.SetActive(false);
            }
        }
    }

    private void SetPromptText()
    {
        promptText.gameObject.SetActive(true);
        promptText.text ="SomeObject";
        //promptText.text = curInteractable.GetInteractPrompt();
    }
}