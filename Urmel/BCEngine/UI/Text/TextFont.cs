using BCEngine.UI.Text.FontFormats;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;


namespace BCEngine.UI.Text
{
  public class TextFont
  {
    public Texture2D FontSheet { get; }
    public FontFormat fontFormat { get; }
    public string Name { get; }

    public int CharWidth { get; }
    public int CharHeight { get; }
    public Point CharSize { get; }

    public TextFont(string FontSheetName, ContentManager ContentManager, int CharWidth, int CharHeight, FontFormat fontFormat)
    {
      FontSheet = ContentManager.Load<Texture2D>(FontSheetName);
      this.CharWidth = CharWidth;
      this.CharHeight = CharHeight;
      this.fontFormat = fontFormat;
      Name = FontSheetName;

      //Font Char sizes are manually defined because font formats that arent Codepage 437 may have textures with more than 16 chars per row/column
      CharSize = new Point(CharWidth, CharHeight);
    }
  }
}
