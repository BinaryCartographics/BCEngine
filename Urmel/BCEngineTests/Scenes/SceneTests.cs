using BCEngine;
using BCEngine.Scenes;
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
      Scene scene = new Scene();
      Assert.NotNull(scene);
    }

    [Theory]
    [MemberData(nameof(ColorData))]
    public void SetBackgroundColorIsReturnedOnGet(Color expectedColor)
    {
      Scene scene = new Scene { BackgroundColor = expectedColor };
      Assert.Equal(expectedColor, scene.BackgroundColor);
    }

    [Fact]
    public void CanAddObjectToScene()
    {
      Scene scene = new Scene();
      Character character = new Character("A name");
      Assert.True(scene.AddGameObject(character));
    }

    [Fact]
    public void CannotAddSameObjectTwice()
    {
      Scene scene = new Scene();
      Character character = new Character("A name");
      scene.AddGameObject(character);
      Assert.False(scene.AddGameObject(character));
    }

    public static IEnumerable<object[]> ColorData()
    {
      var allData = new List<object[]>
        {
          new object[] { Color.Red },
          new object[] { Color.Blue },
          new object[] { Color.Green },
        };

      return allData;
    }
  }
}