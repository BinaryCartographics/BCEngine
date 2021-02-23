namespace BCEngine.TileMapping.Interfaces
{
  public interface ITileMapLayer
  {
    string Name { get; }
    bool IsVisible { get; set; }
  }
}