using Godot;
using System;

public partial class Hud : Control
{
    [Export] private Label _label;

    public override void _Ready()
    {
        GD.Print("Hud: Ready!");
    }
}
