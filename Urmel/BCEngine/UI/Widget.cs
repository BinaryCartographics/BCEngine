using BCEngine.Math;
using BCEngine.Interfaces;
using BCEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using BCEngine.Graphics;
using System;
using IDrawable = BCEngine.Interfaces.IDrawable;

namespace BCEngine.UI
{
  public abstract partial class Widget : IDrawable, ITransformable
  {
    /// <summary>
    /// Private members and initialization stuff
    /// </summary>
    private List<IGameObject> _children;
    private List<RenderPass> _attatchedRenderPasses;
    protected Widget()
    {
      _children = new List<IGameObject>();
      Children = _children.AsReadOnly();
      _attatchedRenderPasses = new List<RenderPass>();
      AttachedRenderPasses = _attatchedRenderPasses.AsReadOnly();
      this.SetScale(Vector2.One);
    }
    public IReadOnlyList<RenderPass> AttachedRenderPasses { get; }
    public Vector2 Origin { get; set; }
    public Rectangle SourceRectangle { get; set; }
    public Color Color { get; set; }
    public SpriteEffects SpriteEffects { get; set; }
    public float LayerDepth { get; set; }
    public string Name { get; }
    public IGameObject Parent { get; set; }
    public IReadOnlyList<IGameObject> Children { get; }
    public Transform Transform { get; set; }
    public Rectangle Bounds { get; set; }
    public void AddRenderPass(RenderPass renderPass)
    {
      this.AddRenderPassDefaultImplementation(renderPass, _attatchedRenderPasses);
    }
    public void RemoveRenderPass(RenderPass renderPass)
    {
      this.RemoveRenderPassDefaultImplementation(renderPass, _attatchedRenderPasses);
    }
    public bool Contains(Vector2 Position)
    {
      return this.ContainsDefaultImplementation(Transform, Position);
    }
    public abstract void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch);
  }
}
