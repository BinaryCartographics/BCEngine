using BCEngine.Graphics;
using BCEngine.Helpers;
using BCEngine.Interfaces;
using BCEngine.Math;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Urmel.TestClasses
{
  class MyDrawable : BCEngine.Interfaces.IDrawable
  {
    public string Name { get; }
    private readonly List<IGameObject> _children;
    private readonly List<RenderPass> _attachedRenderPasses;
    public Transform Transform { get; set; } = Transform.Identity;
    public Transform WorldTransform
    {
      get
      {
        return this.WorldTransformDefaultImplementation();
      }
    }
    public IGameObject Parent { get; set; }
    public IReadOnlyList<IGameObject> Children { get; }
    public IReadOnlyList<RenderPass> AttachedRenderPasses { get; }
    public Texture2D Texture { get; set; }
    public Vector2 Origin { get; set; }
    public Rectangle Bounds { get; set; }
    public Rectangle SourceRectangle { get; set; }
    public Color Color { get; set; } = Color.White;
    public SpriteEffects SpriteEffects { get; set; } = SpriteEffects.None;
    public float LayerDepth { get; set; } = 0f;
    public MyDrawable(string name, Texture2D texture2D)
    {
      Texture = texture2D;
      Name = name;
      _children = new List<IGameObject>();
      Children = _children.AsReadOnly();

      _attachedRenderPasses = new List<RenderPass>();
      AttachedRenderPasses = _attachedRenderPasses.AsReadOnly();

      SourceRectangle = Texture.Bounds;
      Bounds = Texture.Bounds;
      Origin = new Vector2(Bounds.Width / 2, Bounds.Height / 2);
    }
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
    public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      this.DrawDefaultImplementation(Texture, spriteBatch, LayerDepth);
    }

    public bool Contains(Vector2 Position)
    {
      return this.ContainsDefaultImplementation(Transform, Position);
    }
  }
}
