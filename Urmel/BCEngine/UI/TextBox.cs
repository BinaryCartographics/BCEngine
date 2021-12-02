using System;
using BCEngine.Math;
using BCEngine.UI.Text;
using BCEngine.Helpers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngine.UI
{
  public class TextBox : Widget
  {
    public CharTile[,] Characters { get; private set; }

    /// <summary>
    /// The width of the TextBox in Characters
    /// </summary>
    public int BufferWidth { get; private set; }

    /// <summary>
    /// The height of the TextBox in Characters
    /// </summary>
    public int BufferHeight { get; private set; }

    /// <summary>
    /// The width of the TextBox in pixels
    /// </summary>
    public int Width { get; private set; }
    /// <summary>
    /// The height of the TextBox in pixels
    /// </summary>
    public int Height { get; private set; }

    /// <summary>
    /// Constructs a new TextBox 
    /// Note: Using pixel mode will only create a character width below pixel width, if a char is 12 px, and you set width to 13, you get 1 character
    /// </summary>
    /// <param name="width">The width of the TextBox in relation to textScalingMode</param>
    /// <param name="height">The width of the TextBox in relation to textScalingMode</param>
    /// <param name="textFont">The font of the TextBox</param>
    /// <param name="textScalingMode">The scaling mode for the textBox, either in characters, or pixels</param>
    public TextBox(int width, int height, TextFont textFont, TextScalingMode textScalingMode)
    {
      CreateTextBox(width, height, textFont, textScalingMode);
    }
    /// <summary>
    /// Constructs a new TextBox
    /// </summary>
    /// <param name="width">The width of the TextBox in relation to textFont.CharWidth</param>
    /// <param name="height">The height of the TextBox in relation to textFont.CharHeight</param>
    /// <param name="textFont">The font of the TextBox</param>
    public TextBox(int width, int height, TextFont textFont)
    {
      CreateTextBox(width, height, textFont, TextScalingMode.Characters);
    }
    private void CreateTextBox(int width, int height, TextFont textFont, TextScalingMode textScalingMode)
    {
      switch (textScalingMode)
      {
        case TextScalingMode.Characters:
          BufferWidth = width;
          BufferHeight = height;
          break;
        case TextScalingMode.Pixels:
          BufferWidth = MathHelper.Max(width / textFont.CharWidth, 1);
          BufferHeight = MathHelper.Max(height / textFont.CharHeight, 1);
          break;
      }

      Characters = new CharTile[BufferWidth, BufferHeight];

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
          MathHelper.Clamp(X, 0, BufferWidth - 1),
          MathHelper.Clamp(Y, 0, BufferHeight - 1));
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
