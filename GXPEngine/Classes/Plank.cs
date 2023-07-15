using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;

class Plank : Placeable
{
    public Plank() : base(new Vec2(0, 0))
    {
        //build(length);
        Sprite body = new Sprite(Settings.ASSET_PATH + "Art/plank.png", false, false);
        width = body.width;
        height = body.height;
        body.SetOrigin(body.width / 2, body.height / 2);

        AddChild(body);

        mainColliderRect = new PhysicsRectangle(width, height, new Vec2(0, 0));
        PhysicsObjects.Add(mainColliderRect);
    }

    void build(int length)
    {
        Sprite body;

        for (int i = 0; i < length;)
        {
            body = new Sprite(Settings.ASSET_PATH + "Art/metal_wall.png");
            //body.SetOrigin(body.width/2, body.height/2);

            body.x = i;

            height = body.height;

            i += body.width;
            AddChild(body);

            width = i;
        }
    }

    protected override void Collide()
    {
        //new Sound(Settings.ASSET_PATH + "SFX/Bouncing.wav").Play(false, 0, Settings.sfxVolume, 0);
    }

    protected override void Run()
    {
        base.Run();
    }
}
