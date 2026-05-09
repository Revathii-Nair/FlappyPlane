using Godot;
using System;

public partial class GameManager : Node{
    public static GameManager Instance {get; private set;}
    public PackedScene _gameScene =  GD.Load<PackedScene>("res://Scenes/Game/game.tscn");
    public PackedScene _mainScene = GD.Load<PackedScene>("res://Scenes/Main/Main.tscn");

    public override void _Ready(){
        Instance = this;
    }

    public static void LoadMainScene(){
        Instance.GetTree().ChangeSceneToPacked(Instance._mainScene);
    }

    public static void LoadGameScene(){
        Instance.GetTree().ChangeSceneToPacked(Instance._gameScene);
    }
}
