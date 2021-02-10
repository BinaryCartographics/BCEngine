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
        return this.WorldTransformDefaultImplementation();
      }
    }
    public IGameObject Parent { get; set; }

    private readonly List<IGameObject> _children;
    public IReadOnlyList<IGameObject> Children { get; }

    public MockIGameObject(string name)
    {
      Name = name;
      _children = new List<IGameObject>();
      Children = _children.AsReadOnly();
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
