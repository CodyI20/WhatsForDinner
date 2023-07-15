using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;
using System;

class AnimalBall : PhysicsCircle
{
    Timer deadTimer;
    Sprite body;
    Sound animalChannel;
    public float _mass;
    public float _bunnyMass=0.1f;
    public float _foxMass=0.25f;
    public float _hogMass=0.5f;
    public bool hasBeenBoosted = false;
    private new Vec2 acceleration = new Vec2(0, 0.01f);

    public AnimalBall(int pRadius, Vec2 pPosition, Vec2 pVelocity = new Vec2()) : base(pRadius, pPosition)
    {
        _radius = pRadius;
        position = pPosition;
        //_speed = pSpeed;
        velocity = pVelocity;
        _mass = _foxMass;
        body = new Sprite(Settings.ASSET_PATH + "Art/FoxVector.png", false, false);
        SetBody();
        AddChild(body);
        //SetColor(System.Drawing.Color.White);

        affectedByGravity = true;
        _bounciness = 0.6f;
        
        //SetColor(System.Drawing.Color.Pink);
    }

    public override bool moving
    {
        get { return true; }
    }

    public override void Collide(PhysicsObject other)
    {
        base.Collide(other); // Call base method to handle the collision
        float reflectStrength;
        reflectStrength = other._bounciness + _bounciness;

        if (other is PhysicsLine)
        {
            velocity.Reflect(((PhysicsLine)other).lineVector.Normal(), reflectStrength);
        }
        else if (other is PhysicsCircle)
        {
            velocity.Reflect(Vec2.DirectionBetween(position, other.position).Normalized(), reflectStrength);
        }
    }

    public override void Update()
    {
        Console.WriteLine(velocity.length);
        ChangeAnimal();
        if (velocity.length > 200f)
        {
            body.rotation = velocity.angleDeg + 90;
        }

        if (deadTimer != null)
        {
            if (deadTimer.done)
                LateRemove();
        }
        if (game.Currentscene is Level)
        {
            base.Update();
        }
        if (Input.GetKeyDown(Key.SPACE))
        {
            LateRemove();
        }
    }

    public void Die()
    {
        if (deadTimer == null)
        {
            deadTimer = new Timer(0.01f);
            AddChild(deadTimer);
            parent.recieveMessage("dead");
        }
    }

    void SetBody()
    {
        body.SetXY(0 - body.width / 2, 0 - body.height / 2 + 25*body.scale);
        body.SetOrigin(radius, radius);
        body.scale = 0.2f;
    }

    void ChangeAnimal()
    {
        SetBody();
        if (Input.GetKeyDown(Key.ONE))
        {
            new Sound(Settings.ASSET_PATH + "SFX/Bunny.mp3").Play();
            RemoveChild(body);
            _mass = _bunnyMass;
            body = new Sprite(Settings.ASSET_PATH + "Art/BunnyVector.png", false, false);
            AddChild(body);
        }
        if (Input.GetKeyDown(Key.TWO))
        {
            animalChannel = new Sound(Settings.ASSET_PATH + "SFX/Fox.mp3");
            animalChannel.Play();
            RemoveChild(body);
            _mass = _foxMass;
            body = new Sprite(Settings.ASSET_PATH + "Art/FoxVector.png", false, false);
            AddChild(body);
        }
        if (Input.GetKeyDown(Key.THREE))
        {
            animalChannel = new Sound(Settings.ASSET_PATH + "SFX/Hog.mp3");
            animalChannel.Play();
            RemoveChild(body);
            _mass = _hogMass;
            body = new Sprite(Settings.ASSET_PATH + "Art/HogVector.png", false, false);
            AddChild(body);
        }
    }

    public override void Step()
    {
        velocity += acceleration * _mass * Time.deltaTime;
        //Console.WriteLine(velocity.length);
        position += velocity * Time.deltaTime;
        UpdateScreenPosition();
    }
}

