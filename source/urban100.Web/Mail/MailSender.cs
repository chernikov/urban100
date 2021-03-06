﻿using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;
using urban100.Web.Global.Config;

namespace urban100.Web.Mail
{
    public class MailSender
    {

        protected IConfig Config
        {
            get
            {
                if (_config == null)
                {
                    _config = DependencyResolver.Current.GetService<IConfig>();
                }
                return _config;
            }
        }
        private IConfig _config;

        private static NLog.Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public void SendMail(string email, string subject, string body)
        {
            try
            {
                if (Config.EnableMail)
                {
                    var client = new SmtpClient();

                    var message = new MailMessage()
                    {
                        Subject = subject,
                        BodyEncoding = Encoding.UTF8,
                        Body = body,
                        IsBodyHtml = true,
                        SubjectEncoding = Encoding.UTF8
                    };
                    message.To.Add(new MailAddress(email));
                    
                    client.Send(message);
                }
                else
                {
                    logger.Debug("Email : {0} {1} \t Subject: {2} {3} Body: {4}", email, Environment.NewLine, subject, Environment.NewLine, body);
                }
            }
            catch (Exception ex)
            {
                logger.Error("Mail send exception: " +  ex.Message);
            }
        }
    }

}