using Godot;
using System;

public partial class Main : Node
{

    private ISignalService _iSignalService;
    private FoodSpawner _spawner;
    private bool _isFoodSpawned = false;

    public override void _Ready()
    {
        _iSignalService = _iSignalService = GetNode<SignalService>("/root/Main/SignalService");
        _spawner = GetNode<FoodSpawner>("/root/Main/FoodSpawner");

        if (_iSignalService == null)
        {
            GD.PrintErr("Main: _iSignalService is null!" + GetPath());
        }
        GD.Print("Main Ready!" + GetPath());
        _iSignalService.ConnectSignal("FoodEaten", this, nameof(OnFoodEaten)); 
    }

    public override void _Process(double delta)
    {
        if (!_isFoodSpawned)
        {
            _spawner.SpawnFood(_iSignalService);
            _isFoodSpawned = true;
        }
    }

    private void OnFoodEaten(GodotObject foodObj)
    {
        GD.Print("Main: Food was eaten" + GetPath());
        _isFoodSpawned = false;
    }
}