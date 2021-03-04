using BCEngine.Graphics;
using BCEngine.Helpers;
using BCEngine.Interfaces;
using BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using IDrawable = BCEngine.Interfaces.IDrawable;

namespace BCEngine.Common
{
  public abstract class DrawableGameObject : IGameObject, IDrawable
  {
    private readonly List<IGameObject> _children;
    private readonly List<RenderPass> _attachedRenderPasses;
    protected DrawableGameObject()
    {
      _children = new List<IGameObject>();
      Children = _children.AsReadOnly();

      _attachedRenderPasses = new List<RenderPass>();
      AttachedRenderPasses = _attachedRenderPasses.AsReadOnly();
    }
    public string Name { get; }
    public IGameObject Parent { get; set; }
    public IReadOnlyList<IGameObject> Children { get; }
    public Transform WorldTransform => this.WorldTransformDefaultImplementation();
    public Transform Transform { get; set; }
    public Vector2 Origin { get; set; }
    public IReadOnlyList<RenderPass> AttachedRenderPasses { get; }
    public Rectangle Bounds { get; set; }
    public bool AddGameObject(IGameObject gameObject)
    {
      return this.AddGameObjectDefaultImplementation(gameObject, _children);
    }
    public bool RemoveGameObject(IGameObject gameObject)
    {
      return this.RemoveGameObjectDefaultImplementation(gameObject, _children);
    }
    public void AddRenderPass(RenderPass renderPass)
    {
      this.AddRenderPassDefaultImplementation(renderPass, _attachedRenderPasses);
    }
    public void RemoveRenderPass(RenderPass renderPass)
    {
      this.RemoveRenderPassDefaultImplementation(renderPass, _attachedRenderPasses);
    }
    public bool Contains(Vector2 Position)
    {
      return this.ContainsDefaultImplementation(Transform, Position);
    }
    public abstract void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch);
  }
}
