using BCEngine.Helpers;
using BCEngine.Input;
using BCEngine.UI.Skinning;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace BCEngine.UI
{
  public class Button : Widget
  {
    public Button(ButtonSkin Skin)
    {
      this.DefaultTexture = Skin.DefaultTexture;
      this.HoverTexture = Skin.HoverTexture;
      this.PressTexture = Skin.PressTexture;
      Texture = DefaultTexture;
      Bounds = Texture.Bounds;
      SourceRectangle = Bounds;
    }
    public Button(Texture2D DefaultTexture, Texture2D HoverTexture, Texture2D PressTexture)
    {
      this.DefaultTexture = DefaultTexture;
      this.HoverTexture = HoverTexture;
      this.PressTexture = PressTexture;
      Texture = DefaultTexture;
      Bounds = Texture.Bounds;
      SourceRectangle = Bounds;
    }
    public Texture2D DefaultTexture { get; set; }
    public Texture2D HoverTexture { get; set; }
    public Texture2D PressTexture { get; set; }
    public Texture2D Texture { get; private set; }
    public override void Update(GameTime gameTime)
    {
      MouseEventArgs mouseEventArgs = new MouseEventArgs(InputManager.MouseState);
      Vector2 LocalMousePos = InputManager.MouseState.Position.ToVector2();

      if (Contains(LocalMousePos))  //if mouse is over the button
      {
        // if the mouse button is pressed
        if (InputManager.MouseState.LeftButton == ButtonState.Pressed)
        {
          // if the button was pressed during the current frame, invoke OnMouseDown
          if (InputManager.OldMouseState.LeftButton == ButtonState.Released)
            base.OnMousePress(mouseEventArgs);


          // every update, if the mouse is pressed, this will invoke IsMouseDown
          base.IsMouseDown(mouseEventArgs);

          Texture = PressTexture;
        }
        else
        {
          // if the button was released during the current frame, invoke OnMouseUp
          if (InputManager.OldMouseState.LeftButton == ButtonState.Released)
            base.OnMouseRelease(mouseEventArgs);

          // if the button was entered during the current frame, invoke OnMouseEnter 
          if (!Contains(InputManager.OldMouseState.Position.ToVector2()))
            base.OnMouseEnter(mouseEventArgs);

          // every update, if the mouse is not pressed, this will invoke IsMouseHover
          base.IsMouseHover(mouseEventArgs);
          Texture = HoverTexture;
        }
      }
      else
      {
        Texture = DefaultTexture;
      }
    }

    public override void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      throw new NotImplementedException();
    }
  }
}
