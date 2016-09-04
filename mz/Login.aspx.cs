using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class mz_Default : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД

    protected void Page_Load(object sender, EventArgs e)
    {

    }

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

    string GetHashString(string s)
    {
        //переводим строку в байт-массим  
        byte[] bytes = Encoding.Unicode.GetBytes(s);

        //создаем объект для получения средст шифрования  
        MD5CryptoServiceProvider CSP =
            new MD5CryptoServiceProvider();

        //вычисляем хеш-представление в байтах  
        byte[] byteHash = CSP.ComputeHash(bytes);

        string hash = string.Empty;

        //формируем одну цельную строку из массива  
        foreach (byte b in byteHash)
            hash += string.Format("{0:x2}", b);

        return hash;
    }

    protected void SQLConnect()
    {

        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }

    }
    protected void Go_Click(object sender, EventArgs e)
    {
        string CheckUserName = "SELECT        COUNT(*) AS Expr1 FROM            AdminUsers GROUP BY UserName HAVING        (UserName = @UserName)"; // делаем запрос на проверку имени пользователя
        SqlCommand CUN = new SqlCommand(CheckUserName, con);
        CUN.Parameters.AddWithValue("@UserName", txtloginusername.Text.Replace(" ", string.Empty));
        try
        {
            SQLConnect();

            if (Convert.ToInt32(CUN.ExecuteScalar().ToString()) == 1)
            {

                string CheckUserPass = "SELECT Password FROM AdminUsers WHERE UserName=@UserName"; // выбор пароля по имени пользователя
                SqlCommand CUP = new SqlCommand(CheckUserPass, con);
                CUP.Parameters.AddWithValue("@UserName", txtloginusername.Text.Replace(" ", string.Empty));
                try
                {
                    if (CUP.ExecuteScalar().ToString() == GetHashString(txtloginpass.Text.Replace(" ", string.Empty)))
                    {

                        string cmdStr3 = "SELECT UserID FROM AdminUsers WHERE (UserName = @UserName)";
                        SqlCommand medorg = new SqlCommand(cmdStr3, con);
                        medorg.Parameters.AddWithValue("@UserName", txtloginusername.Text.Replace(" ", string.Empty));
                        int ID_user = Convert.ToInt32(medorg.ExecuteScalar());
                        SQLConnect();


                        Session["UserID"] = Convert.ToString(ID_user);
                        // Session["New"] = txtloginusername.Text; //создаеться сессия и записываеться в нее пользователь    

                        //string CheckModeracija = "SELECT Moderacija FROM Users WHERE UserName=@UserName"; // делаем запрос на проверку модерации
                        //SqlCommand CМod = new SqlCommand(CheckModeracija, con);
                        //CМod.Parameters.AddWithValue("@UserName", txtloginusername.Text.Replace(" ", string.Empty));
                        //try
                        //{
                        //    SQLConnect();
                        //    if (Convert.ToInt32(CМod.ExecuteScalar().ToString()) == 0)
                        //    {
                        //        Session["Moderacija"] = 0;
                        //        //Response.Cookies["Moderacija"].Value = "0";
                        //        //Response.Cookies["Moderacija"].Expires = DateTime.Now.AddDays(1);
                        //    }
                        //    SQLConnect();
                        //}
                        //catch (Exception ex)
                        //{
                        //    SendMail("testmedspec@r-19.ru", ex.Message, "Ошибка в приложении");
                        //    SQLConnect();
                        //    Log("ОШИБКА Запрос статуса модерации у пользователя " + txtloginusername.Text.Replace(" ", string.Empty));
                        //}
                        //CreateFirstTest();
                        Response.Redirect("/mz/Default.aspx");





                    }
                    else
                    {

                        SQLConnect();
                        NotificationSystem("error", "Пароль введен неверено.");

                    }
                }
                catch (Exception ex)
                {
                    SendMail("testmedspec@r-19.ru", ex.Message, "Ошибка в приложении");
                    SQLConnect();
                }
            }
            else
            {
                SQLConnect();
                NotificationSystem("error", "Имя пользователя введено не верно.");
            }
        }
        catch (Exception ex)
        {
            SendMail("testmedspec@r-19.ru", ex.Message, "Ошибка в приложении");
            SQLConnect();
        }
    }

    protected void NotificationSystem(string status, string msg)
    {
        Notif.Text = msg;
    }
}