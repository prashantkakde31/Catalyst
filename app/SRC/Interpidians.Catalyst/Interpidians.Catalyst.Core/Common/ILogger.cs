using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpidians.Catalyst.Core.Common
{
    public interface ILogger
    {
        void Info(Object message);
        void Error(Object message);
    }
}
