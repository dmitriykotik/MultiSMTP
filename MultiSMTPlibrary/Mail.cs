using System.Net.Mail;
using System.Net;
using System.Threading.Tasks;

namespace MSL
{
    /// <summary>
    /// SMTP client with the need to use a static class
    /// </summary>
    public class SMTP_static
    {
        /// <summary>
        /// Sends an email from the specified mailbox to another mailbox
        /// </summary>
        /// <param name="UserNameFROM">Name of the user from whom the e-mail will be sent</param>
        /// <param name="MailFROM">Mail from which the letter will be sent</param>
        /// <param name="MailTO">The e-mail address to which this letter will arrive</param>
        /// <param name="smtpServer">SMTP server. This is the domain name where the mail server is located. For example, gmail is located at: smtp.gmail.com</param>
        /// <param name="smtpPort">SMTP port. This is the port on which the mail server is located. For example, for gmail it is 587</param>
        /// <param name="smtpMail">SMTP mail, it must match the sending mail.</param>
        /// <param name="smtpPassword">SMTP password. This is the password for the mail itself</param>
        /// <param name="subject">Subject line</param>
        /// <param name="body">The body of the letter. You can write both plain text and HTML code</param>
        /// <returns>true or false. true - if everything was successful, false - if an error occurred while sending the e-mail.</returns>
        public static bool send(string UserNameFROM, string MailFROM, string MailTO, string smtpServer, int smtpPort, string smtpMail, string smtpPassword, string subject, string body)
        {
            try
            {
                MailAddress from = new MailAddress(MailFROM, UserNameFROM);
                MailAddress to = new MailAddress(MailTO);
                MailMessage m = new MailMessage(from, to);
                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
                smtp.Credentials = new NetworkCredential(smtpMail, smtpPassword);
                smtp.EnableSsl = true;
                smtp.Send(m);
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Sends an email from the specified mail to another mail with additional files added
        /// </summary>
        /// <param name="UserNameFROM">Name of the user from whom the e-mail will be sent</param>
        /// <param name="MailFROM">Mail from which the letter will be sent</param>
        /// <param name="MailTO">The e-mail address to which this letter will arrive</param>
        /// <param name="smtpServer">SMTP server. This is the domain name where the mail server is located. For example, gmail is located at: smtp.gmail.com</param>
        /// <param name="smtpPort">SMTP port. This is the port on which the mail server is located. For example, for gmail it is 587</param>
        /// <param name="smtpMail">SMTP mail, it must match the sending mail.</param>
        /// <param name="smtpPassword">SMTP password. This is the password for the mail itself</param>
        /// <param name="subject">Subject line</param>
        /// <param name="body">The body of the letter. You can write both plain text and HTML code</param>
        /// <param name="attachmentsPATH">This is where you can list what files you want to attach to the email</param>
        /// <returns>true or false. true - if everything was successful, false - if an error occurred while sending the e-mail.</returns>
        public static bool send(string UserNameFROM, string MailFROM, string MailTO, string smtpServer, int smtpPort, string smtpMail, string smtpPassword, string subject, string body, string[] attachmentsPATH)
        {
            try
            {
                MailAddress from = new MailAddress(MailFROM, UserNameFROM);
                MailAddress to = new MailAddress(MailTO);
                MailMessage m = new MailMessage(from, to);
                for (int a = 1; attachmentsPATH.Length > a; a++)
                {
                    m.Attachments.Add(new Attachment(attachmentsPATH[a - 1]));
                }
                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
                smtp.Credentials = new NetworkCredential(smtpMail, smtpPassword);
                smtp.EnableSsl = true;
                smtp.Send(m);
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Sends an email from the specified mail to another mail in an asynchronous method
        /// </summary>
        /// <param name="UserNameFROM">Name of the user from whom the e-mail will be sent</param>
        /// <param name="MailFROM">Mail from which the letter will be sent</param>
        /// <param name="MailTO">The e-mail address to which this letter will arrive</param>
        /// <param name="smtpServer">SMTP server. This is the domain name where the mail server is located. For example, gmail is located at: smtp.gmail.com</param>
        /// <param name="smtpPort">SMTP port. This is the port on which the mail server is located. For example, for gmail it is 587</param>
        /// <param name="smtpMail">SMTP mail, it must match the sending mail.</param>
        /// <param name="smtpPassword">SMTP password. This is the password for the mail itself</param>
        /// <param name="subject">Subject line</param>
        /// <param name="body">The body of the letter. You can write both plain text and HTML code</param>
        /// <returns>true or false. true - if everything was successful, false - if an error occurred while sending the e-mail.</returns>
        public static async Task<bool> send_async(string UserNameFROM, string MailFROM, string MailTO, string smtpServer, int smtpPort, string smtpMail, string smtpPassword, string subject, string body)
        {
            try
            {
                MailAddress from = new MailAddress(MailFROM, UserNameFROM);
                MailAddress to = new MailAddress(MailTO);
                MailMessage m = new MailMessage(from, to);
                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
                smtp.Credentials = new NetworkCredential(smtpMail, smtpPassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(m);
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Sends an email from the specified mail to another mail in an asynchronous file-added method
        /// </summary>
        /// <param name="UserNameFROM">Name of the user from whom the e-mail will be sent</param>
        /// <param name="MailFROM">Mail from which the letter will be sent</param>
        /// <param name="MailTO">The e-mail address to which this letter will arrive</param>
        /// <param name="smtpServer">SMTP server. This is the domain name where the mail server is located. For example, gmail is located at: smtp.gmail.com</param>
        /// <param name="smtpPort">SMTP port. This is the port on which the mail server is located. For example, for gmail it is 587</param>
        /// <param name="smtpMail">SMTP mail, it must match the sending mail.</param>
        /// <param name="smtpPassword">SMTP password. This is the password for the mail itself</param>
        /// <param name="subject">Subject line</param>
        /// <param name="body">The body of the letter. You can write both plain text and HTML code</param>
        /// <param name="attachmentsPATH">This is where you can list what files you want to attach to the email</param>
        /// <returns>true or false. true - if everything was successful, false - if an error occurred while sending the e-mail.</returns>
        public static async Task<bool> send_async(string UserNameFROM, string MailFROM, string MailTO, string smtpServer, int smtpPort, string smtpMail, string smtpPassword, string subject, string body, string[] attachmentsPATH)
        {
            try
            {
                MailAddress from = new MailAddress(MailFROM, UserNameFROM);
                MailAddress to = new MailAddress(MailTO);
                MailMessage m = new MailMessage(from, to);
                for (int a = 1; attachmentsPATH.Length > a; a++)
                {
                    m.Attachments.Add(new Attachment(attachmentsPATH[a - 1]));
                }
                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
                smtp.Credentials = new NetworkCredential(smtpMail, smtpPassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(m);
                return true;
            }
            catch { return false; }
        }
    }

    /// <summary>
    /// SMTP client without the need to use a static class
    /// </summary>
    public class SMTP_not_static
    {
        /// <summary>
        /// Sends an email from the specified mailbox to another mailbox
        /// </summary>
        /// <param name="UserNameFROM">Name of the user from whom the e-mail will be sent</param>
        /// <param name="MailFROM">Mail from which the letter will be sent</param>
        /// <param name="MailTO">The e-mail address to which this letter will arrive</param>
        /// <param name="smtpServer">SMTP server. This is the domain name where the mail server is located. For example, gmail is located at: smtp.gmail.com</param>
        /// <param name="smtpPort">SMTP port. This is the port on which the mail server is located. For example, for gmail it is 587</param>
        /// <param name="smtpMail">SMTP mail, it must match the sending mail.</param>
        /// <param name="smtpPassword">SMTP password. This is the password for the mail itself</param>
        /// <param name="subject">Subject line</param>
        /// <param name="body">The body of the letter. You can write both plain text and HTML code</param>
        /// <returns>true or false. true - if everything was successful, false - if an error occurred while sending the e-mail.</returns>
        public bool send(string UserNameFROM, string MailFROM, string MailTO, string smtpServer, int smtpPort, string smtpMail, string smtpPassword, string subject, string body)
        {
            try
            {
                MailAddress from = new MailAddress(MailFROM, UserNameFROM);
                MailAddress to = new MailAddress(MailTO);
                MailMessage m = new MailMessage(from, to);
                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
                smtp.Credentials = new NetworkCredential(smtpMail, smtpPassword);
                smtp.EnableSsl = true;
                smtp.Send(m);
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Sends an email from the specified mail to another mail with additional files added
        /// </summary>
        /// <param name="UserNameFROM">Name of the user from whom the e-mail will be sent</param>
        /// <param name="MailFROM">Mail from which the letter will be sent</param>
        /// <param name="MailTO">The e-mail address to which this letter will arrive</param>
        /// <param name="smtpServer">SMTP server. This is the domain name where the mail server is located. For example, gmail is located at: smtp.gmail.com</param>
        /// <param name="smtpPort">SMTP port. This is the port on which the mail server is located. For example, for gmail it is 587</param>
        /// <param name="smtpMail">SMTP mail, it must match the sending mail.</param>
        /// <param name="smtpPassword">SMTP password. This is the password for the mail itself</param>
        /// <param name="subject">Subject line</param>
        /// <param name="body">The body of the letter. You can write both plain text and HTML code</param>
        /// <param name="attachmentsPATH">This is where you can list what files you want to attach to the email</param>
        /// <returns>true or false. true - if everything was successful, false - if an error occurred while sending the e-mail.</returns>
        public bool send(string UserNameFROM, string MailFROM, string MailTO, string smtpServer, int smtpPort, string smtpMail, string smtpPassword, string subject, string body, string[] attachmentsPATH)
        {
            try
            {
                MailAddress from = new MailAddress(MailFROM, UserNameFROM);
                MailAddress to = new MailAddress(MailTO);
                MailMessage m = new MailMessage(from, to);
                for (int a = 1; attachmentsPATH.Length > a; a++)
                {
                    m.Attachments.Add(new Attachment(attachmentsPATH[a - 1]));
                }
                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
                smtp.Credentials = new NetworkCredential(smtpMail, smtpPassword);
                smtp.EnableSsl = true;
                smtp.Send(m);
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Sends an email from the specified mail to another mail in an asynchronous method
        /// </summary>
        /// <param name="UserNameFROM">Name of the user from whom the e-mail will be sent</param>
        /// <param name="MailFROM">Mail from which the letter will be sent</param>
        /// <param name="MailTO">The e-mail address to which this letter will arrive</param>
        /// <param name="smtpServer">SMTP server. This is the domain name where the mail server is located. For example, gmail is located at: smtp.gmail.com</param>
        /// <param name="smtpPort">SMTP port. This is the port on which the mail server is located. For example, for gmail it is 587</param>
        /// <param name="smtpMail">SMTP mail, it must match the sending mail.</param>
        /// <param name="smtpPassword">SMTP password. This is the password for the mail itself</param>
        /// <param name="subject">Subject line</param>
        /// <param name="body">The body of the letter. You can write both plain text and HTML code</param>
        /// <returns>true or false. true - if everything was successful, false - if an error occurred while sending the e-mail.</returns>
        public async Task<bool> send_async(string UserNameFROM, string MailFROM, string MailTO, string smtpServer, int smtpPort, string smtpMail, string smtpPassword, string subject, string body)
        {
            try
            {
                MailAddress from = new MailAddress(MailFROM, UserNameFROM);
                MailAddress to = new MailAddress(MailTO);
                MailMessage m = new MailMessage(from, to);
                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
                smtp.Credentials = new NetworkCredential(smtpMail, smtpPassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(m);
                return true;
            }
            catch { return false; }
        }
        /// <summary>
        /// Sends an email from the specified mail to another mail in an asynchronous file-added method
        /// </summary>
        /// <param name="UserNameFROM">Name of the user from whom the e-mail will be sent</param>
        /// <param name="MailFROM">Mail from which the letter will be sent</param>
        /// <param name="MailTO">The e-mail address to which this letter will arrive</param>
        /// <param name="smtpServer">SMTP server. This is the domain name where the mail server is located. For example, gmail is located at: smtp.gmail.com</param>
        /// <param name="smtpPort">SMTP port. This is the port on which the mail server is located. For example, for gmail it is 587</param>
        /// <param name="smtpMail">SMTP mail, it must match the sending mail.</param>
        /// <param name="smtpPassword">SMTP password. This is the password for the mail itself</param>
        /// <param name="subject">Subject line</param>
        /// <param name="body">The body of the letter. You can write both plain text and HTML code</param>
        /// <param name="attachmentsPATH">This is where you can list what files you want to attach to the email</param>
        /// <returns>true or false. true - if everything was successful, false - if an error occurred while sending the e-mail.</returns>
        public async Task<bool> send_async(string UserNameFROM, string MailFROM, string MailTO, string smtpServer, int smtpPort, string smtpMail, string smtpPassword, string subject, string body, string[] attachmentsPATH)
        {
            try
            {
                MailAddress from = new MailAddress(MailFROM, UserNameFROM);
                MailAddress to = new MailAddress(MailTO);
                MailMessage m = new MailMessage(from, to);
                for (int a = 1; attachmentsPATH.Length > a; a++)
                {
                    m.Attachments.Add(new Attachment(attachmentsPATH[a - 1]));
                }
                m.Subject = subject;
                m.Body = body;
                m.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient(smtpServer, smtpPort);
                smtp.Credentials = new NetworkCredential(smtpMail, smtpPassword);
                smtp.EnableSsl = true;
                await smtp.SendMailAsync(m);
                return true;
            }
            catch { return false; }
        }
    }
}
