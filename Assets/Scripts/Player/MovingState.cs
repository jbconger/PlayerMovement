using UnityEngine;

public class MovingState : GroundedState
{
	protected bool jump;
	protected bool dash;

    public MovingState(PlayerController player) : base(player)
	{

	}

	public override void Enter()
	{
		base.Enter();
		jump = false;
		dash = false;
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void HandleInput()
	{
		base.HandleInput();
		if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Z) && isGrounded)
			jump = true;
		else if (Input.GetKeyDown(KeyCode.X) || Input.GetKeyDown(KeyCode.LeftAlt))
			dash = true;
	}

	public override void StateUpdate()
	{
		base.StateUpdate();

		Moving();

		if (jump)
		{
			player.stateMachine.ChangeState(player.jumpState);
			isGrounded = false;
		}
		else if (dash)
			player.stateMachine.ChangeState(player.dashState);
	}

	private void Moving()
	{
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			if (player.rb2D.velocity.x > 0)
				inputs.X = 0;
			inputs.X = Mathf.MoveTowards(inputs.X, -1, player.acceleration * Time.deltaTime);
		}
		else if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			if (player.rb2D.velocity.x < 0)
				inputs.X = 0;
			inputs.X = Mathf.MoveTowards(inputs.X, 1, player.acceleration * Time.deltaTime);
		}
		else
		{
			inputs.X = Mathf.MoveTowards(inputs.X, 0, player.acceleration * 2 * Time.deltaTime);
		}

		Vector3 velocity = new Vector3(inputs.X * player.moveSpeed, player.rb2D.velocity.y);
		player.rb2D.velocity = Vector3.MoveTowards(player.rb2D.velocity, velocity, player.moveLerpSpeed * Time.deltaTime);

		// set walking animation
	}
}
