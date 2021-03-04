using System;
using System.Collections.Generic;

namespace BCEngine.Helpers
{
  public class TwoWayDictionary<type1, type2>
  {
    private readonly Dictionary<type1, type2> Dict1;
    private readonly Dictionary<type2, type1> Dict2;

    public TwoWayDictionary()
    {
      Dict1 = new Dictionary<type1, type2>();
      Dict2 = new Dictionary<type2, type1>();
    }

    public void Add(type1 first, type2 second)
    {
      Dict1.Add(first, second);
      Dict2.Add(second, first);
    }

    public type2 this[type1 value]
    {
      get
      {
        if (Dict1.ContainsKey(value))
        {
          return Dict1[value];
        }

        throw new ArgumentException(nameof(value));
      }
    }

    public type1 this[type2 value]
    {
      get
      {
        if (Dict2.ContainsKey(value))
        {
          return Dict2[value];
        }

        throw new ArgumentException(nameof(value));
      }
    }
  }
}
