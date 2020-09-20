using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BCEngine.Scenes
{
  public class SceneManager
  {
    private readonly List<Scene> _scenes;

    public Scene CurrentScene { get; private set; }
    public IReadOnlyList<Scene> Scenes { get; }

    public SceneManager()
    {
      _scenes = new List<Scene>();
      Scenes = _scenes.AsReadOnly();
    }

    /// <summary>
    /// Add a new scene to the scene manager
    /// </summary>
    /// <param name="newScene">new scene to add</param>
    /// <returns>True if scene was added successfully, else false</returns>
    public bool AddScene(Scene newScene)
    {
      if (!_scenes.Contains(newScene))
      {
        _scenes.Add(newScene);
        return true;
      }
      return false;
    }

    public bool RemoveScene(Scene toRemove)
    {
      if (_scenes.Contains(toRemove) && toRemove != CurrentScene)
      {
        _scenes.Remove(toRemove);
        return true;
      }
      return false;
    }

    public bool NavigateToScene(Scene scene)
    {
      if (_scenes.Contains(scene) && CurrentScene != scene)
      {
        CurrentScene = scene;
        return true;
      }
      return false;
    }

    public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      var color = CurrentScene?.BackgroundColor ?? Color.Black;
      graphicsDevice.Clear(color);
    }
  }
}
