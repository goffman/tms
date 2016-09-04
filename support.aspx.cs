using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class support : System.Web.UI.Page
{

    private void NotificationSystem(string tip, string message)
    {
        


    }

    protected void Page_Load(object sender, EventArgs e)
    {
    }

    private void SendMail(string msg)// отправляет письмо
    {
      string  mailto = "testmedspec@r-19.ru";
     string   Subject = "Сообщение с сайта tms.mz19.ru";
        System.Net.Mail.MailMessage mm = new System.Net.Mail.MailMessage();
        mm.From = new System.Net.Mail.MailAddress(WebConfigurationManager.AppSettings["email_system"]);
        mm.To.Add(new System.Net.Mail.MailAddress(mailto));
        mm.Subject = Subject;
        mm.IsBodyHtml = true;//письмо в html формате (если надо)
        mm.Body = msg;
        System.Net.Mail.SmtpClient client = new System.Net.Mail.SmtpClient(WebConfigurationManager.AppSettings["email_system_smtp"]);
        client.Host = WebConfigurationManager.AppSettings["email_system_smtp"];
        client.Credentials = new System.Net.NetworkCredential(WebConfigurationManager.AppSettings["email_system"], WebConfigurationManager.AppSettings["email_system_pass"]);
        client.Send(mm);//поехало
    }

    protected void Button1_Click1(object sender, EventArgs e)
    {

     
    }
    protected void Msg_TextChanged(object sender, EventArgs e)
    {

    }
    //protected void Button2_Click(object sender, EventArgs e)
    //{
      
    //        if (sline.Length < 2)
    //        {
               
    //        }
    //        else
    //        {
                
    //        }
        
    //}
}