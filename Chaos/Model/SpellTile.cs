using System.Drawing;

namespace Chaos.Engine
{
    internal class SpellTile : Tile
    {
        //TODO: Stworzyć klasę dziedziczącą po Tile, która zawiera czar (obrazek, efekt po kliknięciu itd.)
        //TODO: konstruktor bezargumentowy tworzy losowy tile czar ze spelem

        public SpellTile(Point coordinates) : base(coordinates)
        {
            FieldLocalization = coordinates;
            Occupant = new Nothing();
            UpdateField();
        }
    }
}