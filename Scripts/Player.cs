using Godot;
using System;

public class Player : Godot.KinematicBody2D
{

    public Sprite sprite;
    [Export]
    Texture open ;//= (Texture)GD.Load("res://image.png"); 
    [Export]
    Texture close ;
    [Export]
    public float speed = 1;
    [Export]
    public float flapDelay = .5f;

    // Called when the node enters the scene tree for the first time.
   
    public override void _Ready()
    {
        sprite = (Sprite)this.GetNode("Sprite");
        Position = GetViewportRect().Size/2;
        //this.Position = new Vector2(100,100);
        FlapAnim();
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
 public override void _Process(float delta)
 {
    float dir = Input.GetAxis("Left","Right");
    if(dir != 0){
        flapDelay = .2f;
    }else{
        flapDelay = .6f;
    }
    this.Position = new Vector2(this.Position.x+(dir*speed),this.Position.y);   
 }
 public async void FlapAnim()
 {
    //var messageTimer = GetNode<Timer>("MessageTimer");
    GD.Print("test1");
    while(true)
    {
        sprite.Texture = open;
        await ToSignal(GetTree().CreateTimer(flapDelay), "timeout");
        sprite.Texture = close;
        await ToSignal(GetTree().CreateTimer(flapDelay), "timeout");
    }
 }
}