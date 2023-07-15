using GXPEngine;
using GXPEngine.Core;
using GXPEngine.Physics;

public class PlayableLevel : Level
{
    public PlayableLevel() : base("playableLevel")
    {
        name = "playableLevel";
        gravity = new Vec2(0, 10f);
        resistance = 0.006f;
        rotatedTriangle1 = rotatedTriangle2 = rotatedTriangle3 = rotatedTriangle4 = 8;

    }

    public override void onLoad()
    {
        AddChild(new Spikes(30, 0, height + 10));
        AddChild(new BoostPad(51,51, 558,954 ));
        AddChild(new BoostPad(51, 51, 575, 787));
        AddChild(new BoostPad(51, 51, 799,786,315 ));
        AddChild(new BoostPad(51, 51, 1078,646,180 ));
        AddChild(new BoostPad(51, 51, 1061,461 ));
        AddChild(new BoostPad(51, 51, 1277, 951));
        AddChild(new BoostPad(51, 51, 1282, 854));
        AddChild(new BoostPad(51, 51, 1370, 719,180));
        AddChild(new BoostPad(51, 51, 1556, 971));
        AddChild(new BoostPad(51, 51, 1568, 836,315));
        //AddChild(new BreakableSurface(new Vec2(412, 969)));

        AddChild(new BreakableSurface(new Vec2(475, 968)));
        AddChild(new BreakableSurface(new Vec2(523, 779)));//
        AddChild(new BreakableSurface(new Vec2(807, 968)));
        AddChild(new BreakableSurface(new Vec2(807, 927)));
        AddChild(new BreakableSurface(new Vec2(1224, 871)));
        AddChild(new BreakableSurface(new Vec2(1448, 704),90));
        AddChild(new BreakableSurface(new Vec2(1480, 704), 90));


        ///Normal platforms
        AddChild(new Platforms(1, 443, 926, new Sprite(Settings.ASSET_PATH + "Art/3.png", false, false)));//
        AddChild(new Platforms(1, 461, 747, new Sprite(Settings.ASSET_PATH + "Art/4.png", false, false)));//
        AddChild(new Platforms(1, 314, 1025, new Sprite(Settings.ASSET_PATH + "Art/5.png", false, false)));
        AddChild(new Platforms(1, 685, 1026, new Sprite(Settings.ASSET_PATH + "Art/5.png", false, false)));
        AddChild(new Platforms(1, 1153, 1026, new Sprite(Settings.ASSET_PATH + "Art/5.png", false, false)));
        AddChild(new Platforms(1, 1202, 852, new Sprite(Settings.ASSET_PATH + "Art/7.png", false, false)));
        AddChild(new Platforms(1, 1332, 725, new Sprite(Settings.ASSET_PATH + "Art/8.png", false, false)));
        AddChild(new Platforms(1, 1187, 650, new Sprite(Settings.ASSET_PATH + "Art/9.png", false, false)));
        AddChild(new Platforms(1, 1313, 654, new Sprite(Settings.ASSET_PATH + "Art/9-smallblock.png", false, false)));
        AddChild(new Platforms(1, 1865, 853, new Sprite(Settings.ASSET_PATH + "Art/10.png", false, false)));
        AddChild(new Platforms(1, 1503, 775, new Sprite(Settings.ASSET_PATH + "Art/11.png", false, false)));
        AddChild(new Platforms(1, 1716, 1045, new Sprite(Settings.ASSET_PATH + "Art/12.png", false, false)));
        //AddChild(new Platforms(1, 174, 857, new Sprite(Settings.ASSET_PATH + "Art/f1.png", false, false)));
        AddChild(new Platforms(1, 697, 894, new Sprite(Settings.ASSET_PATH + "Art/f2.png", false, false)));
        AddChild(new Platforms(1, 862, 823, new Sprite(Settings.ASSET_PATH + "Art/f3.png", false, false)));
        AddChild(new Platforms(1, 990, 721, new Sprite(Settings.ASSET_PATH + "Art/f4.png", false, false)));
        AddChild(new Platforms(1, 1001, 860, new Sprite(Settings.ASSET_PATH + "Art/f4-bottom.png", false, false)));
        AddChild(new Platforms(1, 1203, 923, new Sprite(Settings.ASSET_PATH + "Art/f5.png", false, false)));
        AddChild(new Platforms(1, 1503, 914, new Sprite(Settings.ASSET_PATH + "Art/f6.png", false, false)));

        ///EXTRA PLATFORMS
        AddChild(new Platforms(1, 703, 521, new Sprite(Settings.ASSET_PATH + "Art/3.png", false, false)));
        AddChild(new Platforms(1, 1731, 672, new Sprite(Settings.ASSET_PATH + "Art/3.png", false, false)));
        AddChild(new Platforms(1, 725, 384, new Sprite(Settings.ASSET_PATH + "Art/3.png", false, false)));
        AddChild(new Platforms(1, 955, 389, new Sprite(Settings.ASSET_PATH + "Art/3.png", false, false)));
        AddChild(new Platforms(1, 1203, 390, new Sprite(Settings.ASSET_PATH + "Art/3.png", false, false)));
        AddChild(new Platforms(1, 149, 415, new Sprite(Settings.ASSET_PATH + "Art/3.png", false, false)));



        ///Bouncy platforms
        AddChild(new Platforms(1, 602, 1027  , new Sprite(Settings.ASSET_PATH + "Art/mushroom.png", false, false), true, true));
        AddChild(new Platforms(1, 901, 1027, new Sprite(Settings.ASSET_PATH + "Art/mushroom.png", false, false), true, true));
        AddChild(new Platforms(1, 1083, 1027, new Sprite(Settings.ASSET_PATH + "Art/mushroom.png", false, false), true, true));
        AddChild(new Platforms(1, 1354, 1027, new Sprite(Settings.ASSET_PATH + "Art/mushroom.png", false, false), true, true));

        base.onLoad();

        AddChild(new Objective(188, 87, 1805, 822));
    }
}


