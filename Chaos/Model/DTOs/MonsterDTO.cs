using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExtendedXmlSerialization;
using System.Drawing;

namespace Chaos.Model
{
    [Serializable]
    public class MonsterDTO
    {
        public string Owner;
        public Point Coordinates;
        public string Name;
        public int MaxHealth;
        public int Health;
        public int MagicResistance;
        public int Attack;
        public int Moves;
        public int MovesRemaining;
    }
}
