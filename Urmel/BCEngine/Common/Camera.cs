using BCEngine.Helpers;
using BCEngine.Interfaces;
using BCEngine.Math;
using Microsoft.Xna.Framework;

namespace BCEngine.Common
{
  public class Camera : ITransformable, IBounds
  {
    public Transform Transform { get; set; }
    public Rectangle Bounds { get; set; }
    public Vector2 Origin { get; set; }
    public bool Contains(Vector2 Position)
    {
      return this.ContainsDefaultImplementation(Transform, Position);
    }
    public Matrix TransformMatrix
    {
      get
      {
          return Matrix.CreateTranslation(-Transform.Position.X,
             -Transform.Position.Y, 0) *
             Matrix.CreateRotationZ(-Transform.Rotation) *
             Matrix.CreateScale(new Vector3(1 / Transform.Scale.X, 1 / Transform.Scale.Y, 1)) *
             Matrix.CreateTranslation(new Vector3(Origin, 0));
      }
    }
  }
}
