using BCEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Urmel.Scenes.GaussianBlurTestSceneClasses;
using Urmel.TestClasses;
using BCEngine.Helpers;
namespace Urmel.Scenes
{
  public class PipelineTestScene : Scene
  {
    private PipelineMaterial MyMaterial { get; }
    private PipelinePass MyPass { get; }
    private MyDrawable myDrawable { get; }

    public PipelineTestScene(GraphicsDevice graphicsDevice, ContentManager content) : base(graphicsDevice)
    {
      FinalRenderTarget = new RenderTarget2D(graphicsDevice, 200, 150);

      Effect gEffect = content.Load<Effect>("Effects/CrtEffect");
      myDrawable = new MyDrawable("testing", content.Load<Texture2D>("Textures/bcflag"));

      PipelineEffect BlurTestEffect = new PipelineEffect(gEffect, 200, 150);

      MyMaterial = new PipelineMaterial(BlurTestEffect);
      MyPass = new PipelinePass(FinalRenderTarget);
      myDrawable.SetScale(Vector2.One * 5);
      AddRenderPass(MyPass);
      AddGameObject(myDrawable, MyPass);

      myDrawable.SetPosition(Vector2.One * 100);
      MyPass.Material = MyMaterial;
    }
    public override void OnSceneEnter()
    {
      
    }

    public override void OnSceneExit()
    {
      
    }

    public override void OnUpdate(GameTime gameTime)
    {
      var delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
      myDrawable.Rotate(0.5f * delta);
    }
  }
}
