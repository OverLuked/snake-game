using Godot;
using System;

public partial class WorldManager : Node
{
    [Export] private Player _player;
 public override void _Ready()
    {
        GD.Print("World Manager Ready!");
        
        var signalService = new SingalService();
        _player.Inject(signalService);
    }
}
