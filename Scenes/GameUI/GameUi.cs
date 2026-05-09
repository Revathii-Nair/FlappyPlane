using Godot;
using System;

public partial class GameUi : Control{
    [Export] private Label _gameOverLabel;
    [Export] private Label _startAgainLabel;
    [Export] private Label _currentScoreLabel;
    [Export] private Timer _startAgainTimer;
    [Export] private AudioStreamPlayer _gameOverMusic;
    public static int _score = 0;

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
        SignalHub.Instance.Connect(SignalHub.SignalName.CurrentGameScoreChange,Callable.From(UpdateCurrentGameScore));
        _gameOverLabel.Hide();
        _startAgainLabel.Hide();
        _startAgainTimer.Timeout += OnStartAgainTimeout;
    }

    public void ShowGameOver(){
        _gameOverLabel.Show();
        _gameOverMusic.Play();
        _startAgainTimer.Start();
        _score = 0;
    }

    public void OnStartAgainTimeout(){
        _startAgainLabel.Show();
    }

    public void UpdateCurrentGameScore(){
        _score +=1;
        _currentScoreLabel.Text = _score.ToString("D3");
        ScoreManager.Instance.HighScore = _score;
    }
}
