using System;
using System.Collections.Generic;
using System.Text;

namespace Urmel.Tilemapping
{
  public interface IMapGenerator
  {
    void GenerateMap(int Width, int Height, int seed);
  }
}
