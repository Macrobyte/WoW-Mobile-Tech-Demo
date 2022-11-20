using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputManager : MonoBehaviour
{

    //Instance
    public static PlayerInputManager Instance;


    private PlayerInputActions _inputActions;
    private Vector2 _movementInput;

    private float lastHorizontalInput;



    private void Awake()
    {
        Instance = this;
              
        _inputActions = new PlayerInputActions();
        _inputActions.Player.Enable();

        _inputActions.Player.Attack.performed += HandleAttackInput;
    }

    private void Update()
    {
        HandleMovementInput();
    }
    
    private void HandleMovementInput()
    {
        _movementInput = _inputActions.Player.Movement.ReadValue<Vector2>();
    }

    private void HandleAttackInput(InputAction.CallbackContext obj)
    {
        
    }
    
    public Vector2 GetMovementVector()
    {
        return _movementInput;
    }
    
    public float GetMovementX()
    {
        return _movementInput.x;
    }

    public float GetMovementY()
    {
        return _movementInput.y;
    }

    public void SetHorizontalInput(float value)
    {
        lastHorizontalInput = value;
    }

    public float GetLastHorizontalInput()
    {
        return lastHorizontalInput;
    }

    public void DebugFunc(string message)
    {
        Debug.Log(message);
    }
}
