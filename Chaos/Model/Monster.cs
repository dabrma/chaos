using Chaos.Engine;

namespace Chaos.Model
{
    public class Monster : GameObject
    {
        public Monster(Player owner)
        {
            Owner = owner;
            Caption = Owner.Name + "'s " + Name;
        }

        public string Name { get; set; }

        public int Health { get; set; }

        public int Moves { get; set; }

        public int MovesRemaining { get; set; }

        public int MagicResistance { get; set; }

        public int Attack { get; set; }

        public int Defense { get; set; }

        #region Fields

        #endregion
    }
}