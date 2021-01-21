using BCEngine.Interfaces;
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
    public static Transform Compose(Transform parent, Transform child)
    {
      Transform result = new Transform();
      result.Position = parent.Position + Vector2.Transform(child.Position * parent.Scale, Matrix.CreateRotationZ(parent.Rotation));
      result.Rotation = parent.Rotation + child.Rotation;
      result.Scale = parent.Scale * child.Scale;
      return result;
    }

    public static void Lerp(ref Transform from, ref Transform to, float amount, ref Transform result)
    {
      result.Position = Vector2.Lerp(from.Position, to.Position, amount);
      result.Scale = Vector2.Lerp(from.Scale, to.Scale, amount);
      result.Rotation = MathHelper.Lerp(from.Rotation, to.Rotation, amount);
    }

    public Vector2 TransformVector(Vector2 point)
    {
      Vector2 result = Vector2.Transform(point, Matrix.CreateRotationZ(Rotation));
      result *= Scale;
      result += Position;
      return result;
    }

    public Vector2 InverseTransformVector(Vector2 point)
    {
      Vector2 result = point - Position;
      result = Vector2.Transform(result, Matrix.CreateRotationZ(-Rotation));
      result /= Scale;
      return result;
    }

    public Vector2 GetRelativePosition(Vector2 RelativeTo)
    {
      Transform result = new Transform();
      result.Position = RelativeTo * -Position;
      result.Rotation = -Rotation;
      result.Scale = -Scale;
      return result.Position;
    }
  }
}