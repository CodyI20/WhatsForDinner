using GXPEngine.Core;
using System.Collections.Generic;

namespace GXPEngine.Physics
{
    public class PhysicsRectangle : PhysicsPolygon
    {
        //Change constructor to contain AnimationSprite/Sprite and change the Vec2 to AnimationSprite/Sprite.width or height
        Sound bounceSound = null;
        readonly bool isBouncy;

        public PhysicsRectangle(int pWidth, int pHeight, Vec2 pPosition) :
            base(
            new List<Vec2>()
            {
                new Vec2(- pWidth / 2, - pHeight / 2),
                new Vec2(pWidth / 2, - pHeight / 2),
                new Vec2(pWidth / 2, pHeight / 2),
                new Vec2(- pWidth / 2,pHeight / 2)
            },
            pWidth, pHeight, pPosition)
        {
        }

        public PhysicsRectangle(int pWidth, int pHeight, int pX, int pY, bool isBouncy = false) : this(pWidth, pHeight, new Vec2(pX, pY))
        {
            //SetColor(System.Drawing.Color.Green);
            this.isBouncy = isBouncy;
            if (isBouncy)
                bounceSound = new Sound(Settings.ASSET_PATH + "SFX/Mushroom_bounce.mp3");
        }

        public override void Update()
        {
            base.Update();
            collided = false;
        }

        public override void Collide(PhysicsObject other)
        {
            base.Collide(other);
            collided = true;
            if (bounceSound != null)
                bounceSound.Play();
        }

        protected override void Draw()
        {
            base.Draw();
            //draw.Rect(0, 0, width * 2, height * 2);
        }
    }
}
