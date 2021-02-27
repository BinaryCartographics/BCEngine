using Microsoft.Xna.Framework.Graphics;


namespace BCEngine.Graphics
{
  public abstract class Material
  {
		public Effect Effect { get; }
		public BlendState BlendState { get; }
		public SamplerState SamplerState { get; }
		public DepthStencilState DepthStencilState { get; }
		protected Material(Effect effect)
		{
			Effect = effect;
		}
	}
}
