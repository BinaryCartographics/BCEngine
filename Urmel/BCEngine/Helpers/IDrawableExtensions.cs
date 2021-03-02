using BCEngine.Graphics;
using BCEngine.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BCEngine.Helpers
{
  public static class IDrawableExtensions
  {
    public static bool DrawDefaultImplementation(this IDrawable Parent, Texture2D texture, SpriteBatch spriteBatch, float LayerDepth)
    {
      spriteBatch.Draw(texture, Parent.WorldTransform.Position, Parent.SourceRectangle, Parent.Color, 
        Parent.WorldTransform.Rotation, Parent.Origin, Parent.WorldTransform.Scale, SpriteEffects.None, LayerDepth);
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
