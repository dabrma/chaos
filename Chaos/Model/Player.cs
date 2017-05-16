using System.Collections.Generic;

namespace Chaos.Model
{
    public class Player
    {
        private int id;

        // TODO: Każdy gracz powinien posiadać listę czarów, które może rzucić.

        public Player(string playerName)
        {
            Name = playerName;
            AvailableSpells = new List<Spell>();
            SelectedSpell = null;
        }

        public string Name { get; set; }

        public List<Spell> AvailableSpells;
        public Spell SelectedSpell;

        public override string ToString()
        {
            return Name;
        }
    }
}