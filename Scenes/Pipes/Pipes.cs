using Godot;
using System;

public partial class Pipes : Node2D{
	[Export] private Area2D _upperPipe;
	[Export] private Area2D _lowerPipe;
	private const float MOVEMENT_SPEED = -120.0f;
	private static float _totalScore = 0;
	
	public override void _PhysicsProcess(double delta){
		Position += new Vector2(MOVEMENT_SPEED * (float)delta,0);
	}

	public void OnScreenExit(){
		QueueFree();
	}

	public void OnLifeTimeout(){
		QueueFree();
	}

	public void OnPipeBodyEntered(Node2D body){
		if(body is Plane){
			(body as Plane).die();
		}
	}

	public void OnLaserBodyExited(Node2D body){
		if(body is Plane){
			AddScore();
			GD.Print(_totalScore);
		}
	}

	private void AddScore(){
		_totalScore += 1;
	}
}
