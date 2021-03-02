using BCEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace BCEngineTests.Scenes
{
  class MockScene : Scene
  {
    public MockScene(GraphicsDevice graphicsDevice) : base(graphicsDevice)
    { 

    
    }
    public override void OnSceneEnter()
    {
      //nothing
    }

    public override void OnSceneExit()
    {
      //nothing
    }

    public override void OnUpdate(GameTime gameTime)
    {
      //nothing  
    }
  }
}
