using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaos.Model.DTOs
{
    [Serializable]
    class GameState
    {
        public List<MonsterDTO> monsters = new List<MonsterDTO>();
        public List<PlayerDTO> players = new List<PlayerDTO>();
    }
}
