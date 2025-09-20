using Godot;
using System;

public partial class PlayerState : Node
{
    protected Player Player;

    public void Init(Player player)
    {
        Player = player;
    }

    public virtual void Enter(PlayerData data = null) { }
    public virtual void Exit() { }
    public virtual void Update(double delta) { }
    public virtual void FixedUpdate(double delta) { }
    
    public virtual void OnAnimationCompelete()
    {

    }
}
