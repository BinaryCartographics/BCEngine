using Microsoft.Xna.Framework.Graphics;

namespace BCEngine.Interfaces
{
  public interface IDrawable : IGameObject
  {
    void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch);
  }
}
