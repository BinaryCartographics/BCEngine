using BCEngine.Graphics;
using System.Collections.Generic;

namespace BCEngine.Rendering
{
  public class RenderPassCollection
  {
    private readonly List<RenderPass> _renderPasses;

    public RenderPassCollection()
    {
      _renderPasses = new List<RenderPass>();
      RenderPasses = _renderPasses.AsReadOnly();
    }
    public IReadOnlyList<RenderPass> RenderPasses { get; }

    public bool AddRenderLayer(RenderPass renderLayer)
    {
      if (!_renderPasses.Contains(renderLayer))
      {
        _renderPasses.Add(renderLayer);

        _renderPasses.Sort((x, y) => x.RenderPriority.CompareTo(y.RenderPriority));

        return true;
      }
      return false;
    }

    public bool RemoveRenderLayer(RenderPass renderLayer)
    {
      if (_renderPasses.Contains(renderLayer))
      {
        _renderPasses.Remove(renderLayer);
        return true;
      }
      return false;
    }
  }
}
