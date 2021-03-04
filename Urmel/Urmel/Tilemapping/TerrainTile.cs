
namespace Urmel.Tilemapping
{
  public class TerrainTile
  {
    public TerrainType TerrainType { get; }
    public TerrainTile(TerrainType terrainType)
    {
      TerrainType = terrainType;
    }
    public TerrainTile()
    {
      TerrainType = TerrainType.Water;
    }
  }
}
