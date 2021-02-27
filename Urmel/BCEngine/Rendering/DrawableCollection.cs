using BCEngine.Interfaces;
using System.Collections.Generic;

namespace BCEngine.Rendering
{
  class DrawableCollection
  {
    private readonly List<IDrawable> _drawables;
    public DrawableCollection()
    {
      _drawables = new List<IDrawable>();
      Drawables = _drawables.AsReadOnly();
    }
    public IReadOnlyList<IDrawable> Drawables { get; }

    public bool AddDrawable (IDrawable drawable)
    {
      if (!_drawables.Contains(drawable))
      {
        _drawables.Add(drawable);
        return true;
      }
      return false;
    }

    public bool RemoveGameObject(IDrawable drawable)
    {
      if (_drawables.Contains(drawable))
      {
        _drawables.Remove(drawable);
        return true;
      }
      return false;
    }
  }
}
