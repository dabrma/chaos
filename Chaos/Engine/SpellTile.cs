using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaos.Engine
{
    class SpellTile : Tile
    {
        //TODO: Stworzyć klasę dziedziczącą po Tile, która zawiera czar (obrazek, efekt po kliknięciu itd.)
        //TODO: konstruktor bezargumentowy tworzy losowy tile czar ze spelem

        public SpellTile(Point coordinates) : base(coordinates)
        {
            this.FieldLocalization = coordinates;
            this.Occupant = new Nothing();
            this.UpdateField();
        }
    }
}
