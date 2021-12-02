using BCEngine.Common;
using BCEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngine.Graphics
{ 
  public class Sprite : DrawableGameObject
  {
    public Texture2D Texture { get; set; }
    public Sprite(Texture2D texture)
    {
      Texture = texture;
      Bounds = texture.Bounds;
      this.SetScale(Vector2.One);
      this.Origin = new Vector2(Texture.Width / 2, Texture.Height / 2);
    }
    public override void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      this.DrawDefaultImplementation(WorldTransform, Bounds, Texture, spriteBatch, 0.5f);
    }
  }
}
