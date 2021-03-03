using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace BCEngine.Input
{
  public class MouseEventArgs : EventArgs
  {

    /// <summary>
    /// Initializes a new instance of the MouseEventArgs class.
    /// </summary>
    public MouseEventArgs(MouseState mouseState)
    {
      MouseState = mouseState;
      X = mouseState.X;
      Y = mouseState.Y;
    }

    /// <summary>
    /// Gets the XNA input mouse state during an event
    /// </summary>
    public MouseState MouseState { get; }

    /// <summary>
    /// Gets the X coordinate of a mouse click
    /// </summary>
    public int X { get; }

    /// <summary>
    /// Gets the Y coordinate of a mouse click
    /// </summary>
    public int Y { get; }

    /// <summary>
    /// Gets the location of the mouse during a mouse event
    /// </summary>
    public Point Location => new Point(X, Y);
  }
}
