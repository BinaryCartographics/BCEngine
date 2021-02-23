using System;
using System.Collections.Generic;
using System.Text;

namespace BCEngine.TileMapping.Interfaces
{
  public interface ITileMapRegion
  {
    string Name { get; }
    int Width { get; }
    int Height { get; }
    IReadOnlyList<ITileMapLayer> TileMapLayers { get; }
  }
}
