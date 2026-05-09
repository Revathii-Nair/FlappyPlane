using Godot;
using System;

public partial class Main : Control{
	[Export] private Label _highScore;
	private PackedScene _gameScene;
	public override void _UnhandledInput(InputEvent @event){
		if (@event.IsActionPressed("start")){
			GameManager.LoadGameScene();
		}
	}
	public override void _Ready(){
		GetTree().Paused = false;
		_highScore.Text = ScoreManager.Instance.HighScore.ToString("D3");
	}
}
