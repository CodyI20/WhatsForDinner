using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;

class BreakableSurface : PhysicsRectangle
{
    Sprite body;
    bool active;
    public BreakableSurface(Vec2 pPosition, int angle=0) : base(63,64,pPosition)
    {
        Restart();
        rotation = angle;
        body = new Sprite(Settings.ASSET_PATH + "Art/breakable.png", false, false); 
        body.rotation = angle;
        body.SetOrigin(body.width / 2, body.height / 2);
        AddChild(body);
    }

    public void Restart()
    {
        active = true;
    }

    public override void Update()
    {
        base.Update();
        if (active == false)
        {
            body.LateDestroy();
            LateDestroy();
        }
    }

    public override void Collide(PhysicsObject other)
    {
        if (other is AnimalBall && active && ((AnimalBall)other)._mass==((AnimalBall)other)._hogMass)
        {
            active = false;
        }
    }
}
