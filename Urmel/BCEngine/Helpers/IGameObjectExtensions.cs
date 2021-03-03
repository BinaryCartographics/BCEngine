using BCEngine.Interfaces;
using BCEngine.Math;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BCEngine.Helpers
{
  public static class IGameObjectExtensions
  {
    public static bool AddGameObjectDefaultImplementation(this IGameObject Parent, IGameObject gameObject, IList<IGameObject> children)
    {
      if (!children.Contains(gameObject))
      {
        if (gameObject.Parent != null)
        {
          gameObject.Parent.RemoveGameObject(gameObject);
        }
        gameObject.Parent = Parent;
        children.Add(Parent);
        return true;
      }
      return false;
    }

    public static bool RemoveGameObjectDefaultImplementation(this IGameObject Parent, IGameObject gameObject, IList<IGameObject> children)
    {
      if (children.Contains(gameObject))
      {

        children.Remove(gameObject);
        return true;
      }
      return false;
    }

    public static Transform WorldTransformDefaultImplementation(this IGameObject gameObject)
    {
      if (gameObject.Parent == null)
      {
        return gameObject.Transform;
      }
      return Transform.Compose(gameObject.Parent.Transform, gameObject.Transform);
    }
  }
}
