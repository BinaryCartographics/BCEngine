using BCEngine.Interfaces;

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
  }
}
