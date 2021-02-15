using BCEngine.Interfaces;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BCEngine.Helpers
{
  public static class IDrawableExtensions
  {
    public static bool DrawDefaultImplementation(this IDrawable Parent, SpriteBatch spriteBatch, float LayerDepth)
    {
      spriteBatch.Draw(Parent.Texture, Parent.WorldTransform.Position, Parent.SourceRectangle, Parent.Color, Parent.WorldTransform.Rotation, Parent.Origin, Parent.WorldTransform.Scale, SpriteEffects.None, LayerDepth);
      return true;
    }
  }
}
