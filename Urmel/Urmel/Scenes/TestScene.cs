using BCEngine.Graphics;
using BCEngine.Helpers;
using BCEngine.Scenes;
using BCEngine.Input;
using BCEngine.UI;
using BCEngine.UI.Text;
using BCEngine.UI.Text.FontFormats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Urmel.Roguelike.Generators.Bsp;
using Urmel.Roguelike.Tiles;

namespace Urmel.Scenes
{
  class TestScene : Scene
  {
    BasicRenderPass BasicRenderPass { get; }
    readonly GraphicsDevice GraphicsDevice;
    readonly TextBox TextThing;
    readonly float CameraZoom = 1f;
    public TestScene(GraphicsDevice graphicsDevice, ContentManager content, Codepage437 fontFormat) : base(graphicsDevice, content)
    {
      //Basic scene code, do not delete unless you have read the source code recently
      #region setting up graphics device and render targets
      GraphicsDevice = graphicsDevice;

      FinalRenderTarget = new RenderTarget2D(graphicsDevice, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
      BasicRenderPass = new BasicRenderPass(FinalRenderTarget, MainCamera);
      AddRenderPass(BasicRenderPass);

      MainCamera.Bounds = FinalRenderTarget.Bounds;
      #endregion


      TextFont tf = new TextFont("Textures/UI/Fonts/Codepage437/jazz12_df", content, 12, 12, fontFormat);

      TextThing = new TextBox(100, 50, tf);
      //TextThing.SetPosition(Vector2.One * 100);

      //THIS HAS NOT BEEN ADDED AS AN IGAMEOBJECT TO THE SCENE, IT IS UI
      BasicRenderPass.AddDrawableToRenderPass(TextThing);


      MainCamera.Rotate(MathHelper.ToRadians(20));

      MainCamera.Bounds = graphicsDevice.Viewport.Bounds;
      MainCamera.Origin = new Vector2(MainCamera.Bounds.Width / 2, MainCamera.Bounds.Height / 2);
      MainCamera.SetScale(Vector2.One * CameraZoom);
      MainCamera.CameraMode = BCEngine.Common.CameraMode.Default;
      TextThing.Write("HELLO COMMANDERS, THIS IS", Color.White, Color.White, 0, 0);
      TextThing.Write(" NOT ", Color.Red, Color.Red);
      TextThing.Write("A COMMAND PROMPT WINDOW", Color.White, Color.White);

      //MainCamera.SetPosition(TextThing.Characters[0, 0].WorldTransform.Position);
    }
    public override void OnSceneEnter()
    {

    }
    public override void OnSceneExit()
    {

    }
    public Vector2 getCameraInput()
    {
      var keyState = InputManager.KeyboardState;
      float x = 0;
      float y = 0;
      
      if (keyState.IsKeyDown(Keys.A))
      {
        x = -10 * DeltaTime;
      }
      if (keyState.IsKeyDown(Keys.D))
      {
        x = 10 * DeltaTime;
      }
      if (keyState.IsKeyDown(Keys.W))
      {
        y = -10 * DeltaTime;
      }
      if (keyState.IsKeyDown(Keys.S))
      {
        y = 10 * DeltaTime;
      }
      return new Vector2(x, y);
    }
    public override void OnUpdate(GameTime gameTime)
    {
      Vector2 cam = getCameraInput() * 10f;
      MainCamera.Translate(cam);
    }
  }
}
