using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BCEngine.Math
{
  public class Transform
  {
    ///private Transform _parent;
    public Transform Parent { get; private set; }

    private readonly List<Transform> _children;
    public IReadOnlyList<Transform> Children { get; }
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
    public Transform() 
    {
      _children = new List<Transform>();
      Children = _children.AsReadOnly();
    }

    /// <summary>
    /// 
    /// 
    /// add to self
    /// remove from self
    /// set parent  > parent.add to self
    /// remove parent > parent.remove from self
    /// 
    /// 
    /// </summary>

    public bool AddTransform(Transform transform)
    {
      if (!_children.Contains(transform))
      {
        if (transform.Parent != null)
        {
          transform.Parent._children.Remove(transform);
        }
        transform.Parent = this;
        _children.Add(transform);
        return true;  
      }
      return false;
    }

    public bool RemoveTransform(Transform transform)
    {
      if (_children.Contains(transform))
      {
        transform.Parent = null;
        _children.Remove(transform);
        return true;
      }
      return false;
    }

    public List<Transform> GetChildren()
    {
      return _children;
    }

    public Transform WorldTransform
    {
      get
      {
        if (Parent == null)
        {
          return this;
        }
        return Transform.Compose(Parent, this);
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
      Vector2 result = point - WorldTransform.Position;
      result = Vector2.Transform(result, Matrix.CreateRotationZ(-WorldTransform.Rotation));
      result /= WorldTransform.Scale;
      return result;
    }

    public Vector2 GetRelativePosition(Vector2 WorldPosition)
    {
      Transform result = new Transform();
      result.Position = WorldPosition * -WorldTransform.Position;
      result.Rotation = -WorldTransform.Rotation;
      result.Scale = -WorldTransform.Scale;
      return result.Position;
    }
  }
}