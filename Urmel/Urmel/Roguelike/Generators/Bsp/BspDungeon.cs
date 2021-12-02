using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using Urmel.Roguelike.Tiles;

namespace Urmel.Roguelike.Generators.Bsp
{
  class BspDungeon
  {
    public int Width { get; }
    public int Height { get; }

    readonly BspNode RootBspNode;

    public Tile[,] MapTiles { get; set; }

    public BspDungeon(int width, int height, int seed)
    {
      Width = width;
      Height = height;
      Random random = new Random(seed);
      RootBspNode = new BspNode(new Rectangle(0, 0, Width, Height), random);

      RootBspNode.Split();


      MapTiles = new Tile[Width, Height];
      for (int y = 0; y < Height; y++)
      {
        for (int x = 0; x < Width; x++)
        {
          MapTiles[x, y] = new Tile();
        }
      }
      CreateMapRooms();
    }

    /// <summary>
    /// just some general purpose data stuff, ignore the tiletypes and whatnot as its temporary
    /// </summary>
    public void CreateMapRooms()
    {
      List<Rectangle> rooms = new List<Rectangle>();
      RootBspNode.GetRooms(rooms);
      foreach (Rectangle r in rooms)
      {
        for (int y = r.Top; y < r.Bottom; y++)
        {
          for (int x = r.Left; x < r.Right; x++)
          {
            MapTiles[x, y].SetData(TileType.Traversable, Color.White, Color.White, '♥');
          }
        }
      }
    }
  }
}
