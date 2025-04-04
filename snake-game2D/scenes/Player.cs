using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public float Speed;
    [Export] public bool IsAlive;

    public override void _Ready()
    {
        GD.Print("Player Node Ready!");
    }
}
