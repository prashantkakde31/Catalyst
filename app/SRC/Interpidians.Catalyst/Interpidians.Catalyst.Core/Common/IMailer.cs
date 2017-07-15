using System;

namespace Interpidians.Catalyst.Core.Common
{
    public interface IMailer
    {
        void Send(string to, string message);
    }
}
