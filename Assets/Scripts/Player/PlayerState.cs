using UnityEngine;

public class PlayerState
{
    protected PlayerController player;

    protected struct Inputs
	{
        public int RawX;
        public int RawY;
        public float X;
        public float Y;
	}

    protected Inputs inputs;
    protected bool isFacingLeft;

    public PlayerState(PlayerController i_playerController)
	{
        player = i_playerController;
	}

    public virtual void Enter()
	{
        inputs.RawX = inputs.RawY = 0;
        inputs.X = inputs.Y = 0;
	}

    public virtual void Exit()
    {

    }

    public virtual void HandleInput()
	{
        CheckInput();
        UpdateSprite();
	}

    public virtual void StateUpdate()
	{
        Falling();
	}

    protected void CheckInput()
    {
        inputs.RawX = (int)Input.GetAxisRaw("Horizontal");
        inputs.RawY = (int)Input.GetAxisRaw("Vertical");
        inputs.X = Input.GetAxis("Horizontal");
        inputs.Y = Input.GetAxis("Vertical");

        isFacingLeft = inputs.RawX != 1 && (inputs.RawX == -1 || isFacingLeft);
    }

    protected void UpdateSprite()
	{
        if (isFacingLeft)
            player.sprite.flipX = true;
        else
            player.sprite.flipX = false;
    }

    protected void Falling()
    {
        if (player.rb2D.velocity.y < player.jumpVelocityFalloff || player.rb2D.velocity.y > 0 && (!Input.GetKey(KeyCode.Space) && !Input.GetKey(KeyCode.Z)))
            player.rb2D.velocity += player.fallMultiplier * Physics.gravity.y * Vector2.up * Time.deltaTime;
    }
}
