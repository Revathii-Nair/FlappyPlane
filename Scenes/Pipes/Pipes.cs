using Godot;
using System;

public partial class Pipes : Node2D{
	private const float MOVEMENT_SPEED = -120.0f; 
	
	public override void _PhysicsProcess(double delta){
		Position += new Vector2(MOVEMENT_SPEED * (float)delta,0);
	}

	public void OnScreenExit(){
		QueueFree();
		GD.Print("Exited");
	}

	public void OnLifeTimeout(){
		QueueFree();
	}

	
}
