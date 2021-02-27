using BCEngine.Scenes;
using Urmel.TestClasses;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Xunit;

namespace BCEngineTests.Scenes
{
  public class SceneTests
  {
    [Fact]
    public void SceneConstructorDoesntCrash()
    {
      MyScene scene = new MyScene();
      Assert.NotNull(scene);
    }

    [Theory]
    [MemberData(nameof(ColorData))]
    public void SetBackgroundColorIsReturnedOnGet(Color expectedColor)
    {
      MyScene scene = new MyScene { BackgroundColor = expectedColor };
      Assert.Equal(expectedColor, scene.BackgroundColor);
    }
    public static IEnumerable<object[]> ColorData()
    {
      var allData = new List<object[]>
        {
          new object[] { Color.Red },
          new object[] { Color.Blue },
          new object[] { Color.Green },
          new object[] { Color.CornflowerBlue },
        };

      return allData;
    }

    [Fact]
    public void CanAddObjectToScene()
    {
      MyScene scene = new MyScene();
      MockIGameObject character = new MockIGameObject("A name");
      Assert.True(scene.AddGameObject(character));
    }

    [Fact]
    public void ObjectAddedToSceneIsInGameObjectsCollection()
    {
      MyScene scene = new MyScene();
      MockIGameObject character = new MockIGameObject("A name");
      scene.AddGameObject(character);
      Assert.Contains(character, scene.GameObjects);
    }

    [Fact]
    public void CannotAddSameObjectTwice()
    {
      Scene scene = new Scene();
      MockIGameObject character = new MockIGameObject("A name");
      scene.AddGameObject(character);
      Assert.False(scene.AddGameObject(character));
    }

    [Fact]
    public void CanAddMultipleObjects()
    {
      Scene scene = new Scene();
      MockIGameObject character = new MockIGameObject("A name");
      MockIGameObject character2 = new MockIGameObject("B name");
      Assert.True(scene.AddGameObject(character));
      Assert.True(scene.AddGameObject(character2));
    }

    [Fact]
    public void MultipleObjectsAreAddedToCollection()
    {
      Scene scene = new Scene();
      MockIGameObject character = new MockIGameObject("A name");
      MockIGameObject character2 = new MockIGameObject("B name");
      scene.AddGameObject(character);
      scene.AddGameObject(character2);

      Assert.Contains(character, scene.GameObjects);
      Assert.Contains(character2, scene.GameObjects);
    }

    [Fact]
    public void CanRemoveObjectFromScene()
    {
      Scene scene = new Scene();
      MockIGameObject character = new MockIGameObject("A name");
      scene.AddGameObject(character);
      Assert.True(scene.RemoveGameObject(character));
    }

    [Fact]
    public void ObjectIsRemovedFromScene()
    {
      Scene scene = new Scene();
      MockIGameObject character = new MockIGameObject("A name");
      scene.AddGameObject(character);
      scene.RemoveGameObject(character);
      Assert.DoesNotContain(character, scene.GameObjects);
    }

    [Fact]
    public void CanAddIDrawablesCorrectly()
    {
      Scene scene = new Scene();
      MockIDrawable character = new MockIDrawable("Dave");
      Assert.True(scene.AddGameObject(character));
    }

    [Fact]
    public void IDrawablesGetAddedToGameObjects()
    {
      Scene scene = new Scene();
      MockIDrawable character = new MockIDrawable("Dave");
      scene.AddGameObject(character);
      Assert.Contains(character, scene.GameObjects);
    }

    [Fact]
    public void IDrawablesGetRemovedFromGameObjects()
    {
      Scene scene = new Scene();
      MockIDrawable character = new MockIDrawable("Dave");
      scene.AddGameObject(character);
      scene.RemoveGameObject(character);
      Assert.DoesNotContain(character, scene.GameObjects);
    }

    [Fact]
    public void IDrawablesGetAddedToDrawables()
    {
      Scene scene = new Scene();
      MockIDrawable character = new MockIDrawable("Dave");
      scene.AddGameObject(character);
      Assert.Contains(character, scene.Drawables);
    }

    [Fact]
    public void IDrawablesGetRemovedFromDrawables()
    {
      Scene scene = new Scene();
      MockIDrawable character = new MockIDrawable("Dave");
      scene.AddGameObject(character);
      scene.RemoveGameObject(character);
      Assert.DoesNotContain(character, scene.Drawables);
    }

  }
}