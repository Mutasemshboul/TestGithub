using learn.core.DTO;
using learn.core.service;
using MimeKit;
using MailKit.Net.Smtp;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text;
using learn.core.Repoisitory;

namespace learn.infra.service
{
    public class emailclass : Iemailservice
    {

        private readonly Iempemailrepo emp;
        public emailclass(Iempemailrepo emp)
        {
            this.emp = emp;
        }
        public string GetEmail(empverifiy e)
        {
            bool result = emp.checkemailisexist(e);
            if (result == false)
            {
                return "email is invalid";

            }
            else if(result == true)
            {
                Random rand = new Random();
                e.verficationcode = Convert.ToString(rand.Next(1000, 9999));
                emp.checkverify(e);
                MimeMessage message = new MimeMessage();
                BodyBuilder builder = new BodyBuilder();
                MailboxAddress from = new MailboxAddress("User", "osamaalessa@outlook.com");
                MailboxAddress to = new MailboxAddress("user", e.email);
                builder.HtmlBody = "hello world" + e.verficationcode;
                message.Body = builder.ToMessageBody();
                message.From.Add(from);
                message.To.Add(to);
                message.Subject = "checking";
                using (var item = new MailKit.Net.Smtp.SmtpClient())
                {
                    item.Connect("smtp.office365.com", 587, false);
                    item.Authenticate("osamaalessa@outlook.com", "osama12345");
                    item.Send(message);
                    item.Disconnect(true);

                }
                return "true";
            }
            return "true";
        }
    }
}
