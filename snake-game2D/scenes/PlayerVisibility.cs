using Godot;
using System;

public partial class PlayerVisibility : VisibleOnScreenNotifier2D
{
    private Player _player;


    public override void _Notification(int what)
    {
        _player.IsOnScreen = IsOnScreen();
    }
}
