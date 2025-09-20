using Godot;
using System;

public partial class PlayerStateJumpPreparation : PlayerState
{
    public override void Enter(PlayerData data = null)
    {
        GD.Print("Enter State jump_preparation");
        Player.PlayerAnimation.Play("jump_preparation");
    }

    public override void OnAnimationCompelete()
    {
        Player.ChangeState(Player.JumpState);
    }

}
