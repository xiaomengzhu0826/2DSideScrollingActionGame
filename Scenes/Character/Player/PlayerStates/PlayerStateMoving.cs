using Godot;
using System;

public partial class PlayerStateMoving : PlayerState
{
	private bool _isSprint;

	public override void _PhysicsProcess(double delta)
	{
		Vector2 input = InputManager.GetInputVector(Player.ControlScheme.P1);
		_player.Velocity = input * _player.NormalSpeed;
		
	}
}
