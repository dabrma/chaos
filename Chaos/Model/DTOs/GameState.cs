using System;
using System.Collections.Generic;

namespace Chaos.Model.DTOs
{
    [Serializable]
    internal class GameState
    {
        public Player currentPlayer;
        public List<MonsterDTO> monsters = new List<MonsterDTO>();
        public List<PlayerDTO> players = new List<PlayerDTO>();
    }
}