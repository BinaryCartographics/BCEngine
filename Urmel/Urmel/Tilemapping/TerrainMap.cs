using BCEngine.Common;
using BCEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Urmel.Tilemapping
{
  public class TerrainMap : DrawableGameObject
  {
    Texture2D col;

    private TerrainTile[,] tilemap { get; }
    public int Width { get; }
    public int Height { get; }
    public TerrainMap(int width, int height)
    {
      Width = width;
      Height = height;
      tilemap = new TerrainTile[width, height];
      CreateEmptyMap();

    }
    public TerrainTile this[int x, int y]
    {
      get { return tilemap[x, y]; }
      set { tilemap[x, y] = value; }
    }

    private void CreateEmptyMap()
    {
      for (int x = 0; x < Width; x++)
      {
        for (int y = 0; y < Height; y++)
        {
          tilemap[x, y] = new TerrainTile();
        }
      }
    }

    public override void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      col = TextureGenerator.CreateColorPixel(Color.White, graphicsDevice);
      for (int x = 0; x < Width; x++)
      {
        for (int y = 0; y < Height; y++)
        {
          spriteBatch.Draw(col, new Rectangle(x*16, y*16, 16, 16), col.Bounds, tilemap[x, y].TerrainType == TerrainType.Grass ? Color.Green : Color.Yellow, 0f, Vector2.Zero, SpriteEffects.None, 0.5f);
        }
      }
    }
  }
}
