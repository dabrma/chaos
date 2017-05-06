using System.Drawing;
using System.Windows.Forms;

namespace Chaos.Engine
{
    public class Tile
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

        #region Fields

        #endregion

        #region Properties

        public GameObject Occupant { get; set; }

        public PictureBox Field { get; set; }

        public Point FieldLocalization { get; set; }

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

        public void OcupantEnter(GameObject newOcuppant)
        {
            Occupant = newOcuppant;
            UpdateField();
        }

        public void OcuppantLeave()
        {
            Occupant = new Nothing();
            UpdateField();
        }

        protected void UpdateField()
        {
            Field.Image = Occupant.Sprite;
        }

        #endregion
    }
}