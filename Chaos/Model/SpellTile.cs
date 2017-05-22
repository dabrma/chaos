using System.Drawing;

namespace Chaos.Engine
{
    public class SpellTile : Tile
    {

        public SpellTile(Point coordinates) : base(coordinates)
        {
            FieldLocalization = coordinates;
            SetOccupant();
            // UpdateField();
        }
    }
}