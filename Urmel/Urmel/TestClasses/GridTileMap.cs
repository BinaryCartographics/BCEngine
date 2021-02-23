using BCEngine.TileMapping;
using BCEngine.TileMapping.Interfaces;
using System.Collections.Generic;

namespace Urmel.TestClasses
{
  class GridTileMap : ITileMap
  {
    public GridTileMap(string Name)
    {
      this.Name = Name;
    }
    public string Name { get; }
    public RegionManager RegionManager { get; }
    public LayerVisibilityManager LayerManager { get; }

    public bool LoadRegion(ITileMapRegion region)
    {
      if (RegionManager.LoadRegion(region))
      {
        LayerManager.AddRegionToLayers(region);
        return true;
      }
      return false;
    }

    public bool UnloadRegion(ITileMapRegion region)
    {
      if (RegionManager.UnloadRegion(region))
      {
        LayerManager.RemoveRegionFromLayers(region);
        return true;
      }
      return false;
    }
  }
}
