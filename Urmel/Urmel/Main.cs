using BCEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Linq;
using Urmel.TestClasses;

namespace Urmel
{
  public class Main : Game
  {
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly SceneManager _sceneManager;
    MyScene scene;
    MyEffect MyGaussianEffect;
    MyMaterial MyGaussianMaterial;
    public Main()
    {
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
      _sceneManager = new SceneManager();


    }
    protected override void Initialize()
    {
      base.Initialize();
    }

    protected override void LoadContent()
    {
      var GaussianEffect = Content.Load<Effect>("Effects/GaussianBlur");
      MyGaussianEffect = new MyEffect(GaussianEffect);
      MyGaussianMaterial = new MyMaterial(MyGaussianEffect);
      ///
      ///Leave this at the bottom, we can load content before we load scenes
      ///
      _spriteBatch = new SpriteBatch(GraphicsDevice);

      scene = new MyScene() { BackgroundColor = new Color(0x00, 0x80, 0x80) };

      _sceneManager.AddScene(scene);
      _sceneManager.NavigateToScene(scene);
    }

    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
          Keyboard.GetState().IsKeyDown(Keys.Escape) || 
          TouchPanel.GetState().Any())
        Exit();

      _sceneManager.Update(gameTime);
      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      _sceneManager.Draw(GraphicsDevice, _spriteBatch);
      base.Draw(gameTime);
    }
  }
}
