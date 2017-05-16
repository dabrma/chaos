using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chaos.Interfaces
{
    interface ILookupable<T>
    {
        /// <summary>
        /// Returns an array of elements by default
        /// </summary>
        /// <returns></returns>
        IEnumerable<T> GetElementsCollection();
        T GetElement(T elementReference);
        T GetElement(Point cooridnates);
    }
}
