using System.Drawing;

namespace Chaos.Engine
{
    public class MonsterTemplate
    {
        public int MaxHealth { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Moves { get; set; }
        public int MovesRemaining { get; set; }
        public int MagicResistance { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public bool canAttack { get; set; }
        public bool isUndead { get; set; }
        public Bitmap sprite { get; set; }
    }
}