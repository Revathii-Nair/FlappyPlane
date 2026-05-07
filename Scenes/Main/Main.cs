using Godot;
using System;

public partial class Main : Control
{
	private PackedScene _gameScene;
	public override void _UnhandledInput(InputEvent @event){
		if (@event.IsActionPressed("start")){
			GameManager.LoadGameScene();
		}
	}
	public override void _Process(double delta){
		
	}
}
