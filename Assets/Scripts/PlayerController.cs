using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Intance
    public static PlayerController Instance;

    private Rigidbody2D _rigidBody2D;
    private float playerScale;

    
    private PlayerInputManager _inputManager;


    private void Awake()
    {
        Instance = this;
        
        _rigidBody2D = GetComponent<Rigidbody2D>();
        playerScale = transform.localScale.x;
    }

    private void Start()
    {
        _inputManager = PlayerInputManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
    }
  
    
    /// <summary>
    /// Flips Player Sprite based on movement direction
    /// </summary>
    private void FlipPlayer()
    {
        if (_inputManager.GetMovementX() != 0) _inputManager.SetHorizontalInput(_inputManager.GetMovementX());
        transform.localScale = new Vector3(_inputManager.GetLastHorizontalInput() > 0 ? playerScale : -playerScale, playerScale, playerScale);
    }
    
    public void SetRigidbodyVelocity(float speed)
    {
        _rigidBody2D.velocity = new Vector2(_inputManager.GetMovementX() * speed, _inputManager.GetMovementY() * speed);
    }

}
