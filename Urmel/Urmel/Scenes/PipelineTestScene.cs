using BCEngine.Scenes;
using BCEngine.Helpers;
using BCEngine.UI;
using Urmel.Scenes.GaussianBlurTestSceneClasses;
using Urmel.TestClasses;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using BCEngine.UI.Skinning;
using System;

namespace Urmel.Scenes
{
  public class PipelineTestScene : Scene
  {
    private PipelineMaterial MyMaterial { get; }
    private PipelinePass MyPass { get; }
    private MyDrawable myDrawable { get; }

    private Button B { get; }
    public PipelineTestScene(GraphicsDevice graphicsDevice, ContentManager content) : base(graphicsDevice)
    {
      FinalRenderTarget = new RenderTarget2D(graphicsDevice, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);

      Effect gEffect = content.Load<Effect>("Effects/CrtEffect");
      myDrawable = new MyDrawable("testing", content.Load<Texture2D>("Textures/bcflag"));
      myDrawable.SetScale(Vector2.One * 5);

      PipelineEffect BlurTestEffect = new PipelineEffect(gEffect, graphicsDevice.Viewport.Width, graphicsDevice.Viewport.Height);

      MyMaterial = new PipelineMaterial(BlurTestEffect);
      MyPass = new PipelinePass(FinalRenderTarget);
      AddRenderPass(MyPass);
      AddGameObject(myDrawable, MyPass);

      myDrawable.SetPosition(Vector2.One * 100);
      MyPass.Material = MyMaterial;

      ButtonSkin bs = new ButtonSkin(content);
      B = new Button(bs);
      AddGameObject(B);
      B.SetScale(Vector2.One);
      B.SetPosition(new Vector2(300, 100));
      MyPass.AddDrawableToRenderPass(B);


      B.MousePressHandler += HandleCustomEvent;
    }

    private void HandleCustomEvent(object sender, EventArgs e)
    {
      myDrawable.Rotate(100);
    }

    public override void OnSceneEnter()
    {
      
    }

    public override void OnSceneExit()
    {
      
    }

    public override void OnUpdate(GameTime gameTime)
    {
      B.Update(gameTime);
      var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
      myDrawable.Rotate(0.5f * delta);
    }
  }
}
