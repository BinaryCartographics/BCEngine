using Microsoft.Xna.Framework;
using BCEngine.Common;
using Microsoft.Xna.Framework.Graphics;
using BCEngine.Helpers;
using BCEngine.Math;

namespace BCEngine.UI.Text
{
  public class CharTile : DrawableGameObject
  {
    private TextFont Font { get; }
    new private Widget Parent { get; }
    new public Transform WorldTransform { get
      {
        return Transform.Compose(Parent.Transform, Transform);
      }
    }
    private int CharWidth { get; }
    private int CharHeight { get; }
    public CharTile(TextFont font, Widget parent)
    {
      Parent = parent;

      Font = font;
      CharWidth = font.CharWidth;
      CharHeight = font.CharHeight;
      this.SetScale(Vector2.One);

      this.Char = ' ';
      UpdateBounds();
    }
    public char Char { get; private set; }
    public Color ForeColor { get; private set; }
    public Color BackColor { get; private set; }

    public void Clear()
    {
      ForeColor = Color.Transparent;
      BackColor = Color.Transparent;
      this.Char = ' ';
      UpdateBounds();
    }
    public void SetData(char Char, Color foreColor, Color backColor)
    {
      this.ForeColor = ForeColor;
      this.BackColor = BackColor;
      this.Char = Char;
      UpdateBounds();
    }

    private void UpdateBounds()
    {
      Point Coord = Font.fontFormat.GetTextureCoordinate(Char);
      int X = Coord.X * CharWidth;
      int Y = Coord.Y * CharHeight;
      Bounds = new Rectangle(X, Y, CharWidth, CharHeight);
    }

    public override void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      Transform T = Transform.Compose(Parent.Transform, Transform);
      this.DrawDefaultImplementation(T, Bounds, Font.FontSheet, spriteBatch, 1f);
    }
  }
}
