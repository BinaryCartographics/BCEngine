using BCEngine.Helpers;
using BCEngine.Interfaces;
using BCEngine.Math;
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
        if (Parent == null)
        {
          return this.Transform;
        }
        return Transform.Compose(Parent.Transform, this.Transform);
      }
    }
    public IGameObject Parent { get; set; }
    public IList<IGameObject> Children { get; }

    public MockIDrawable(string name)
    {
      Name = name;
    }
    public void Draw()
    {
      throw new System.NotImplementedException();
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
