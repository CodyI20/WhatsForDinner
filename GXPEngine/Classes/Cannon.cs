using GXPEngine;
using GXPEngine.Core;
using System;

class Cannon : Sprite
{
    AnimalBall _ball;
    public Vec2 position
    {
        get { return _position; }
    }

    private Vec2 _position;
    private Vec2 velocity;
    private float _angle;
    public Cannon(Vec2 pPosition) : base(Settings.ASSET_PATH + "Art/cannon.png", false, false)
    {
        scale = 0.25f;
        SetOrigin(0, height + 90);
        //x += 50;
        _position = pPosition;
        Console.WriteLine(_position.ToString());
    }

    public void ShootBall()
    {
        if (Input.GetKeyDown(Key.SPACE))
        {
            new Sound(Settings.ASSET_PATH + "SFX/Trunk_shoot.mp3").Play(false, 0, Settings.sfxVolume, 0);
            Vec2 cannonTip = new Vec2(position.x + Mathf.Cos(Vec2.Deg2Rad(_angle)) * width, position.y + Mathf.Sin(Vec2.Deg2Rad(_angle)) * width);
            // Calculate the velocity vector based on the angle and power of the shot
            Vec2 velocity = Vec2.GetUnitVectorDeg(_angle) * 0.12f;
            _ball = new AnimalBall(25, cannonTip, velocity*Time.deltaTime);
            // Add the ball to the game
            game.Currentscene.AddChildAt(_ball, 100);
        }
    }

    void UpdatePosition()
    {
        //_position = new Vec2(x+parent.x,y+parent.y);
        x = position.x;
        y = position.y;
    }

    void PointAtMouse()
    {
        Vec2 mousePos = new Vec2(Input.mouseX, Input.mouseY);
        Vec2 direction = Vec2.DirectionBetween(_position, mousePos).Normalized();
        _angle = direction.angleDeg;
        if (_angle > -33.58)
            _angle = (float)-33.58;
        if (_angle < -96)
            _angle = (float)-96;
        rotation = _angle;
    }

    public void Update()
    {
        UpdatePosition();
        ShootBall();
        PointAtMouse();
    }
}
