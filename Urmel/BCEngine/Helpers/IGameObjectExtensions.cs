using BCEngine.Interfaces;
using BCEngine.Math;

namespace BCEngine.Helpers
{
  public static class IGameObjectExtensions
  {
    public static bool AddGameObjectDefaultImplementation(this IGameObject Parent, IGameObject gameObject)
    {
      if (!Parent.Children.Contains(gameObject))
      {
        if (gameObject.Parent != null)
        {
          gameObject.Parent.RemoveGameObject(gameObject);
        }
        gameObject.Parent = Parent;
        Parent.Children.Add(Parent);
        return true;
      }
      return false;
    }

    public static bool RemoveGameObjectDefaultImplementation(this IGameObject Parent, IGameObject gameObject)
    {
      if (Parent.Children.Contains(gameObject))
      {
        gameObject.Parent = null;
        Parent.Children.Remove(gameObject);
        return true;
      }
      return false;
    }

    public static Transform WorldTransformDefaultImplementation(this IGameObject gameObject)
    {
      if (gameObject.Parent == null)
      {
        return gameObject.Transform;
      }
      return Transform.Compose(gameObject.Parent.Transform, gameObject.Transform);
    }
  }
}
