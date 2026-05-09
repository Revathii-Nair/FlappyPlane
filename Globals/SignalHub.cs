using Godot;
using System;

public partial class SignalHub : Node{
    public static SignalHub Instance {get; private set;}
    [Signal] public delegate void PlaneDiedEventHandler();
    [Signal] public delegate void CurrentGameScoreChangeEventHandler();

    public override void _Ready(){
        Instance = this;
    }

    public static void OnPlaneDied(){
        Instance.EmitSignal(SignalName.PlaneDied);
    }

    public static void OnCurrentGameScoreChange(){
        Instance.EmitSignal(SignalName.CurrentGameScoreChange);
    }

}
