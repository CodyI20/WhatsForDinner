using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;
using System;

class BoostPad : PhysicsRectangle
{
    AnimationSprite boostSprite;
    float boostAmount = 1f;
    public BoostPad(int pWidth, int pHeight, int pX, int pY,int angle = 0) : base(pWidth, pHeight, new Vec2(pX,pY))
    {
        //SetColor(System.Drawing.Color.White);
        trigger = true;
        scale = 0.2f;
        boostSprite = new AnimationSprite(Settings.ASSET_PATH + "Art/boost.png",10,1,-1,false,true);
        boostSprite.SetCycle(0,10);
        boostSprite.SetOrigin(boostSprite.width/2,boostSprite.height/2);
        boostSprite.SetXY(0, 0);
        boostSprite.rotation = angle;
        AddChild(boostSprite);
        rotation = angle;
        SetXY(pX, pY);
    }
    public override void Update()
    {
        base.Update();
        boostSprite.Animate(0.05f);
    }
    public override void Collide(PhysicsObject other)
    {
        AnimalBall animalBall = (AnimalBall)other;
        if (other is AnimalBall)
        {
            animalBall.velocity.Boost(boostAmount,rotation);
            new Sound(Settings.ASSET_PATH + "SFX/Whoosh.mp3").Play(false, 0, Settings.sfxVolume, 0);
            LateDestroy();
        }
    }
}
