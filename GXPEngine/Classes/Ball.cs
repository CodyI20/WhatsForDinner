using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;
using System;

public class Ball : EasyDraw
{
    public int radius
    {
        get
        {
            return _radius;
        }
    }
    private Vec2 acceleration = new Vec2(0, 0.1f);
    private Vec2 velocity;
    private float extraSpeed;
    private Vec2 oldPosition;
    private Vec2 position;

    int _radius;
    float _mass = 0.7f;
    //float _speed;

    public Ball(int pRadius, Vec2 pPosition, Vec2 pVelocity = new Vec2()) : base(pRadius * 2 + 1, pRadius * 2 + 1)
    {
        _radius = pRadius;
        position = pPosition;
        //_speed = pSpeed;
        velocity = pVelocity;

        UpdateScreenPosition();
        SetOrigin(_radius, _radius);

        Draw(255, 255, 255);
    }

    void Draw(byte red, byte green, byte blue)
    {
        ClearTransparent();
        SetColor(1, 0, 0);
        Fill(red, green, blue);
        Stroke(red, green, blue);
        Ellipse(_radius, _radius, 2 * _radius, 2 * _radius);
    }

    //void FollowMouse() {
    //	position.SetXY (Input.mouseX, Input.mouseY);
    //}

    //public void CheckLineCollision()
    //{
    //    foreach (NLineSegment nLine in ((MyGame)game)._lineSegments)
    //    {
    //        Vec2 ltb = position - nLine.start;
    //        float ballDistance = ltb.Dot((nLine.end - nLine.start).Normal());
    //        //compare distance with ball radius
    //        //Console.WriteLine(extraSpeed);
    //        if (ballDistance <= radius)
    //        {
    //            if(nLine.lineSpeedBoost != 0)
    //            {
    //                extraSpeed = nLine.lineSpeedBoost;
    //                //play speed sound;
    //            }
    //            else if(nLine.lineBounciness != 0)
    //            {
    //                //play bouncepad bounce sound;
    //            }
    //            else
    //            {
    //                //play normal bounce sound;
    //            }
    //            //
    //            float a = (nLine.start - oldPosition).Dot((nLine.start - nLine.end).Normal()) - radius;
    //            float b = -velocity.Dot((nLine.end - nLine.start).Normal());
    //            float t = a / b;
    //            Vec2 desiredPos = oldPosition + (velocity * t);
    //            Vec2 lineVector = nLine.end - nLine.start;
    //            float lineLength = lineVector.length;
    //            Vec2 _ballToLine = desiredPos - nLine.start;
    //            float dotProduct = _ballToLine.Dot(lineVector.Normalized());
    //            if ((dotProduct >= 0 && dotProduct <= lineLength) && !(b <= 0) && !(a < 0))
    //            {
    //                position = desiredPos;
    //                velocity.Reflect((nLine.end - nLine.start).Normal(), .8f + nLine.lineBounciness);

    //                /*Console.WriteLine("---Collision at "+Time.time+"---");
				//	Console.WriteLine(t + " : " + a + " : " + b);
				//	Console.WriteLine(_ball.velocity);
				//	Console.WriteLine((nLine.end - nLine.start).Normal());
				//	Console.WriteLine("--------------------------------");*/

    //                rotation = velocity.angleDeg;
    //                continue;
    //            }
    //            else
    //            {
    //                position = oldPosition + velocity;
    //                //SetColor(0, 1, 0);

    //                Vec2 u = oldPosition - (nLine.start);
    //                float aC = Mathf.Pow(velocity.length, 2);
    //                float bC = u.Dot(velocity) * 2;
    //                float cC = Mathf.Pow(u.length, 2) - Mathf.Pow(radius + 0, 2);
    //                float dC = Mathf.Pow(b, 2) - (4 * aC * cC);

    //                if (cC < 0)
    //                {
    //                    if (bC < 0)
    //                    {
    //                        velocity.Reflect((nLine.end - nLine.start).Normal(), .2f + nLine.lineBounciness);
    //                        rotation = velocity.angleDeg;
    //                    }
    //                }

    //                continue;
    //            }
    //        }
    //        else
    //        {
    //            continue;
    //        }
    //    }
    //}

    void ReduceBoost()
    {
        //extraSpeed -= 
        if(extraSpeed < 0.0001f)
        {
            extraSpeed = 0f;
        }
    }

    void ChangeAnimal()
    {
        if (Input.GetKeyDown(Key.ONE))
        {
            _mass = 0.2f;
            SetColor(0, 1, 1);
        }
        if (Input.GetKeyDown(Key.TWO))
        {
            _mass = 0.6f;
            SetColor(1, 0, 0);
        }
        if (Input.GetKeyDown(Key.THREE))
        {
            _mass = 1f;
            SetColor(1, 1, 1);
        }
    }

    void Update()
    {
        Step();
        //CheckLineCollision();
        ChangeAnimal();
        //Console.WriteLine("Ball velocity: " + velocity.Length().ToString());
    }

    void UpdateScreenPosition()
    {
        x = position.x;
        y = position.y;
    }

    public void Step()
    {
        velocity += acceleration * _mass;
        //Vec2 normalVelocity = velocity;
        //velocity += normalVelocity*extraSpeed;
        oldPosition = position;
        position += velocity;

        UpdateScreenPosition();
    }
}
