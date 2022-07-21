using Dapper;
using learn.core.Data;
using learn.core.domain;
using learn.core.DTO;
using learn.core.Repoisitory;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace learn.infra.Repoisitory
{
    public class empeamilrepo : Iempemailrepo
    {
        private readonly IDBContext dbContext;

        public empeamilrepo(IDBContext dbcontext)
        {
            this.dbContext = dbcontext;
        }

        public bool cheack(empverifiy emp)
        {
            var parameter = new DynamicParameters();
            parameter.Add("veerf", emp.verficationcode, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("emailof", emp.email, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<empverifiy> result = dbContext.dBConnection.Query<empverifiy>("EMP_EMAIL_tapi.cheack", parameter, commandType: System.Data.CommandType.StoredProcedure);
            if (result.FirstOrDefault() != null)
            {
                return true;
            }
            return false;
            
        }

        public bool checkemailisexist(empverifiy emp)
        {
            var parameter = new DynamicParameters();
            parameter.Add("emailof", emp.email, dbType: DbType.String, direction: ParameterDirection.Input);
            //select * from course_api where id=idofcourse;
            IEnumerable<empverifiy> result = dbContext.dBConnection.Query<empverifiy>("EMP_EMAIL_tapi.updateemail", parameter, commandType: CommandType.StoredProcedure);
            //course_api result1 = dbContext.dbConnection.QueryFirstOrDefault<course_api>("course_package_api.getbyid", parameter, commandType: CommandType.StoredProcedure);
            //return result;
            if (result.Count() == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }
        public bool checkverify(empverifiy emp)
        {
            var parameter = new DynamicParameters();
            parameter.Add("veerf", emp.verficationcode, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("emailof", emp.email, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("EMP_EMAIL_tapi.updayeverifiy", parameter, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool del(int id)
        {
            throw new NotImplementedException();
        }

        public bool ins(emp_email emp_Email)
        {
            Random rnd = new Random();
            int r = rnd.Next();

            var parameter = new DynamicParameters();

            parameter.Add("p_EMAIL", emp_Email.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("p_PASSWORD", emp_Email.passweord, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("p_VERIFICATION", r, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("EMP_EMAIL_tapi.ins", parameter, commandType: CommandType.StoredProcedure);

            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("User", "osamaalessa@outlook.com");
            MailboxAddress to = new MailboxAddress("user", emp_Email.email);
            builder.HtmlBody = "hello world "+ "the VERIFICATION code is "+ r.ToString();
            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = "VERIFICATION Code";
            using (var item = new MailKit.Net.Smtp.SmtpClient())
            {
                item.Connect("smtp.office365.com", 587, false);
                item.Authenticate("osamaalessa@outlook.com", "osama12345");
                item.Send(message);
                item.Disconnect(true);

            }



            return true;
        }

        public bool upd(emp_email emp_Email)
        {
            Random rnd = new Random();
            int r = rnd.Next();

            var parameter = new DynamicParameters();

            parameter.Add("p_EMAIL", emp_Email.email, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("p_PASSWORD", emp_Email.passweord, dbType: DbType.String, direction: ParameterDirection.Input);
            parameter.Add("p_VERIFICATION", r, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.dBConnection.ExecuteAsync("EMP_EMAIL_tapi.upd", parameter, commandType: CommandType.StoredProcedure);

            MimeMessage message = new MimeMessage();
            BodyBuilder builder = new BodyBuilder();
            MailboxAddress from = new MailboxAddress("User", "osamaalessa@outlook.com");
            MailboxAddress to = new MailboxAddress("user", emp_Email.email);
            builder.HtmlBody = "hello world " + "the VERIFICATION code is " + r.ToString();
            message.Body = builder.ToMessageBody();
            message.From.Add(from);
            message.To.Add(to);
            message.Subject = "VERIFICATION Code";
            using (var item = new MailKit.Net.Smtp.SmtpClient())
            {
                item.Connect("smtp.office365.com", 587, false);
                item.Authenticate("osamaalessa@outlook.com", "osama12345");
                item.Send(message);
                item.Disconnect(true);

            }



            return true;
        }
    }
}
