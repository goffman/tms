using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site_result : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД

    private void SendMail(string mailto, string msg, string Subject)// отправляет письмо
    {
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

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("/default.aspx");
        }
        if (Convert.ToInt32(Request.QueryString["f"]) == 1)
        {
            result.Text = Convert.ToString(Math.Round(Convert.ToDouble(Request.QueryString["result"]) / 15 * 100)) + "%";
        }
        else if (Request.QueryString["test"] != null)
        {
            int tmp = 0;
            string ResultTest = "SELECT        rezultat FROM            prohozhdenie_testa WHERE        (ID_testiruemyj = @ID) AND (ID = @IDTest)"; // получаем результат тестирования
            SqlCommand RT = new SqlCommand(ResultTest, con);
            RT.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
            RT.Parameters.AddWithValue("@IDTest", Request.QueryString["test"].ToString());
            try
            {
                con.Open();
                tmp = Convert.ToInt32(Math.Round(Convert.ToDouble(RT.ExecuteScalar().ToString())/70*100));
                result.Text = Convert.ToString(tmp) + "%";
                con.Close();
            }
            catch
            {
                con.Close();
            }

            if (tmp <= 70)
            {
                ResultTestText.Text = "Ваш тест признается НЕ пройденным. ";
                info.Visible = true;
            }
            else
            {
                ResultTestText.Text = "Ваш тест признается пройденным. ";
                info.Visible = true;
            }

            SendResultToEmail();

        }
        else
        {
            result.Text = "Результат теста не определен";
        }
   
    }

    protected void SendResultToEmail()
    {
        string email = null;
        string FIO = null;
        string dolz = null;
        int staz = 0;
        int result = 0;
        DateTime dat=new DateTime();
        string ResultTest = "SELECT        [l-kabinet].F, [l-kabinet].I, [l-kabinet].O, dolzhnost.dolzhnost, [l-kabinet].stazh, [l-kabinet].email, prohozhdenie_testa.rezultat, prohozhdenie_testa.data FROM            prohozhdenie_testa INNER JOIN [l-kabinet] ON prohozhdenie_testa.ID_testiruemyj = [l-kabinet].ID INNER JOIN dolzhnost ON prohozhdenie_testa.ID_dolzhnost = dolzhnost.ID WHERE        (prohozhdenie_testa.ID = @IDTest)"; // получаем результат тестирования
        SqlCommand RT = new SqlCommand(ResultTest, con);
        RT.Parameters.AddWithValue("@IDTest", Request.QueryString["test"].ToString());
        try
        {
            con.Open();
            SqlDataReader read = RT.ExecuteReader();

            while (read.Read())
            {
                FIO = read[0].ToString() + " " + read[1].ToString() + " " + read[2].ToString();
                dolz = read[3].ToString();
                staz = Convert.ToInt32(read[4].ToString());
                email = read[5].ToString();
                result = Convert.ToInt32(Math.Round(Convert.ToDouble(read[6].ToString())/70*100));
                dat = Convert.ToDateTime(read[7].ToString());
            }
            con.Close();
            read.Close();
            string msg = "ФИО: " + FIO + "<br/> Должность: " + dolz + " <br/> Стаж: " + staz + "<br/> Результат: " + result + "% <br/>Дата тестирования: "+Convert.ToString(dat);
            SendMail(email, msg, "Результаты прохождения квалификационного");

        }
        catch (Exception)
        {
         con.Close();
        }
    }
}