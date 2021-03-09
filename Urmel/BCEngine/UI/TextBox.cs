using BCEngine.Math;
using BCEngine.UI.Text;
using BCEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngine.UI
{
  public class TextBox : Widget
  {
    private CharTile[,] Characters { get; }
    private Transform OldTransform { get; set; }
    public int BufferWidth { get; }
    public int BufferHeight { get; }
    public TextBox(int width, int height, TextFont textFont)
    {
      BufferWidth = width;
      BufferHeight = height;
      Characters = new CharTile[width, height];
      
      for (int y = 0; y < Characters.GetLength(1); y++)
      {
        for (int x = 0; x < Characters.GetLength(0); x++)
        {
          Vector2 charPos = new Vector2(x * textFont.CharWidth, y * textFont.CharHeight);
          CharTile charTile = new CharTile(textFont, this);
          charTile.SetPosition(charPos);
          Characters[x, y] = charTile;
        }
      }
      SetCursorPosition(Point.Zero);
    }
    public Point CursorPosition { get; private set; }
    public void SetCursorPosition(int X, int Y)
    {
      CursorPosition = new Point(
          MathHelper.Clamp(X, 0, BufferWidth),
          MathHelper.Clamp(Y, 0, BufferHeight)
          );
    }
    public void SetCursorPosition(Point position)
    {
      SetCursorPosition(position.X, position.Y);
    }
    private void IncrementCursorPosition()
    {
      int xPos = CursorPosition.X + 1;
      int yPos = CursorPosition.Y;
      if (xPos >= BufferWidth)
      {
        xPos = 0;
        if (CursorPosition.Y < BufferHeight)
        {
          yPos++;
        }
      }
      SetCursorPosition(xPos, yPos);
    }
    public void Clear()
    {
      for (int y = 0; y < Characters.GetLength(1); y++)
      {
        for (int x = 0; x < Characters.GetLength(0); x++)
        {
          Characters[x, y].Clear();
        }
      }
      SetCursorPosition(Point.Zero);
    }
    public void Clear(char Char, Color ForeColor, Color BackColor)
    {
      for (int y = 0; y < Characters.GetLength(1); y++)
      {
        for (int x = 0; x < Characters.GetLength(0); x++)
        {
          Characters[x, y].SetData(Char, ForeColor, BackColor);
        }
      }
      SetCursorPosition(Point.Zero);
    }
    public void Write(char Char, Color ForeColor, Color BackColor)
    {
      Characters[CursorPosition.X, CursorPosition.Y].SetData(Char, ForeColor, BackColor);
      IncrementCursorPosition();
    }
    public void Write(char Char, Color ForeColor, Color BackColor, int X, int Y)
    {
      SetCursorPosition(X, Y);
      Characters[CursorPosition.X, CursorPosition.Y].SetData(Char, ForeColor, BackColor);
      IncrementCursorPosition();
    }
    public void Write(char Char, Color ForeColor, Color BackColor, Point position)
    {
      Write(Char, ForeColor, BackColor, position.X, position.Y);
    }
    public void Write(string String, Color ForeColor, Color BackColor)
    {
      int position = CursorPosition.X;
      foreach (char Char in String)
      {
        if (Char == '\n')
        {
          SetCursorPosition(position, CursorPosition.Y + 1);
        }
        else
        {
          Characters[CursorPosition.X, CursorPosition.Y].SetData(Char, ForeColor, BackColor);
          IncrementCursorPosition();
        }
      }
    }
    public void Write(string String, Color ForeColor, Color BackColor, Point position)
    {
      SetCursorPosition(position);
      Write(String, ForeColor, BackColor);
    }
    public void Write(string String, Color ForeColor, Color BackColor, int X, int Y)
    {
      SetCursorPosition(X, Y);
      Write(String, ForeColor, BackColor);
    }
    public override void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      for (int y = 0; y < Characters.GetLength(1); y++)
      {
        for (int x = 0; x < Characters.GetLength(0); x++)
        {
          Characters[x, y].Draw(graphicsDevice, spriteBatch);
        }
      }
    }
  }
}
