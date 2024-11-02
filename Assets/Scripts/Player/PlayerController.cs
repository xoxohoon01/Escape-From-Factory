using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [Header("Move")]
    [SerializeField][Range(1, 10)] private float moveSpeed;
    [SerializeField][Range(5, 15)] private float sprintSpeed;
    private Vector2 moveInput;
    public bool isSprint;

    [Header("Look")]
    [SerializeField] private Transform camContainer;
    [SerializeField] private float lookSensitively = 0.02f;
    [SerializeField] private float minYLook = -85;
    [SerializeField] private float maxYLook = 80;
    private float curCamXRotation;
    private float curCamYRotation;

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
        Look();
    }

    #region 이동

    public void OnSprint(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
            isSprint = true;
        else
            isSprint = false;
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
        }
    }

    private void Move()
    {
        Vector3 _dir = (transform.forward * moveInput.y + transform.right * moveInput.x).normalized * (isSprint?sprintSpeed:moveSpeed) * Time.deltaTime;
        rb.MovePosition(rb.position + _dir);
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

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started && isGrounded())
        {
            rb.AddForce(Vector2.up * jumpPower, ForceMode.Impulse);
        }
    }

    #endregion

    #region 카메라 회전
    public void OnLook(InputAction.CallbackContext context)
    {
        Vector2 _lookVector = context.ReadValue<Vector2>();
        curCamXRotation += _lookVector.x * lookSensitively;
        curCamYRotation = Mathf.Clamp(curCamYRotation + (_lookVector.y * lookSensitively), minYLook, maxYLook);
    }

    private void Look()
    {
        camContainer.localEulerAngles = new Vector3(-curCamYRotation, 0, 0);
        transform.eulerAngles = new Vector3(0, curCamXRotation, 0);
    }

    #endregion

    public void OnInteract(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            onInteraction?.Invoke();
        }
    }

    public void OnInventory(InputAction.CallbackContext context)
    {
        if(context.phase == InputActionPhase.Started)
        {
            onOpenInventory?.Invoke();
        }
    }
}
