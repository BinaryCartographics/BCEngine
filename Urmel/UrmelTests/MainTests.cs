using Urmel;
using Xunit;

namespace UrmelTests
{
  public class MainTests
  {
    [Fact]
    public void MainConstructorDoesntCrash()
    {
      var game = new Main();
      Assert.NotNull(game);
    }
  }
}
