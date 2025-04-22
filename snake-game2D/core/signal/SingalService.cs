using Godot;
using System.Collections.Generic;

public partial class SingalService : Node, ISignalService
{

    private Dictionary<string, Signal> _signals = new();

    // Signal Interface Management
    public void ConnectSignal(string signalName, GodotObject target, string methodName)
    {
        if (!_signals.ContainsKey(signalName)) _signals[signalName] = new Signal();
        _signals[signalName].Connect(target, methodName);
    }

    public void EmitSignal(string signalName, params GodotObject[] args)
    {
        if (_signals.TryGetValue(signalName, out var signal)) signal.Emit(args);
    }

    public void DisconnectSignal(string signalName, GodotObject target, string methodName)
    {
        if (_signals.TryGetValue(signalName, out var signal)) signal.Disconnect(target, methodName);
    }

    // Initialize Signal Service
    private class Signal
    {
        private List<(GodotObject, string)> _connections = new();

        public void Connect(GodotObject target, string methodName)
        {
            _connections.Add((target, methodName));
        }

        public void Disconnect(GodotObject target, string methodName)
        {
            _connections.RemoveAll(c => c.Item1 == target && c.Item2 == methodName);
        }

        public void Emit(params GodotObject[] args)
        {
            foreach (var (target, method) in _connections)
            {
                target.Call(method, args);
            }
        }
    }
}