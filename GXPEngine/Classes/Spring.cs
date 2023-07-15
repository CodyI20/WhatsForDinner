using GXPEngine.Physics;
using GXPEngine;

public class Spring : Placeable
{
    AnimationSprite body;

    public Spring() : base(new GXPEngine.Core.Vec2(0, 0))
    {
        body = new AnimationSprite(Settings.ASSET_PATH + "Art/spring.png", 6, 2, 12, false, false);
        width = body.width;
        height = body.height;
        body.SetOrigin(body.width / 2, body.height / 2);
        body.SetCycle(0, 12, 0);

        AddChild(body);

        PhysicsRectangle left = new PhysicsRectangle(2, height, -width / 2, 0);
        left.vecRotation.angleDeg = 180f;
        PhysicsObjects.Add(left);

        PhysicsRectangle right = new PhysicsRectangle(2, height, width / 2, 0);
        PhysicsObjects.Add(right);

        mainColliderRect = new PhysicsRectangle(width - 4, height + 5, 0, 0);
        mainColliderRect._bounciness = 0.60f;
        PhysicsRectangle spring2 = new PhysicsRectangle(width - 14, height - 10, 0, 0);
        spring2._bounciness = 0.60f;
        //mainColliderRect.SetColor(System.Drawing.Color.Green);
        PhysicsObjects.Add(mainColliderRect);
    }

    protected override void Collide()
    {
        body.SetFrame(1);
        ///new Sound(Settings.ASSET_PATH + "SFX/SpringJump.wav").Play(false, 0, Settings.sfxVolume, 0);
    }

    protected override void Run()
    {
        base.Run();

        if (body.currentFrame > 0)
        {
            body.Animate();
        }
    }
}
