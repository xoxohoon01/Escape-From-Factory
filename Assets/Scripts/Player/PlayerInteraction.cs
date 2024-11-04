using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public TextMeshProUGUI promptText;
    private Camera camera;
    
    private PlayerController controller;


    private void Awake()
    {
        controller = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        controller.onInteraction += OnInteract;
    }

    private void OnDisable()
    {
        controller.onInteraction -= OnInteract;
    }

    private void Update()
    {
        //RayCheck();
    }

    private void OnInteract()
    {

    }


    private void RayCheck()
    {
        throw new NotImplementedException();
    }

}
