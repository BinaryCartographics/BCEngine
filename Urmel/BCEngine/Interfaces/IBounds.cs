
using Microsoft.Xna.Framework;

namespace BCEngine.Interfaces
{
  public interface IBounds
  {
    Rectangle Bounds { get; set; }
    Vector2 Origin { get; set; }
    bool Contains(Vector2 Position);
  }
}
