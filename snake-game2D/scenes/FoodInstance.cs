using Godot;
using System;

public partial class FoodInstance : CharacterBody2D
{
    [Export] private Sprite2D _body;
    [Export] private CollisionShape2D _hitBox;
    [Export] private Food Data {get; set;}

    public void Initialized(Food food)
    {
        Data = food;
        if (_body != null) _body.Texture = food.Texture;
    }
}
