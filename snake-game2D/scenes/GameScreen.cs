
using Godot;
using System;

public partial class GameScreen : Camera2D
{
    [Export] private Player _player;
    public override void _Ready()
    {
        GD.Print("GameScreen is Working!");
    }

    public override void _Process(double delta)
    {
        if (!_player.IsOnScreen)
        {
            GD.Print("Player left the screen");
        }
    }
}
