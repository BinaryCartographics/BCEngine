using BCEngine.Common;
using BCEngine.Helpers;
using BCEngine.Graphics;
using BCEngine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using IDrawable = BCEngine.Interfaces.IDrawable;

namespace BCEngine.Scenes
{
  public abstract class Scene
  {
    private readonly List<IGameObject> _gameObjects;
    private readonly List<RenderPass> _renderPasses;

    protected Scene(GraphicsDevice graphicsDevice, ContentManager contentManager)
    {
      _gameObjects = new List<IGameObject>();
      GameObjects = _gameObjects.AsReadOnly();

      _renderPasses = new List<RenderPass>();
      RenderPasses = _renderPasses.AsReadOnly();

      BackgroundColor = Color.Transparent;
      MainCamera = new Camera();
    }
    public Camera MainCamera { get; }
    public RenderTarget2D FinalRenderTarget { get; set; }
    public IReadOnlyList<IGameObject> GameObjects { get; }
    public IReadOnlyList<RenderPass> RenderPasses { get; }
    public Color BackgroundColor { get; set; }
    public float DeltaTime { get; set; }

    /// <summary>
    /// When the scene manager navigates to a scene, it will call this function on the scene that was navigated to
    /// </summary>
    public abstract void OnSceneEnter();

    /// <summary>
    /// Before the scene manager navigates to a scene, it will call this function on the scene currently loaded
    /// </summary>
    public abstract void OnSceneExit();

    /// <summary>
    /// This will be called by the scene manager before all IUpdatables are updated
    /// </summary>
    /// <param name="gameTime">The elapsed time since the last call to Main.Update</param>
    public abstract void OnUpdate(GameTime gameTime);

    /// <summary>
    /// adds a game object to the scene, 
    /// </summary>
    /// <param name="gameObject">gameobject to add to scene</param>
    /// <returns>boolean value representing whether or not the function was successful</returns>
    public bool AddGameObject(IGameObject gameObject)
    {
      if (!_gameObjects.Contains(gameObject))
      {
        _gameObjects.Add(gameObject);
        return true;
      }
      return false;
    }

    /// <summary>
    /// removes a game object from the scene,
    /// </summary>
    /// <param name="gameObject">gameobject to remove from the scene</param>
    /// <returns>boolean value representing whether or not the function was successful</returns>
    public bool RemoveGameObject(IGameObject toRemove)
    {
      if (_gameObjects.Contains(toRemove))
      {
        _gameObjects.Remove(toRemove);
        return true;
      }
      return false;
    }

    public bool AddRenderPass(RenderPass renderPass)
    {
      if (!_renderPasses.Contains(renderPass))
      {
        _renderPasses.Add(renderPass);
        _renderPasses.Sort((x, y) => x.RenderPriority.CompareTo(y.RenderPriority));
        return true;
      }
      return false;
    }

    public bool RemoveRenderPass(RenderPass renderPass)
    {
      if (_renderPasses.Contains(renderPass))
      {
        _renderPasses.Remove(renderPass);
        return true;
      }
      return false;
    }
    public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      foreach (RenderPass R in this._renderPasses)
      {
        R.Render(spriteBatch, graphicsDevice);
      }

      graphicsDevice.SetRenderTarget(null);
      spriteBatch.Begin();
      spriteBatch.Draw(FinalRenderTarget, graphicsDevice.Viewport.Bounds, FinalRenderTarget.Bounds, Color.White);
      spriteBatch.End();
    }
  }
}
