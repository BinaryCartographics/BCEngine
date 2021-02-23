using System;
using System.Collections.Generic;
using System.Text;

namespace BCEngine.TileMapping.Interfaces
{
  public interface ITileMapLayerCollection : ITileMapLayer
  {
    IReadOnlyList<ITileMapLayer> LayerRegions { get; }
  }
}
