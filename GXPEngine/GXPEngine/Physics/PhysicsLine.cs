using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GXPEngine.Core;

namespace GXPEngine.Physics
{
    public class PhysicsLine : PhysicsObject
    {
        public Vec2 start;
        public Vec2 end;
        public Vec2 middle
        {
            get { return CalculateMiddle(start, end); }
        }
        public Vec2 lineVector
        {
            get { return start - end; }
        }

        public PhysicsLine(Vec2 pStart, Vec2 pEnd, float pBouncyness = 0f, bool pTrigger = false) : base((int)Vec2.Distance(pEnd, pStart), 1, CalculateMiddle(pStart, pEnd))
        {
            start = pStart;
            end = pEnd;

            _bounciness = pBouncyness;
            trigger = pTrigger;
            vecRotation.angleDeg = lineVector.angleDeg;

            UpdateScreenPosition();
        }

        public PhysicsLine(int startX, int startY, int endX, int endY ) : this(new Vec2(startX, startY), new Vec2(endX, endY))
        {
            //SetColor(System.Drawing.Color.Pink);
        }

        private static Vec2 CalculateMiddle(Vec2 _start, Vec2 _end)
        {
            Vec2 middle = _end + _start;
            middle /= 2f;
            return middle;
        }

        protected override void Draw()
        {
            draw.Rect(0, 0, width*2, height*2);
            //draw.Clear(System.Drawing.Color.Green);
        }

        public override bool Colliding(PhysicsLine other)
        {
            throw new NotImplementedException();
        }

        public override bool Colliding(PhysicsCircle circle)
        {
            throw new NotImplementedException();
        }

        public override void Collide(PhysicsObject other)
        {
        }
    }
}
