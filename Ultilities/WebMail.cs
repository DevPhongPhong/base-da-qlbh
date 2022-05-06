using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;
using System.IO;
using Ultilities.Models;

namespace Ultilities
{
    /// <summary>
    /// Class for Email Methods
    /// </summary>
    public class EmailHelper
    {
        public static async void SendGMail(GmailSmtp gmailSmtp)
        {
            MailMessage message = new MailMessage();
            SmtpClient smtpClient = new SmtpClient();
            var emailData = gmailSmtp.EmailData;
            try
            {
                MailAddress fromAddress = new MailAddress(emailData.from);
                message.From = fromAddress;
                if (emailData.toList != null)
                {
                    if (emailData.toList.Count > 0)
                    {
                        foreach (var to in emailData.toList)
                        {
                            message.To.Add(to);
                        }
                    }
                }
                else
                {
                    return;
                }
                if (emailData.ccList != null)
                {
                    if (emailData.ccList?.Count > 0)
                    {
                        foreach (var cc in emailData.ccList)
                        {
                            message.CC.Add(cc);
                        }
                    }
                }
                message.Subject = emailData.subject;
                message.IsBodyHtml = emailData.isBodyHtml;
                message.Body = emailData.body;
                // We use gmail as our smtp client
                smtpClient.Host = gmailSmtp.smtpAddress;
                smtpClient.Port = gmailSmtp.portNumber;
                smtpClient.EnableSsl = gmailSmtp.enableSSL;
                smtpClient.UseDefaultCredentials = gmailSmtp.useDefaultCredentials;
                smtpClient.Credentials = new System.Net.NetworkCredential(
                    gmailSmtp.sender, gmailSmtp.password);
                await Task.Run(() => smtpClient.Send(message));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}