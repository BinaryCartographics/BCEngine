using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngine.Interfaces
{
  public interface IDrawable : IGameObject
  {
    Texture2D Texture { get; set; }
    Vector2 Origin { get; set; }
    Rectangle Bounds { get; set; }
    Rectangle SourceRectangle { get; set; }
    Color Color { get; set; }
    SpriteEffects SpriteEffects { get; set; }
    float LayerDepth { get; set; }
    void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch);
  }
}
