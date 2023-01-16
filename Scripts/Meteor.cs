using Godot;
using System;

public class Meteor : KinematicBody2D
{
    Random rnd = new Random();
    
    [Export]
    public float speed = 2;
    public Vector2 direction;
    

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // get a random rotation to fall at
        float fallingAngle = rnd.Next(180-40,180+40);
        direction = Vector2.Up.Rotated(Mathf.Deg2Rad(fallingAngle));

        // start at a random x position
        float startingX = rnd.Next(0,(int)GetViewportRect().Size.x);
        this.Position = new Vector2(startingX,0);
    }

//  // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {
        //this.Position += direction*speed*delta;
        KinematicCollision2D collisions = this.MoveAndCollide(direction*speed*delta*100);

        if(collisions != null)
        {
            GD.Print("game over");
            //QueueFree();
            GameManager.instance.GameOver();
        }
    }
}
