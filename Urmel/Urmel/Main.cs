using BCEngine.Scenes;
using BCEngine.Helpers;
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
    readonly Scene scene;
    MyDrawable drawableObject;

    private readonly System.Random R;
    float ScaleY;

    readonly float MoveAmount = 20f;

    public Main()
    {
      _graphics = new GraphicsDeviceManager(this);
      Content.RootDirectory = "Content";
      IsMouseVisible = true;
      _sceneManager = new SceneManager();

      scene = new Scene() { BackgroundColor = new Color(0x00, 0x80, 0x80) };
      _sceneManager.AddScene(scene);
      _sceneManager.NavigateToScene(scene);
      R = new System.Random();
    }
    protected override void Initialize()
    {
      base.Initialize();
    }

    protected override void LoadContent()
    {
      _spriteBatch = new SpriteBatch(GraphicsDevice);
      var bcflag = Content.Load<Texture2D>("bcflag");


      drawableObject = new MyDrawable("flagObject", bcflag);
      drawableObject.SetScale(new Vector2(1f, 0.5f));
      MyDrawable TL = new MyDrawable("TL", bcflag);
      MyDrawable TR = new MyDrawable("TR", bcflag);

      MyDrawable BL = new MyDrawable("BL", bcflag);
      MyDrawable BR = new MyDrawable("BR", bcflag);

      scene.AddGameObject(drawableObject);
      scene.AddGameObject(TL);
      scene.AddGameObject(TR);
      scene.AddGameObject(BL);
      scene.AddGameObject(BR);


      drawableObject.AddGameObject(TL);
      drawableObject.AddGameObject(TR);
      drawableObject.AddGameObject(BL);
      drawableObject.AddGameObject(BR);

      TL.SetPosition(new Vector2(-50, -50));
      TR.SetPosition(new Vector2(50, -50));
      BL.SetPosition(new Vector2(-50, 50));
      BR.SetPosition(new Vector2(50, 50));

      TL.SetScale(new Vector2(5, 5));
      TR.SetScale(new Vector2(5, 4));
      BL.SetScale(new Vector2(4, 5));
      BR.SetScale(new Vector2(4, 4));

      drawableObject.LayerDepth = 0.5f;
      TL.LayerDepth = 1f;
      TR.LayerDepth = 1f;
      BL.LayerDepth = 1f;
      BR.LayerDepth = 1f;
    }

    protected override void Update(GameTime gameTime)
    {
      if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
          Keyboard.GetState().IsKeyDown(Keys.Escape) || 
          TouchPanel.GetState().Any())
        Exit();

      var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;

      Vector2 moveDirection = Vector2.One * MoveAmount * delta;
      drawableObject.Translate(moveDirection);
      drawableObject.Rotate(MathHelper.ToRadians(20) * delta);
      ScaleY += delta / 5;
      drawableObject.SetScale(new Vector2(1f, ScaleY));
      base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
      _sceneManager.Draw(GraphicsDevice, _spriteBatch);
      base.Draw(gameTime);
    }
  }
}
