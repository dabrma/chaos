using Chaos.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaos.Interfaces
{
    interface IOccupiable
    {
        /// <summary>
        /// Retrive occupant information from current Tile
        /// </summary>
        /// <returns></returns>
        GameObject GetOccupant();
        /// <summary>
        /// Creates a new Occupant of Nothing type
        /// </summary>
        void SetOccupant();
        /// <summary>
        /// Sets gameobject from argument as a Tile occupant
        /// </summary>
        /// <param name="occupant"></param>
        void SetOccupant(GameObject occupant);
    }
}
