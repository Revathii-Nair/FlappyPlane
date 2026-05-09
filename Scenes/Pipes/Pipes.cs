using Godot;
using System;

public partial class Pipes : Node2D{
	[Export] private Area2D _upperPipe;
	[Export] private Area2D _lowerPipe;
	[Export] private Area2D _laser;
	[Export] private AudioStreamPlayer _scoreSound;
	private const float MOVEMENT_SPEED = -120.0f;
	private bool _laserActive = true;

    public override void _Ready(){
		_laser.BodyExited += OnLaserBodyExited;
		SignalHub.Instance.PlaneDied += OnPlaneDied;
	}

    public override void _ExitTree(){
		SignalHub.Instance.PlaneDied -= OnPlaneDied;
	}

	public override void _PhysicsProcess(double delta){
		Position += new Vector2(MOVEMENT_SPEED * (float)delta,0);
	}

	public void OnScreenExit() {QueueFree();}
	public void OnLifeTimeout() {QueueFree();}

	public void OnPipeBodyEntered(Node2D body){
		if(body is Plane){
			(body as Plane).die();
		}
	}

	public void OnLaserBodyExited(Node2D body){
		if(body is Plane){
			SignalHub.OnCurrentGameScoreChange();
			_scoreSound.Play();
		}
	}

	public void OnPlaneDied(){
		if(_laserActive){
			_laser.BodyExited -= OnLaserBodyExited;
			_laserActive = false;
		}
	}
}
