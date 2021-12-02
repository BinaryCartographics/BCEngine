using BCEngine.Input;
using BCEngine.Scenes;
using BCEngine.UI.Text.FontFormats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Linq;
using Urmel.Scenes;

namespace Urmel
{
  public class Main : Game
  {
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly SceneManager _sceneManager;
    TestScene scene;

    readonly Codepage437 TextFormat437 = new Codepage437();

    public Main()
    {
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
      _sceneManager = new SceneManager();
      Window.AllowUserResizing = true;
      Window.ClientSizeChanged += OnResize;
    }

    protected override void Initialize()
    {
      base.Initialize();
    }

    protected override void LoadContent()
    {
      scene = new TestScene(GraphicsDevice, Content, TextFormat437);
      _sceneManager.AddScene(scene);
      _sceneManager.NavigateToScene(scene);
      _spriteBatch = new SpriteBatch(GraphicsDevice);
    }
    private void OnResize(object sender, EventArgs e)
    {
      _graphics.ApplyChanges();
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
