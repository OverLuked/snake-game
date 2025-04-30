using System.Collections.Generic;
using System.Linq;
using Godot;


public partial class Player : CharacterBody2D
{
    [Export] public float Speed;
    [Export] public bool IsAlive;
    [Export] private int _distanceOfSegments;
    private PackedScene _body;
    
    
    private List<Vector2> _positionHistory = new List<Vector2>();
    private Vector2 _direction;
    private Vector2 _velocity;
    private int _bodyIndex = 0;
    private bool _playerInMotion = false;

    
    public override void _Ready()
    {
        GD.Print("Player: Ready!");
        
        _body = GD.Load<PackedScene>("res://scenes/player/body.tscn");
        
        GetNode<SignalBus>("/root/SignalBus").OnEaten += OnEaten;
    }
    
    public override void _PhysicsProcess(double delta)
    {
        // Player Movement
        _direction = new Vector2(
            Input.GetActionStrength("Right") - Input.GetActionStrength("Left"),
            Input.GetActionStrength("Down") - Input.GetActionStrength("Up")
        );

        _velocity = _direction.LimitLength();
        Velocity = Velocity != Vector2.Zero
            ? Velocity.Lerp(_velocity * Speed * 2, 0.35f)
            : Velocity.Lerp(Vector2.One * Speed * 2, 0.35f);


        _playerInMotion = _velocity != Vector2.Zero;

        MoveAndSlide();
        
        _positionHistory.Insert(0, GlobalPosition);

        // if (_bodyIndex != 0)
        // {
        //     int positionLength = (_bodyIndex + 1) * _distanceOfSegments;
        //
        //     if (_positionHistory.Count > positionLength) 
        //         _positionHistory.RemoveRange(positionLength, _positionHistory.Count);
        // }
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
        
        var bodySegment = (Body)_body.Instantiate();
        CallDeferred(nameof(DeferredAddBody), bodySegment, _bodyIndex + 1);
    }
    private void OnDeath(CharacterBody2D body)
    {
        GD.Print("Player Dead! Game Over!");
    }

    public List<Vector2> GetPositionHistory()
    {
        return _positionHistory;
    }
    
    private void DeferredAddBody(Body bodySegment, int index)
    {
        AddChild(bodySegment);
        int historyIndex = index * _distanceOfSegments;
        bodySegment.SetBody(this, historyIndex);
        _bodyIndex += 1;
    }

    public bool InMotion()
    {
        return _playerInMotion;
    }
}
