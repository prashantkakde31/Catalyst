using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.Entity
{
    public class KeyValueData<T, Q>
    {
        /// <summary>
        /// Get or Set the Key with T type
        /// </summary>
        public T Key { get; set; }

        /// <summary>
        ///  Get or Set the Value with Q type
        /// </summary>
        public Q Value { get; set; }
    }
}
