using BCEngine.Interfaces;
using BCEngine.Math;
using Microsoft.Xna.Framework;

namespace BCEngine.Helpers
{
  public static class IBoundsExtensions
  {
    /// <summary>
    /// Default implementation for "Contains", checks whether an object with bounds contains a point
    /// </summary>
    /// <param name="Bounds">The object that has bounds</param>
    /// <param name="transform">The transform of the bounds object</param>
    /// <param name="Point">The point that is being checked</param>
    /// <returns>True if Bounds contains Point, False if this is not the case</returns>
    public static bool ContainsDefaultImplementation(this IBounds Bounds, Transform transform, Vector2 Point)
    {
      Vector2 WorldToLocal = Transform.InverseTransformVector(transform, Point);
      return Bounds.Bounds.Contains(WorldToLocal);
    }
  }
}
