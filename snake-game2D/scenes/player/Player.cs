using Godot;


public partial class Player : CharacterBody2D
{
    [Export] public float Speed;
    [Export] public bool IsAlive;
    
    
    public override void _Ready()
    {
        GD.Print("Player: Ready!");
    }

    private void OnExit()
    {
        var onExitPos = GetPosition();
        GD.Print(onExitPos); 
        if (onExitPos.X is >= 550 or <= -550) SetPosition(new Vector2(-onExitPos.X, onExitPos.Y));
        if (onExitPos.Y is >= 370 or <= -370) SetPosition(new Vector2(onExitPos.X, -onExitPos.Y));
    }
    
    // Signal Player Death
    private void OnPlayerDeath()
    {
        GD.Print("Player Dead! Game Over!");
    }

    // private void ConnectSignals()
    // {
    //     _signalService?.ConnectSignal("PlayerDeath", this, nameof(OnPlayerDeath));
    // }
}
