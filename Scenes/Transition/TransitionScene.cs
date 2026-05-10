using Godot;
using System;

public partial class TransitionScene : CanvasLayer{
    [Export] private AnimationPlayer _animationPlayer;

    public void playAnimation(){
        _animationPlayer.Play("flash");
    }

    public void changeScene(){
        GameManager.LoadNextScene();
    }
}
