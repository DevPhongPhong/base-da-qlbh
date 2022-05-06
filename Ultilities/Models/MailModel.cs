using System;
using System.Collections.Generic;
using System.Text;

namespace Ultilities.Models
{
    public class MailModel
    {
    }
    public class Email
    {
        public string from { get; set; }
        public List<string> toList { get; set; }
        public List<string> ccList { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public bool isBodyHtml { get; set; }

    }

    public class GmailSmtp
    {
        public bool useDefaultCredentials { get; set; }
        public int portNumber { get; set; }
        public string smtpAddress { get; set; }
        public bool enableSSL { get; set; }
        public string sender { get; set; }
        public string password { get; set; }
        public Email EmailData { get; set; }
    }

    public class YahooSmtp
    {

        public int portNumber = 587;
        public string smtpAddress = "smtp.mail.yahoo.com";
        public bool enableSSL = true;
        public string sender = "<your_email>";
        public string password = "<your_password>";

    }

    public class HotmailSmtp
    {

        public int portNumber = 587;
        public string smtpAddress = "smtp.live.com";
        public bool enableSSL = true;
        public string sender = "<your_email>";
        public string password = "<your_password>";

    }

    public class OutlookSmtp
    {

        public int portNumber = 587;
        public string smtpAddress = "smtp-mail.outlook.com";
        public bool enableSSL = true;
        public string sender = "<your_email>";
        public string password = "<your_password>";

    }
}
