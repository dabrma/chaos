using Chaos.Engine;

namespace Chaos.Interfaces
{
    internal interface IOccupiable
    {
        /// <summary>
        ///     Retrive occupant information from current Tile
        /// </summary>
        /// <returns></returns>
        GameObject GetOccupant();

        /// <summary>
        ///     Creates a new Occupant of Nothing type
        /// </summary>
        void SetOccupant();

        /// <summary>
        ///     Sets gameobject from argument as a Tile occupant
        /// </summary>
        /// <param name="occupant"></param>
        void SetOccupant(GameObject occupant);
    }
}