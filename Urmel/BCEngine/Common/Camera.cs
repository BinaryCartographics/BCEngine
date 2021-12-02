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

    public CameraMode CameraMode { get; set; }
    private CameraMode TrueCameraMode { get; set; }
    public Camera()
    {
      this.SetScale(Vector2.One);
    }
    public bool Contains(Vector2 Position)
    {
      return this.ContainsDefaultImplementation(Transform, Position);
    }
    public Matrix TransformMatrix
    {
      get
      {
        if (CameraMode == CameraMode.Default && Transform.Scale == Vector2.One)
        {
          TrueCameraMode = CameraMode.PixelPerfect;
        }
        else
        {
          TrueCameraMode = CameraMode;
        }


        if (TrueCameraMode == CameraMode.PixelPerfect)
        { 
          int posX = (int)Transform.Position.X;
          int posY = (int)Transform.Position.Y;
          return Matrix.CreateTranslation(-posX,
            -posY, 0) *
            Matrix.CreateRotationZ(-Transform.Rotation) *
            Matrix.CreateScale(new Vector3(1 / Transform.Scale.X, 1 / Transform.Scale.Y, 1)) *
            Matrix.CreateTranslation(new Vector3(Origin, 0));
        }
          return Matrix.CreateTranslation(-Transform.Position.X,
             -Transform.Position.Y, 0) *
             Matrix.CreateRotationZ(-Transform.Rotation) *
             Matrix.CreateScale(new Vector3(1 / Transform.Scale.X, 1 / Transform.Scale.Y, 1)) *
             Matrix.CreateTranslation(new Vector3(Origin, 0));
      }
    }
  }
}
