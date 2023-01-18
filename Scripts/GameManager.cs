using Godot;
using System;

public class GameManager : Node2D
{
    [Export]
    PackedScene GameOverScene;
    [Export]
    PackedScene MusicPlayerScene;

    [Export]
    AudioStreamSample music;

    public static GameManager instance;
    public static bool gameOver = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Print(GetTree().Root);
        if(instance == null)
        {
            instance = this;
        }

        GetTree().Root.CallDeferred("add_child",MusicPlayerScene.Instance());
        // ChangleScene(GameOverScene);
    }

    public void ChangleScene(PackedScene newScene)
    {
        Viewport root = GetTree().Root;


        var level = root.GetChild(0);
        root.CallDeferred("remove_child",level);
        level.CallDeferred("free"); 

        Node scene = newScene.Instance();
        root.CallDeferred("add_child",scene);
        
        GD.Print(root.GetChildCount());
    }

    public void GameOver()
    {
        ChangleScene(GameOverScene);
        music.LoopMode = AudioStreamSample.LoopModeEnum.Disabled;
    }
//  // Called every frame. 'delta' is the elapsed time since the previous frame.
//  public override void _Process(float delta)
//  {
//      
//  }
}
