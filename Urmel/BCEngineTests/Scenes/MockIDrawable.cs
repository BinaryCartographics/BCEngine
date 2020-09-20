using BCEngine.Interfaces;

namespace BCEngineTests.Scenes
{
  internal class MockIDrawable : IDrawable
  {
    public string Name { get; }

    public MockIDrawable(string name)
    {
      Name = name;
    }

    public void Draw()
    {
      //Method left intentionally empty
    }
  }
}
