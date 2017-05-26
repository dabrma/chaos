using System;
using System.Collections.Generic;

namespace Chaos.Model.DTOs
{
    [Serializable]
    internal class PlayerDTO
    {
        public string Name;
        public int Points;
        public List<string> Spells = new List<string>();
    }
}