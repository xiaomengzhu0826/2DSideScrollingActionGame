using Godot;
using System;
using System.Collections.Generic;

public class PlayerStateFactroy 
{
    public Dictionary<Player.State,  Func<PlayerState>> _states;

    public PlayerStateFactroy()
    {
        _states = new()
        {
            {Player.State.IDLE, () => new PlayerStateIdle() },
            { Player.State.MOVING, () => new PlayerStateMoving() },
        };
    }

    public PlayerState GetNewState(Player.State state)
    {
        if (!_states.TryGetValue(state, out Func<PlayerState> value))
        {
            throw new Exception("State does not exist");
        }
        return value();
    }
}
