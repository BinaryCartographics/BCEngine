using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BCEngine.Scenes
{
  public class SceneManager
  {
    private readonly List<Scene> _scenes;
    public SceneManager()
    {
      _scenes = new List<Scene>();
      Scenes = _scenes.AsReadOnly();
    }
    public IReadOnlyList<Scene> Scenes { get; }
    public Scene CurrentScene { get; private set; }

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

    /// <summary>
    /// Remove a scene from the scene manager
    /// </summary>
    /// <param name="toRemove">scene to remove from collection</param>
    /// <returns>True if scene was removed successfully, else false</returns>
    public bool RemoveScene(Scene toRemove)
    {
      if (_scenes.Contains(toRemove) && toRemove != CurrentScene)
      {
        _scenes.Remove(toRemove);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Navigate to a scene in the scene manager
    /// </summary>
    /// <param name="scene">scene to navigate to</param>
    /// <returns>True if scene was successfully navigated to, else false</returns>
    public bool NavigateToScene(Scene scene)
    {
      if (_scenes.Contains(scene) && CurrentScene != scene)
      {
        if (CurrentScene != null)
        { 
          CurrentScene.OnSceneExit();
        }

        CurrentScene = scene;

        scene.OnSceneEnter();
        return true;
      }
      return false;
    }

    /// <summary>
    /// Called when the game updates, updates the current scene
    /// </summary>
    /// <param name="gameTime">The elapsed time since the last call to Update()</param>
    public void Update(GameTime gameTime)
    {
      if (CurrentScene != null)
      { 
        CurrentScene.OnUpdate(gameTime);
        CurrentScene.DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
      }
    }

    public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      CurrentScene?.Draw(graphicsDevice, spriteBatch);
    }
  }
}
