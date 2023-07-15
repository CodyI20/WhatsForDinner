using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;

class Objective : PhysicsRectangle
{
    //Level2 lvl2 = new Level2();
    //SceneManager _sceneManager;
    Timer deadTimer;
    Sprite den;
    bool played = false;

    public Objective(int pWidth, int pHeight, int pX, int pY) : base(pWidth, pHeight, new Vec2(pX, pY))
    {
        trigger = true;
        //SetColor(System.Drawing.Color.Green);
        SetUpDen();
        //dest = destination;

        //den = ((Level)game.Currentscene).den;

    }

    protected void SetUpDen()
    {
        den = new Sprite(Settings.ASSET_PATH + "Art/den.png", false, false);
        den.SetOrigin(den.width/2, den.height/2);
        den.scale = 1f;
        AddChild(den);
    }

    public override void Update()
    {
        base.Update();

        FinishLevel();
    }

    void FinishLevel()
    {
        if (deadTimer != null && deadTimer.done)
        {
            LateRemove();
            game.SceneManager.GotoNextscene();
        }
    }

    public override void Collide(PhysicsObject other)
    {
        if (other is AnimalBall)
        {
            ((AnimalBall)other).LateDestroy();

            if (deadTimer == null)
            {
                deadTimer = new Timer(0.1f);

                AddChild(deadTimer);
                new Sound(Settings.ASSET_PATH + "SFX/Finish.mp3").Play(false, 0, Settings.sfxVolume, 0);
                if (played == false)
                {
                    //new Sound(Settings.ASSET_PATH + "SFX/Rocket.wav").Play(false, 0, Settings.sfxVolume, 0);
                    played = true;
                }
            }
        }
    }
}
