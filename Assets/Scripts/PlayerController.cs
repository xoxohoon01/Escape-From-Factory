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


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Move();
    }

    private void LateUpdate()
    {
        Look();
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
        if(context.phase == InputActionPhase.Started)
        {

        }
    }

}
