using System.Collections.Generic;
using GXPEngine.Core;

namespace GXPEngine.Physics
{
    public class PhysicsTriangle : PhysicsPolygon
    {

        public PhysicsTriangle(int pBase, int pHeight, Vec2 pPosition) :
            base(
            new List<Vec2>()
            {
                new Vec2(0, 0),
                new Vec2(pBase, 0),
                new Vec2(pBase, pHeight),
            },
            pBase, pHeight, pPosition)
        {
        }

        public PhysicsTriangle(int pBase, int pHeight, int pX, int pY) : this(pBase, pHeight, new Vec2(pX, pY))
        {
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
        }

        protected override void Draw()
        {
            base.Draw();
            //draw.Triangle(width/2, 0, -width/2, 0, 0, height);
        }
    }
}
