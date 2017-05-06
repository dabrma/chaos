using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaos.Engine
{
    class Nothing : GameObject
    {
        public Nothing()
        {
            base.Caption = "Nothing";
            base.Sprite = Properties.Resources.Nothing;
        }
    } 
}
