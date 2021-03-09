using BCEngine.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BCEngine.Math
{
  public struct Transform
  {
    private static Transform _identity = new Transform()
    {
      Position = Vector2.Zero,
      Scale = Vector2.One,
      Rotation = 0f
    };

    public Transform(Vector2 position, Vector2 scale, float rotation)
    {
      Position = position;
      Scale = scale;
      Rotation = rotation;
    }

    public Vector2 Position { get; set; }
    public Vector2 Scale { get; set; }
    public float Rotation { get; set; }
    public float RotationDegrees 
    { 
      get 
      { 
        return MathHelper.ToDegrees(Rotation); 
      }
      set
      {
        Rotation = MathHelper.ToRadians(value);
      }
    }

    public static Transform Identity 
    {
      get { return _identity; }
    }

    public static bool operator ==(Transform a, Transform b)
    {
      bool pos = a.Position == b.Position;
      bool rot = a.Rotation == b.Rotation;
      bool scl = a.Scale == b.Scale;
      return pos && rot && scl;
    }
    public static bool operator !=(Transform a, Transform b)
    {
      return !(a == b);
    }

    public override bool Equals(object obj) =>
    obj is Transform transform
        && transform.Position == Position
        && transform.Rotation == Rotation
        && transform.Scale == Scale;

    public override int GetHashCode() => (Position, Rotation, Scale).GetHashCode();

    /// <summary>
    /// Creates a world space transform from a parent transform and child transform where the child coordinates are localised to the parent
    /// </summary>
    /// <param name="parent">Composition parent</param>
    /// <param name="child">Composition child</param>
    /// <returns>transform result</returns>
    public static Transform Compose(Transform parent, Transform child)
    {
      Transform result = new Transform();
      result.Position = parent.Position + Vector2.Transform(child.Position * parent.Scale, Matrix.CreateRotationZ(parent.Rotation));
      result.Rotation = parent.Rotation + child.Rotation;
      result.Scale = parent.Scale * child.Scale;
      return result;
    }

    /// <summary>
    /// Linear interpolation between two transforms by a float amount, usually from 0 to 1
    /// </summary>
    /// <param name="from">The transform to interpolate from</param>
    /// <param name="to">The transform to interpolate to</param>
    /// <param name="amount">The amount of interpolation</param>
    /// <returns>transform result</returns>
    public static Transform Lerp(Transform from, Transform to, float amount)
    {
      Transform result = new Transform();
      result.Position = Vector2.Lerp(from.Position, to.Position, amount);
      result.Scale = Vector2.Lerp(from.Scale, to.Scale, amount);
      result.Rotation = MathHelper.Lerp(from.Rotation, to.Rotation, amount);
      return result;
    }
    /// <summary>
    /// Transforms a Vector2 from local space to world space. The opposite of Transform.InverseTransformVector
    /// </summary>
    /// <param name="point">local space Vector2</param>
    /// <param name="transform">transform that point is localised to</param>
    /// <returns>localised Vector2 position</returns>
    public static Vector2 TransformVector(Transform transform, Vector2 point)
    {
      Vector2 result = Vector2.Transform(point, Matrix.CreateRotationZ(transform.Rotation));
      result *= transform.Scale;
      result += transform.Position;
      return result;
    }
    /// <summary>
    /// Transforms the vector x, y from world space to local space. The opposite of Transform.TransformVector
    /// if the transform is a child object, world space refers to parent space
    /// </summary>
    /// <param name="point">world space vector2</param>
    /// <param name="transform">transform to localise point into</param>
    /// <returns>world space Vector2</returns>
    public static Vector2 InverseTransformVector(Transform transform, Vector2 point)
    {
      Vector2 result = point - transform.Position;
      result = Vector2.Transform(result, Matrix.CreateRotationZ(-transform.Rotation));
      result /= transform.Scale;
      return result;
    }

    /// <summary>
    /// Gets the relative position from a transform relative to a world space vector2
    /// </summary>
    /// <param name="relativeTo">the reference point to measure the relative distance from</param>
    /// <param name="transform">the transform to measure to</param>
    /// <returns>relative position Vector2</returns>
    public static Vector2 GetRelativePosition(Transform transform, Vector2 relativeTo)
    {
      Transform result = new Transform();
      result.Position = relativeTo * -transform.Position;
      result.Rotation = -transform.Rotation;
      result.Scale = -transform.Scale;
      return result.Position;
    }

    /// <summary>
    /// Sets the local position of a transform to the value of Vector2
    /// </summary>
    /// <param name="transform">Transform to have its position modified</param>
    /// <param name="Position">Position to be set on the transform</param>
    /// <returns>new transform with local position applied</returns>
    public static Transform SetPosition(Transform transform, Vector2 Position)
    {
      transform.Position = Position;
      return transform;
    }

    /// <summary>
    /// Sets the local scale of a transform to the value of Vector2
    /// </summary>
    /// <param name="transform">Transform to have its position modified</param>
    /// <param name="scale">Scale to be set on the transform</param>
    /// <returns>new transform with local scale applied</returns>
    public static Transform SetScale(Transform transform, Vector2 scale)
    {
      transform.Scale = scale;
      return transform;
    }

    /// <summary>
    /// Sets the local rotation of a transform to the value of a float
    /// </summary>
    /// <param name="transform">Transform to have its position modified</param>
    /// <param name="rotation">Rotation to be set on the transform</param>
    /// <returns>new transform with local rotation applied</returns>
    public static Transform SetRotation(Transform transform, float rotation)
    {
      transform.Rotation = rotation;
      return transform;
    }

    /// <summary>
    /// Translates a transform in local space by the value of a vector2
    /// </summary>
    /// <param name="transform">Transform to be translated</param>
    /// <param name="Translation">translation amount</param>
    /// <returns>new transform with local translation applied</returns>
    public static Transform Translate(Transform transform, Vector2 Translation)
    {
      transform.Position += Translation;
      return transform;
    }
    /// <summary>
    /// Translates a transform in local space by the value of a vector2
    /// </summary>
    /// <param name="transform">Transform to be translated</param>
    /// <param name="Translation">translation amount</param>
    /// <returns>new transform with local translation applied</returns>
    public static Transform Rotate(Transform transform, float rotation)
    {
      transform.Rotation += rotation;
      return transform;
    }
  }
}