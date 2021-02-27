using BCEngine.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using IDrawable = BCEngine.Interfaces.IDrawable;

namespace BCEngine.Scenes
{
  public abstract class Scene
  {
    private readonly List<IGameObject> _gameObjects;
    private readonly List<IDrawable> _drawables;


    protected Scene()
    {
      _gameObjects = new List<IGameObject>();
      _drawables = new List<IDrawable>();

      GameObjects = _gameObjects.AsReadOnly();
      Drawables = _drawables.AsReadOnly();

      BackgroundColor = Color.Transparent;
    }
    public IReadOnlyList<IGameObject> GameObjects { get; }
    public IReadOnlyList<IDrawable> Drawables { get; }
    public Color BackgroundColor { get; set; }

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
    /// adds a game object to the scene to be updated and drawn, 
    /// if you would prefer to draw something to a render layer, 
    /// add the gameobject to that directly, without adding it to the scene
    /// </summary>
    /// <param name="gameObject">gameobject to add to scene</param>
    /// <returns>boolean value representing whether or not the function was successful</returns>
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
        if (toRemove is IDrawable drawableObject)
          _drawables.Remove(drawableObject);
        return true;
      }
      return false;
    }

    public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
    {
      var color = BackgroundColor;
      graphicsDevice.Clear(color);

      spriteBatch.Begin(SpriteSortMode.BackToFront, BlendState.AlphaBlend, SamplerState.PointClamp, DepthStencilState.DepthRead, RasterizerState.CullNone, null, null);
      foreach (var drawable in _drawables)
      {
        drawable.Draw(graphicsDevice, spriteBatch);
      }
      spriteBatch.End();
    }
  }
}
