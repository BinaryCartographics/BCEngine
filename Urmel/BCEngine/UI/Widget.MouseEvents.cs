using System;

namespace BCEngine.UI
{
  public abstract partial class Widget
  {
    public bool IsMouseDown { get; private set; }
    public bool IsMouseHover { get; private set; }

    public event EventHandler MouseClick;
    public event EventHandler MouseDown;
    public event EventHandler MouseUp;
    public event EventHandler MouseEnter;
    public event EventHandler MouseLeave;

    internal virtual void OnMouseClick()
    {
      MouseClick?.Invoke(this, new EventArgs());
    }
    internal virtual void OnMouseDown()
    {
      IsMouseDown = true;
      MouseDown?.Invoke(this, new EventArgs());
    }

    internal virtual void OnMouseUp()
    {
      IsMouseDown = false;
      MouseUp?.Invoke(this, new EventArgs());
    }

    internal virtual void OnMouseEnter()
    {
      IsMouseHover = true;
      MouseEnter?.Invoke(this, new EventArgs());
    }

    internal virtual void OnMouseLeave()
    {
      IsMouseHover = false;
      MouseLeave?.Invoke(this, new EventArgs());
    }
  }
}
