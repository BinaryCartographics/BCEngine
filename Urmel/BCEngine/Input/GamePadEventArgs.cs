using Microsoft.Xna.Framework.Input;
using System;

namespace BCEngine.Input
{
  public class GamepadEventArgs : EventArgs
  {
    /// <summary>
    ///  Initializes a new instance of the GamePadEventArgs class.
    /// </summary>
    public GamepadEventArgs(GamePadState gamePadState)
    {
      GamePadState = gamePadState;
    }

    /// <summary>
    /// Gets the gamepad state for an event
    /// </summary>
    public GamePadState GamePadState { get; }

    /// <summary>
    ///  Gets or sets a value indicating whether the event was handled.
    /// </summary>
    public bool Handled { get; set; }
  }
}
