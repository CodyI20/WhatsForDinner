using System.Collections.Generic;
using GXPEngine.Physics;
using GXPEngine.Core;
using GXPEngine;

public abstract class Placeable : GameObject
{
    protected List<PhysicsObject> PhysicsObjects;
    public int width = 0;
    public int height = 0;
    public PhysicsRectangle mainColliderRect;
    public PhysicsTriangle mainColliderTriang;

    Vec2 oldPos;
    Vec2 position;

    float oldRotation;

    public Placeable(Vec2 pPosition) : base(false)
    {
        PhysicsObjects = new List<PhysicsObject>();
        position = pPosition;
        Step();
    }

    protected void Step()
    {
        position.SetXY(x, y);

        foreach (PhysicsObject physicsObject in PhysicsObjects)
        {
            physicsObject.parent = parent;
            physicsObject.position += (position - oldPos);
            physicsObject.vecRotation.RotateDegrees(rotation - oldRotation);
            physicsObject.position.RotateAroundDegrees(rotation - oldRotation, position);
        }

        if (Input.GetMouseButtonDown(0) && IsInside(Input.mouseX, Input.mouseY))
        {
            ((MyGame)game).mouse.receive(this);
        }
        oldPos = position;
        oldRotation = rotation;
    }

    public override void Destroy()
    {
        base.Destroy();

        foreach (PhysicsObject physicsObject in PhysicsObjects)
        {
            physicsObject.Destroy();
        }
    }

    protected virtual void Run()
    {
        if (mainColliderRect != null && mainColliderRect.collided)
        {
            Collide();
        }
        if (mainColliderTriang != null && mainColliderTriang.collided)
        {
            Collide();
        }
    }

    protected abstract void Collide();

    protected void Update()
    {
        Step();

        if (!(parent is Mouse))
        {
            Run();
        }
    }

    private bool IsInside(int pX, int pY)
    {
        int rx = (int)x - width/2;
        int ry = (int)y - height/2;
        int rw = (int)width;
        int rh = (int)height;

        if (pX >= rx &&         // right of the left edge AND
        pX <= rx + rw &&    // left of the right edge AND
        pY >= ry &&         // below the top AND
        pY <= ry + rh)
        {    // above the bottom
            return true;
        }
        return false;
    }
}
