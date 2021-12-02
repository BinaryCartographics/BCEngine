using Microsoft.Xna.Framework;

namespace Urmel.Roguelike.Tiles
{
  public class Tile
  {
    public TileType Type { get; private set; }
    public Color BackgroundColor { get; private set; }
    public Color ForegroundColor { get; private set; }
    public char Character { get; private set; }

    public Tile()
    {
      SetData(TileType.Void, Color.Black, Color.Black, ' ');
    }

    public void SetData(TileType type, Color bg, Color fg, char character)
    {
      Type = type;
      BackgroundColor = bg;
      ForegroundColor = fg;
      Character = character;
    }
  }
}
