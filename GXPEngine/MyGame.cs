using GXPEngine;                                // GXPEngine contains the engine

public class MyGame : Game
{
	public SoundChannel soundChannel;
	public Mouse mouse;
	public float volume = 0.5f;

    public MyGame() : base(1920, 1080, true,false)
	{
		targetFps = 120;

		mouse = new Mouse();

		_sceneManager.addscene(new Menu());
		_sceneManager.addscene(new PlayableLevel());
		_sceneManager.addscene(new Menu());

		soundChannel = new Sound(Settings.ASSET_PATH + "SFX/Soundtrack.mp3", true, false).Play(false, 0, volume, 0);

    }

    void Update()
	{
		Input.PrintMouseCoordinates();
		AddChildAt(mouse, 100);
	}

	static void Main()							// Main() is the first method that's called when the program is run
	{
		new MyGame().Start();                   // Create a "MyGame" and start it
	}
}
