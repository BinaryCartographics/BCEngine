using Microsoft.Xna.Framework.Graphics;


namespace BCEngine.Graphics
{
  public abstract class Material
  {
		public Effect Effect { get;}
		public BlendState BlendState { get; set; }
		public SamplerState SamplerState { get; set; }
		public DepthStencilState DepthStencilState { get; set; }
		protected Material(Effect effect)
		{
			Effect = effect;
		}
	}
}
