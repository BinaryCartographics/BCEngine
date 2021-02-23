using BCEngine.TileMapping.Interfaces;
using System.Collections.Generic;

namespace Urmel.TestClasses
{
  public class TestRegion : ITileMapRegion
  {
    private readonly List<ITileMapLayer> _tileMapLayers;
    public TestRegion(string Name, int Width, int Height)
    {
      this.Name = Name;
      this.Width = Width;
      this.Height = Height;
      _tileMapLayers = new List<ITileMapLayer>();
      TileMapLayers = _tileMapLayers.AsReadOnly();

    }
    public string Name { get; }
    public int Width { get; }
    public int Height { get; }
    public IReadOnlyList<ITileMapLayer> TileMapLayers { get; }
  }
}
