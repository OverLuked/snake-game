using Godot;
using System;

public partial class FoodInstance : Node2D
{
    [Export] private Sprite2D _body;
    [Export] private CollisionShape2D _hitBox;
    [Export] public Food Data { get; set; }

    public void Initialize(Food food)
    {
        Data = food;
        if (_body != null) _body.Texture = food.Texture;
    }

    public override void _Ready()
    {
        GetNode<SignalBus>("/root/SignalBus").OnEaten += Eaten;
    }
    
    private void Eaten(Node2D body)
    {
        if (body is not Player) return;
        GD.Print("FoodInstance: Player entered food area");
        QueueFree();
        GetNode<SignalBus>("/root/SignalBus").EmitSignal(SignalBus.SignalName.OnEaten, this);
    }
    
}