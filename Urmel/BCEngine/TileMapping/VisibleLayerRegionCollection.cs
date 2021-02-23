using BCEngine.TileMapping.Interfaces;
using System.Collections.Generic;

namespace BCEngine.TileMapping
{
  public class VisibleLayerRegionCollection : ITileMapLayerCollection
  {
    private readonly List<ITileMapLayer> _layerRegions;
    public VisibleLayerRegionCollection(string Name)
    {
      this.Name = Name;
      _layerRegions = new List<ITileMapLayer>();
      LayerRegions = _layerRegions.AsReadOnly();
    }
    public IReadOnlyList<ITileMapLayer> LayerRegions { get; }
    public string Name { get; }
    public bool IsVisible { get; set; }

    public bool AddLayerRegion(ITileMapLayer layer)
    {
      if (!_layerRegions.Contains(layer))
      {
        _layerRegions.Add(layer);
        return true;
      }
      return false;
    }
    public bool RemoveLayerRegion(ITileMapLayer layer)
    {
      if (_layerRegions.Contains(layer))
      {
        _layerRegions.Remove(layer);
        return true;
      }
      return false;
    }
  }
}
