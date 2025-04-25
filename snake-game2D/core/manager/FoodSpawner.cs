using Godot;
using System;
using System.Collections.Generic;

public partial class FoodSpawner : Node
{
    [Export] public PackedScene FoodInstance;
    [Export] public Vector2 SpawnArea = new Vector2(550, 370); 
    [Export] public String FoodFolder;

    private List<Food> _food = [];


    public override void _Ready()
    {
        GD.Print("Food spawner Ready!");
        
        // Load food resource
        var dir = DirAccess.Open(FoodFolder);

        if (dir == null)
        {
            GD.PrintErr("Food not found!");
            return;
        }

        dir.ListDirBegin();
        string filename;
        while ((filename = dir.GetNext()) != "")
        {
            if (!filename.EndsWith(".tres")) continue;
            var food = ResourceLoader.Load<Food>(FoodFolder + filename);
            if (food != null) _food.Add(food);
        }

        dir.ListDirEnd();
        GD.Print(_food.Count);


        // spawn food
        if (_food.Count == 0 || FoodInstance == null)
        {
            GD.PrintErr("Food not Found!");
            return;
        }

        var foodResource = _food[GD.RandRange(0, _food.Count - 1)];
        var instance = FoodInstance.Instantiate<FoodInstance>();
        instance.Initialize(foodResource);
        
        // Spawn Location
        Vector2 spawnPos = SpawnArea != null
            ? new Vector2(
                (float)GD.RandRange(-SpawnArea.X, SpawnArea.X),
                (float)GD.RandRange(-SpawnArea.Y, SpawnArea.Y)
            )
            : new Vector2(GD.RandRange(0,550), GD.RandRange(0,370));
        
        instance.Position = spawnPos;
        AddChild(instance);
    }
    
}
