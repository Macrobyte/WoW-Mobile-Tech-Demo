
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    private PlayerController _playerController;
    public float Speed = 5f;
   

    private void Start()
    {
        _playerController = PlayerController.Instance;
    }


    private void Update()
    {
        HandlePlayerMovement();
    }

    private void HandlePlayerMovement()
    {
        _playerController.Move(Speed);

    }


}

