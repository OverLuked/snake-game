using Godot;
using System;

public partial class Main : Node
{
    
    private FoodSpawner _spawner;
    private bool _isFoodSpawned = false;

    public override void _Ready()
    {
        GetNode<SignalBus>("/root/SignalBus").OnEaten += OnFoodEaten;
        _spawner = GetNode<FoodSpawner>("/root/Main/FoodSpawner");
        
        GD.Print("Main Ready!" + GetPath());
    }

    public override void _Process(double delta)
    {
        if (!_isFoodSpawned)
        {
            _spawner.SpawnFood();
            _isFoodSpawned = true;
        }
    }

    private void OnFoodEaten(GodotObject foodObj)
    {
        GD.Print("Main: Food was eaten" + GetPath());
        _isFoodSpawned = false;
    }
}