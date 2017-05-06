using System.Drawing;
using Chaos.Model;

namespace Chaos.Engine
{
    public abstract class GameObject
    {
        #region Fields

        #endregion

        #region Properties

        public Bitmap Sprite { get; set; }

        public string Caption { get; set; }

        public Player Owner { get; set; }

        #endregion

        #region Methods

        #endregion
    }
}