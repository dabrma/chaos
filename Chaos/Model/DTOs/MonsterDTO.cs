using System;
using System.Drawing;

namespace Chaos.Model
{
    [Serializable]
    public class MonsterDTO
    {
        public int Attack;
        public Point Coordinates;
        public int Health;
        public int MagicResistance;
        public int MaxHealth;
        public int Moves;
        public int MovesRemaining;
        public string Name;
        public string Owner;
    }
}