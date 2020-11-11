using System;

namespace BCEngine.UI
{
  public abstract partial class Widget
  {
    public event EventHandler TouchClick;
    public event EventHandler TouchDown;
    public event EventHandler TouchUp;

    internal virtual void OnTouchClick()
    {
      TouchClick?.Invoke(this, new EventArgs());
    }
    internal virtual void OnTouchDown()
    {
      TouchDown?.Invoke(this, new EventArgs());
    }

    internal virtual void OnTouchUp()
    {
      TouchUp?.Invoke(this, new EventArgs());
    }
  }
}
