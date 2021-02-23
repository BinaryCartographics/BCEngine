using BCEngine.TileMapping.Interfaces;
using System.Collections.Generic;

namespace BCEngine.TileMapping
{
  public class LayerVisibilityManager
  {
    private readonly List<VisibleLayerRegionCollection> _visibleLayers;

    public LayerVisibilityManager()
    {
      _visibleLayers = new List<VisibleLayerRegionCollection>();
      VisibleLayers = _visibleLayers.AsReadOnly();
    }
    public IReadOnlyList<VisibleLayerRegionCollection> VisibleLayers { get; }

    public bool AddRegionToLayers(ITileMapRegion region)
    {
      foreach (ITileMapLayer layer in region.TileMapLayers)
      {
        if (layer.IsVisible)
        {
          int index = _visibleLayers.FindIndex(item => item.Name == layer.Name);
          if (index >= 0)
          {
            _visibleLayers[index].AddLayerRegion(layer);
          }
          else
          {
            index = _visibleLayers.Count;
            _visibleLayers.Add(new VisibleLayerRegionCollection(layer.Name));
            _visibleLayers[index].AddLayerRegion(layer);
          }
        }
      }
      return true;
    }
    public bool RemoveRegionFromLayers(ITileMapRegion region)
    {
      foreach (ITileMapLayer layer in region.TileMapLayers)
      {
        if (layer.IsVisible)
        {
          int index = _visibleLayers.FindIndex(item => item.Name == layer.Name);
          if (index >= 0)
          {
            _visibleLayers[index].RemoveLayerRegion(layer);
            if (_visibleLayers[index].LayerRegions.Count == 0)
            {
              _visibleLayers.RemoveAt(index);
            }
          }
          else
          {
            //something went wrong if you are removing a layer region from a collection that does not contain it.
            return false;
          }
        }
      }
      return true;
    }
  }
}
