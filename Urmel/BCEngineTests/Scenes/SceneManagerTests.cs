using BCEngine.Scenes;
using Xunit;

namespace BCEngineTests.Scenes
{
  public class SceneManagerTests
  {
    [Fact]
    public void SceneManagerConstructorDoesntCrash()
    {
      SceneManager sceneManager = new SceneManager();
      Assert.NotNull(sceneManager);
    }

    [Fact]
    public void SceneManagerCanAddScene()
    {
      SceneManager sceneManager = new SceneManager();
      Scene sceneToAdd = new Scene();
      Assert.True(sceneManager.AddScene(sceneToAdd));
    }

    [Fact]
    public void SceneManagerCannotAddSameSceneTwice()
    {
      SceneManager sceneManager = new SceneManager();
      Scene sceneToAdd = new Scene();
      sceneManager.AddScene(sceneToAdd);
      Assert.False(sceneManager.AddScene(sceneToAdd));
    }

    [Fact]
    public void SceneManagerCanHaveMultipleScenesAdded()
    {
      SceneManager sceneManager = new SceneManager();
      Scene sceneToAdd = new Scene();
      Assert.True(sceneManager.AddScene(sceneToAdd));
      Scene otherScene = new Scene();
      Assert.True(sceneManager.AddScene(otherScene));
    }

    [Fact]
    public void SceneManagerCanNavigateToScene()
    {
      SceneManager sceneManager = new SceneManager();
      Scene scene = new Scene();
      sceneManager.AddScene(scene);

      Assert.True(sceneManager.NavigateToScene(scene));
    }

    [Fact]
    public void SceneManagerCurrentSceneUpdatesWhenNavigatingToScene()
    {
      SceneManager sceneManager = new SceneManager();
      Scene scene = new Scene();
      sceneManager.AddScene(scene);

      sceneManager.NavigateToScene(scene);

      Assert.Equal(scene, sceneManager.CurrentScene);
    }

    [Fact]
    public void SceneManagerCannotNavigateToSceneNotAdded()
    {
      SceneManager sceneManager = new SceneManager();
      Scene scene = new Scene();

      Assert.False(sceneManager.NavigateToScene(scene));
    }

    [Fact]
    public void SceneManagerCannotNavigateToCurrentScene()
    {
      SceneManager sceneManager = new SceneManager();
      Scene scene = new Scene();
      sceneManager.AddScene(scene);

      sceneManager.NavigateToScene(scene);
      Assert.False(sceneManager.NavigateToScene(scene));
    }
  }
}
