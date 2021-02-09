using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngine.Helpers
{
  public static class Shapes
  {
    /// <summary>
    /// creates a 1x1 pixel image of a desired colour, if no color is passed in, it returns white
    /// </summary>
    /// <param name="color">nullable, used to set color of texture</param>
    /// <param name="graphicsDevice"> the graphics device used to perform the operation</param>
    /// <returns>1x1 texture 2d</returns>
    public static Texture2D CreateColorPixel(Color? color, GraphicsDevice graphicsDevice)
    {
      var rect = new Texture2D(graphicsDevice, 1, 1);
      rect.SetData(new[] 
      { 
        color.HasValue ? color.Value : Color.White 
      });
      return rect;
    }
  }
}
