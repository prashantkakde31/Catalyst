using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.Entity
{
    /// <summary>
    /// This entity will use for Add-Edit entity base class
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets or sets the created by
        /// </summary>
        public int? CreatedBy { get; set; }

        /// <summary>
        /// Gets or sets the created on
        /// </summary>
        public DateTime? CreatedOn { get; set; }

        /// <summary>
        /// Gets or sets the updated by
        /// </summary>
        public int? UpdatedBy { get; set; }

        /// <summary>
        /// Gets or sets the updated on
        /// </summary>
        public DateTime? UpdatedOn { get; set; }
    }
}
