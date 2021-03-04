using BCEngine.Common;
using BCEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Urmel.Scenes.TilemappingDevScene
{
  class Sprite : DrawableGameObject
  {
    public Texture2D Texture { get; }
    public Sprite(Texture2D texture)
    {
      Texture = texture;
      Bounds = texture.Bounds;
      this.SetScale(Vector2.One);
    }
    public override void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      this.DrawDefaultImplementation(WorldTransform, Bounds, Texture, spriteBatch, 0.5f);
    }
  }
}
