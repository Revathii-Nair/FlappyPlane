using Godot;
using System;

public partial class ScoreManager : Node
{
    public static ScoreManager Instance {get;private set;}
    private static int _highScore = 0;

    public override void _Ready(){
        Instance = this;
    }

    public int HighScore{
        get{return _highScore;}
        set{ if (_highScore < value) _highScore = value;}
    }

}
