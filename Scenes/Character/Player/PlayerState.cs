using Godot;
using System;

public partial class PlayerState : Node
{
    [Signal] public delegate void OnStateTransitionRequestEventHandler(Player.State newState, PlayerStateData stateData);

    protected Player _player;

    public virtual void OnAnimationCompelete()
    {

    }

    public void Setup(Player contextPlayer)
    {
        _player = contextPlayer;
    }

    public void TransitionState(Player.State newState,PlayerStateData data=null)
    {
        EmitSignal(SignalName.OnStateTransitionRequest,(int)newState,data);
    }

}
