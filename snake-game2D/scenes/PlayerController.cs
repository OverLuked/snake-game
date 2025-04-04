using Godot;
using System;

public partial class PlayerController : Node
{

    [Export] private Player _player;
    
    private Vector2 _direction;
    private Vector2 _velocity;
    
    public override void _Ready()
    {
        GD.Print("Player Controller Ready!");
    }

    public override void _PhysicsProcess(double delta)
    {
        // Player Movement
        _direction = new Vector2(
            Input.GetActionStrength("Right") - Input.GetActionStrength("Left"),
            Input.GetActionStrength("Down") - Input.GetActionStrength("Up")
            );

        _velocity = _direction.LimitLength();
        _player.Velocity = _velocity != Vector2.Zero
            ? _player.Velocity.Lerp(_velocity * _player.Speed * 2, 0.35f)
            : _player.Velocity.Lerp(Vector2.Zero, 0.5f);

        _player.MoveAndSlide();
    }
}
