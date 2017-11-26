using Interpidians.Catalyst.Core.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Net;
using System.Net.Mail;

namespace Interpidians.Catalyst.Infrastructure.Mailer
{
    public class SmtpMailer : IMailer
    {
        private readonly SmtpConfiguration _config;
        private const string MailUserNameKey = "MailUserName";
        private const string MailPasswordKey = "MailPassword";
        private const string MailHostKey = "MailHost";
        private const string MailPortKey = "MailPort";
        private const string MailSslKey = "MailSsl";

        public SmtpMailer()
        {
            _config = new SmtpConfiguration();
            var mailUserName = ConfigurationManager.AppSettings[MailUserNameKey];
            var mailPassword = ConfigurationManager.AppSettings[MailPasswordKey];
            var mailHost = ConfigurationManager.AppSettings[MailHostKey];
            var mailPort = Int32.Parse(ConfigurationManager.AppSettings[MailPortKey]);
            var mailSsl = Boolean.Parse(ConfigurationManager.AppSettings[MailSslKey]);
            _config.UserName = mailUserName;
            _config.Password = mailPassword;
            _config.Host = mailHost;
            _config.Port = mailPort;
            _config.Ssl = mailSsl;
        }
        public bool Send(string to,string subject,string message)
        {
            try
            {
                // Send mail logic......
                var smtp = new SmtpClient
                {
                    Host = _config.Host,
                    Port = _config.Port,
                    EnableSsl = _config.Ssl,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(_config.UserName, _config.Password)
                };

                using (var smtpMessage = new MailMessage(_config.UserName,to))
                {
                    smtpMessage.Subject = subject;
                    smtpMessage.Body = message;
                    smtpMessage.IsBodyHtml = true;
                    smtp.Send(smtpMessage);
                }

                // For testing:
                Debug.WriteLine("SmtpMailer >> E-Mail to: {0}, Message: {1}", to, message);

                return true;
            }
            catch (Exception ex)
            {
                //todo: add logging integration
                //throw;
                return false;
            }
        }
    }

    public class SmtpConfiguration
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
        public bool Ssl { get; set; }
    }
}
