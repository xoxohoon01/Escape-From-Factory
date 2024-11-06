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
    public InteractableObject currentInteractObject;
    private IInteractable currentInteractable;

    public float checkRate = 0.05f;
    private float lastCheckTime;
    public float maxCheckDistance;
    public LayerMask layerMask;
    public InventoryController inventoryController;

    private void Awake()
    {
        inventoryController = GetComponent<InventoryController>();
    }
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
            InteractItem();
            currentInteractGameObject = null;
            currentInteractable = null;
            promptText.gameObject.SetActive(false);
        }
    }

    public void InteractItem()
    {
        if ( currentInteractable.IsObtainable())
        {
            inventoryController.inventory.AddItem(currentInteractObject.objectSO);
            Destroy(currentInteractGameObject.gameObject);
        }
        else
        {
            currentInteractable.Interact();
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
                    currentInteractObject = hit.collider.GetComponent<InteractableObject>();
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
        promptText.text = currentInteractObject.objectSO.Name;
    }
}