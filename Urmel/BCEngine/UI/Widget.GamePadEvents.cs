using System;

namespace BCEngine.UI
{
  public abstract partial class Widget
  {
    public event EventHandler GamePadButtonClick;
    public event EventHandler GamePadButtonDown;
    public event EventHandler GamePadButtonUp;
    public event EventHandler GamePadEnter;
    public event EventHandler GamePadLeave;

    internal virtual void OnGamePadButtonPress()
    {
      GamePadButtonClick?.Invoke(this, new EventArgs());
    }
    internal virtual void OnGamePadButtonDown()
    {
      GamePadButtonDown?.Invoke(this, new EventArgs());
    }

    internal virtual void OnGamePadButtonUp()
    {
      GamePadButtonUp?.Invoke(this, new EventArgs());
    }

    internal virtual void OnGamePadEnter()
    {
      GamePadEnter?.Invoke(this, new EventArgs());
    }

    internal virtual void OnGamePadLeave()
    {
      GamePadLeave?.Invoke(this, new EventArgs());
    }
  }
}
