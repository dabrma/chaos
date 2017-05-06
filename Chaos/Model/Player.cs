using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaos.Model
{
    public class Player
    {
        // TODO: Każdy gracz powinien posiadać listę czarów, które może rzucić.

        public Player(string playerName, int id)
        {
            this.name = playerName;
            this.id = id;
        }
        private string name;
        private int id;

        public string Name { get { return name; } set { name = value; } }
    }
}
