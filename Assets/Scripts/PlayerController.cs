using UnityEngine;

public class PlayerController : Character
{
    //Intance
    public static PlayerController Instance;

    private PlayerInputManager _inputManager;

    private Rigidbody2D _rigidBody2D;
    private float playerScale;


    public ScriptableBuff speedBuff;
    


    private void Awake()
    {
        Instance = this;
        currentHealth = maxHealth;
        currentResource = 0;

        _rigidBody2D = GetComponent<Rigidbody2D>();
        playerScale = transform.localScale.x;


    }

    private void Start()
    {
        _inputManager = PlayerInputManager.Instance;
    }

    // Update is called once per frame
    private new void Update()
    {
        base.Update();
        FlipPlayer();
    }

    public override void AddBuff(TimedBuff buff)
    {
        base.AddBuff(buff);
        
        UIBuffController.Instance.AddBuff(buff);
    }

    public void TestSpeedBuff()
    {
        AddBuff(speedBuff.InitializeBuff(gameObject));
    }

    /// <summary>
    /// Flips Player Sprite based on movement direction.
    /// </summary>
    private void FlipPlayer()
    {
        if (_inputManager.GetMovementX() != 0) _inputManager.SetHorizontalInput(_inputManager.GetMovementX());
        transform.localScale = new Vector3(_inputManager.GetLastHorizontalInput() > 0 ? playerScale : -playerScale, playerScale, playerScale);
    }

    /// <summary>
    /// Moves the player's rigidbody at a given speed.
    /// </summary>
    /// <param name="speed"></param>
    public void Move(float speed)
    {
        _rigidBody2D.velocity = new Vector2(_inputManager.GetMovementX() * speed, _inputManager.GetMovementY() * speed);
    }

}
