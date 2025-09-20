using Godot;
using System;

public partial class PlayerData : Resource
{
    public Vector2 SpawnPoint;

    public static PlayerData Build()
    {
        return new PlayerData();
    }

    public PlayerData SetSpawnPoint(Vector2 spawnPoint)
    {
        SpawnPoint = spawnPoint;
        return this;
    }

}
