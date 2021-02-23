using System;
using System.Collections.Generic;
using System.Text;

namespace BCEngine.TileMapping.Interfaces
{
  public interface IMapTile
  {
    TileSet TileSet { get;}
    int TileX { get; }
    int TileY { get; }
  }
}
