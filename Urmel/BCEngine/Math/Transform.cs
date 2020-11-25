using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BCEngine.Math
{
  public class Transform
  {
    private Transform _parent;
    public Transform Parent { get; }

    private readonly List<Transform> _children;
    public IReadOnlyList<Transform> Children { get; }

    private Vector2 _position;
    public Vector2 Position { get; set; }

    private Vector2 _scale;
    public Vector2 Scale { get; set; }

    private float _rotation;
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


    public bool AddTransform(Transform transform)
    {
      if (!_children.Contains(transform))
      {
        _children.Add(transform); 
        return true;
      }
      return false;
    }
    public bool RemoveTransform(Transform transform)
    {
      if (_children.Contains(transform))
      {
        _children.Remove(transform);
        return true;
      }
      return false;
    }
    public bool SetParentTransform(Transform transform)
    {
      if (!transform._children.Contains(this))//if this is not a child to the new parent, continue
      {
        if (_parent != null)  //if this transform has a parent, remove self from old parents child-list, otherwise, continue
        {
          _parent.RemoveTransform(this);
        }
        _parent = transform;
        _parent.AddTransform(this);
        return true;
      }
      return false;
    }

    public Transform WorldTransform
    {
      get
      {
        if (_parent == null)
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