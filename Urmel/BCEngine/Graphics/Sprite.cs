
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngine.Graphics
{
  public struct Sprite
  {
    public Texture2D texture { get; }
    public Vector2 position { get; }
    public Rectangle? sourceRectangle { get; }
    public Color color { get; }
    public float rotation { get; }
    public Vector2 origin { get; } 
    public Vector2 scale { get; }
    public SpriteEffects effects { get; }
  }
}
