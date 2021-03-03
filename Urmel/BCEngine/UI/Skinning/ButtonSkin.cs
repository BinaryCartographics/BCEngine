using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace BCEngine.UI.Skinning
{
  public class ButtonSkin
  {
    /// <summary>
    /// default initializer for ButtonSkin, automatically loads default texture files for a simple button skin
    /// </summary>
    /// <param name="content">Content manager used for loading button skins</param>
    public ButtonSkin(ContentManager content)
    {
      DefaultTexture = content.Load<Texture2D>("Textures/UI/Button/Button_DefaultTexture");
      HoverTexture = content.Load<Texture2D>("Textures/UI/Button/Button_HoverTexture");
      PressTexture =content.Load<Texture2D>("Textures/UI/Button/Button_PressTexture");
    }
    /// <summary>
    /// simple initializer for buttonSkin that allows for custom textures to be loaded per button state
    /// </summary>
    /// <param name="DefaultTexture">Default button state Texture</param>
    /// <param name="HoverTexture">Hover state Texture</param>
    /// <param name="PressTexture">Press state Texture</param>
    public ButtonSkin(Texture2D DefaultTexture, Texture2D HoverTexture, Texture2D PressTexture)
    {
      this.DefaultTexture = DefaultTexture;
      this.HoverTexture = HoverTexture;
      this.PressTexture = PressTexture;
    }
    public Texture2D DefaultTexture { get; set; }
    public Texture2D HoverTexture { get; set; }
    public Texture2D PressTexture { get; set; }
  }
}
