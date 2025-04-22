using Godot;
using System;

public partial class Player : CharacterBody2D
{
    [Export] public float Speed;
    [Export] public bool IsAlive;

    public bool IsOnScreen;

    public override void _Ready()
    {
        GD.Print("Player Node Ready!");
    }

    // Signal Player Exit
    private void OnExit()
    {
        GD.Print("Player Exited Screen");
    }
}
