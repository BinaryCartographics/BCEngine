using BCEngine.Interfaces;
using BCEngine.UI;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace BCEngine.Graphics
{
  public abstract class RenderPass
  {
    /// <summary>
    /// The render target for the current render pass to be drawn to. Note:
    /// passing a render target in by reference and reusing it for multiple 
    /// passes may be more efficient than using a render target per render pass
    /// </summary>
    public RenderTarget2D RenderTarget { get; set; }

    /// <summary>
    /// The material used to complete the render pass with, responsible for handling 
    /// the shader and its parameters, which create the visual effects for your game
    /// </summary>
    public Material Material { get; set; }

    /// <summary>
    /// the drawables to be drawn in the current render pass
    /// </summary>
    private readonly List<IDrawable> _drawables;

    protected RenderPass()                                           
    {
      _drawables = new List<IDrawable>();
      Drawables = _drawables.AsReadOnly();
    }
    /// <summary>
    /// the drawables to be drawn in the current render pass
    /// </summary>
    public IReadOnlyList<IDrawable> Drawables { get; }


    /// <summary>
    /// The priority of a render pass, used for organising render passes in a RenderPassCollection
    /// </summary>
    public int RenderPriority { get; }                                                                             

    /// <summary>
    /// Adds an IDrawable to the render pass for it to be rendered to renderTarget this.Material
    /// Note: it is possible to add an IDrawable to multiple render passses
    /// </summary>
    /// <param name="drawable">The IDrawable to be added to the pass</param>
    /// <returns>True if the method completed sucessfully</returns>
    public bool AddDrawableToRenderPass(IDrawable drawable) 
    {
      if (!_drawables.Contains(drawable))
      {
        _drawables.Add(drawable);
        drawable.AddRenderPass(this);
        return true;
      }
      return false;
    }

    /// <summary>
    /// Removes an IDrawable from a render pass so that it cannot be drawn to renderTarget
    /// </summary>
    /// <param name="drawable">The IDrawable to be removed from this pass</param>
    /// <returns>True if the method completed sucessfully</returns>
    public bool RemoveDrawableFromRenderPass(IDrawable drawable)
    {
      if (_drawables.Contains(drawable))
      {
        _drawables.Remove(drawable);
        drawable.RemoveRenderPass(this);
        return true;
      }
      return false;
    }

    /// <summary>
    /// This is called by the Scene renderer, it renders to the RenderTarget
    /// </summary>
    /// <param name="spriteBatch">The spritebatch passed in by the renderer for rendering</param>
    public abstract bool Render(SpriteBatch spriteBatch, GraphicsDevice graphicsDevice);
  }
}
