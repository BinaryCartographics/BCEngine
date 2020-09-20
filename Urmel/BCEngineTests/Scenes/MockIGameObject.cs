using BCEngine.Interfaces;

namespace BCEngineTests.Scenes
{
  public class MockIGameObject : IGameObject
  {
    public string Name { get; }

    public MockIGameObject(string name)
    {
      Name = name;
    }
  }
}
