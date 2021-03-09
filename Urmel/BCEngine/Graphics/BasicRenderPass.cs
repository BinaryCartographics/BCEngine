using BCEngine.Common;
using BCEngine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using IDrawable = BCEngine.Interfaces.IDrawable;

namespace BCEngine.Graphics
{
  public class BasicRenderPass : RenderPass
  {
    public Camera Camera { get; set; }
    public BasicRenderPass(RenderTarget2D renderTarget2D, Camera camera)
    {
      Camera = camera;
      RenderTarget = renderTarget2D;
    }
    public override int RenderPriority { get; } = 1;
    public override void Render(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice)
    {
      graphicsDevice.SetRenderTarget(RenderTarget);
      graphicsDevice.Clear(Color.Black);
      spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, null, null, null, Camera.TransformMatrix);
      foreach (IDrawable drawable in Drawables)
      {
        drawable.Draw(graphicsDevice, spriteBatch);
      }
      spriteBatch.End();
    }
  }
}
