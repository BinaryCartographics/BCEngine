
using Microsoft.Xna.Framework;

namespace BCEngine.Interfaces
{
  public interface IBounds
  {
    Rectangle Bounds { get; set; }
    bool Contains(Vector2 Position);
  }
}
