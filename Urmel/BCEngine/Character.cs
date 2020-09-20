using BCEngine.Interfaces;

namespace BCEngine
{
  public class Character : IGameObject
  {
    public string Name { get; }

    public Character(string name)
    {
      Name = name;
    }
  }
}