public class Level : Scene
{
    public Camera mainCam;
    public Vec2 gravity;
    public float resistance;
    public int stars;
    public Sprite den;

    protected Sprite panel;
    protected MyGame myGame;

    protected int rotatedTriangle1;
    protected int rotatedTriangle2;
    protected int rotatedTriangle3;
    protected int rotatedTriangle4;


    public Level(string name) : base(name, Settings.ASSET_PATH + "Art/" + name + "Background.png")
    {
        myGame = (MyGame)game;
    }

    public override void Update()
    {
        base.Update();
    }


    public override void onLoad()
    {
        base.onLoad();

        AddChildAt(new Sprite(Settings.ASSET_PATH + "Art/tree_branches.png", false, false), 1000);
        AddChildAt(new Sprite(Settings.ASSET_PATH + "Art/stems.png", false, false), 1000);
        AddChildAt(new Sprite(Settings.ASSET_PATH + "Art/fauna.png", false, false), 1000);
        AddChildAt(new Sprite(Settings.ASSET_PATH + "Art/UI.png", false, false), 1000);
        AddChildAt(new Platforms(1, 15, 1020, new Sprite(Settings.ASSET_PATH + "Art/cannon_rock.png", false, false), false, false, 0.35f), 9);
        AddChild(new TrianglePlaceableButton(233, 190, rotatedTriangle4));
        AddChild(new ButtonAssemblyw(0, 0, 3, 1));

        AddChild(new PhysicsLine(0, 0, 0, height));
        AddChild(new PhysicsLine(width, height, width, 0));
        AddChild(new PhysicsLine(width, 150, 0, 150));

        AddChildAt(new Cannon(new Vec2(45, 995)), 8);

        //mainCam = new Camera(0, 0, width, height);
        //AddChild(mainCam);
    }

    public override void onLeave()
    {
        base.onLeave();
    }

    public override void recieveMessage(string message)
    {
    }
}
