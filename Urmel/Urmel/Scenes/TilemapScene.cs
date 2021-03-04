using BCEngine.Helpers;
using BCEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Urmel.Scenes.TilemappingDevScene;
using Urmel.Tilemapping;

namespace Urmel.Scenes
{
  class TilemapScene : Scene
  {


    BasicRenderPass BasicRenderPass { get; }
    public TilemapScene(GraphicsDevice graphicsDevice, ContentManager content) : base(graphicsDevice, content)
    {

      MainCamera.Bounds = graphicsDevice.Viewport.Bounds;
      MainCamera.Origin = new Vector2(MainCamera.Bounds.Width / 2, MainCamera.Bounds.Height / 2);
      MainCamera.SetScale(Vector2.One);

      FinalRenderTarget = new RenderTarget2D(graphicsDevice, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);
      BasicRenderPass = new BasicRenderPass(FinalRenderTarget, MainCamera);
      AddRenderPass(BasicRenderPass);

      
    }
    public override void OnSceneEnter()
    {
    }
    public override void OnSceneExit()
    {
    }
    public override void OnUpdate(GameTime gameTime)
    {
    }
  }
}
