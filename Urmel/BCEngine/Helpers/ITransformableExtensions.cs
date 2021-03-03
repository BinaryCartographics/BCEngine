using BCEngine.Interfaces;
using BCEngine.Math;
using Microsoft.Xna.Framework;

namespace BCEngine.Helpers
{
  public static class ITransformableExtensions
  {
    /// <summary>
    /// Sets the local position of an IGameObject.Transform to the value of Vector2
    /// </summary>
    /// <param name="Position">Position to be set on the IGameObject.Transform</param>
    /// <returns>true</returns>
    public static bool SetPosition(this ITransformable transformable, Vector2 position)
    {
      transformable.Transform = Transform.SetPosition(transformable.Transform, position);
      return true;
    }

    /// <summary>
    /// Sets the local scale of an IGameObject.Transform to the value of Vector2
    /// </summary>
    /// <param name="scale">Scale to be set on the transform</param>
    /// <returns>true</returns>
    public static bool SetScale(this ITransformable transformable, Vector2 scale)
    {
      transformable.Transform = Transform.SetScale(transformable.Transform, scale);
      return true;
    }

    /// <summary>
    /// Sets the local rotation of an IGameObject.Transform to the value of a float
    /// </summary>
    /// <param name="rotation">Rotation to be set on the transform</param>
    /// <returns>true</returns>
    public static bool SetRotation(this ITransformable transformable, float rotation)
    {
      transformable.Transform = Transform.SetRotation(transformable.Transform, rotation);
      return true;
    }

    /// <summary>
    /// Translates an IGameObject.Transform in local space by the value of a vector2
    /// </summary>
    /// <param name="Translation">translation amount</param>
    /// <returns>true</returns>
    public static bool Translate(this ITransformable transformable, Vector2 translation)
    {
      transformable.Transform = Transform.Translate(transformable.Transform, translation);
      return true;
    }

    /// <summary>
    /// Translates an IGameObject.Transform in local space by the value of a vector2
    /// </summary>
    /// <param name="Translation">translation amount</param>
    /// <returns>true</returns>
    public static bool Rotate(this ITransformable transformable, float rotation)
    {
      transformable.Transform = Transform.Rotate(transformable.Transform, rotation);
      return true;
    }
  }
}
