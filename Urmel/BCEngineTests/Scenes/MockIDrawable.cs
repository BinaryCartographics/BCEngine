using BCEngine.Interfaces;
using BCEngine.Math;

namespace BCEngineTests.Scenes
{
  internal class MockIDrawable : IDrawable
  {
    public string Name { get; }
    public IGameObject Parent { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    string IGameObject.Name => throw new System.NotImplementedException();

    IGameObject IGameObject.Parent { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }
    Transform IGameObject.Transform { get => throw new System.NotImplementedException(); set => throw new System.NotImplementedException(); }

    Transform IGameObject.WorldTransform => throw new System.NotImplementedException();

    public MockIDrawable(string name)
    {
      Name = name;
    }

    public void Draw()
    {
      //Method left intentionally empty
    }

    public bool AddGameObject(IGameObject gameObject)
    {
      throw new System.NotImplementedException();
    }

    public bool RemoveGameObject(IGameObject gameObject)
    {
      throw new System.NotImplementedException();
    }

    void IDrawable.Draw()
    {
      throw new System.NotImplementedException();
    }

    bool IGameObject.AddGameObject(IGameObject gameObject)
    {
      throw new System.NotImplementedException();
    }

    bool IGameObject.RemoveGameObject(IGameObject gameObject)
    {
      throw new System.NotImplementedException();
    }
  }
}
