using BCEngine.Interfaces;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace BCEngine.Scenes
{
  public class Scene
  {
    private readonly List<IGameObject> _gameObjects;

    public Color BackgroundColor { get; set; }

    public Scene()
    {
      _gameObjects = new List<IGameObject>();
      BackgroundColor = Color.Transparent;
    }

    public bool AddGameObject(IGameObject gameObject)
    {
      if (!_gameObjects.Contains(gameObject))
      {
        _gameObjects.Add(gameObject);
        return true;
      }
      return false;
    }
  }
}
