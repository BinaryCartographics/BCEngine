using BCEngine.Math;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Xunit;

namespace BCEngineTests.Math
{
  public class TransformTests
  {
    /// <summary>
    /// Temporarily Commented out to preserve unit tests for a time when the code can be reused with GameObject implementations
    /// </summary>

    /*
    [Fact]
    public void TransformConstructorDoesntCrash()
    {
      Transform transform = new Transform();
      Assert.NotNull(transform);
    }

    [Fact]
    public void CanAddChildTransformToTransform()
    {
      Transform transform1 = new Transform();
      Transform transform2 = new Transform();
      transform1.AddTransform(transform2);

      Assert.Contains(transform2, transform1.GetChildren());
      Assert.Equal(transform1, transform2.Parent);
    }
    
    [Fact]
    public void CanRemoveChildTransformFromTransform()
    {
      Transform transform1 = new Transform();
      Transform transform2 = new Transform();
      transform1.AddTransform(transform2);

      Assert.Contains(transform2, transform1.GetChildren());
      Assert.Equal(transform1, transform2.Parent);

      transform1.RemoveTransform(transform2);
      Assert.DoesNotContain(transform2, transform1.GetChildren());
      Assert.NotEqual(transform1, transform2.Parent);
    }
    */
    [Theory]
    [MemberData(nameof(ComposeTransformsData))]
    public void CanComposeTransformPositions(Transform parent, Transform child, Transform expectedResult)
    {
      Transform composeResult = Transform.Compose(parent, child);
      Assert.Equal(expectedResult, composeResult);
    }

    public static IEnumerable<object[]> ComposeTransformsData()
    {
      Transform parent1 = new Transform()
      {
        Position = new Vector2(10.85f, 99.4f),
        Rotation = 5.4f,
        Scale = Vector2.One
      };
      Transform child1 = new Transform()
      {
        Position = new Vector2(15f, 12f),
        Rotation = 0.1f,
        Scale = new Vector2(5, 1)
      };
      Transform expected1 = new Transform()
      {
        Position = new Vector2(29.643568f, 95.42485f),
        Rotation = 5.5f,
        Scale = new Vector2(5, 1)
      };

      Transform parent2 = new Transform()
      {
        Position = new Vector2(15f, 4f),
        Rotation = 0.4f,
        Scale = new Vector2(114, 22)
      };
      Transform child2 = new Transform()
      {
        Position = new Vector2(1f, 120f),
        Rotation = 00f,
        Scale = new Vector2(445, 12)
      };
      Transform expected2 = new Transform()
      {
        Position = new Vector2(-908.0635f, 2479.9949f),
        Rotation = 0.4f,
        Scale = new Vector2(50730, 264)
      };

      Transform parent3 = new Transform()
      {
        Position = new Vector2(1f, 43f),
        Rotation = -90f,
        Scale = new Vector2(14, 220)
      };
      Transform child3 = new Transform()
      {
        Position = new Vector2(-231f, 120f),
        Rotation = 90f,
        Scale = new Vector2(405, 12)
      };
      Transform expected3 = new Transform()
      {
        Position = new Vector2(25051.582f, -8894.958f),
        Rotation = 0f,
        Scale = new Vector2(5670, 2640)
      };

      Transform parent4 = new Transform()
      {
        Position = new Vector2(-10f, -43f),
        Rotation = -50f,
        Scale = new Vector2(1, 1)
      };
      Transform child4 = new Transform()
      {
        Position = new Vector2(21f, -20f),
        Rotation = -12f,
        Scale = new Vector2(405, 12)
      };
      Transform expected4 = new Transform()
      {
        Position = new Vector2(15.511784f, -56.789448f),
        Rotation = -62f,
        Scale = new Vector2(405, 12)
      };

      var allData = new List<object[]>
      {
        new object[]{ parent1, child1, expected1 },
        new object[]{ parent2, child2, expected2 },
        new object[]{ parent3, child3, expected3 },
        new object[]{ parent4, child4, expected4 }
      };

      return allData;
    }
  }
}
