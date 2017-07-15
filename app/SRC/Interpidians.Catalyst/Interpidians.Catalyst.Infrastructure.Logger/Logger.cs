using System;
using log4net;
using Interpidians.Catalyst.Core.Common;

namespace Interpidians.Catalyst.Infrastructure.Logger
{
    public class Logger : ILogger
    {
        public Logger()
        {
            log4net.Config.XmlConfigurator.Configure();
        }
        private static readonly log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public void Info(Object message)
        {
            log.Info(Convert.ToString(message));
        }

        public void Error(Object message)
        {
            log.Error(Convert.ToString(message));
        }
    }
}
