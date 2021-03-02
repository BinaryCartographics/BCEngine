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
      MockScene sceneToAdd = new MockScene(null);
      Assert.True(sceneManager.AddScene(sceneToAdd));
    }

    [Fact]
    public void SceneManagerContainsAddedScene()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene sceneToAdd = new MockScene(null);
      sceneManager.AddScene(sceneToAdd);
      Assert.Contains(sceneToAdd, sceneManager.Scenes);
    }

    [Fact]
    public void SceneManagerCannotAddSameSceneTwice()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene sceneToAdd = new MockScene(null);
      sceneManager.AddScene(sceneToAdd);
      Assert.False(sceneManager.AddScene(sceneToAdd));
    }

    [Fact]
    public void SceneManagerCanHaveMultipleScenesAdded()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene sceneToAdd = new MockScene(null);
      MockScene otherScene = new MockScene(null);
      Assert.True(sceneManager.AddScene(sceneToAdd));
      Assert.True(sceneManager.AddScene(otherScene));
    }

    [Fact]
    public void SceneManagerContainsMultipleScenes()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene sceneToAdd = new MockScene(null);
      sceneManager.AddScene(sceneToAdd);
      MockScene otherScene = new MockScene(null);
      sceneManager.AddScene(otherScene);

      Assert.Contains(sceneToAdd, sceneManager.Scenes);
      Assert.Contains(otherScene, sceneManager.Scenes);
    }

    [Fact]
    public void SceneManagerCanNavigateToScene()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene scene = new MockScene(null);
      sceneManager.AddScene(scene);

      Assert.True(sceneManager.NavigateToScene(scene));
    }

    [Fact]
    public void SceneManagerCurrentSceneUpdatesWhenNavigatingToScene()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene scene = new MockScene(null);
      sceneManager.AddScene(scene);

      sceneManager.NavigateToScene(scene);

      Assert.Equal(scene, sceneManager.CurrentScene);
    }

    [Fact]
    public void SceneManagerCannotNavigateToSceneNotAdded()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene scene = new MockScene(null);

      Assert.False(sceneManager.NavigateToScene(scene));
    }

    [Fact]
    public void SceneManagerCannotNavigateToCurrentScene()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene scene = new MockScene(null);
      sceneManager.AddScene(scene);

      sceneManager.NavigateToScene(scene);
      Assert.False(sceneManager.NavigateToScene(scene));
    }

    [Fact]
    public void SceneManagerCanRemoveScene()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene scene = new MockScene(null);
      sceneManager.AddScene(scene);

      Assert.True(sceneManager.RemoveScene(scene));
    }

    [Fact]
    public void SceneManagerCannotRemoveSceneThatDidntExist()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene scene = new MockScene(null);

      Assert.False(sceneManager.RemoveScene(scene));
    }

    [Fact]
    public void SceneManagerCannotRemoveCurrentScene()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene scene = new MockScene(null);
      sceneManager.AddScene(scene);
      sceneManager.NavigateToScene(scene);
      Assert.False(sceneManager.RemoveScene(scene));
    }

    [Fact]
    public void SceneManagerDoesNotContainRemovedScene()
    {
      SceneManager sceneManager = new SceneManager();
      MockScene scene = new MockScene(null);
      sceneManager.AddScene(scene);

      sceneManager.RemoveScene(scene);

      Assert.DoesNotContain(scene, sceneManager.Scenes);
    }
  }
}
