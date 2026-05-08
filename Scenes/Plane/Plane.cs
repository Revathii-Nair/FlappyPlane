using Godot;
using System;

public partial class Plane : CharacterBody2D{
    [Export] private AnimatedSprite2D _sprite;
    [Export] private AnimationPlayer _jumpAnimation;
    private const float JUMP_POWER = -350.0f;
    private bool _didJump = false;
    private float _gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
    
	public override void _PhysicsProcess(double delta){
        fly(delta);
        MoveAndSlide();
        if (IsOnFloor()){
            die();
        }
    }

    private void fly(double delta){
        Vector2 velocity = Velocity;
        velocity.Y += _gravity * (float)delta;

        if (Input.IsActionJustPressed("jump")){
            velocity.Y = JUMP_POWER;
            _jumpAnimation.Play("jump");
        }
        Velocity = velocity;
    }

    public void die(){
        // SetPhysicsProcess(false);
        // _sprite.Stop();
        SignalHub.OnPlaneDied();
        GetTree().Paused = true;
    }
}
