using SLH.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SLH.Service.Common
{
    public class EmailSent
    {
        public static async Task<EmailLog> SendEmailAsync(EmailParams emailParams)
        {
            try
            {
                SetEmailParams(emailParams);
                using (SmtpClient smtpClient = new SmtpClient(emailParams.Host, emailParams.Port))
                {
                    using (MailMessage message = new MailMessage())
                    {
                        foreach (var item in emailParams.To.Split(';'))
                        {
                            if (!string.IsNullOrWhiteSpace(item))
                            {
                                message.To.Add(new MailAddress(item.Trim()));
                            }
                        }

                        ////message.To.Add(new MailAddress(emailParams.To));
                        message.From = new MailAddress(emailParams.From, emailParams.FromName);
                        message.Subject = emailParams.Subject;
                        string linkBody = string.Empty;
                        string fileName = string.Empty;

                        emailParams.Body += linkBody;
                        message.Body = emailParams.Body;
                        message.IsBodyHtml = true;

                        if (!string.IsNullOrWhiteSpace(emailParams.Bcc))
                        {
                            message.Bcc.Add(new MailAddress(emailParams.Bcc));
                        }
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.EnableSsl = emailParams.EnableSsl;

                        if (!string.IsNullOrWhiteSpace(emailParams.AttachFileName) && emailParams.AttachFileBytes != null)
                        {
                            Stream stream = new MemoryStream(emailParams.AttachFileBytes);
                            message.Attachments.Add(new Attachment(stream, emailParams.AttachFileName));
                        }

                        smtpClient.Credentials = new NetworkCredential(emailParams.Username, emailParams.Password);
                        await smtpClient.SendMailAsync(message);

                        return new EmailLog(emailParams, true, "Success");
                    }
                }
            }
            catch (Exception ex)
            {
                return new EmailLog(emailParams, false, ex.Message);
            }
        }

        private static void SetEmailParams(EmailParams emailParams)
        {
            emailParams.Host = AppSettings.SMTPmail;
            emailParams.Port = Convert.ToInt32(AppSettings.SMTPPort);
            emailParams.From = string.IsNullOrWhiteSpace(emailParams.From) ? AppSettings.MailFrom : emailParams.From;
            emailParams.FromName = emailParams.From;
            emailParams.Username = AppSettings.SMTPUserName;
            emailParams.Password = AppSettings.SMTPPassword;
            emailParams.EnableSsl = AppSettings.EnableSsl;
        }
    }
}
