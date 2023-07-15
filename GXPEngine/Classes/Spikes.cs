using GXPEngine;
using GXPEngine.Physics;

class Spikes : GameObject
{
    PhysicsRectangle rect;
    int width;
    int height;

    public Spikes(int length, int pX, int pY, int angle = 0)
    {
        visible = false;
        x = pX;
        y = pY;

        rotation = angle;
        build(length);

        rect = new Destructor(width, height, pX + width / 2, pY + height / 2);
        rect.vecRotation.angleDeg = rotation;
        rect.position.RotateAroundDegrees(rotation, new GXPEngine.Core.Vec2(x, y));
        game.Currentscene.AddChild(rect);
    }

    void build(int length)
    {
        Sprite body;

        for (int i = 0; i < length; i++)
        {
            body = new Sprite(Settings.ASSET_PATH + "Art/Spike.png");
            //body.SetOrigin(body.width/2, body.height/2);
            body.x = i * body.width;

            AddChild(body);

            width = length * body.width;
            height = body.height;
        }
    }
}

