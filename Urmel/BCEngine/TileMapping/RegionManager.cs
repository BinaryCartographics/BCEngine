using BCEngine.TileMapping.Interfaces;
using System.Collections.Generic;

namespace BCEngine.TileMapping
{
  public class RegionManager
  {
    private readonly List<ITileMapRegion> _loadedRegions;
    public RegionManager()
    {
      _loadedRegions = new List<ITileMapRegion>();
      LoadedRegions = _loadedRegions.AsReadOnly();
    }
    public IReadOnlyList<ITileMapRegion> LoadedRegions { get; }
    public bool LoadRegion(ITileMapRegion region)
    {
      if (!_loadedRegions.Contains(region))
      {
        _loadedRegions.Add(region);
        return true;
      }
      return false;
    }
    public bool UnloadRegion(ITileMapRegion region)
    {
      if (_loadedRegions.Contains(region))
      {
        _loadedRegions.Remove(region);
        return true;
      }
      return false;
    }
  }
}

