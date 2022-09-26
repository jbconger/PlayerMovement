using UnityEngine;

public class JumpState : MovingState
{
	public JumpState (PlayerController player) : base(player)
	{

	}

	public override void Enter()
	{
		base.Enter();
		dash = false;
		isGrounded = false;
		Jump();
	}

	public override void Exit()
	{
		base.Exit();
	}

	public override void HandleInput()
	{
		base.HandleInput();
	}

	public override void StateUpdate()
	{
		base.StateUpdate();

		if (isGrounded)
		{ 
			player.stateMachine.ChangeState(player.movingState); 
			Debug.Log("Changed to move state"); 
		}
		else if (dash)
			player.stateMachine.ChangeState(player.dashState);
	}

	private void Jump()
	{
		player.rb2D.velocity = new Vector2(player.rb2D.velocity.x, player.jumpForce);
	}
}
