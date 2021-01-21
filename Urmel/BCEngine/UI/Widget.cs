using BCEngine.Math;
using Microsoft.Xna.Framework;

namespace BCEngine.UI
{
  public abstract partial class Widget
  {
    public Transform transform { get; set; }
    /// <summary>
    /// Bare bones code for now, needs to be worked on, then unit tests
    /// can be added.
    /// </summary>
    public bool Enabled { get; set; }
    public Vector2 Location { get; set; }
    public Vector2 Size { get; set; }
    public Color BackgroundColor { get; set; }
    public Rectangle Bounds => new Rectangle((int)Location.X, (int)Location.Y, (int)Size.X, (int)Size.Y);

    protected Widget()
    {
      Enabled = true;
      BackgroundColor = Color.Transparent;
    }
  }
}
