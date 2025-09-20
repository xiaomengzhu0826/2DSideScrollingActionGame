using Godot;
using System;

public partial class PlayerStateBrake : PlayerState
{
    private float _groundBrake = 20f;

    public override void Enter(PlayerData data = null)
    {
        GD.Print("Enter State Brake");
        Player.PlayerAnimation.Play("brake");
    }

    public override void FixedUpdate(double delta)
    {
        Player.Velocity = new Vector2(Mathf.Lerp(Player.Velocity.X, 0, _groundBrake * (float)delta), Player.Velocity.Y);
        if (Mathf.Abs(Player.Velocity.X) < .1f)
        {
            Player.ChangeState(Player.IdleState);
        }
    }
}
