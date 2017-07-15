using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.Entity
{
    /// <summary>
    /// Used in ExcelHelper or can be used for non mandatory properties to skip validation
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class IncludeInExcelAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            return true;
        }
    }
}
