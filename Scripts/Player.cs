using Godot;
using System;

public class Player : Godot.KinematicBody2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";
    [Export]
    public float speed = 1;

    // Called when the node enters the scene tree for the first time.
   
    public override void _Ready()
    {
        
        Position = GetViewportRect().Size/2;
        //this.Position = new Vector2(100,100);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta)
 {
    float dir = Input.GetAxis("Left","Right");
    GD.Print(dir);
    this.Position = new Vector2(this.Position.x+(dir*speed),this.Position.y);   
 }
//  public async void FlapAnim()
//  {
//     var messageTimer = GetNode<Timer>("MessageTimer");
//     // while(true)
//     // {
//         await ToSignal(messageTimer, "timeout");
//     // }
//  }
}
