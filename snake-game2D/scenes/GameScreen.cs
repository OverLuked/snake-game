
using Godot;
using System;

public partial class GameScreen : Camera2D
{
    [Export] private Player _player;
    public override void _Ready()
    {
        GD.Print("GameScreen is Working!");
    }
}
