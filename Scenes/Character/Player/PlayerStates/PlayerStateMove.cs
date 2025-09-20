using Godot;
using System;

public partial class PlayerStateMove : PlayerState
{
	private float _speed = 100f;
	private float _acceleration = 50f;
	private float _groundBrake = 20f;

	public override void Enter(PlayerData data = null)
	{
		GD.Print("Enter State Move");
		Player.PlayerAnimation.Play("run");
	}

	public override void FixedUpdate(double delta)
	{
		float xInput = InputManager.GetHorizontalAxis(Player.CurrentControlScheme);
		if (xInput != 0)
		{
			Player.Velocity = new Vector2(Mathf.Lerp(Player.Velocity.X, xInput * Player.NormalSpeed, _acceleration * (float)delta), Player.Velocity.Y);
		}
		else
		{
			Player.ChangeState(Player.IdleState);
		}

		if (InputManager.IsActionPressed(Player.CurrentControlScheme, InputManager.InputType.JUMP) && Player.IsOnFloor())
		{
			Player.ChangeState(Player.JumpPreparationState);
		}
		Player.SetHeading();
	}

}
