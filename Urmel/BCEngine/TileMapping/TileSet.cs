using Microsoft.Xna.Framework.Graphics;

namespace BCEngine.TileMapping
{
  public struct TileSet
  {
    Texture2D Atlas { get; }
    int TileWidth { get; }
    int TileHeight { get; }
    public TileSet(Texture2D TileSetAtlas, int TileWidth, int TileHeight)
    {
      Atlas = TileSetAtlas;
      this.TileWidth = TileWidth;
      this.TileHeight = TileHeight;
    }
  }
}
