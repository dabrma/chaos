using Chaos.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaos.Model
{
    public class Monster : GameObject
    {
        
        public Monster(Player owner)
        {
            base.Owner = owner;
            base.Caption = base.Owner.Name + "'s " + this.Name;
        }

        #region Fields
        private string name;
        private int health;
        private int moves;
        private int movesRemaining;
        private int attack;
        private int defense;
        private int magicResistance;
        #endregion

        public string Name { get { return name; } set { name = value; } }
        public int Health { get { return health; } set { health = value; } }
        public int Moves{ get { return moves; } set { moves = value; } }
        public int MovesRemaining { get { return movesRemaining; } set { movesRemaining = value; } }
        public int MagicResistance { get { return magicResistance; } set { magicResistance = value; } }

        public int Attack { get { return attack; } set { attack = value; } }
        public int Defense { get { return defense; } set { defense = value; } }



    }
}
