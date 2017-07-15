using Interpidians.Catalyst.Core.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Interpidians.Catalyst.Infrastructure.Mailer
{
    public class SmtpMailer : IMailer
    {
        public void Send(string to, string message)
        {
            // Send mail logic......

            // For testing:
            Debug.WriteLine("SmtpMailer >> E-Mail to: {0}, Message: {1}", to, message);
        }
    }
}
