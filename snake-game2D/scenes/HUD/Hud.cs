using Godot;
using System;
using System.Net.Mime;

public partial class Hud : Control
{
    [Export] private Label _label;

    private int _score = 0;

    public override void _Ready()
    {
        GD.Print("Hud: Ready!");
        GetNode<SignalBus>("/root/SignalBus").OnEaten += UpdateScore;
        
        _label.SetText(_score.ToString());
    }

    private void UpdateScore(GodotObject food)
    {
        _score += 1;
        _label.SetText(_score.ToString());
    }
}
