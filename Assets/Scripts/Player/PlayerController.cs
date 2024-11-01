using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Move")]
    [SerializeField][Range(1, 10)] private float moveSpeed;
    private Vector2 moveInput;

    [Header("Look")]
    [SerializeField] private Transform camContainer;
    [SerializeField] private float lookSensitively;
    [SerializeField] private float maxXLook;
    [SerializeField] private float minXLook;
    private Vector2 lookInput;
    private float curCamXRot;
    private bool isInvenOpen;

    [Header("Jump")]
    [SerializeField] private float jumpPower;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float maxRayDistance;

    [Header("Inventory")]
    public Action onOpenInventory;

    [Header("Interact")]
    public Action onInteraction;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        if (isInvenOpen = Cursor.lockState == CursorLockMode.Locked)
        {
            Look();
        }
    }

    private void Move()
    {
        Vector3 dir = (transform.forward * moveInput.y + transform.right * moveInput.x).normalized;
        dir *= moveSpeed;
        dir.y = rb.velocity.y;
        rb.velocity = dir;
    }

    private void Look()
    {
        curCamXRot += lookInput.y * lookSensitively;
        curCamXRot = Mathf.Clamp(curCamXRot, minXLook, maxXLook);
        camContainer.localEulerAngles = new Vector3(-curCamXRot, 0, 0);
        transform.eulerAngles += new Vector3(0, lookInput.x * lookSensitively, 0);
    }

    private bool isGrounded()
    {
        Ray[] rays = new Ray[4]
        {
            new Ray(transform.position + (transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.forward * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down),
            new Ray(transform.position + (-transform.right * 0.2f) + (transform.up * 0.01f), Vector3.down)
        };

        for (int i = 0; i < rays.Length; i++)
        {
            if (Physics.Raycast(rays[i], maxRayDistance, groundLayer))
            {
                return true;
            }
        }
        return false;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            moveInput = context.ReadValue<Vector2>();
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            moveInput = Vector2.zero;
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }
    }

    public void OnLook(InputAction.CallbackContext context)
    {
        lookInput = context.ReadValue<Vector2>();
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            onInteraction?.Invoke();
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            OnToggle();
            onOpenInventory?.Invoke();
        }
    }

    private void OnToggle()
    {
        Cursor.lockState = isInvenOpen ? CursorLockMode.None : CursorLockMode.Locked;
    }
}
