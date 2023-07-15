using GXPEngine;
using GXPEngine.Physics;
using GXPEngine.Core;

class TrianglePlaceable : Placeable
{
    Sprite body;

    public TrianglePlaceable(int bodyNumber = 1) : base(new Vec2(0, 0))
    {
        SetUpBody(bodyNumber);

        mainColliderTriang = new PhysicsTriangle(width, height, new Vec2(0, 0));

        PhysicsObjects.Add(mainColliderTriang);
    }

    void SetUpBody(int bodyNumber)
    {
        switch (bodyNumber)
        {
            case 2:
                body = new Sprite(Settings.ASSET_PATH + "Art/triang.png", false, false);
                break;
            case 3:
                body = new Sprite(Settings.ASSET_PATH + "Art/triang3.png", false, false);
                break;
            case 4:
                body = new Sprite(Settings.ASSET_PATH + "Art/triang4.png", false, false);
                break;
            default:
                body = new Sprite(Settings.ASSET_PATH + "Art/triang.png", false, false);
                break;
        }
        width = body.width;
        height = body.height;
        body.SetOrigin(0, 0);
        AddChild(body);
    }

    protected override void Collide()
    {
        //int num = Utils.Random(-1, 4);
        //new Sound(Settings.ASSET_PATH + "SFX/Pillow" + num + ".wav").Play(false, 0, Settings.sfxVolume * 3f, 0);
    }
}
