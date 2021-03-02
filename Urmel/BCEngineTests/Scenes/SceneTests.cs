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
      MockScene scene = new MockScene(null);
      Assert.NotNull(scene);
    }

    [Theory]
    [MemberData(nameof(ColorData))]
    public void SetBackgroundColorIsReturnedOnGet(Color expectedColor)
    {
      MockScene scene = new MockScene(null) { BackgroundColor = expectedColor };
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
      MockScene scene = new MockScene(null);
      MockIGameObject character = new MockIGameObject("A name");
      Assert.True(scene.AddGameObject(character));
    }

    [Fact]
    public void ObjectAddedToSceneIsInGameObjectsCollection()
    {
      MockScene scene = new MockScene(null);
      MockIGameObject character = new MockIGameObject("A name");
      scene.AddGameObject(character);
      Assert.Contains(character, scene.GameObjects);
    }

    [Fact]
    public void CannotAddSameObjectTwice()
    {
      MockScene scene = new MockScene(null);
      MockIGameObject character = new MockIGameObject("A name");
      scene.AddGameObject(character);
      Assert.False(scene.AddGameObject(character));
    }

    [Fact]
    public void CanAddMultipleObjects()
    {
      MockScene scene = new MockScene(null);
      MockIGameObject character = new MockIGameObject("A name");
      MockIGameObject character2 = new MockIGameObject("B name");
      Assert.True(scene.AddGameObject(character));
      Assert.True(scene.AddGameObject(character2));
    }

    [Fact]
    public void MultipleObjectsAreAddedToCollection()
    {
      MockScene scene = new MockScene(null);
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
      MockScene scene = new MockScene(null);
      MockIGameObject character = new MockIGameObject("A name");
      scene.AddGameObject(character);
      Assert.True(scene.RemoveGameObject(character));
    }

    [Fact]
    public void ObjectIsRemovedFromScene()
    {
      MockScene scene = new MockScene(null);
      MockIGameObject character = new MockIGameObject("A name");
      scene.AddGameObject(character);
      scene.RemoveGameObject(character);
      Assert.DoesNotContain(character, scene.GameObjects);
    }

    [Fact]
    public void CanAddIDrawablesCorrectly()
    {
      MockScene scene = new MockScene(null);
      MockIDrawable character = new MockIDrawable("Dave");
      Assert.True(scene.AddGameObject(character));
    }

    [Fact]
    public void IDrawablesGetAddedToGameObjects()
    {
      MockScene scene = new MockScene(null);
      MockIDrawable character = new MockIDrawable("Dave");
      scene.AddGameObject(character);
      Assert.Contains(character, scene.GameObjects);
    }

    [Fact]
    public void IDrawablesGetRemovedFromGameObjects()
    {
      MockScene scene = new MockScene(null);
      MockIDrawable character = new MockIDrawable("Dave");
      scene.AddGameObject(character);
      scene.RemoveGameObject(character);
      Assert.DoesNotContain(character, scene.GameObjects);
    }
  }
}