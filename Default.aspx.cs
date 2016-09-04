using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class suite_Default : System.Web.UI.Page
{
    DateTime date = new DateTime();
    protected void Log(string log_mes)
    {
        //StreamWriter LogStream = new StreamWriter(@"C:\inetpub\wwwproject\log\login.txt", true);

        //try
        //{
        //    LogStream.WriteLine(log_mes);
        //    LogStream.Close();
        //}
        //catch
        //{
        //}
    }

    protected void SQLConnect()
    {

        if (con.State == ConnectionState.Closed)
        {
        con.Open();
        }
        else
        {
            con.Close();
        }

    }

    private void NotificationSystem(string tip, string message)
    {


        if (tip == "error")
        {
            Notification.Title = "Ошибка";
            Notification.Text = message;
            Notification.TitleIcon = "warning";
            Notification.ContentIcon = "warning";
            Notification.ShowSound = "warning";
            Notification.Show();
            //Alert.Visible = true;
            //Alert.Attributes["class"] = "alert alert-error";

            //lblNotification.Text = message;
        }
        else if (tip == "success")
        {

            
            Notification.Title = "Успех";
            Notification.Text = message;
            Notification.TitleIcon = "ok";
            Notification.ContentIcon = "ok";
            Notification.ShowSound = "ok";
            Notification.Show();

        }
        else if (tip == "info")
        {

             Notification.Title = "Информация";
            Notification.Text = message;
            Notification.TitleIcon = "info";
            Notification.ContentIcon = "info";
            Notification.ShowSound = "info";
            Notification.Show();
         
        }
    }

    //---НАЧАЛО
    //ШИФРОВАНИЕ
    static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("kUyX2jHm");//ключ для шифрования
    public static string Decrypt(string cryptedString)
    {
        if (String.IsNullOrEmpty(cryptedString))
        {
            throw new ArgumentNullException
               ("Строка, которая должна быть расшифрована не может быть пустой");
        }
        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        MemoryStream memoryStream = new MemoryStream
                (Convert.FromBase64String(cryptedString));
        CryptoStream cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
        StreamReader reader = new StreamReader(cryptoStream);
        return reader.ReadToEnd();
    }

    public static string Encrypt(string originalString)
    {
        if (String.IsNullOrEmpty(originalString))
        {
            throw new ArgumentNullException
                   ("Строка, которая должна быть защифрована не может быть пустой.");
        }
        DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        MemoryStream memoryStream = new MemoryStream();
        CryptoStream cryptoStream = new CryptoStream(memoryStream,
            cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
        StreamWriter writer = new StreamWriter(cryptoStream);
        writer.Write(originalString);
        writer.Flush();
        cryptoStream.FlushFinalBlock();
        writer.Flush();
        return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
    }
    //---КОНЕЦ

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД

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


    protected void ActivStatus()
    {

        string ProverkaActivID1 = "SELECT     COUNT(activation_id) AS Expr1 FROM         users GROUP BY activation_id HAVING      (activation_id = @activ_id)"; // делаем запрос на проверку существования кода активации
        SqlCommand PAID1 = new SqlCommand(ProverkaActivID1, con);
        PAID1.Parameters.AddWithValue("@activ_id", Request.QueryString["activ_id"]);
        try
        {
            SQLConnect();
            int tmp = Convert.ToInt32(PAID1.ExecuteScalar());
            SQLConnect();

            Log(date.ToString() + " Запрос проверки существования Кода активации: " + Request.QueryString["activ_id"] + " Успешно");
            if (tmp == 1)
            {
               
                string ProverkaActivID2 = "SELECT     users.UserID FROM         users INNER JOIN [l-kabinet] ON users.ID_l_kabinet = [l-kabinet].ID WHERE     (users.activation_id = @activ_id)"; // делаем запрос с введеным в тектовое поле логином
                SqlCommand PAID2 = new SqlCommand(ProverkaActivID2, con);
                PAID2.Parameters.AddWithValue("@activ_id", Request.QueryString["activ_id"]);
                try
                {
                    SQLConnect();
                    ViewState["param1"] = Convert.ToInt32(PAID2.ExecuteScalar());
                    SQLConnect();
                }
                catch
                {
                    SQLConnect();
                }
               
                string UpdateModeracija = "UPDATE    users SET              Moderacija = 0 WHERE     (UserID = @UserId)"; // делаем запрос с введеным в тектовое поле логином
                SqlCommand UModeracija = new SqlCommand(UpdateModeracija, con);
                UModeracija.Parameters.AddWithValue("@UserId", ViewState["param1"]);
                try
                {
                    SQLConnect();
                    UModeracija.ExecuteNonQuery();
                    SQLConnect();
                    string UpdateActivID = "UPDATE    users SET              activation_id = N'1' WHERE     (UserID = @UserId)"; // делаем запрос с введеным в тектовое поле логином
                    SqlCommand UAID = new SqlCommand(UpdateActivID, con);
                    UAID.Parameters.AddWithValue("@UserId", ViewState["param1"]);
                    try
                    {
                        SQLConnect();
                        UAID.ExecuteNonQuery();
                        SQLConnect();

                        NotificationSystem("success", "Ваша учетная запись активирована");

                        txtloginusername.Text = Request.QueryString["user"];
                        //string SelectUserName = "SELECT     UserName FROM         users WHERE     (UserID = @UserId)"; // делаем запрос с введеным в тектовое поле логином
                        //SqlCommand SUN = new SqlCommand(SelectUserName, con);
                        //SUN.Parameters.AddWithValue("@UserId", ViewState["param1"]);
                        //txtloginusername.Text = SUN.ExecuteScalar().ToString();

                    }
                    catch (Exception er)
                    {
                        NotificationSystem("error", "Активация не удалась");
                    }
                    finally
                    {
                        ViewState["param1"] = null;
                    }

                }
                catch (Exception er)
                {
                    NotificationSystem("error", "Поле модерации не обновлено");

                }

            }

        }
        catch
        {
            SQLConnect();
        }




    }

    protected void Page_Load(object sender, EventArgs e)
    {

     //   Response.Cookies["Moderacija"].Expires = DateTime.Now.AddDays(-1);
       
        Session["UserID"] = null;
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "http://yandex.st/jquery/2.0.3/jquery.min.js",

        });

        if (Request.QueryString["session"] == "close")
        {
            Session["UserID"] = null;
        }
        //if (Request.QueryString["recoverypassword"] == "ok")
        //{
        //    //Panel1.Visible = false;
        //    // RecoveryStatus.Text = "Выш новый пароль отправлен на почту: " + Decrypt(Request.QueryString["send"].ToString()).ToString();
        //}
        //if (Request.QueryString["recoverpassword"] == "1")
        //{
        //    RecoveryPass1.Visible = true;
        //    // Panel2.Visible = false;
        //    LoginAuth.Visible = false;
        //    recovery.Text = "Авторизация";
        //    Label1.Text = "Уже есть логин и пароль? ";
        //    recovery.PostBackUrl = "default.aspx";
        //    TitlePage.Text = "Восстановить пароль ";
        //}
        //else
        //{
        //    RecoveryPass1.Visible = false;
        //    // Panel2.Visible = true;
        //    LoginAuth.Visible = true;
        //    recovery.Text = "Восстановить пароль";
        //    Label1.Text = "Забыли пароль? ";
        //    recovery.PostBackUrl = "default.aspx?recoverpassword=1";
        //    TitlePage.Text = "Авторизация ";
        //}
        if (!IsPostBack)
        {
            string activ_id = Request.QueryString["activ_id"];
            if (activ_id != null)
            {

                ActivStatus();

            }
        }
    }


    int StatusOnDell()
    {
       

         string ReadSatusDell = "SELECT        [l-kabinet].on_delete FROM            [l-kabinet] INNER JOIN users ON [l-kabinet].ID = users.ID_l_kabinet WHERE        (users.UserName = @UserName) AND (users.Password = @Password)"; // проверяем отметку на удаление человека
         SqlCommand RSD = new SqlCommand(ReadSatusDell, con);
         RSD.Parameters.AddWithValue("@Password", GetHashString(txtloginpass.Text.Replace(" ", string.Empty)));
         RSD.Parameters.AddWithValue("@UserName", txtloginusername.Text.Replace(" ", string.Empty));
        try
        {
            if (con.State == ConnectionState.Closed)
            {
                SQLConnect();
            }
            int tmp = Convert.ToInt32(RSD.ExecuteScalar());
            SQLConnect();
            if (tmp == 1)
            {
                return 1;
            }
            else
            {
              return  0;
            }

        }
        catch (Exception er)
        {
            
           con.Close();
            return 0;
           // throw;
        }



    }


    protected void CreateFirstTest()
    {
        string SelectProhozdTest = "SELECT     COUNT(*) AS Expr1, ID_testiruemyj FROM         prohozhdenie_testa GROUP BY naimenovanie_testa, ID_testiruemyj HAVING      (naimenovanie_testa = (SELECT     dolzhnost.dolzhnost FROM         dolzhnost INNER JOIN [l-kabinet] ON dolzhnost.ID = [l-kabinet].ID_dolzhnost WHERE     ([l-kabinet].ID = @ID))) AND (ID_testiruemyj = @ID)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand SProhozdTest = new SqlCommand(SelectProhozdTest, con);
        SProhozdTest.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
        try
        {
            SQLConnect();

            int tmp = Convert.ToInt32(SProhozdTest.ExecuteScalar());
            SQLConnect();


            if (tmp < 1)
            {


                string SelectDolzn = "SELECT     dolzhnost.ID FROM dolzhnost INNER JOIN [l-kabinet] ON dolzhnost.ID = [l-kabinet].ID_dolzhnost WHERE     ([l-kabinet].ID = @ID)"; // делаем запрос с введеным в тектовое поле логином
                SqlCommand SDolzn = new SqlCommand(SelectDolzn, con);
                SDolzn.Parameters.AddWithValue("@ID", Session["UserID"]);
                try
                {
                    SQLConnect();
                    int dolzn = Convert.ToInt32(SDolzn.ExecuteScalar());
                    SQLConnect();

                    string SelectDolznName = " SELECT     dolzhnost.dolzhnost FROM         dolzhnost INNER JOIN [l-kabinet] ON dolzhnost.ID = [l-kabinet].ID_dolzhnost WHERE     ([l-kabinet].ID = @ID)"; // делаем запрос с введеным в тектовое поле логином
                    SqlCommand SDolznname = new SqlCommand(SelectDolznName, con);
                    SDolznname.Parameters.AddWithValue("@ID", Session["UserID"]);
                    try
                    {
                        SQLConnect();
                        string dolzn_name = SDolznname.ExecuteScalar().ToString();
                        SQLConnect();

                        string InsertTest = "INSERT INTO prohozhdenie_testa (ID_testiruemyj, ID_dolzhnost, status, naimenovanie_testa,rezultat,otpravlen,time) VALUES     (@ID_testiruemyj,@ID_dolzhnost,@status,@naimenovanie_testa,@rezultat,@otpravlen,@time)"; // делаем запрос с введеным в тектовое поле логином
                        SqlCommand Itest = new SqlCommand(InsertTest, con);
                        Itest.Parameters.AddWithValue("@ID_testiruemyj", Session["UserID"]);
                        Itest.Parameters.AddWithValue("@ID_dolzhnost", dolzn);
                        Itest.Parameters.AddWithValue("@naimenovanie_testa", dolzn_name);
                        Itest.Parameters.AddWithValue("@status", 0);
                        Itest.Parameters.AddWithValue("@rezultat", 0);
                        Itest.Parameters.AddWithValue("@time", 0);
                        Itest.Parameters.AddWithValue("@otpravlen", 0);
                        try
                        {
                            SQLConnect();
                            Itest.ExecuteNonQuery();
                            SQLConnect();
                        }
                        catch (Exception er)
                        {
                            SQLConnect();
                            Response.Redirect("~/error.aspx?error=107"); //Невозможно произвести запись контрольных сумм в таблицу!
                        }
                    }
                    catch
                    {
                        SQLConnect();
                    }
                }
                catch
                {
                    SQLConnect();
                }
            }
        }
        catch
        {
            SQLConnect();
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
       
        string CheckUserName = "SELECT COUNT (*) FROM users WHERE UserName=@UserName"; // делаем запрос на проверку имени пользователя
        SqlCommand CUN = new SqlCommand(CheckUserName, con);
        CUN.Parameters.AddWithValue("@UserName", txtloginusername.Text.Replace(" ", string.Empty));
        try
        {
                SQLConnect();
        
            if (Convert.ToInt32(CUN.ExecuteScalar().ToString()) == 1)
            {

                string CheckUserPass = "SELECT Password FROM Users WHERE UserName=@UserName"; // выбор пароля по имени пользователя
                SqlCommand CUP = new SqlCommand(CheckUserPass, con);
                CUP.Parameters.AddWithValue("@UserName", txtloginusername.Text.Replace(" ", string.Empty));
                try
                {
                    if (CUP.ExecuteScalar().ToString() == GetHashString(txtloginpass.Text.Replace(" ", string.Empty)))
                    {

                        string cmdStr3 = "SELECT [l-kabinet].ID FROM  [l-kabinet] INNER JOIN users ON [l-kabinet].ID = users.ID_l_kabinet WHERE (users.UserName = @UserName)";
                        SqlCommand medorg = new SqlCommand(cmdStr3, con);
                        medorg.Parameters.AddWithValue("@UserName", txtloginusername.Text.Replace(" ", string.Empty));
                        int ID_user = Convert.ToInt32(medorg.ExecuteScalar());
                        SQLConnect();
                      
                            
                            Session["UserID"] = Convert.ToString(ID_user);
                            // Session["New"] = txtloginusername.Text; //создаеться сессия и записываеться в нее пользователь    

                            string CheckModeracija = "SELECT Moderacija FROM Users WHERE UserName=@UserName"; // делаем запрос на проверку модерации
                            SqlCommand CМod = new SqlCommand(CheckModeracija, con);
                            CМod.Parameters.AddWithValue("@UserName", txtloginusername.Text.Replace(" ", string.Empty));
                            try
                            {
                                SQLConnect();
                                if (Convert.ToInt32(CМod.ExecuteScalar().ToString()) == 0)
                                {
                                    Session["Moderacija"] = 0;
                                    //Response.Cookies["Moderacija"].Value = "0";
                                    //Response.Cookies["Moderacija"].Expires = DateTime.Now.AddDays(1);
                                }
                                SQLConnect();
                            }
                            catch (Exception ex)
                            {
                                SendMail("testmedspec@r-19.ru", ex.Message, "Ошибка в приложении");
                                SQLConnect();
                                Log("ОШИБКА Запрос статуса модерации у пользователя " + txtloginusername.Text.Replace(" ", string.Empty));
                            }
                            CreateFirstTest();
                            Response.Redirect("site/Default.aspx");

                      
                       


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


    public void Page_Error(object sender, EventArgs e)
    {

        Exception objErr = Server.GetLastError().GetBaseException();
        string err = "<br><b>Ошибка в: </b>" + Request.Url.ToString() +
                "<br><b>Сообщение: </b>" + objErr.Message.ToString() +
                "<br><b>Stack Trace:</b><br>" +
                          objErr.StackTrace.ToString();
        // Response.Write(err.ToString());
       // SendMail("testmedspec@r-19.ru", err, "Ошибка в приложении");
        // Response.Write(err);
        Server.ClearError();

        //  Response.Redirect(Request.RawUrl);


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



}