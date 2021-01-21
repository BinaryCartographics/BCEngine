using BCEngine.Math;

namespace BCEngine.Interfaces
{
  public interface IGameObject
  {
    string Name { get; }
    IGameObject Parent { get; set; }
    Transform Transform { get; set; }
    Transform WorldTransform { get; }

    bool AddGameObject(IGameObject gameObject);
    bool RemoveGameObject(IGameObject gameObject);
  }
}
