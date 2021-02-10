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

    /// <summary>
    /// Sets the local position of an IGameObject.Transform to the value of Vector2
    /// </summary>
    /// <param name="Position">Position to be set on the IGameObject.Transform</param>
    /// <returns>true</returns>
    public static bool SetPosition(this IGameObject gameObject, Vector2 position)
    {
      gameObject.Transform = Transform.SetPosition(gameObject.Transform, position);
      return true;
    }

    /// <summary>
    /// Sets the local scale of an IGameObject.Transform to the value of Vector2
    /// </summary>
    /// <param name="scale">Scale to be set on the transform</param>
    /// <returns>true</returns>
    public static bool SetScale(this IGameObject gameObject, Vector2 scale)
    {
      gameObject.Transform = Transform.SetScale(gameObject.Transform, scale);
      return true;
    }

    /// <summary>
    /// Sets the local rotation of an IGameObject.Transform to the value of a float
    /// </summary>
    /// <param name="rotation">Rotation to be set on the transform</param>
    /// <returns>true</returns>
    public static bool SetRotation(this IGameObject gameObject, float rotation)
    {
      gameObject.Transform = Transform.SetRotation(gameObject.Transform, rotation);
      return true;
    }

    /// <summary>
    /// Translates an IGameObject.Transform in local space by the value of a vector2
    /// </summary>
    /// <param name="Translation">translation amount</param>
    /// <returns>true</returns>
    public static bool Translate(this IGameObject gameObject, Vector2 translation)
    {
      gameObject.Transform = Transform.Translate(gameObject.Transform, translation);
      return true;
    }

    /// <summary>
    /// Translates an IGameObject.Transform in local space by the value of a vector2
    /// </summary>
    /// <param name="Translation">translation amount</param>
    /// <returns>true</returns>
    public static bool Rotate(this IGameObject gameObject, float rotation)
    {
      gameObject.Transform = Transform.Rotate(gameObject.Transform, rotation);
      return true;
    }
  }
}
