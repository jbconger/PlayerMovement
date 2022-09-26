using UnityEngine;

public class GroundedState : PlayerState
{
    protected bool isGrounded;
    private readonly Collider2D[] ground = new Collider2D[1];

    public GroundedState(PlayerController player) : base(player)
	{
        
	}

	public override void Enter()
	{
		base.Enter();
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

		Grounding();
	}

	protected void Grounding()
	{
		bool grounded = Physics2D.OverlapCircleNonAlloc(player.transform.position + new Vector3(0, player.groundOffset), player.groundRadius, ground, player.groundMask) > 0;
		Debug.Log(grounded);
		if (!isGrounded && grounded)
		{
			isGrounded = true; 
			Debug.Log("Grounded: " + isGrounded);
		}
		else if (isGrounded && !grounded)
		{
			isGrounded = false;
		}
	}
}
