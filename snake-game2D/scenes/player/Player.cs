using System.Collections.Generic;
using System.Linq;
using Godot;


public partial class Player : CharacterBody2D
{
    [Export] public float Speed;
    [Export] public bool IsAlive;
    [Export] private PackedScene _body;
    

    private List<CharacterBody2D> _instance;
    private Vector2 _currentPos;
    private Vector2 _direction;
    private Vector2 _velocity;

    
    public override void _Ready()
    {
        GD.Print("Player: Ready!");
        _instance = new List<CharacterBody2D>();
        GetNode<SignalBus>("/root/SignalBus").OnEaten += OnEaten;
    }

    public override void _Process(double delta)
    {
        _currentPos = Position;
    }

    public override void _PhysicsProcess(double delta)
    {
        // Player Movement
        _direction = new Vector2(
            Input.GetActionStrength("Right") - Input.GetActionStrength("Left"),
            Input.GetActionStrength("Down") - Input.GetActionStrength("Up")
        );

        _velocity = _direction.LimitLength();
        Velocity = _velocity != Vector2.Zero
            ? Velocity.Lerp(_velocity * Speed * 2, 0.35f)
            : Velocity.Lerp(Vector2.Zero, 0.5f);

        MoveAndSlide();
    }

    private void OnExit()
    {
        var onExitPos = GetPosition();
        GD.Print("Player: Exit location: ", onExitPos); 
        if (onExitPos.X is >= 550 or <= -550) SetPosition(new Vector2(-onExitPos.X, onExitPos.Y));
        if (onExitPos.Y is >= 370 or <= -370) SetPosition(new Vector2(onExitPos.X, -onExitPos.Y));
    }
    
    // Add body instance
    
    private void OnEaten(GodotObject foodObj)
    {
        // fix this 
        GD.Print("Player: Adding body");
        
        _instance.Add(_body.Instantiate<CharacterBody2D>());
        GD.Print("Player: body instance count = ", _instance.Count);
        
        // Change to velocity in player direction
        _instance[^1].Position = _instance.Count != 1 
            ? new Vector2(_instance[^1].Position.X + 10, _instance[^1].Position.Y + 10) 
            : new Vector2(_currentPos.X +  10, _currentPos.Y + 10);
        
        AddChild(_instance[^1]);
    }
    private void OnDeath(CharacterBody2D body)
    {
        GD.Print("Player Dead! Game Over!");
    }
}
