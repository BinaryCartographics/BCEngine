using BCEngine.Math;
using Xunit;

namespace BCEngineTests.Math
{
  public class TransformTests
  {
    [Fact]
    public void TransformConstructorDoesntCrash()
    {
      Transform transform = new Transform();
      Assert.NotNull(transform);
    }

    [Fact]
    public void CanAddTransformToTransform()
    {
      Transform transform1 = new Transform();
      Transform transform2 = new Transform();
      transform1.AddTransform(transform2);

      Assert.Contains(transform2, transform1.GetChildren());
      Assert.Equal(transform1, transform2.Parent);
    }
  }
}
