using System.Drawing;
using System.Windows.Forms;
using Chaos.Interfaces;

namespace Chaos.Engine
{
    public class Tile : IOccupiable, ILocalizable
    {
        private const int FIELD_SIZE = 48;

        public Tile()
        {
        }

        public Tile(Point position)
        {
            FieldLocalization = position;
            Occupant = new Nothing();
            FieldSetup();
        }

        public Point GetCoordinates()
        {
            return FieldLocalization;
        }

        public GameObject GetOccupant()
        {
            return Occupant;
        }

        public void SetOccupant()
        {
            Occupant = new Nothing();
            UpdateField();
        }

        public void SetOccupant(GameObject occupant)
        {
            Occupant = occupant;
            UpdateField();
        }

        #region Fields

        #endregion

        #region Properties

        private GameObject Occupant { get; set; }

        public PictureBox Field { get; set; }

        protected Point FieldLocalization { get; set; }

        #endregion

        #region Private Methods

        private void FieldSetup()
        {
            Field = new PictureBox();
            Field.BorderStyle = BorderStyle.FixedSingle;
            Field.Location = new Point(FieldLocalization.X * FIELD_SIZE, FieldLocalization.Y * FIELD_SIZE);
            Field.Size = new Size(new Point(FIELD_SIZE, FIELD_SIZE));
            Field.Image = Occupant.Sprite;
        }

        private void UpdateField()
        {
            Field.Image = Occupant.Sprite;
        }

        #endregion
    }
}