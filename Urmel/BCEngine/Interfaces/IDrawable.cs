using BCEngine.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BCEngine.Interfaces
{
  public interface IDrawable : IBounds
  {
    IReadOnlyList<RenderPass> AttachedRenderPasses { get; }
    void AddRenderPass(RenderPass renderPass);
    void RemoveRenderPass(RenderPass renderPass);
    void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch);
  }
}
