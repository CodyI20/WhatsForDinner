using GXPEngine;
using GXPEngine.Physics;

class Platforms : GameObject
{
    PhysicsRectangle rect;
    int width;
    int height;

    public Platforms(int length, int pX, int pY, Sprite spriteUsed, bool hasCollision = true, bool isBouncy = false, float scale = 1f, int angle = 270)
    {
        this.scale = scale;
        x = pX;
        y = pY;

        rotation = angle;
        build(length, spriteUsed);

        if (hasCollision)
        {
            rect = new PhysicsRectangle(width, height, pX + width / 2, pY + height / 2, isBouncy);
            //rect.SetColor(System.Drawing.Color.Pink);
            rect.vecRotation.angleDeg = rotation;
            rect.position.RotateAroundDegrees(rotation, new GXPEngine.Core.Vec2(x, y));
            game.Currentscene.AddChild(rect);
            if (isBouncy)
            {
                rect._bounciness = 0.6f;
            }
        }
    }


    void build(int length, Sprite body)
    {
        Sprite savedBody = body;
        savedBody.SetOrigin(0, 0);
        for (int i = 0; i < length; i++)
        {
            //body.SetOrigin(body.width/2, body.height/2);
            savedBody.x = +savedBody.height;
            savedBody.y = i*savedBody.width;

            savedBody.rotation = 90;

            AddChild(savedBody);

            width = savedBody.height;
            height = length * savedBody.width;
        }
    }
}

