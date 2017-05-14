using System.Collections;
using Chaos.Engine;

namespace Chaos.Model
{
    public class Spell : GameObject
    {
        public bool CanCastOnNothing { get; set; }
        public bool CanCastOnMonster { get; set; }
        public int EffectPower { get; set; }
        public string EffectLabel { get; set; }
    }
}