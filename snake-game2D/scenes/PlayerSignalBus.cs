using Godot;
using System;

public partial class EventBus : Node
{
    public override void _Ready()
    {
        GD.Print("Player Signal Bus Ready!");
    }
}
