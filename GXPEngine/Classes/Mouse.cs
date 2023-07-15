using GXPEngine.Core;
using GXPEngine;

public class Mouse : GameObject
{
    Vec2 position;
    Vec2 oldPosition;

    public bool hovering;
    Sprite cursor;
    Placeable equipped;

    Vec2 direction
    {
        get { return position - oldPosition; }
    }

    public Mouse() : base(false)
    {
        cursor = new Sprite(Settings.ASSET_PATH + "Art/Cursor.png", false, false);
        cursor.SetOrigin(cursor.width / 2, cursor.height / 2);
        cursor.SetXY(6, 9);
        cursor.scale = 0.1f;
        game.ShowMouse(false);
        AddChild(cursor);
    }


    public void Update()
    {
        oldPosition = position;
        SetXY(Input.mouseX, Input.mouseY);
        position = new Vec2(x, y);


        if (equipped != null)
        {

            if (Input.GetKeyDown(Key.A))
            {
                equipped.rotation += -20f;
            }

            if (Input.GetKeyDown(Key.D))
            {
                equipped.rotation += 20f;
            }
        }

        if (Input.GetMouseButtonUp(0) && equipped != null)
        {
            release();
        }

        if (hovering)
        {
            hovering = false;
        }
    }

    private void release()
    {
        if (y < 120)
        {
            if (equipped is Plank)
            {
                ((PlankButton)game.Currentscene.FindObjectOfType(typeof(PlankButton))).stock ++;
            }
            if (equipped is Spring)
            {
                ((SpringButton)game.Currentscene.FindObjectOfType(typeof(SpringButton))).stock++;
            }
            if (equipped is LowBounce)
            {
                ((PillowButton)game.Currentscene.FindObjectOfType(typeof(PillowButton))).stock++;
            }
            if (equipped is TrianglePlaceable)
            {
                ((TrianglePlaceableButton)game.Currentscene.FindObjectOfType(typeof(TrianglePlaceableButton))).stock++;
            }

            equipped.Destroy();
        }
        else
        {
            equipped.SetXY(position.x, position.y);
            game.Currentscene.AddChild(equipped);
        }

        equipped = null;
    }

    public void receive(Placeable placeable)
    {
        if (equipped == null)
        {
            equipped = placeable;

            equipped.SetXY(0, 0);
            AddChildAt(equipped,0);
        }
    }
}

