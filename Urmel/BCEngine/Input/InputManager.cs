using Microsoft.Xna.Framework.Input;

namespace BCEngine.Input
{
  public static class InputManager
  {
    public static KeyboardState OldKeyboardState { get; private set; }
    public static KeyboardState KeyboardState { get; private set; }
    public static MouseState OldMouseState { get; private set; }
    public static MouseState MouseState { get; private set; }

    public static void Update()
    {
      OldKeyboardState = KeyboardState;
      KeyboardState = Keyboard.GetState();

      OldMouseState = MouseState;
      MouseState = Mouse.GetState();
    }
  }
}
