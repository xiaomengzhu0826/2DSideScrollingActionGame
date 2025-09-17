using Godot;
using System;

public partial class PlayerStateData : Resource
{
    public Vector2 SpawnPoint;

    public static PlayerStateData Build()
    {
        return new PlayerStateData();
    }

    public PlayerStateData SetSpawnPoint(Vector2 spawnPoint)
    {
        SpawnPoint = spawnPoint;
        return this;
    }

}
