using Godot;
using System;

public partial class Game : Node{
	[Export] private PackedScene _pipeScene;
	[Export] private Marker2D _upperSpawnMarker;
	[Export] private Marker2D _lowerSpawnMarker;
	[Export] private Node _pipesHolder;

    public override void _UnhandledInput(InputEvent @event){
		if (@event.IsActionPressed("exit_game")){
			GameManager.LoadMainScene();
		}
	}

	public void OnSpawnTimeout(){
		Pipes newpipe = _pipeScene.Instantiate<Pipes>();
		float random_y = (float)GD.RandRange(_upperSpawnMarker.Position.Y,_lowerSpawnMarker.Position.Y);
		newpipe.Position = new Vector2(_upperSpawnMarker.Position.X,random_y);
		_pipesHolder.AddChild(newpipe);
	}
}
