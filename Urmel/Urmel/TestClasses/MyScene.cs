using BCEngine.Scenes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Urmel.TestClasses
{
  public class MyScene : Scene
  {
    public MyScene()
    {

    }
    public override void OnSceneEnter()
    { 
      //background is black, begin fading in
    }

    public override void OnSceneExit()
    {
      //begin fading out to black or something
    }

    public override void OnUpdate(GameTime gameTime)
    {
      throw new System.NotImplementedException();
    }
  }
}
