using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaos.Model.DTOs
{
    [Serializable]
    class PlayerDTO
    {
        public string Name;
        public List<string> Spells = new List<string>();
    }
}
