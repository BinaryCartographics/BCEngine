using BCEngine.Interfaces;
using BCEngine.Math;
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

    private readonly List<IGameObject> _children;

    public MockIGameObject(string name)
    {
      _children = new List<IGameObject>();
      Name = name;
    }

    public bool AddGameObject(IGameObject gameObject)
    {
      if (!_children.Contains(gameObject))
      {
        if (gameObject.Parent != null)
        {
          gameObject.Parent.RemoveGameObject(gameObject);
        }
        gameObject.Parent = this;
        _children.Add(gameObject);
        return true;
      }
      return false;
    }
    public bool RemoveGameObject(IGameObject gameObject)
    {
      if (_children.Contains(gameObject))
      {
        gameObject.Parent = null;
        _children.Remove(gameObject);
        return true;
      }
      return false;
    }
  }
}
