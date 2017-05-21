using System.Collections.Generic;

namespace Chaos.Model
{
    public class Player
    {
        public List<Spell> AvailableSpells;
        private int id;
        public Spell SelectedSpell;

        // TODO: Każdy gracz powinien posiadać listę czarów, które może rzucić.

        public Player(string playerName)
        {
            Name = playerName;
            AvailableSpells = new List<Spell>();
            SelectedSpell = null;
        }

        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}