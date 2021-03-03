using BCEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BCEngine.Interfaces
{
  public interface IDrawable : IGameObject, IBounds
  {
    IReadOnlyList<RenderPass> AttachedRenderPasses { get; }
    Vector2 Origin { get; set; }
    Rectangle SourceRectangle { get; set; }
    Color Color { get; set; }
    SpriteEffects SpriteEffects { get; set; }
    float LayerDepth { get; set; }
    void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch);

    void AddRenderPass(RenderPass renderPass);
    void RemoveRenderPass(RenderPass renderPass);
  }
}
