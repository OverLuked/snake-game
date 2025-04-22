using Godot;
using System;

public interface ISignalService
{
    void ConnectSignal(string signalName, GodotObject target, string methodName);
    void EmitSignal(string signalName, params GodotObject[] args);
    void DisconnectSignal(string signalName, GodotObject target, string methodName);
}
