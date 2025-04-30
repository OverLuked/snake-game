using Godot;
using System;

public partial class Body : CharacterBody2D
{
    private Player _player;
    private int _historyIndex;

    public void SetBody(Player player, int historyIndex)
    {
        _player = player;
        _historyIndex = historyIndex;
    }

    public override void _PhysicsProcess(double delta)
    {
        var history = _player.GetPositionHisotry();
        if (_historyIndex < history.Count) GlobalPosition = history[_historyIndex];
    }
}
