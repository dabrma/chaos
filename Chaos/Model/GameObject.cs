using Chaos.Model;
using System.Drawing;

namespace Chaos.Engine
{
    public abstract class GameObject
    {
        public GameObject() { }
        #region Fields
        Bitmap sprite;
        Player owner;
        string caption;
        #endregion

        #region Properties
        public Bitmap Sprite { get { return sprite; } set { sprite = value; } }
        public string Caption { get { return caption; } set { caption = value; } }
        public Player Owner { get { return owner; } set { owner = value; } }
        #endregion

        #region Methods
        #endregion
    }
}