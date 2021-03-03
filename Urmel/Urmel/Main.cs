using BCEngine.Input;
using BCEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System.Linq;
using Urmel.Scenes;
using Urmel.Scenes.GaussianBlurTestSceneClasses;
using Urmel.TestClasses;

namespace Urmel
{
  public class Main : Game
  {
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly SceneManager _sceneManager;
    PipelineTestScene gaussianBlurTestScene;
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
      gaussianBlurTestScene = new PipelineTestScene(GraphicsDevice, Content);

      _sceneManager.AddScene(gaussianBlurTestScene);
      _sceneManager.NavigateToScene(gaussianBlurTestScene);
      _spriteBatch = new SpriteBatch(GraphicsDevice);
    }

    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
          Keyboard.GetState().IsKeyDown(Keys.Escape) || 
          TouchPanel.GetState().Any())
        Exit();
      InputManager.Update();
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
