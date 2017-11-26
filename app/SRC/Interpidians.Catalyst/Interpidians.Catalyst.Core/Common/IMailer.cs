using System;

namespace Interpidians.Catalyst.Core.Common
{
    public interface IMailer
    {
        bool Send(string to, string subject,string message);
    }
}
