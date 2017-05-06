using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            this.fieldLocalization = position;
            ocuppant = new Nothing();
            FieldSetup();
        }

        #region Fields
        private GameObject ocuppant;
        private PictureBox field;
        private Point fieldLocalization;
        #endregion

        #region Properties
        public GameObject Occupant { get { return ocuppant; } set { ocuppant = value; } }
        public PictureBox Field { get { return field; } set { field = value; } }
        public Point FieldLocalization { get { return fieldLocalization; } set { fieldLocalization = value; } }
        #endregion

        #region Private Methods
        private void FieldSetup()
        {
            field = new PictureBox();
            field.BorderStyle = BorderStyle.FixedSingle;
            field.Location = new Point((fieldLocalization.X * FIELD_SIZE), (fieldLocalization.Y * FIELD_SIZE));
            field.Size = new Size(new Point(FIELD_SIZE, FIELD_SIZE));
            field.Image = ocuppant.Sprite;          
        }

        public void OcupantEnter(GameObject newOcuppant)
        {
            this.ocuppant = newOcuppant;
            UpdateField();
        }

        public void OcuppantLeave()
        {
            this.ocuppant = new Nothing();
            UpdateField();
            
        }

        protected void UpdateField()
        {
            field.Image = ocuppant.Sprite;
        }
        #endregion

    }
}
