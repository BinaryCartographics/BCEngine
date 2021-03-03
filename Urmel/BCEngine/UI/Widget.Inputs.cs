using BCEngine.Input;
using System;

namespace BCEngine.UI
{
  public abstract partial class Widget
  {
    /// <summary>
    /// One shot Mouse events 
    /// </summary>
    // Mouse button was pressed down
    public event EventHandler MousePressHandler;
    public virtual void OnMousePress(MouseEventArgs e)
    {
      MousePressHandler?.Invoke(this, e);
    }
    // Mouse button was released
    public event EventHandler MouseReleaseHandler;
    public virtual void OnMouseRelease(MouseEventArgs e)
    {
      MouseReleaseHandler?.Invoke(this, e);
    }
    // Mouse begun hovering over a control
    public event EventHandler MouseEnterHandler;
    public virtual void OnMouseEnter(MouseEventArgs e)
    {
      MouseEnterHandler?.Invoke(this, e);
    }
    // Mouse stopped hovering over a control
    public event EventHandler MouseLeaveHandler;
    public virtual void OnMouseLeave(MouseEventArgs e)
    {
      MouseLeaveHandler?.Invoke(this, e);
    }

    /// <summary>
    /// Per frame Mouse events
    /// </summary>
    // Mouse button is currently down
    public event EventHandler MouseDownHandler;
    public virtual void IsMouseDown(MouseEventArgs e)
    {
      MouseDownHandler?.Invoke(this, e);
    }
    // Mouse cursor is currently over a control
    public event EventHandler MouseHoverHandler;
    public virtual void IsMouseHover(MouseEventArgs e)
    {
      MouseHoverHandler?.Invoke(this, e);
    }
    /// <summary>
    /// One shot Key events 
    /// </summary
    // key was pressed down
    public event EventHandler KeyPressHandler;
    protected virtual void OnKeyPress(KeyEventArgs e)
    {
      KeyPressHandler?.Invoke(this, e);
    }
    // Key was released
    public event EventHandler KeyReleaseHandler;
    protected virtual void OnKeyRelease(KeyEventArgs e)
    {
      KeyReleaseHandler?.Invoke(this, e);
    }

    /// <summary>
    /// Per frame Key events 
    /// </summary>
    // Key is currently down
    public event EventHandler KeyDownHandler;
    protected virtual void IsKeyDown(KeyEventArgs e)
    {
      KeyDownHandler?.Invoke(this, e);
    }
    // Key is currently up
    public event EventHandler KeyUpHandler;
    protected virtual void IsKeyUp(KeyEventArgs e)
    {
      KeyUpHandler?.Invoke(this, e);
    }
  }
}
