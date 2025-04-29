using Godot;


public partial class Player : CharacterBody2D
{
    [Export] public float Speed;
    [Export] public bool IsAlive;
    [Export] private PackedScene _body;

    private Vector2 _currentPos;
    
    
    public override void _Ready()
    {
        GD.Print("Player: Ready!");
        GetNode<SignalBus>("/root/SignalBus").OnEaten += OnEaten;
    }

    public override void _Process(double delta)
    {
        _currentPos = Position;
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
        var instance = _body.Instantiate<CharacterBody2D>();
        instance.Position = new Vector2(_currentPos.X +  40, _currentPos.Y + 40);
        AddChild(instance);
    }
    private void OnDeath(CharacterBody2D body)
    {
        GD.Print("Player Dead! Game Over!");
    }
}
