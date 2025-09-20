using Godot;
using System;

public partial class PlayerStateIdle : PlayerState
{
    private float _acceleration = 50f;
    private float _groundBrake = 20f;

    public override void Enter(PlayerData data = null)
    {
        GD.Print("Enter State Idle");
        Player.PlayerAnimation.Play("idle");
    }

    public override void FixedUpdate(double delta)
    {
        float xInput = InputManager.GetHorizontalAxis(Player.CurrentControlScheme);
        if (xInput != 0)
        {
            Player.ChangeState(Player.MoveState);
        }
        else
        {
            Player.Velocity = new Vector2(Mathf.Lerp(Player.Velocity.X, 0, _groundBrake * (float)delta), Player.Velocity.Y);
        }
        if (InputManager.IsActionPressed(Player.CurrentControlScheme, InputManager.InputType.JUMP) && Player.IsOnFloor())
        {
            Player.ChangeState(Player.JumpPreparationState);
        }
    }
}
