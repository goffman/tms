using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Сводное описание для SendEmail
/// </summary>
public static class SendEmail {
    public static void SendToAdmin(string subject,string msg)
    {
        Execute(Common.Email.EmailSystem, subject, msg);
    }

    public static void Send(string mailto,string subject,string msg)
    {
        Execute(mailto, subject, msg);
    }

    private static void Execute(string mailto, string Subject, string msg)
    {
        System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage
        {
            From = new System.Net.Mail.MailAddress(Common.Email.EmailSystem)
        };
        mm.To.Add(new System.Net.Mail.MailAddress(mailto));
        mm.Subject=Subject;
        mm.IsBodyHtml=true;//письмо в html формате (если надо)
        mm.Body=msg;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(Common.Email.EmailSystemSmtp)
        {
            Host = Common.Email.EmailSystemSmtp,
            Credentials = new System.Net.NetworkCredential(Common.Email.EmailSystem, Common.Email.EmailSystemPass)
        };
        //client.Send(mm);//поехало
    }
}