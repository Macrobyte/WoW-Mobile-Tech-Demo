using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator _animator;
    private PlayerInputManager _inputManager;

    private void Awake()
    {
        _animator = GetComponent<Animator>();

        
    }
    private void Start()
    {
        _inputManager = PlayerInputManager.Instance;
    }
    private void Update()
    {
        HandlePlayerAnimation();
    }

    private void HandlePlayerAnimation()
    {
        if (_inputManager.GetMovementVector() != Vector2.zero)
        {      
            _animator.SetFloat("Horizontal", _inputManager.GetMovementX());
            _animator.SetFloat("Vertical", _inputManager.GetMovementY());
            _animator.SetBool("IsMoving", true);
        }
        else
        {
            _animator.SetBool("IsMoving", false);
        }
    }
}
