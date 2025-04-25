using Godot;
using System;

public partial class FoodInstance : Node2D
{
    [Export] private Sprite2D _body;
    [Export] private CollisionShape2D _hitBox;
    [Export] private Food Data { get; set; }

    private ISignalService _signalService;

    public void Initialize(Food food)
    {
        Data = food;
        if (_body != null) _body.Texture = food.Texture;
    }

    public void Inject(ISignalService signalService)
    {
        _signalService = signalService;
        signalService.ConnectSignal("FoodEaten", this, nameof (Eaten));
    }
    

    public void Eaten(Node2D body)
    {
        if (body is not Player || _signalService == null) return;

        GD.Print("FoodInstance: Player entered food area");
        QueueFree();
        _signalService.EmitSignal(signalName: "FoodEaten");
    }
}