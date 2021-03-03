using BCEngine.Math;
using System.Collections.Generic;

namespace BCEngine.Interfaces
{
  public interface IGameObject : ITransformable
  {
    string Name { get; }
    IGameObject Parent { get; set; }
    IReadOnlyList<IGameObject> Children { get; }
    Transform WorldTransform { get; }
    bool AddGameObject(IGameObject gameObject);
    bool RemoveGameObject(IGameObject gameObject);
  }
}
