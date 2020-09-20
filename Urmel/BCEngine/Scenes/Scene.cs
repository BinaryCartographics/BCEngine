using BCEngine.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using IDrawable = BCEngine.Interfaces.IDrawable;

namespace BCEngine.Scenes
{
  public class Scene
  {
    private readonly List<IGameObject> _gameObjects;
    private readonly List<IDrawable> _drawables;

    public Color BackgroundColor { get; set; }

    public Scene()
    {
      _gameObjects = new List<IGameObject>();
      _drawables = new List<IDrawable>();
      GameObjects = _gameObjects.AsReadOnly();
      Drawables = _drawables.AsReadOnly();
      BackgroundColor = Color.Transparent;
    }

    public IReadOnlyList<IGameObject> GameObjects { get; }
    public IReadOnlyList<IDrawable> Drawables { get; }
    public bool AddGameObject(IGameObject gameObject)
    {
      if (!_gameObjects.Contains(gameObject))
      {
        _gameObjects.Add(gameObject);
        if (gameObject is IDrawable drawableObject)
          _drawables.Add(drawableObject);
        return true;
      }
      return false;
    }

    public bool RemoveGameObject(IGameObject toRemove)
    {
      if (_gameObjects.Contains(toRemove))
      {
        _gameObjects.Remove(toRemove);
        if (toRemove is IDrawable drawableObject)
          _drawables.Remove(drawableObject);
        return true;
      }
      return false;
    }
  }
}
