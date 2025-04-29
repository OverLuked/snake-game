using Godot;
using System;

public partial class SignalBus : Node
{
    // Signal Manager [Delegate] Signals for centralized data flow

    [Signal]
    public delegate void OnEatenEventHandler(Node2D signal);

    [Signal]
    public delegate void OnDeathEventHandler(CharacterBody2D body);

    public override void _Ready()
    {
        GD.Print("SignalBus: Ready!");
    }
}
