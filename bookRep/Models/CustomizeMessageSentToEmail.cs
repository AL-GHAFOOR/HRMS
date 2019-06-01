using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;
using bookRep;
using bookRep.Models;
using ServiceReportingSystem.Models;
using MailAddress = System.Net.Mail.MailAddress;

using MailMessage = System.Net.Mail.MailMessage;

using SmtpClient = System.Net.Mail.SmtpClient;

namespace PanArabInternationalApp.EmailConfig
{
    public class CustomizeMessageSentToEmail
    {

        public void SentMail(Exception ex)
        {
            string tempName = ex.GetBaseException().ToString();
            MailMessage mail = new MailMessage();

            mail.Body = tempName;

            //Mail(mail, "commencement@eastdelta.edu.bd");

        }
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
  
        eLibraryDbEntities db=new eLibraryDbEntities();

        public string ForgotVefificaionCode(ModelUser userverify)
        {

            string code = RandomString(8);
          
           
            MailMessage mail = new MailMessage();
            mail.Subject = "Password Recovery Request";
            mail.Body = "Your password has been changed and your password is "+ code;

            //"    \n" +"Off Campus : " + Outurl;
            string message = Mail(mail, userverify.email_address);
            if (message == "success")
            {
                var student = db.tbl_Student.FirstOrDefault(a => a.email_address == userverify.email_address);
                if (student!=null)
                {

                    student.Password = code;
                }

                db.SaveChanges();

            }
            return message;
        }
       
        public  string Mail(MailMessage mail, string toemail)
        {
         //   ComponentInfo.SetLicense("FREE-LIMITED-KEY");
            string error = "";
            try
            {
                //using (GemBox.Email.Smtp.SmtpClient smtp = new GemBox.Email.Smtp.SmtpClient("smtp.gmail.com", 587))
                //{

                //    // Connect and login.
                //    smtp.Connect();
                //    // Console.WriteLine("Connected.");

                //    smtp.Authenticate("it.office@eastdelta.edu.bd", "e@t2wiceASDFG");


                //    GemBox.Email.MailMessage message = new GemBox.Email.MailMessage("it.office@eastdelta.edu.bd", toemail);
                //    message.Subject = mail.Subject;
                //    message.BodyText = mail.Body;


                //    // Send message
                //    smtp.SendMessage(message);
                //    return "success";


                //}
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                mail.From = new MailAddress("it.office@eastdelta.edu.bd");
                //mail.From = new MailAddress("tohidul.a@eastdelta.edu.bd");
                mail.To.Add(toemail);
                mail.BodyEncoding = System.Text.Encoding.UTF8;
                mail.SubjectEncoding = System.Text.Encoding.UTF8;
                SmtpServer.Port = 587;

                SmtpServer.Credentials = new System.Net.NetworkCredential("it.office@eastdelta.edu.bd", "e@t2wiceASDFG");
                //SmtpServer.Credentials = new System.Net.NetworkCredential("tohidul.a@eastdelta.edu.bd", "e@t2wice");
                SmtpServer.EnableSsl = true;
                // SmtpServer.SendAsync(mail,SmtpServer);
                SmtpServer.Send(mail);
                return "success";


            }
            catch (Exception ex)
            {
                 SentMail(ex);
                error = ex.GetBaseException().ToString();

            }
            return error;

        }
        public bool Mail(MailMessage mail)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.To.Add("convocation@eastdelta.edu.bd");
                
                //mail.To.Add("tohidul.a@eastdelta.edu.bd");
                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential("convocation@eastdelta.edu.bd", "e@t2wice");
                SmtpServer.EnableSsl = true;
                SmtpServer.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
      
    }
}