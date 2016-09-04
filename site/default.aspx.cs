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
using System.Windows.Forms.VisualStyles;

public partial class suite_Default : System.Web.UI.Page
{
    DateTime date = new DateTime();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД

    public void Page_Error(object sender, EventArgs e)
    {

        Exception objErr = Server.GetLastError().GetBaseException();
        string err = "<br><b>Ошибка в: </b>" + Request.Url.ToString() +
                "<br><b>Сообщение: </b>" + objErr.Message.ToString() +
                "<br><b>Stack Trace:</b><br>" +
                          objErr.StackTrace.ToString();
        // Response.Write(err.ToString());
        SendMail("testmedspec@r-19.ru", err, "Ошибка в приложении");
        Response.Write("<h1 style='outline: 0px; padding: 0px 8px 7px 0px; margin: 0px; font-size: 36px; font-weight: 400; color: rgb(51, 51, 51); line-height: 40px; letter-spacing: -1px; text-shadow: rgb(255, 255, 255) 0px 1px 0px; text-align: center; font-family: 'PT Sans', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);'>Произошла техническая ошибка</h1> <article style='display: block; outline: 0px; padding: 0px; margin: 0px; color: rgb(51, 51, 51); font-family: 'PT Sans', Arial, Helvetica, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);'> <p style='outline: 0px; padding: 0px; margin: 30px 0px 24px; font-size: 18px; line-height: 24px; color: rgb(102, 102, 102); text-align: center;'> К сожалению, при обработке вашего действия на сайте произошла непредвиденная ошибка.<br /> Уведомление о возникшей проблеме уже отправлено в отдел разработки.<span class='Apple-converted-space'>&nbsp;</span>Спасибо!<span class='Apple-converted-space'>&nbsp;</span></p> <p style='outline: 0px; padding: 0px; margin: 30px 0px 24px; font-size: 18px; line-height: 24px; color: rgb(102, 102, 102); text-align: center;'><input type='button' value='Перезагрузить страницу' Class='btn btn-success btn-large'  onclick='location.reload()'/></p> </article>");





        Server.ClearError();


        //  Response.Redirect(Request.RawUrl);


    }

    string SystemQuery(string param)
    {
        try
        {
            con.Open();
            string SelectSystem = "SELECT zn FROM         system WHERE     (param = @paramiter)"; // делаем запрос с введеным в тектовое поле 
            SqlCommand SSystem = new SqlCommand(SelectSystem, con);
            SSystem.Parameters.AddWithValue("@paramiter", param);
            string p = SSystem.ExecuteScalar().ToString();
            con.Close();
            return p;
        }
        catch (Exception ex)
        {
            con.Close();
           // SendMailBug(ex.Message);
            return null;
        }

    }

