using Godot;
using System;

public partial class PlayerStateJump : PlayerState
{
    private float _jumpForce = 250.0f;

    public override void Enter(PlayerData data = null)
    {
        GD.Print("Enter State Jump");
        Player.Velocity = new Vector2(Player.Velocity.X, Player.Velocity.Y - _jumpForce);
        Player.PlayerAnimation.Play("jump");
    }



    

}
