using Godot;
using System;

[GlobalClass]
public partial class Food : Resource
{
    
    [Export] public string Name;
    [Export] public int Point;
    [Export] public Texture2D Texture;
}
