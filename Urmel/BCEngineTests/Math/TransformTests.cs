using BCEngine.Math;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace BCEngineTests.Math
{
  public class TransformTests
  {
    [Theory]
    [MemberData(nameof(ComposeTransformsData))]
    public void CanComposeTransforms(Transform parent, Transform child, Transform expectedResult)
    {
      Transform composeResult = Transform.Compose(parent, child);
      Assert.Equal(expectedResult, composeResult);
    }

    [Theory]
    [MemberData(nameof(LerpTransformsData))]
    public void CanLerpTransforms(Transform from, Transform to, float amount, Transform expectedResult)
    {
      Transform lerpResult = Transform.Lerp(from, to, amount);
      Assert.Equal(expectedResult, lerpResult);
    }

    [Theory]
    [MemberData(nameof(TransformVectorData))]
    public void CanTransformVector(Transform transform, Vector2 vector, Vector2 expectedResult)
    {
      Vector2 TransformVectorResult = Transform.TransformVector(transform, vector);
      Assert.Equal(TransformVectorResult, expectedResult);
    }

    [Theory]
    [MemberData(nameof(InverseTransformVectorData))]
    public void CanInverseTransformVector(Transform transform, Vector2 vector, Vector2 expectedResult)
    {
      Vector2 InverseTransformVectorResult = Transform.InverseTransformVector(transform, vector);
      Assert.Equal(InverseTransformVectorResult, expectedResult);
    }

    [Theory]
    [MemberData(nameof(GetRelativePositionData))]
    public void CanGetRelativePosition(Transform transform, Vector2 vector, Vector2 expectedResult)
    {
      Vector2 GetRelativePositionResult = Transform.GetRelativePosition(transform, vector);
      Assert.Equal(GetRelativePositionResult, expectedResult);
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

    public static IEnumerable<object[]> LerpTransformsData()
    {
      Transform from1 = new Transform()
      {
        Position = new Vector2(10.85f, 99.4f),
        Rotation = 5.4f,
        Scale = Vector2.One
      };
      Transform to1 = new Transform()
      {
        Position = new Vector2(15f, 12f),
        Rotation = 0.1f,
        Scale = new Vector2(5, 1)
      };
      float amount1 = 0.5f;
      Transform expected1 = new Transform()
      {
        Position = new Vector2(12.925f, 55.7f),
        Rotation = 2.75f,
        Scale = new Vector2(3f, 1f)
      };

      Transform from2 = new Transform()
      {
        Position = new Vector2(15f, 4f),
        Rotation = 0.4f,
        Scale = new Vector2(114, 22)
      };
      Transform to2 = new Transform()
      {
        Position = new Vector2(1f, 120f),
        Rotation = 00f,
        Scale = new Vector2(445, 12)
      };
      float amount2 = 0.75f;
      Transform expected2 = new Transform()
      {
        Position = new Vector2(4.5f, 91f),
        Rotation = 0.099999994f,
        Scale = new Vector2(362.25f, 14.5f)
      };

      Transform from3 = new Transform()
      {
        Position = new Vector2(1f, 43f),
        Rotation = -90f,
        Scale = new Vector2(14, 220)
      };
      Transform to3 = new Transform()
      {
        Position = new Vector2(-231f, 120f),
        Rotation = 90f,
        Scale = new Vector2(405, 12)
      };
      float amount3 = 5.5f;
      Transform expected3 = new Transform()
      {
        Position = new Vector2(-1275f, 466.5f),
        Rotation = 900f,
        Scale = new Vector2(2164.5f, -924f)
      };

      Transform from4 = new Transform()
      {
        Position = new Vector2(-10f, -43f),
        Rotation = -50f,
        Scale = new Vector2(1, 1)
      };
      Transform to4 = new Transform()
      {
        Position = new Vector2(21f, -20f),
        Rotation = -12f,
        Scale = new Vector2(405, 12)
      };
      float amount4 = 0f;
      Transform expected4 = new Transform()
      {
        Position = new Vector2(-10f, -43f),
        Rotation = -50f,
        Scale = new Vector2(1f, 1f)
      };

      var allData = new List<object[]>
      {
        new object[]{ from1, to1, amount1, expected1 },
        new object[]{ from2, to2, amount2, expected2 },
        new object[]{ from3, to3, amount3, expected3 },
        new object[]{ from4, to4, amount4, expected4 }
      };

      return allData;
    }

    public static IEnumerable<object[]> TransformVectorData()
    {
      Transform transform1 = new Transform()
      {
        Position = new Vector2(10.85f, 99.4f),
        Rotation = 5.4f,
        Scale = Vector2.One
      };
      Vector2 vector1 = new Vector2(15f, 12f);
      Vector2 expected1 = new Vector2(29.643568f, 95.42485f);

      Transform transform2 = new Transform()
      {
        Position = new Vector2(15f, 4f),
        Rotation = 0.4f,
        Scale = new Vector2(114, 22)
      };
      Vector2 vector2 = new Vector2(1f, 120f);
      Vector2 expected2 = new Vector2(-5207.2417f, 2444.1682f);

      Transform transform3 = new Transform()
      {
        Position = new Vector2(1f, 43f),
        Rotation = -90f,
        Scale = new Vector2(14, 220)
      };
      Vector2 vector3 = new Vector2(-231f, 120f);
      Vector2 expected3 = new Vector2(2951.9844f, 33646.766f);

      Transform transform4 = new Transform()
      {
        Position = new Vector2(-10f, -43f),
        Rotation = -50f,
        Scale = new Vector2(1, 1)
      };
      Vector2 vector4 = new Vector2(21f, -20f);
      Vector2 expected4 = new Vector2(15.511784f, -56.789448f);

      var allData = new List<object[]>
      {
        new object[]{ transform1, vector1, expected1 },
        new object[]{ transform2, vector2, expected2 },
        new object[]{ transform3, vector3, expected3 },
        new object[]{ transform4, vector4, expected4 }
      };

      return allData;
    }

    public static IEnumerable<object[]> InverseTransformVectorData()
    {
      Transform transform1 = new Transform()
      {
        Position = new Vector2(10.85f, 99.4f),
        Rotation = 5.4f,
        Scale = Vector2.One
      };
      Vector2 vector1 = new Vector2(15f, 12f);
      Vector2 expected1 = new Vector2(70.173584f, -52.265198f);

      Transform transform2 = new Transform()
      {
        Position = new Vector2(15f, 4f),
        Rotation = 0.4f,
        Scale = new Vector2(114, 22)
      };
      Vector2 vector2 = new Vector2(1f, 120f);
      Vector2 expected2 = new Vector2(0.28313747f, 5.104315f);

      Transform transform3 = new Transform()
      {
        Position = new Vector2(1f, 43f),
        Rotation = -90f,
        Scale = new Vector2(14, 220)
      };
      Vector2 vector3 = new Vector2(-231f, 120f);
      Vector2 expected3 = new Vector2(2.508238f, -1.0995859f);

      Transform transform4 = new Transform()
      {
        Position = new Vector2(-10f, -43f),
        Rotation = -50f,
        Scale = new Vector2(1, 1)
      };
      Vector2 vector4 = new Vector2(21f, -20f);
      Vector2 expected4 = new Vector2(35.948566f, 14.060597f);

      var allData = new List<object[]>
      {
        new object[]{ transform1, vector1, expected1 },
        new object[]{ transform2, vector2, expected2 },
        new object[]{ transform3, vector3, expected3 },
        new object[]{ transform4, vector4, expected4 }
      };

      return allData;
    }

    public static IEnumerable<object[]> GetRelativePositionData()
    {
      Transform transform1 = new Transform()
      {
        Position = new Vector2(10.85f, 99.4f),
        Rotation = 5.4f,
        Scale = Vector2.One
      };
      Vector2 vector1 = new Vector2(15f, 12f);
      Vector2 expected1 = new Vector2(-162.75f, -1192.8f);

      Transform transform2 = new Transform()
      {
        Position = new Vector2(15f, 4f),
        Rotation = 0.4f,
        Scale = new Vector2(114, 22)
      };
      Vector2 vector2 = new Vector2(1f, 120f);
      Vector2 expected2 = new Vector2(-15f, -480f);

      Transform transform3 = new Transform()
      {
        Position = new Vector2(1f, 43f),
        Rotation = -90f,
        Scale = new Vector2(14, 220)
      };
      Vector2 vector3 = new Vector2(-231f, 120f);
      Vector2 expected3 = new Vector2(231f, -5160f);

      Transform transform4 = new Transform()
      {
        Position = new Vector2(-10f, -43f),
        Rotation = -50f,
        Scale = new Vector2(1, 1)
      };
      Vector2 vector4 = new Vector2(21f, -20f);
      Vector2 expected4 = new Vector2(210f, -860f);

      var allData = new List<object[]>
      {
        new object[]{ transform1, vector1, expected1 },
        new object[]{ transform2, vector2, expected2 },
        new object[]{ transform3, vector3, expected3 },
        new object[]{ transform4, vector4, expected4 }
      };

      return allData;
    }
  }
}
