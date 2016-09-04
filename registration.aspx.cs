using System;
using System.Activities.Expressions;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms.VisualStyles;

public partial class registration : System.Web.UI.Page
{
    Dictionary<string, string> words = new Dictionary<string, string>();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    Boolean regst = false;
    public static String LoginVar;
    public static String PassVar;
    public static string LStatus;
    DateTime date1 = DateTime.Now;


    public void Page_Error(object sender, EventArgs e)
    {

        Exception objErr = Server.GetLastError().GetBaseException();
        string err = "<br><b>Ошибка в: </b>" + Request.Url.ToString() +
                "<br><b>Сообщение: </b>" + objErr.Message.ToString() +
                "<br><b>Stack Trace:</b><br>" +
                          objErr.StackTrace.ToString();
        // Response.Write(err.ToString());
        SendMail("testmedspec@r-19.ru", err, "Ошибка в приложении");
        Response.Write("<h1 style='outline: 0px; padding: 0px 8px 7px 0px; margin: 0px; font-size: 36px; font-weight: 400; color: rgb(51, 51, 51); line-height: 40px; letter-spacing: -1px; text-shadow: rgb(255, 255, 255) 0px 1px 0px; text-align: center; font-family: 'PT Sans', Arial, Helvetica, sans-serif; font-style: normal; font-variant: normal; orphans: auto; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);'>Произошла техническая ошибка</h1> <article style='display: block; outline: 0px; padding: 0px; margin: 0px; color: rgb(51, 51, 51); font-family: 'PT Sans', Arial, Helvetica, sans-serif; font-size: 16px; font-style: normal; font-variant: normal; font-weight: normal; letter-spacing: normal; line-height: normal; orphans: auto; text-align: start; text-indent: 0px; text-transform: none; white-space: normal; widows: auto; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255);'> <p style='outline: 0px; padding: 0px; margin: 30px 0px 24px; font-size: 18px; line-height: 24px; color: rgb(102, 102, 102); text-align: center;'> К сожалению, при обработке Вашего действия на сайте произошла непредвиденная ошибка.<br /> Уведомление о возникшей проблеме уже отправлено в отдел разработки.<span class='Apple-converted-space'>&nbsp;</span>Спасибо!<span class='Apple-converted-space'>&nbsp;</span></p> <p style='outline: 0px; padding: 0px; margin: 30px 0px 24px; font-size: 18px; line-height: 24px; color: rgb(102, 102, 102); text-align: center;'><input type='button' value='Перезагрузить страницу' Class='btn btn-success btn-large'  onclick='location.reload()'/></p> </article>");

        Server.ClearError();

    }
    // процедура записи лог-файла
    protected void Log(string log_mes)
    {
        //StreamWriter LogStream = new StreamWriter(@"C:\inetpub\wwwproject\log\reg.txt", true);

        //try
        //{
        //    LogStream.WriteLine(Convert.ToString(date1) + " " + log_mes);
        //    LogStream.Close();
        //}
        //catch
        //{
        //}


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
            SendMailBug(ex.Message);
            return null;
        }

    }

    protected void Page_Load(object sender, EventArgs e)
    {


        //СМС авторизация
        LoginVar = "dremlygov@mail.ru";
        PassVar = "224433160a49d26d440d394c4d657fe1";
        //КОНЕЦ


        if (!IsPostBack)
        {
            Wizard1.ActiveStepIndex = 0;
        }

        //InitializeComponent();
        words.Add("а", "a");
        words.Add("б", "b");
        words.Add("в", "v");
        words.Add("г", "g");
        words.Add("д", "d");
        words.Add("е", "e");
        words.Add("ё", "yo");
        words.Add("ж", "zh");
        words.Add("з", "z");
        words.Add("и", "i");
        words.Add("й", "j");
        words.Add("к", "k");
        words.Add("л", "l");
        words.Add("м", "m");
        words.Add("н", "n");
        words.Add("о", "o");
        words.Add("п", "p");
        words.Add("р", "r");
        words.Add("с", "s");
        words.Add("т", "t");
        words.Add("у", "u");
        words.Add("ф", "f");
        words.Add("х", "h");
        words.Add("ц", "c");
        words.Add("ч", "ch");
        words.Add("ш", "sh");
        words.Add("щ", "sch");
        words.Add("ъ", "j");
        words.Add("ы", "i");
        words.Add("ь", "j");
        words.Add("э", "e");
        words.Add("ю", "yu");
        words.Add("я", "ya");
        words.Add("А", "A");
        words.Add("Б", "B");
        words.Add("В", "V");
        words.Add("Г", "G");
        words.Add("Д", "D");
        words.Add("Е", "E");
        words.Add("Ё", "Yo");
        words.Add("Ж", "Zh");
        words.Add("З", "Z");
        words.Add("И", "I");
        words.Add("Й", "J");
        words.Add("К", "K");
        words.Add("Л", "L");
        words.Add("М", "M");
        words.Add("Н", "N");
        words.Add("О", "O");
        words.Add("П", "P");
        words.Add("Р", "R");
        words.Add("С", "S");
        words.Add("Т", "T");
        words.Add("У", "U");
        words.Add("Ф", "F");
        words.Add("Х", "H");
        words.Add("Ц", "C");
        words.Add("Ч", "Ch");
        words.Add("Ш", "Sh");
        words.Add("Щ", "Sch");
        words.Add("Ъ", "J");
        words.Add("Ы", "I");
        words.Add("Ь", "J");
        words.Add("Э", "E");
        words.Add("Ю", "Yu");
        words.Add("Я", "Ya");
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


    string GetTranstext(string text)
    {
        string source = text;
        foreach (KeyValuePair<string, string> pair in words)
        {
            source = source.Replace(pair.Key, pair.Value);
        }

        return source;
        // return text;
    }

    //Процедура отправки СМС сообщения
    public static String MSender(String Phone, String Message)
    {

        try
        {

            System.Net.WebRequest reqGET = System.Net.WebRequest.Create(@"http://sms.ru/sms/send?api_id=a5b199dd-f98f-ea74-6957-c5c5d9ba5c01&from=tms.mz19.ru&to=" + Phone + "&text=" + Message);
            reqGET.Proxy = null;
            reqGET.Credentials = CredentialCache.DefaultCredentials;
            //  ServicePointManager.ServerCertificateValidationCallback = ((sender, certificate, chain, sslPolicyErrors) => true);
            System.Net.WebResponse resp = reqGET.GetResponse();
            System.IO.Stream stream = resp.GetResponseStream();
            System.IO.StreamReader sr = new System.IO.StreamReader(stream);
            string s = sr.ReadToEnd();
            string[] sline = s.Split(new char[] { '\n' });

            return sline[0];

        }
        catch (Exception ex)
        {

            return null;
        }
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

    int GetUserName(string name)
    {
        SqlConnection conusername = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
        if (conusername.State == ConnectionState.Open)
        {
            conusername.Close();
        }
        string strusername = "SELECT COUNT(UserName) FROM users where UserName=N'" + name + "'"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand selectuser = new SqlCommand(strusername, conusername);
        try
        {
            conusername.Open();
            int temp = Convert.ToInt32(selectuser.ExecuteScalar().ToString());
            if (temp == 1)
            {
                conusername.Close();
                return 1;
            }
            else
            {
                conusername.Close();
                return 0;
            }
        }
        catch (Exception ex)
        {
            string err = "<br><b>Ошибка в: </b>" + Request.Url.ToString() +
                         "<br><b>Сообщение: </b>" + ex.Message.ToString();

            SendMailBug(err);
            conusername.Close();
            return 2;
        }
    }

    protected void SendMailBug(string bug)
    {
        SendMail("testmedspec@r-19.ru", "Источник: " + Request.Url.ToString() + "<br/>" + bug, "Ошибка в приложении");
        Log(bug);

    }

    protected void message(string mes) //вывод сообщений
    {
        //Label1.Text = mes;
        MessageErrorLabel.Text = mes;
    }

    protected void PersonalnyeDannyeTrue_CheckedChanged(object sender, EventArgs e)
    {

        Button1.Enabled = true;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Wizard1.ActiveStepIndex = 1;
    }

    int CheckFIO() //проверка на уже зарегистрированных людей в БД
    {
        string SelectNewUser = "SELECT  COUNT(*) AS Expr1 FROM         [l-kabinet] GROUP BY F, I, O, ID_dolzhnost, ID_lpu HAVING      (F = @F) AND (I = @I) AND (O = @O) AND (ID_dolzhnost = @ID_dolzhnost) AND (ID_lpu = @lpu)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand selectuser = new SqlCommand(SelectNewUser, con);
        selectuser.Parameters.AddWithValue("@F", txtF.Text.Replace(" ", string.Empty));
        selectuser.Parameters.AddWithValue("@I", txtI.Text.Replace(" ", string.Empty));
        selectuser.Parameters.AddWithValue("@O", txtO.Text.Replace(" ", string.Empty));
        selectuser.Parameters.AddWithValue("@lpu", DropMestorab.Text);
        selectuser.Parameters.AddWithValue("@ID_dolzhnost", Dropspec.Text);

        try
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }

            int temp = Convert.ToInt32(selectuser.ExecuteScalar().ToString());
            con.Close();
            return temp;
        }
        catch (Exception ex)
        {

            con.Close();
            string err = "<br><b>Ошибка в: </b>" + Request.Url.ToString() +
                     "<br><b>Сообщение: </b>" + ex.Message.ToString();

            SendMailBug(err);
            return 0;
            //  throw;
        }

    }

    protected void Notif()
    {
        RadNotification1.Text = "Специальность не выбрана.";
        RadNotification1.Title = "Ошибка";
        // RadNotification1.DataBind();
        RadNotification1.Show();
    }

    //Проверка человека в списках на аттестацию
    int ListOfCertifiedCheck()
    {



        string SQLListOfCertifiedCheck = "SELECT        ID FROM            SpisokAttestuemyh WHERE        (F = @F) AND (I = @I) AND (O = @O) AND (DolzhnostID = @DolzhnostID) AND (LPUID = @LPUID)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand SQLLOCC = new SqlCommand(SQLListOfCertifiedCheck, con);
        SQLLOCC.Parameters.AddWithValue("@F", txtF.Text.Replace(" ", string.Empty));
        SQLLOCC.Parameters.AddWithValue("@I", txtI.Text.Replace(" ", string.Empty));
        SQLLOCC.Parameters.AddWithValue("@O", txtO.Text.Replace(" ", string.Empty));
        SQLLOCC.Parameters.AddWithValue("@DolzhnostID", Dropspec.Text);
        SQLLOCC.Parameters.AddWithValue("@LPUID", DropMestorab.Text);
        try
        {
            if (con.State != ConnectionState.Open)
            {
                con.Open();
            }
            int tmp = Convert.ToInt32(SQLLOCC.ExecuteScalar().ToString());
            con.Close();
            return tmp;
        }
        catch (Exception ex)
        {

            con.Close();
            string err = "<br><b>Ошибка в: </b>" + Request.Url.ToString() +
                      "<br><b>Сообщение: </b>" + ex.Message.ToString();

            SendMailBug(err);
            return 0;
        }




    }

    protected void RegistrationButton_Click(object sender, EventArgs e)
    {

        if (Page.IsValid)
        {
            if (Dropspec.SelectedIndex == 0)
            {
                Dropspec.Focus();
                DropNapravAlert.Visible = true;
                DropNapravLabel.Text = "Специальность не выбрана";
                // Notif();

            }
            else if (DropNaprav.SelectedIndex == 0)
            {
                DropNaprav.Focus();
                DropNapravAlert.Visible = true;
                DropNapravLabel.Text = "Специальность не выбрана.";
             

            }
            else if (DropMestorab.SelectedIndex == 0)
            {
                DropMestorab.Focus();
                DropMestorabLabel.Text = "Место работы не выбрано.";
                    DropNapravAlert.Visible = false;
      
            }
            else if (Dropkat.SelectedIndex == 0)
            {
                Dropkat.Focus();
                DropkatAlert.Visible = true;
                DropkatLabel.Text = "Категория не выбрана.";

            }
            else
            {


                Boolean StatusListOfCertifiedCheck = false;
                if (CheckFIO() == 0) // проверка на совпадение с уже зарегистрированными людьми
                {
                    Random rand = new Random();
                    int UserID = 0; //ID созданного пользователя
                    string cmdStr =
                        "INSERT INTO [l-kabinet] (F, I, O, stazh, ID_lpu, ID_dolzhnost, email, kategoria, proba_test, telefon, on_delete) VALUES     (@F,@I,@O,@stazh,@lpu,@ID_dolzhnost,@email,@kategoria, 0,@telefon, 0) SELECT @@IDENTITY";
                    // делаем запрос с введеным в тектовое поле логином
                    SqlCommand insertuser = new SqlCommand(cmdStr, con);
                    insertuser.Parameters.AddWithValue("@F", txtF.Text.Replace(" ", string.Empty));
                    insertuser.Parameters.AddWithValue("@I", txtI.Text.Replace(" ", string.Empty));
                    insertuser.Parameters.AddWithValue("@O", txtO.Text.Replace(" ", string.Empty));
                    insertuser.Parameters.AddWithValue("@stazh",
                        Convert.ToInt32(txtStage.Text.Replace(" ", string.Empty)));
                    insertuser.Parameters.AddWithValue("@lpu", DropMestorab.Text);
                    insertuser.Parameters.AddWithValue("@ID_dolzhnost", Dropspec.Text);
                    insertuser.Parameters.AddWithValue("@email", txtemail.Text.Replace(" ", string.Empty));
                    insertuser.Parameters.AddWithValue("@kategoria", Dropkat.Text);
                    insertuser.Parameters.AddWithValue("@telefon", txtTelefon.Text);

                    try
                    {
                        if (con.State != ConnectionState.Open)
                        {
                            con.Open();
                        }

                        UserID = Convert.ToInt32(insertuser.ExecuteScalar().ToString());



                        //string SelectNewUser1 =
                        //    "SELECT        ID FROM            [l-kabinet] WHERE        (SessionID = @SessionID)";
                        //// делаем запрос с введеным в тектовое поле логином
                        //SqlCommand selectuser1 = new SqlCommand(SelectNewUser1, con);
                        //selectuser1.Parameters.AddWithValue("@SessionID", sessionID);
                        //string UserID = selectuser1.ExecuteScalar().ToString();
                        con.Close();

                        string username = GetTranstext(txtF.Text.Replace(" ", string.Empty).Remove(1)) +
                                          GetTranstext(txtI.Text.Replace(" ", string.Empty).Remove(1)) +
                                          GetTranstext(txtO.Text.Replace(" ", string.Empty).Remove(1));
                        //создаем ноывый логин производим транслит в латиницу и обрезаем пробелы

                        while (GetUserName(username) != 0) //производим запрос на наличие вновь сформированного логина
                        {

                            username = username + rand.Next(100);
                        }

                        //далее производим определение индификатора записанного пользователя
                        //TextBox6.Text = username;
                        Random hashrand = new Random();
                        string s = Convert.ToString(hashrand.Next(1000000));

                        //TextBox6.Text = GetHashString(s) + " - " + Convert.ToString(s);

                        string activ_id = Convert.ToString(hashrand.Next(1000000));


                        string InsertUser =
                            "INSERT INTO users (UserName, ID_l_kabinet, Password, Moderacija,date_reg,activation_id) VALUES (@UserName, @ID_l_kabinet, @Password, @Moderacija, @date_reg, @activation_id)";
                        // делаем запрос с введеным в тектовое поле логином
                        SqlCommand InsertUser2 = new SqlCommand(InsertUser, con);
                        InsertUser2.Parameters.AddWithValue("@UserName", username);
                        InsertUser2.Parameters.AddWithValue("@ID_l_kabinet", UserID);
                        InsertUser2.Parameters.AddWithValue("@Password", GetHashString(s));
                        InsertUser2.Parameters.AddWithValue("@Moderacija", 0);
                        InsertUser2.Parameters.AddWithValue("@date_reg", date1);
                        InsertUser2.Parameters.AddWithValue("@activation_id", GetHashString(activ_id));
                        try
                        {
                            if (con.State != ConnectionState.Open)
                            {
                                con.Open();
                            }

                            InsertUser2.ExecuteNonQuery();

                            con.Close();

                            Log("$УСПЕШНО:$" + UserID + "$" + username + "$" + txtF.Text.Replace(" ", string.Empty) +
                                "$" +
                                txtI.Text.Replace(" ", string.Empty) + "$" + txtO.Text.Replace(" ", string.Empty) + "$" +
                                DropMestorab.Text + "$" + Dropspec.Text);
                            //Отправка почты

                            string MsgOut = "Уважаемый(-ая) " + txtF.Text.Replace(" ", string.Empty) + " " +
                                            txtI.Text.Replace(" ", string.Empty).Remove(1) + ". " +
                                            txtO.Text.Replace(" ", string.Empty).Remove(1) + "." +
                                            "<br>Вы успешно завершили регистрацию в системе тестирования медицинских работников Республики Хакасия <a href='http://tms.miacrh.ru/'>http://tms.miacrh.ru/</a><br> Логин для входа на сайт: " +
                                            username + " <br> Пароль: " + s.ToString() +
                                            "<br> Через некоторое время вашу запись утвердят, после чего откроется доступ для прохождения тестирования. <br>Для активации учетеной записи перейдите по ссылке: " +
                                            "<a href='http://tms.miacrh.ru/default.aspx?user=" + username + "&activ_id=" +
                                            GetHashString(activ_id) + "'>http://tms.miacrh.ru/default.aspx?user=" +
                                            username +
                                            "&activ_id=" + GetHashString(activ_id) +
                                            "</a>, либо воспользуйтесь кодом активации " + activ_id +
                                            "<br> Если Вы не регистрировались в системе тестирования, то активировать учетную запись не нужно";
                            string MsgOutAdmin = txtF.Text.Replace(" ", string.Empty) + " " +
                                                 txtI.Text.Replace(" ", string.Empty) + ". " +
                                                 txtO.Text.Replace(" ", string.Empty) + "." + "</br> МО: " +
                                                 DropMestorab.SelectedItem + "</br> Должность: " + Dropspec.SelectedItem +
                                                 " <br/> логин: " + username + "<br/> пароль: " + s.ToString() +
                                                 " <br/> Код активации: " + activ_id;
                            string smsmsg = "Логин: " + username + " Пароль: " + s.ToString() + " Код Активации: " +
                                            activ_id;

                            if (GetLoginPasswortToSMS.Checked)
                            {
                                string status_mes = MSender(txtTelefon.Text, smsmsg);
                                Log("Статус отправки смс на телефон: " + txtTelefon.Text + status_mes);
                            }
                            SendMail(txtemail.Text, MsgOut, "Регистрация на сайте tms.mz19.ru");
                            SendMail(SystemQuery("email_admin"), MsgOutAdmin,
                                "Новый человек зарегистрировался на сайте ");

                            int resultListOfCertifiedCheck = ListOfCertifiedCheck();
                            if (resultListOfCertifiedCheck != 0)
                            {

                                string UpdateListOfCertified =
                                    " UPDATE       SpisokAttestuemyh SET                UserID =@UserID WHERE        (ID = @ID)";
                                // делаем запрос с введеным в тектовое поле логином
                                SqlCommand ULOS = new SqlCommand(UpdateListOfCertified, con);
                                ULOS.Parameters.AddWithValue("@UserID", UserID);
                                ULOS.Parameters.AddWithValue("@ID", resultListOfCertifiedCheck);

                                try
                                {
                                    if (con.State != ConnectionState.Open)
                                    {
                                        con.Open();
                                    }
                                    ULOS.ExecuteNonQuery();
                                    con.Close();

                                    string AutoModeracija =
                                        "UPDATE       users SET                Moderacija = 1 WHERE        (ID_l_kabinet = @ID_l_kabinet)";
                                    // делаем запрос с введеным в тектовое поле логином
                                    SqlCommand AM = new SqlCommand(AutoModeracija, con);
                                    AM.Parameters.AddWithValue("@ID_l_kabinet", UserID);
                                    try
                                    {
                                        if (con.State != ConnectionState.Open)
                                        {
                                            con.Open();
                                        }
                                        StatusListOfCertifiedCheck = true;
                                        con.Close();
                                    }
                                    catch (Exception ex)
                                    {
                                        con.Close();
                                        SendMailBug(ex.Message);
                                        //throw;
                                    }



                                }
                                catch (Exception ex)
                                {
                                    con.Close();
                                    string err = "<br><b>Ошибка в: </b>" + Request.Url.ToString() +
                                                 "<br><b>Сообщение: </b>" + ex.Message.ToString();

                                    SendMailBug(err);
                                }


                            }

                            regst = true;



                            //     Registracija.Visible = false;
                            //     success.Visible = true;
                            //Label1.Text = "Регистрация прошла успешно! Данные для входа на сайт высланы Вам на электронную почту";



                            //  Response.Write("<b>Регистрация прошла успешно! Данные для входа на сайт высланы Вам на электронную почту<b>");
                            //   con.Close();


                        }
                        catch (Exception ex)
                        {
                            con.Close();
                            string err = "<br><b>Ошибка в: </b>" + Request.Url.ToString() +
                                         "<br><b>Сообщение: </b>" + ex.Message.ToString();

                            SendMailBug(err);
                            Log(
                                "Возникла ошибка какая-то и не понятно что с ней делать во время записи логина пользователфя в базу таблицы user");
                           // message("Что-то пошло не так! Попробуйте еще раз");
                        }



                    }
                    catch (Exception ex)
                    {
                        con.Close();
                        string err = "<br><b>Ошибка в: </b>" + Request.Url.ToString() +
                                     "<br><b>Сообщение: </b>" + ex.Message.ToString();

                        SendMailBug(err);
                        Log(
                            "Возникла ошибка какая-то и не понятно что с ней делать во время записи логина пользователя в базу таблицы l-kabinet");
                      //  message("Что-то пошло не так! Попробуйте еще раз");
                    }


                }
                else
                {
                    message(
                        "Вы не можете зарегистрироваться в системе, т.к. под данными фамилией именем и отчеством уже есть учетная запись. Пожалуйста, свяжитесь с модератором системы");

                    //Label1.Text="Вы не можете зарегистрироваться в системе, т.к. под данными фамилией именем и отчеством уже есть учетная запись. Пожалуйста, свяжитесь с модератором системы";
                }

                if (regst == true)
                {

                    Panel1.Visible = true;
                    if (StatusListOfCertifiedCheck == true)
                    {

                        Label2.Text = "Вы прошли автоматическую модерацию.";
                    }
                    Wizard1.ActiveStepIndex = 2;
                    //  Response.Redirect("registration.aspx?status=success");

                }
                else
                {

                    Panel2.Visible = true;
                    Wizard1.ActiveStepIndex = 2;
                    // Response.Redirect("registration.aspx?status=error");
                }
            }
        }
    }

    protected void txtTelefon_TextChanged(object sender, EventArgs e)
    {

    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Wizard1.ActiveStepIndex = 1;
    }
    protected void Button4_Click(object sender, EventArgs e)
    {

    }
    protected void Button4_Click1(object sender, EventArgs e)
    {
        Wizard1.ActiveStepIndex = 2;
    }
    protected void Dropkat_DataBound(object sender, EventArgs e)
    {

    }
    protected void Dropspec_DataBound(object sender, EventArgs e)
    {
        Dropspec.DataBind();
    }
    protected void Dropspec_DataBinding(object sender, EventArgs e)
    {

    }
    protected void DropNaprav_SelectedIndexChanged(object sender, EventArgs e)
    {
        Dropspec.Items.Clear();
        //Dropspec.AppendDataBoundItems = true;
        //  Dropspec.Items.Insert(0, new ListItem(String.Empty, String.Empty));

        Dropspec.Items.Add(new ListItem("Выберите специальность", ""));

        Dropspec.AppendDataBoundItems = true;
    }
    protected void Button2_Click(object sender, EventArgs e)
    {

        // Button2.Attributes["onclick"] = "AlertHello()";
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {
        //      Page.RegisterStartupScript("MyScript",
        //"<script type='text/javascript'>    function generate(type) {        var n = noty({            text        : type,            type        : type,            dismissQueue: true,            layout      : 'topCenter',            theme       : 'defaultTheme',            maxVisible  : 10        });        console.log('html: ' + n.options.id);    }    function generateAll() {        generate('alert');        generate('information');        generate('error');        generate('warning');        generate('notification');        generate('success');    }    ;</script>");

        //  Page.ClientScript.RegisterStartupScript(this.GetType(), "alert", "generateAll()", true);
        // behin.Attributes.Add("onclick", "generateAll();");
        // Button2.Attributes["onclick"] = "generateAll()";



    }
    protected void Button2_Click2(object sender, EventArgs e)
    {
        RadNotification1.Text = "Категория не выбрана.";
        RadNotification1.Title = "Ошибка";
        RadNotification1.Show();

    }
}