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

    private void UpdateScore(GodotObject foodObj)
    {
        if (foodObj is FoodInstance { Data: not null } foodInstance)
        {
            _score += foodInstance.Data.Point;
            _label.SetText(_score.ToString());
            GD.Print("Hud: Score Updated!");
            GD.Print("Hud: Player ate ", foodInstance.Data.Name);
        } else GD.PrintErr("Hud: Invalid foodObj, unable to update score");
    }
}
