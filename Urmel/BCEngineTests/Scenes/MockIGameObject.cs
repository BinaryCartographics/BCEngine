using BCEngine.Interfaces;
using BCEngine.Math;
using BCEngine.Helpers;
using System.Collections.Generic;

namespace BCEngineTests.Scenes
{
  public class MockIGameObject : IGameObject
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

    public MockIGameObject(string name)
    {
      Children = new List<IGameObject>();
      Name = name;
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
