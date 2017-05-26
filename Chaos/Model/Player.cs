using System.Collections.Generic;

namespace Chaos.Model
{
    public class Player
    {
        public List<Spell> AvailableSpells;
        public Spell SelectedSpell;

        public Player(string playerName)
        {
            Name = playerName;
            Points = 0;
            AvailableSpells = new List<Spell>();
            SelectedSpell = null;
        }

        public string Name { get; set; }
        public int Points { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}