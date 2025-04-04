using Godot;
using System;

public partial class PlayerController : Node
{
    public override void _Ready()
    {
        GD.Print("Player Controller Ready!");
    }

    public override void _PhysicsProcess(double delta)
    {
        // Player Movement
        
    }
}
