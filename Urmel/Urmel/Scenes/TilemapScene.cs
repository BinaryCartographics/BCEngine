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

namespace Urmel.Scenes
{
  class TilemapScene : Scene
  {
    BasicRenderPass BasicRenderPass { get; }
    readonly GraphicsDevice GraphicsDevice;
    TextBox TextThing;
    float camTranslateSpeed = 3f;

    public TilemapScene(GraphicsDevice graphicsDevice, ContentManager content, Codepage437 fontFormat) : base(graphicsDevice, content)
    {
      GraphicsDevice = graphicsDevice;
      MainCamera.Bounds = graphicsDevice.Viewport.Bounds;
      MainCamera.Origin = new Vector2(MainCamera.Bounds.Width / 2, MainCamera.Bounds.Height / 2);
      MainCamera.SetScale(Vector2.One);

      FinalRenderTarget = new RenderTarget2D(graphicsDevice, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
      BasicRenderPass = new BasicRenderPass(FinalRenderTarget, MainCamera);
      AddRenderPass(BasicRenderPass);
      MainCamera.Bounds = FinalRenderTarget.Bounds;


      TextFont tf = new TextFont("Textures/UI/Fonts/Codepage437/jazz12_df", content, 12, 12, fontFormat);
      TextThing = new TextBox(5, 5, tf);
      BasicRenderPass.AddDrawableToRenderPass(TextThing);

      TextThing.Write("hello", Color.Goldenrod, Color.Purple);
      MainCamera.SetScale(Vector2.One / 5f);

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
      return new Vector2((float)x, (float)y);
    }
    public override void OnUpdate(GameTime gameTime)
    {
      Vector2 cam = getCameraInput() * camTranslateSpeed;
      MainCamera.Translate(cam);

      TextThing.Rotate(0.5f * DeltaTime);
      TextThing.Clear();
      TextThing.Write(gameTime.TotalGameTime.TotalSeconds.ToString(), Color.White, Color.Red);
    }
  }
}
