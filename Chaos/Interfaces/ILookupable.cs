using System.Collections.Generic;
using System.Drawing;

namespace Chaos.Interfaces
{
    internal interface ILookupable<T>
    {
        /// <summary>
        ///     Returns an array of elements by default
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetElementsCollection();

        T GetElement(T elementReference);
        T GetElement(Point cooridnates);
    }
}