using Microsoft.Xna.Framework.Input;
using System;

namespace BCEngine.Input
{
  public class KeyEventArgs : EventArgs
  {
    /// <summary>
    ///  Initializes a new instance of the KeyEventArgs class.
    /// </summary>
    public KeyEventArgs(KeyboardState keyboardState)
    {
      KeyboardState = keyboardState;
    }

    /// <summary>
    /// Gets the keyboard state for an event
    /// </summary>
    public KeyboardState KeyboardState { get; }

    /// <summary>
    ///  Gets or sets a value indicating whether the event was handled.
    /// </summary>
    public bool Handled { get; set; }
  }
}
