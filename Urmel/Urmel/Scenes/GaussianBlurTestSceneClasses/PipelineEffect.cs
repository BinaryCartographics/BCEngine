using Microsoft.Xna.Framework.Graphics;

namespace Urmel.Scenes.GaussianBlurTestSceneClasses
{
  class PipelineEffect : Effect
  {
    readonly EffectParameter _width;
    readonly EffectParameter _height;
    public PipelineEffect(Effect effect, int width, int height) : base(effect)
    {
      _width = Parameters["width"];
      _height = Parameters["height"];

      _width.SetValue(width);
      _height.SetValue(height);
    }
  }
}
