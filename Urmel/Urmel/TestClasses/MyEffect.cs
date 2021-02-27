using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Urmel.TestClasses
{
  class MyEffect : Effect
  {
    readonly float _myValue = 16f;
    readonly EffectParameter _myParameter;
    public MyEffect(Effect effect) : base(effect)
    {
      _myParameter = Parameters["MyParameters"];
      _myParameter.SetValue(_myValue);
    }
  }
}
