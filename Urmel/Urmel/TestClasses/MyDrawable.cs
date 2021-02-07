using BCEngine.Graphics;
using BCEngine.Helpers;
using BCEngine.Interfaces;
using BCEngine.Math;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace Urmel.TestClasses
{
  class MyDrawable : IDrawable
  {
    public string Name { get; }

    public Sprite sprite;
    public Transform Transform { get; set; }
    public Transform WorldTransform
    {
      get
      {
        return this.WorldTransformDefaultImplementation();
      }
    }
    public IGameObject Parent { get; set; }
    public IList<IGameObject> Children { get; }

    public MyDrawable(string name)
    {
      Name = name;
    }
    public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      //TODO, draw a sprite
      spriteBatch.Begin();
      spriteBatch.Draw(sprite.texture, sprite.position, sprite.sourceRectangle, sprite.color, sprite.rotation, sprite.origin, sprite.scale, SpriteEffects.None, 0f);
      spriteBatch.End();
    }
    public bool AddGameObject(IGameObject gameObject)
    {
      return this.AddGameObjectDefaultImplementation(gameObject);
    }

    public bool RemoveGameObject(IGameObject gameObject)
    {
      return this.RemoveGameObjectDefaultImplementation(gameObject);
    }
  }
}
