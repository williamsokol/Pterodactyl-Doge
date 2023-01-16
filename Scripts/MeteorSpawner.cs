using Godot;
using System;

public class MeteorSpawner : Control
{
    [Export]
    public PackedScene meteorPrefab;
    public Node meteor;
    [Export]
    public float meteorDelay = 2f;
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        SpawnMeteors();
        
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public async void SpawnMeteors()
    {
        while(GameManager.gameOver == false)
        {
            await ToSignal(GetTree().CreateTimer(meteorDelay), "timeout");
            SpawnMeteor();
        }
    }
    public void SpawnMeteor()
    {
        meteor = meteorPrefab.Instance();
        AddChild(meteor);
    }
}
 