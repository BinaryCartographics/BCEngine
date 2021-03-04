using BCEngine.Graphics;
using BCEngine.Interfaces;
using BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using IDrawable = BCEngine.Interfaces.IDrawable;

namespace BCEngine.Helpers
{
  public static class IDrawableExtensions
  {
    public static bool DrawDefaultImplementation(this IDrawable Parent, Transform transform, Rectangle rectangle, Texture2D texture, SpriteBatch spriteBatch, float LayerDepth)
    {
      spriteBatch.Draw(texture, transform.Position, rectangle, Color.White, 
        transform.Rotation, Parent.Origin, transform.Scale, SpriteEffects.None, LayerDepth);
      return true;
    }

    public static bool AddRenderPassDefaultImplementation(this IDrawable drawable, RenderPass renderPass, IList<RenderPass> renderPasses)
    {
      if (!renderPasses.Contains(renderPass))
      {
        renderPasses.Add(renderPass);
        return true;
      }
      return false;
    }

    public static bool RemoveRenderPassDefaultImplementation(this IDrawable drawable, RenderPass renderPass, IList<RenderPass> renderPasses)
    {
      if (renderPasses.Contains(renderPass))
      {
        renderPasses.Remove(renderPass);
        return true;
      }
      return false;
    }
  }
}