    int StatusOnDell()
    {


        string ReadSatusDell = "SELECT        on_delete FROM            [l-kabinet] WHERE        (ID = @AccountID)"; // проверяем отметку на удаление человека
        SqlCommand RSD = new SqlCommand(ReadSatusDell, con);

        RSD.Parameters.AddWithValue("@AccountID", Session["UserID"].ToString());
        try
        {
            con.Open();
            int tmp = Convert.ToInt32(RSD.ExecuteScalar());
            con.Close();
            if (tmp == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }
        catch (Exception er)
        {
            SendMail("testmedspec@r-19.ru", er.Message, "Ошибка");
            con.Close();
            return 0;
            // throw;
        }



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

    string OtvetModeratorAccount() //Выбор из бащзы ответа отклонения модерации учетной записи
    {

        string OtvetModerator = "SELECT        Answer FROM            ModerationAccount WHERE        (UserID = @UserID) "; // делаем запрос на проверку активации учетной записи
        SqlCommand OM = new SqlCommand(OtvetModerator, con);
        OM.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        try
        {
            SQLConnect();
            string tmp = OM.ExecuteScalar().ToString();
            con.Close();
            return tmp;
        }
        catch
        {
            con.Close();
            return null;
        }



    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Response.Redirect("/default.aspx");
        }
        else
        {
            if (StatusOnDell() == 1)
            {

                AlertTitle.Text = "Внимание";
                AlertText.Text = "Через 10 дней учетная запись будет удалена. Если у Вас возникла вопросы, свяжитесь с службой технической поддержки по телефону 8 (3902) 295-025.";
                alertblock.Visible = true;
                Test.Visible = false;
            }

            //проверка активации учетной записи
            string CheckActiv = "SELECT        COUNT(*) AS Expr1 FROM            users GROUP BY activation_id, ID_l_kabinet HAVING        (activation_id = N'1') AND (ID_l_kabinet = @UserID) ";
            // делаем запрос на проверку активации учетной записи
            SqlCommand CA = new SqlCommand(CheckActiv, con);
            CA.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            try
            {
                SQLConnect();
                int tmp = Convert.ToInt32(CA.ExecuteScalar().ToString());
                con.Close();
                if (tmp == 1)
                {
                    Test.Visible = true;
                    Activ.Visible = false;
                }
            }
            catch
            {
                con.Close();
                Test.Visible = false;
                Activ.Visible = true;

            }



            string CheckModeracija = "SELECT        Moderacija FROM            users WHERE        (ID_l_kabinet = @UserID)";
            // делаем запрос на проверку существования кода активации
            SqlCommand CM = new SqlCommand(CheckModeracija, con);
            CM.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
            try
            {
                SQLConnect();
                int tmp = Convert.ToInt32(CM.ExecuteScalar().ToString());
                con.Close();
                switch (tmp)
                {
                    case 0:
                        Test.Visible = false;
                        alertmodertitle.Text = "Статус модерации";
                        alertmodertext.Text = "Ваша учетная запись поступила на проверку модератором системы";
                        alertmoder.Visible = true;
                        break;
                    case 1:
                        Test.Visible = true;
                        TestingInformation();
                        break;
                    case 2:
                        Test.Visible = false;
                        alertmodertitle.Text = "Статус модерации";
                        alertmodertext.Text = OtvetModeratorAccount();
                        alertmoder.Visible = true;
                        //OtvetModerator.Text = OtvetModeratorAccount();
                        break;
                }

            }
            catch
            {
                SQLConnect();
            }




        }


    }

    int GetResultsTest()
    {
        int result = 0;
        string GetResultTestSQL = "SELECT         ROUND(CONVERT(money, prohozhdenie_testa.rezultat) / 70 * 100, 0) AS result FROM            prohozhdenie_testa WHERE        (ID_testiruemyj = @UserID)";
        // делаем запрос на получения результата тестирования
        SqlCommand GRTSQL = new SqlCommand(GetResultTestSQL, con);
        GRTSQL.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        try
        {
            con.Open();
            result = Convert.ToInt32(GRTSQL.ExecuteScalar());
            con.Close();
            //  double tmp = (result/70)*100;

            return result;
        }
        catch (Exception ex)
        {
            con.Close();
            SendMail("testmedspec@r-19.ru", ex.Message, "Ошибка");
            return result;
        }

    }

    protected void TestingInformation()
    {
        if (GetPilotTestStatus() == 1)
        {
            TrialTestingGO.Text = "Пройден";
            TrialTestingGO.Enabled = false;
        }
        string NameTest = "";
        int StatusTest = 0;
        string GetNameTest = "SELECT naimenovanie_testa, status FROM prohozhdenie_testa WHERE (ID_testiruemyj = @UserID)";
        // делаем запрос на проверку существования кода активации
        SqlCommand GNTSQL = new SqlCommand(GetNameTest, con);
        GNTSQL.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        try
        {
            con.Open();
            SqlDataReader reader = GNTSQL.ExecuteReader();

            while (reader.Read())
            {
                NameTest = reader[0].ToString();
                StatusTest = Convert.ToInt32(reader[1].ToString());
            }

            con.Close();
            reader.Close();
            if (StatusTest == 0)
            {
                NameTestLabel.Text = NameTest;
            }
            else
            {
                NameTestLabel.Text = NameTest;
                QualificationTestingGO.Text = "Результат: " + Convert.ToString(GetResultsTest()) + "%";
                QualificationTestingGO.Enabled = false;
            }
        }
        catch (Exception ex)
        {
            SendMail("testmedspec@r-19.ru",ex.Message,"Ошибка");
            con.Close();
        }

        string GetGroupSpec = "SELECT        gruppa_dolzhnost.gruppa FROM            [l-kabinet] INNER JOIN dolzhnost ON [l-kabinet].ID_dolzhnost = dolzhnost.ID INNER JOIN gruppa_dolzhnost ON dolzhnost.gruppa = gruppa_dolzhnost.ID WHERE        ([l-kabinet].ID = @UserID)";
        // делаем запрос на проверку существования кода активации
        SqlCommand GGS = new SqlCommand(GetGroupSpec, con);
        GGS.Parameters.AddWithValue("@UserID", Session["UserID"].ToString());
        try
        {
            con.Open();
            Group.Text = GGS.ExecuteScalar().ToString();
            con.Close();

        }
        catch (Exception ex)
        {
            con.Close();
            SendMail("testmedspec@r-19.ru",ex.Message,"Ошибка");
        }

        


    }

    protected void GoTest()
    {
        int tmp = 0;
        string GetIDTest = "SELECT        ID FROM            prohozhdenie_testa WHERE        (ID_testiruemyj = @UserID)"; // делаем запрос на проверку существования кода активации
        SqlCommand GIT = new SqlCommand(GetIDTest, con);
        GIT.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
        try
        {
            SQLConnect();
             tmp= Convert.ToInt32(GIT.ExecuteScalar().ToString());
            ViewState["TestID"] = tmp;
            con.Close();
            // Открываем страницу с тестированием передаем парамитр "Номер (ИД) теста" из таблицы prohozdenie_testa
        }
        catch (Exception ex)
        {
           SendMail("testmedspec@r-19.ru",ex.Message,"Ошибка");
            con.Close();

        }
        Response.Redirect("~/site/instruction.aspx?testID=" + Convert.ToString(ViewState["TestID"].ToString()));
    }

    int GetPilotTestStatus()
    {
        int tmp = 0;
        string GetPitoltTest = "SELECT        proba_test FROM            [l-kabinet] WHERE        (ID = @UserID)"; // делаем запрос на проверку существования кода активации
        SqlCommand GPT = new SqlCommand(GetPitoltTest, con);
        GPT.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
        try
        {
            con.Open();
            tmp = Convert.ToInt32(GPT.ExecuteScalar());
            con.Close();
          
        }
        catch (Exception ex)
        {
            SendMail("testdemspec@r-19.ru", ex.Message, "Ошибка");

        }

        return tmp;

    }

    protected void Button3_Click(object sender, EventArgs e)
    {
        

        if (GetPilotTestStatus()==1)
        {
            GoTest();
        }
        else
        {
            Test.Visible = false;
            TestComfirm.Visible = true;
        }


    }
    protected void FormView2_PageIndexChanging(object sender, FormViewPageEventArgs e)
    {

    }

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

    protected void Button1_Click(object sender, EventArgs e)
    {


        string ProverkaActivID1 = "SELECT     COUNT(activation_id) AS Expr1 FROM         users GROUP BY activation_id HAVING      (activation_id = @activ_id)"; // делаем запрос на проверку существования кода активации
        SqlCommand PAID1 = new SqlCommand(ProverkaActivID1, con);
        PAID1.Parameters.AddWithValue("@activ_id", GetHashString(InputAktivKod.Text));

        try
        {
            //Log(date.ToString() + " Запрос проверки существования Кода активации: " + GetHashString(InputAktivKod.Text) + " Успешно" + " результат: " + Convert.ToString(tmp));
            SQLConnect();
            int tmp = Convert.ToInt32(PAID1.ExecuteScalar());
            con.Close();

            if (tmp == 1)
            {

                if (SystemQuery("moderator")=="1")
                {
                    string UpdateModeracija = "UPDATE    users SET              Moderacija = 1 WHERE     (ID_l_kabinet = @UserID)"; // делаем запрос с введеным в тектовое поле логином
                    SqlCommand UModeracija = new SqlCommand(UpdateModeracija, con);
                    UModeracija.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                    try
                    {
                        SQLConnect();
                        UModeracija.ExecuteNonQuery();
                        SQLConnect();
                    }
                    catch (Exception)
                    {
                        SQLConnect();
                    
                    }
                }
                //string UpdateModeracija = "UPDATE    users SET              Moderacija = 1 WHERE     (ID_l_kabinet = @UserID)"; // делаем запрос с введеным в тектовое поле логином
                //SqlCommand UModeracija = new SqlCommand(UpdateModeracija, con);
                //UModeracija.Parameters.AddWithValue("@UserID", Convert.ToInt32(Session["UserID"]));
                //try
                //{
                //    SQLConnect();
                //    UModeracija.ExecuteNonQuery();
                //    con.Close();
                string UpdateActivID = "UPDATE    users SET              activation_id = N'1' WHERE     (ID_l_kabinet = @UserID)"; // делаем запрос с введеным в тектовое поле логином
                SqlCommand UAID = new SqlCommand(UpdateActivID, con);
                UAID.Parameters.AddWithValue("@UserID", Session["UserID"]);
                try
                {
                    SQLConnect();
                    UAID.ExecuteNonQuery();
                    con.Close();
                    Response.Redirect("/site/default.aspx");
                    //Response.Cookies["Moderacija"].Expires = DateTime.Now.AddDays(-1);
                    //HttpContext.Current.Response.Redirect(HttpContext.Current.Request.Url.ToString());
                    //SystemMsg.Text = "Ваша учетная запись активирована";

                    // txtloginusername.Text = Request.QueryString["user"];
                    //string SelectUserName = "SELECT     UserName FROM         users WHERE     (UserID = @UserId)"; // делаем запрос с введеным в тектовое поле логином
                    //SqlCommand SUN = new SqlCommand(SelectUserName, con);
                    //SUN.Parameters.AddWithValue("@UserId", ViewState["param1"]);
                    //txtloginusername.Text = SUN.ExecuteScalar().ToString();

                }
                catch (Exception er)
                {
                    Log("Активация " + Session["UserID"] + " не удалась " + Convert.ToString(er));
                    con.Close();
                    // SystemMsg.Text = "Активация не удалась";
                }
                //}
                //catch (Exception er)
                //{
                //    con.Close();
                //    Log("Поле модерации для пользователя " + Session["UserID"] + " не обновлено");
                //    // SystemMsg.Text = "Поле модерации не обновлено";
                //}

            }
        }
        catch
        {
            con.Close();
        }
    }
    protected void TrialTestingGO_Click(object sender, EventArgs e)
    {

    }
    protected void PilotTest_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/site/test/pilot/pilot_instruction.aspx");
    }
    protected void Cansel_Click(object sender, EventArgs e)
    {
        Test.Visible = true;
        TestComfirm.Visible = false;
    }
    protected void KvalifTest_Click(object sender, EventArgs e)
    {
        GoTest();
    }
}