using BCEngine.Graphics;
using BCEngine.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Urmel.Scenes.GaussianBlurTestSceneClasses
{
  public class PipelinePass : RenderPass
  {
    public PipelinePass(RenderTarget2D renderTarget)
    {
      RenderTarget = renderTarget;
    }

    public override bool Render(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
    {

      graphicsDevice.SetRenderTarget(RenderTarget);

      spriteBatch.Begin(SpriteSortMode.BackToFront,
        Material.BlendState,
        SamplerState.PointClamp,
        Material.DepthStencilState,
        RasterizerState.CullNone,
        Material.Effect, null);

      foreach (IDrawable drawable in Drawables)
      {
        drawable.Draw(graphicsDevice, spriteBatch);
      }

      spriteBatch.End();

      return true;
    }
  }
}
