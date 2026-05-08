using Godot;
using System;

public partial class GameUi : Control{
    [Export] private Label _gameOverLabel;
    [Export] private Label _startAgainLabel;
    [Export] private Timer _startAgainTimer;
    [Export] private AudioStreamPlayer _gameOverMusic;

    public override void _UnhandledInput(InputEvent @event){
        if (@event.IsActionPressed("exit_game")){
            GameManager.LoadMainScene();
        }
        if(@event.IsActionPressed("start_again") && _startAgainLabel.Visible == true){
            GameManager.LoadMainScene();
        }
        
    }
    public override void _Ready(){
        //same as  SignalHub.Instance.PlaneDied += ShowGameOver
        SignalHub.Instance.Connect(SignalHub.SignalName.PlaneDied,Callable.From(ShowGameOver));
        _gameOverLabel.Hide();
        _startAgainLabel.Hide();
        _startAgainTimer.Timeout += OnStartAgainTimeout;
    }

    public void ShowGameOver(){
        _gameOverLabel.Show();
        _gameOverMusic.Play();
        _startAgainTimer.Start();
    }

    public void OnStartAgainTimeout(){
        _startAgainLabel.Show();
    }
}
