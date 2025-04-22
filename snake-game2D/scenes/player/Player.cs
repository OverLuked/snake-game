using Godot;


public partial class Player : CharacterBody2D
{
    [Export] public float Speed;
    [Export] public bool IsAlive;
    public bool OnScreen;

    private ISignalService _signalService;
    
    // Inject signal service
    public void Inject(ISignalService signalService)
    {
        _signalService = signalService;
    }
    public override void _Ready()
    {
        GD.Print("Player Node Ready!");
    }

    // Signal Player Exit
    private void OnExit()
    {
        GD.Print("Player Exited Screen");
        OnScreen = true;
    }
    
    // Signal Player Death
    private void OnPlayerDeath()
    {
        GD.Print("Player Dead! Game Over!");
    }

    private void ConnectSignals()
    {
        _signalService?.ConnectSignal("PlayerDeath", this, nameof(OnPlayerDeath));
    }
}
