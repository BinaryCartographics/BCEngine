using BCEngine.Helpers;
using BCEngine.Interfaces;
using BCEngine.Math;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BCEngineTests.Scenes
{
  internal class MockIDrawable : IDrawable
  {
    public string Name { get; }

    public Transform Transform { get; set; }
    public Transform WorldTransform
    {
      get
      {
        return this.WorldTransformDefaultImplementation();
      }
    }
    public IGameObject Parent { get; set; }

    private readonly List<IGameObject> _children;
    public IReadOnlyList<IGameObject> Children { get; }
    public Microsoft.Xna.Framework.Vector2 Origin { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Microsoft.Xna.Framework.Rectangle Bounds { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Microsoft.Xna.Framework.Rectangle SourceRectangle { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public Microsoft.Xna.Framework.Color Color { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public SpriteEffects SpriteEffects { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    public float LayerDepth { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    public MockIDrawable(string name)
    {
      Name = name;
      _children = new List<IGameObject>();
      Children = _children.AsReadOnly();
    }
    public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      throw new System.NotImplementedException();
    }
    public bool AddGameObject(IGameObject gameObject)
    {
      return this.AddGameObjectDefaultImplementation(gameObject, _children);
    }

    public bool RemoveGameObject(IGameObject gameObject)
    {
      return this.RemoveGameObjectDefaultImplementation(gameObject, _children);
    }
  }
}
