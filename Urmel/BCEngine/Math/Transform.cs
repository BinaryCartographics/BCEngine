﻿using BCEngine.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BCEngine.Math
{
  public struct Transform
  {
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
  }
}