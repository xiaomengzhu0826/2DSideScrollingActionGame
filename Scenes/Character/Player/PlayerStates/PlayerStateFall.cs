using Godot;
using System;

public partial class PlayerStateFall : PlayerState
{
    private float _airSpeed = 100;
	private float _acceleration = 50;

    public override void Enter(PlayerData data = null)
	{
		GD.Print("Enter State Fall");
		Player.PlayerAnimation.Play("fall");
	}

    public override void FixedUpdate(double delta)
	{
		float xInput = InputManager.GetHorizontalAxis(Player.CurrentControlScheme);
		if (xInput != 0)
		{
			Player.Velocity = new Vector2(Mathf.Lerp(Player.Velocity.X, xInput * _airSpeed, _acceleration * (float)delta), Player.Velocity.Y);
		}
		if (Player.IsOnFloor())
		{
			Player.ChangeState(Player.IdleState);
		}
		Player.SetHeading();
	}
}
