using Godot;
using System;

public partial class ScoreManager : Node
{
	public static ScoreManager Instance {get;private set;}
	private string FILE_PATH = "user://Plane.res";
	private static int _highScore = 0;

	public override void _Ready(){
		Instance = this;
		LoadScoreFromFile();
	}

	public int HighScore{
		get{return _highScore;}
		set{ 
			if (_highScore < value){
				_highScore = value;
				SaveScoreToFile();
			}
		}
	}

	public void SaveScoreToFile()
	{
		var hsr = new HighScoreResource();
		hsr.HighScore = _highScore;
		ResourceSaver.Save(hsr,FILE_PATH);
	}

	public void LoadScoreFromFile()
	{
		if (!ResourceLoader.Exists(FILE_PATH)) return;

	   var hsr = ResourceLoader.Load<HighScoreResource>(FILE_PATH);
	   if(hsr != null) { 
		_highScore = hsr.HighScore;
		GD.Print(_highScore);
		}
	}

}
