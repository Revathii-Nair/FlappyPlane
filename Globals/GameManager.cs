using Godot;
using System;

public partial class GameManager : Node{
	public static GameManager Instance {get; private set;}
	public PackedScene _gameScene =  GD.Load<PackedScene>("res://Scenes/Game/game.tscn");
	public PackedScene _mainScene = GD.Load<PackedScene>("res://Scenes/Main/Main.tscn");
	public PackedScene _transitionScene = GD.Load<PackedScene>("res://Scenes/Transition/TransitionScene.tscn"); 
	public PackedScene _nextScene;
	public TransitionScene _transition;

	public PackedScene LoadGame {get {return _gameScene;}}
	public PackedScene LoadMain {get{return _mainScene;}}
	public PackedScene NextScene {get{return _nextScene;} set{_nextScene = value;} }
	public PackedScene TransitionScene {get{return _transitionScene;}}

	public override void _Ready(){
		Instance = this;
		_transition = _transitionScene.Instantiate<TransitionScene>();
		AddChild(_transition);
		ProcessMode = ProcessModeEnum.Always;
	}

	private void StartChange(PackedScene toScene){
		Instance.NextScene = toScene;
		_transition.playAnimation();
		
	}

	public static void LoadMainScene(){
		Instance.StartChange(Instance.LoadMain);
	}

	public static void LoadGameScene(){
		Instance.StartChange(Instance.LoadGame);
	}

	public static void LoadNextScene(){
		if(Instance.NextScene != null)
		{
			Instance.GetTree().ChangeSceneToPacked(Instance.NextScene);
		}
	}
}
