using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;

public class LowBounce : Placeable
{
    AnimationSprite body;
    Timer soundTimer;

    public LowBounce() : base(new Vec2(0, 0))
    {
        body = new AnimationSprite(Settings.ASSET_PATH + "Art/pillow.png", 4, 1, 4, false, false);
        width = body.width;
        height = body.height;
        body.SetOrigin(body.width / 2, body.height / 2);
        body.SetCycle(0, 4, 0);
        AddChild(body);

        mainColliderRect = new PhysicsRectangle(width - 5, height - 20, new Vec2(0, 0));

        mainColliderRect._bounciness = -100;
        //matress.SetColor(System.Drawing.Color.Green);
        PhysicsObjects.Add(mainColliderRect);
        soundTimer = new Timer(2f);
        soundTimer.Stop();
        soundTimer.done = true;
        AddChild(soundTimer);
    }

    protected override void Collide()
    {
        body.SetFrame(1);

        if (soundTimer.done)
        {
            int num = Utils.Random(-1, 4);
            new Sound(Settings.ASSET_PATH + "SFX/Pillow" + num + ".wav").Play(false, 0, Settings.sfxVolume * 3f, 0);
            soundTimer.Start();
        }
    }

    protected override void Run()
    {
        base.Run();

        if ((body.currentFrame == 4 || body.currentFrame == 3) && mainColliderRect.collided)
        {
            body.SetFrame(3);
        }
        else if (body.currentFrame > 0)
        {
            body.Animate();
        }
    }
}
