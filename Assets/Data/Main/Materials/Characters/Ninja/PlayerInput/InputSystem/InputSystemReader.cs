using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputSystemReader : MonoBehaviour
{
    [SerializeField] private PlayerMove _playerMove;

    private InputSystem _inputActions;

    private void Awake()
    {
        _inputActions = new InputSystem();
        _inputActions.Player.Move.performed += OnHorizontalMovement;
        _inputActions.Player.Move.canceled += OnHorizontalMovement;

        _inputActions.Player.Jump.performed += OnJump;        
        _inputActions.Player.Jump.canceled += OnJump;        
    }

    private void OnEnable()
    {
        _inputActions.Enable();
    }

    public void OnHorizontalMovement(InputAction.CallbackContext context)
    {
        var _dirX = context.ReadValue<Vector2>();
        _playerMove.SetMoveDirection(_dirX);
    }


    public void OnJump(InputAction.CallbackContext context)
    {
       float _dirY = context.ReadValue<float>();
        _playerMove.SetJumpDir(_dirY);
    }
}
