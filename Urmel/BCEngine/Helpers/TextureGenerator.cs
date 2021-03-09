using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngine.Helpers
{
  public static class TextureGenerator
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

#pragma warning disable S2368 // Public methods should not have multidimensional array parameters
    //warning disabled as this method is entirely for developing and testing other features.

    /// <summary>
    /// creates a greyscale image from a 2d array of float values, for example, perlin noise
    /// </summary>
    /// <param name="floatArray">the 2d array of floats to sample, this is also used to create the image dimensions</param>
    /// <param name="graphicsDevice">the graphics device used to perform the operation</param>
    /// <returns>greyscale image representing float values in a 2d array</returns>
    public static Texture2D CreateFloatArrayTexture(float[,] floatArray, GraphicsDevice graphicsDevice)
    {
      int width = floatArray.GetLength(0);
      int height = floatArray.GetLength(1);

      //creates a new Texture2D with the same width and height as the float array
      var floatArrayTexture = new Texture2D(graphicsDevice, width, height);
      Color[] oneDimData = new Color[width * height];

      int oneDimIndex = 0;
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          float brightness = floatArray[x, y];
          oneDimData[oneDimIndex++] = new Color(brightness, brightness, brightness, 1f);
        }
      }

      floatArrayTexture.SetData(oneDimData);
      return floatArrayTexture;
    }
#pragma warning restore S2368 // Public methods should not have multidimensional array parameters
  }
}
