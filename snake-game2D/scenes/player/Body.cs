using Godot;
using System;
using System.Collections.Generic;

public partial class Body : CharacterBody2D
{
    private Player _player;
    private int _historyIndex;
    private List<Vector2> _history; 

    public void SetBody(Player player, int historyIndex)
    {
        _player = player;
        _historyIndex = historyIndex;
        _history = new List<Vector2>();
    }

    public override void _PhysicsProcess(double delta)
    {
        _history = _player.GetPositionHistory(); 
        if (_historyIndex < _history.Count) GlobalPosition = _history[_historyIndex];
    }

    // private void OnCollision(Node2D player)
    // {
    //     if (player is not Player) return;
    //     GlobalPosition = _history[^1];
    // }
}
