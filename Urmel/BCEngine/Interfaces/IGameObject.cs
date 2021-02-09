using BCEngine.Math;
using System.Collections.Generic;

namespace BCEngine.Interfaces
{
  public interface IGameObject
  {
    string Name { get; }
    IGameObject Parent { get; set; }
    IReadOnlyList<IGameObject> Children { get; }
    Transform Transform { get; set; }
    Transform WorldTransform { get; }

    bool AddGameObject(IGameObject gameObject);
    bool RemoveGameObject(IGameObject gameObject);
  }
}
