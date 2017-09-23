using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Mail;
using System.Net;
namespace Quartz_Task.Base
{
    public class Mail
    {
        public static void  SendMail(string to, string body )
        {
 
            MailMessage mail = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            string strFromEmail = "xxb@jgsteel.cn"; 
            string strEmailPassword = "Aa111111"; 
            string title = "关于过期未处理事项的提醒";
            string Fname = "信息及管理部";
     
            try
            {
                mail.From = new MailAddress("" + Fname + "<" + strFromEmail + ">");
                mail.To.Add(new MailAddress(to));
                mail.BodyEncoding = Encoding.UTF8;
                mail.IsBodyHtml = true;
                mail.SubjectEncoding = Encoding.UTF8;
                mail.Priority = MailPriority.Normal;
                mail.Body = body;
                mail.Subject = title;
                smtp.Host = "smtp.exmail.qq.com";
                smtp.Port = 25;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new System.Net.NetworkCredential(strFromEmail, strEmailPassword);
                //发送邮件
                smtp.Send(mail);   //同步发送
 
            }
            catch (Exception ex)
            {
                throw ex;
            }
 
   
        }
    }
}
