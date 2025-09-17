using Godot;
using System;

public partial class PlayerStateIdle : PlayerState
{
    public override void _PhysicsProcess(double delta)
    {
        Vector2 input = InputManager.GetInputVector(Player.ControlScheme.P1);
        if (input != Vector2.Zero)
        {
            TransitionState(Player.State.MOVING);
        }
	}
}
