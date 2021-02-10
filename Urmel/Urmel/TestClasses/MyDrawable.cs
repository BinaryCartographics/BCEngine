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

    public Texture2D sprite;


    /// <summary>
    /// id like to know why the fuck i cant do this in MyDrawable.cs, but its completely fucking fine in MockIDrawable.cs
    /// </summary>
#pragma warning disable S1450 // Private fields only used as local variables in methods should become local variables
    private readonly List<IGameObject> _children;
#pragma warning restore S1450 // Private fields only used as local variables in methods should become local variables

    public Transform Transform { get; set; }
    public Transform WorldTransform
    {
      get
      {
        return this.WorldTransformDefaultImplementation();
      }
    }
    public IGameObject Parent { get; set; }
    public IReadOnlyList<IGameObject> Children { get; }

    public MyDrawable(string name, Texture2D texture2D)
    {
      sprite = texture2D;
      this.Name = name;
      _children = new List<IGameObject>();
      Children = _children.AsReadOnly();
    }
    public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      //TODO, draw a sprite
      spriteBatch.Draw(sprite, WorldTransform.Position, Color.White);
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
