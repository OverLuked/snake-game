using Godot;
using System;

public partial class FoodInstance : Node2D
{
    [Export] private Sprite2D _body;
    [Export] private CollisionShape2D _hitBox;
    [Export] private Food Data {get; set;}

    private ISignalService _signalService;


    public override void _Ready()
    {
        base._Ready();
    }

    // Inject signal service
    public void Inject(ISignalService signalService)
    {
        _signalService = signalService;
    }

    public void Initialize(Food food)
    {
        Data = food;
        if (_body != null) _body.Texture = food.Texture;
    }

    public void Eaten(Node2D area)
    {
        GD.Print("Player entered food");
    }
    
    // Private Methods
    private void ConnectSignals()
    {
        _signalService?.ConnectSignal("FoodEaten", this, nameof(Eaten));
    }
}
