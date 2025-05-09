using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector2 MoveInput { get; private set; }
    public bool IsShooting { get; private set; }

    private PlayerInputActions playerActions;

    private void Update()
    {
        Debug.Log("IsShooting:" + IsShooting);
    }

    private void OnEnable()
    {
        playerActions = new PlayerInputActions();
        playerActions.Player.Enable();
        playerActions.Player.Move.performed += OnMove;
        playerActions.Player.Move.canceled += OnMoveCanceled;
        playerActions.Player.Fire.performed += OnFire;
        playerActions.Player.Fire.canceled += OnFireCanceled;
    }

    private void OnDisable()
    {
        playerActions.Player.Move.performed -= OnMove;
        playerActions.Player.Move.canceled -= OnMoveCanceled;
        playerActions.Player.Fire.performed -= OnFire;
        playerActions.Player.Fire.canceled -= OnFireCanceled;
        playerActions.Player.Disable();
    }

    private void OnMove(InputAction.CallbackContext context)
    {
        MoveInput = context.ReadValue<Vector2>();
    }

    private void OnMoveCanceled(InputAction.CallbackContext context)
    {
        MoveInput = Vector2.zero;
    }

    private void OnFire(InputAction.CallbackContext context)
    {
        IsShooting = true;
    }

    private void OnFireCanceled(InputAction.CallbackContext context)
    {
        IsShooting = false;
    }
}

