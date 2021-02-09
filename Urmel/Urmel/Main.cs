using BCEngine.Graphics;
using BCEngine.Math;
using BCEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Input.Touch;
using System;
using System.Diagnostics;
using System.Linq;
using Urmel.TestClasses;

namespace Urmel
{
  public class Main : Game
  {
    private readonly GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    private readonly SceneManager _sceneManager;
    readonly Scene scene;

    public Main()
    {
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
      _sceneManager = new SceneManager();

      scene = new Scene() { BackgroundColor = new Color(0x00, 0x80, 0x80) };
      _sceneManager.AddScene(scene);
      _sceneManager.NavigateToScene(scene);
    }

    protected override void Initialize()
    {
      base.Initialize();
    }

    protected override void LoadContent()
    {
      _spriteBatch = new SpriteBatch(GraphicsDevice);
      var bcflag = Content.Load<Texture2D>("bcflag");

      MyDrawable drawableObject = new MyDrawable("flagObject", bcflag);
      scene.AddGameObject(drawableObject);
    }

    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
          Keyboard.GetState().IsKeyDown(Keys.Escape) || 
          TouchPanel.GetState().Any())
        Exit();
      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      _sceneManager.Draw(GraphicsDevice, _spriteBatch);

      base.Draw(gameTime);
    }
  }
}
