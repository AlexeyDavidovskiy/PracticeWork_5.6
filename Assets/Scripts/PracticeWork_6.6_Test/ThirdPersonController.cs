using UnityEngine;
using Cinemachine;

public class ThirdPersonController : MonoBehaviour, IPlayer
{
    [SerializeField] private Rigidbody rb;
    [SerializeField] private PlayerInputHandler playerInput;
    [SerializeField] private CinemachineFreeLook freeLookCamera;
    [SerializeField] private Transform firePoint;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    private Vector3 moveDirection;
    private Transform cameraTransform;

    public Transform FirePoint => firePoint;

    public Vector3 Position => transform.position;

    private void Awake()
    {
        cameraTransform = Camera.main.transform;
    }

    private void FixedUpdate()
    {
        ProcessInput();

        MoveCharacter();

        RotateCharacter();
    }

    private void ProcessInput() 
    {
        Vector2 input = playerInput.MoveInput;

        Vector3 cameraForward = cameraTransform.forward;
        cameraForward.y = 0;
        cameraForward.Normalize();

        Vector3 cameraRight = cameraTransform.right;
        cameraRight.y = 0;
        cameraRight.Normalize();

        moveDirection = (cameraForward * input.y + cameraRight * input.x).normalized;
    }

    private void MoveCharacter() 
    {
        Vector3 velocity = moveDirection * moveSpeed;
        rb.velocity = new Vector3(velocity.x,rb.velocity.y,velocity.z);
    }

    private void RotateCharacter() 
    {
        if (moveDirection.magnitude > 0.1f) 
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            Quaternion smoothRotation = Quaternion.Slerp(rb.rotation, targetRotation, rotationSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(smoothRotation);
        }
    }
}
