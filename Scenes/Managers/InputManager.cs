using Godot;
using System;
using System.Collections.Generic;

public partial class InputManager : Node
{
    public static InputManager Instance { get; private set; }

    public override void _Ready()
    {
        Instance = this;
    }

    public enum InputType { LEFT, RIGHT, UP, DOWN, JUMP, ATTACK, SPRINT }

    public static readonly Dictionary<Player.ControlScheme, Dictionary<InputType, string>> INPUT_MAP = new()
    {
        {
            Player.ControlScheme.P1, new Dictionary<InputType, string>
            {
                { InputType.LEFT, "p1_left" },
                { InputType.RIGHT, "p1_right" },
                { InputType.UP, "p1_up" },
                { InputType.DOWN, "p1_down" },
                { InputType.JUMP, "p1_jump" },
                
            }
        },
        {
            Player.ControlScheme.P2, new Dictionary<InputType, string>
            {
                { InputType.LEFT, "p2_left" },
                { InputType.RIGHT, "p2_right" },
                { InputType.UP, "p2_up" },
                { InputType.DOWN, "p2_down" },
            }
        },
    };

    public static Vector2 GetInputVector(Player.ControlScheme scheme)
    {
        Dictionary<InputType, string> map = INPUT_MAP[scheme];
        return Input.GetVector(map[InputType.LEFT], map[InputType.RIGHT], map[InputType.UP], map[InputType.DOWN]);
    }

    public static bool IsActionPressed(Player.ControlScheme scheme, InputType action)
    {
        return Input.IsActionPressed(INPUT_MAP[scheme][action]);
    }

    public static bool IsActionJustPressed(Player.ControlScheme scheme, InputType action)
    {
        return Input.IsActionJustPressed(INPUT_MAP[scheme][action]);
    }

    public static bool IsActionJustReleased(Player.ControlScheme scheme, InputType action)
    {
        return Input.IsActionJustReleased(INPUT_MAP[scheme][action]);
    }
    
    public static float GetHorizontalAxis(Player.ControlScheme scheme)
    {
        Dictionary<InputType, string> map = INPUT_MAP[scheme];
        return Input.GetAxis(map[InputType.LEFT], map[InputType.RIGHT]);
    }
}
