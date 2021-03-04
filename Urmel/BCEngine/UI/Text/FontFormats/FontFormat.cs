using BCEngine.Helpers;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BCEngine.UI.Text.FontFormats
{
  public abstract class FontFormat
  {
    /// <summary>
    /// The number of characters horizontally in a font atlas
    /// </summary>
    public int Width { get; protected set; }
    /// <summary>
    /// The number of characters vertically in a font atlas
    /// </summary>
    public int Height { get; protected set; }

    public abstract List<char> CodepageChars { get; }

    /// <summary>
    /// Initializes a font format for use with a png font
    /// </summary>
    /// <param name="Width">The number of characters horizontally in a font atlas</param>
    /// <param name="Height">The number of characters vertically in a font atlas</param>
    protected FontFormat()
    {
      for (int i = 0; i < 256; i++)
      {
        CharDictionary.Add(CodepageChars[i], i);
      }
    }

    private readonly TwoWayDictionary<char, int> CharDictionary = new TwoWayDictionary<char, int>();

    /// <summary>
    /// gets the index of a char from the Codepage
    /// </summary>
    /// <param name="character">Char to find the index of</param>
    /// <returns>index of a char in the current codepage</returns>
    public int GetIndex(char character)
    {
      return CharDictionary[character];
    }

    /// <summary>
    /// gets a char from the codepage by index
    /// </summary>
    /// <param name="index">the index to find a char with</param>
    /// <returns>the char assigned to the passed in index</returns>
    public char GetChar(int index)
    {
      return CharDictionary[index];
    }

    /// <summary>
    /// gets the texture coordinate of a char
    /// </summary>
    /// <param name="character">the char to get the coordinate of</param>
    /// <returns>Point to get a char from</returns>
    public Point GetTextureCoordinate(char character)
    {
      int charVal = CharDictionary[character];
      return new Point(charVal % Width, charVal / Height);
    }
  }
}
