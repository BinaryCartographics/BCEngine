using System;
using System.Collections.Generic;
using System.Text;

namespace BCEngine.TileMapping.Interfaces
{
  public interface ITileMap
  {
    string Name { get; }
    RegionManager RegionManager { get; }
    LayerVisibilityManager LayerManager { get; }
    bool LoadRegion(ITileMapRegion region);
    bool UnloadRegion(ITileMapRegion region);
  }
}
