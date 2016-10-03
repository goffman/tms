using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using FluentNHibernate.Testing.Values;
using Hibernate;
using Hibernate.Domain;
using NHibernate.Linq;
using Telerik.Web.Data.Extensions;

public partial class admin_users_search : System.Web.UI.Page
{
    public static String LoginVar;
    public static String PassVar;
    public static string LStatus;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД


    //protected void Page_Init(object sender, EventArgs e)
    //{
    //    if (Request.QueryString["a"] != null)
    //    {
    //        Response.Cookies["a"].Value = Request.QueryString["a"];
    //        Response.Cookies["a"].Expires = DateTime.Now.AddDays(1);

    //        //ViewState["a"] = ;
    //        //// Редирект без QueryString
    //        Response.Redirect("/admin/users/search.aspx", true);
    //    }
    //}

    //public string GetUriWithoutQueryStr(Uri url)
    //{
    //    return url.GetLeftPart(UriPartial.Path);
    //}


    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["a"] != null)
        {
            SqlDataSource2.SelectParameters["FIO"].DefaultValue = Session["a"].ToString() + "%";
            RadGrid1.DataBind();
            Session["a"] = null;
        }
    }


    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {

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

    private void AlertNotif(string title, string text)
    {

        //      Response.Write("Info('sdasd')");
        alert.Visible = true;
        AlertText.Text += text + "<br/>";
        AlertTitle.Text = title;

    }

    protected void AlertNotifClear()
    {
        alert.Visible = false;
        AlertText.Text = null;
        AlertTitle.Text = null;

    }



    int GetActivationStatus()
    {
        string ActivationStatus = "SELECT        activation_id FROM            users WHERE        (ID_l_kabinet = @IDKabinet)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand AS = new SqlCommand(ActivationStatus, con);
        AS.Parameters.AddWithValue("@IDKabinet", IDAccount.Value);
        string tmp = null;
        try
        {
            con.Open();
            tmp = AS.ExecuteScalar().ToString();
            con.Close();
            if (tmp == "1")
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        catch (Exception)
        {
            con.Close();
            return 0;

        }

    }
    protected void parol_Click(object sender, EventArgs e)
    {
        string Operation = "Изминения пароля";
        //Процедура изминения пароля пользователя
        Random rand = new Random();

        int tmp = rand.Next(1000000); //генерация случайного числа для пароля
        int tmpActivation = rand.Next(1000000); //генерация случайного числа для активации

        string ActivationText = null;
        AlertNotifClear();//чистка уведомлений


        if (GetActivationStatus() == 0)
        {

            string UpdateActivation = "UPDATE       users SET                activation_id = @activation_id WHERE        (ID_l_kabinet = @IDKabinet)"; // делаем запрос с введеным в тектовое поле логином
            SqlCommand UA = new SqlCommand(UpdateActivation, con);
            UA.Parameters.AddWithValue("@activation_id", GetHashString(Convert.ToString(tmpActivation)));
            UA.Parameters.AddWithValue("@IDKabinet", IDAccount.Value);
            try
            {
                con.Open();
                UA.ExecuteNonQuery();
                con.Close();
                AlertNotif(Operation, "Код активации: Обновлен на новый " + Convert.ToString(tmpActivation));
                ActivationText = " Код активации: " + tmpActivation;
            }
            catch (Exception ex)
            {
                con.Close();
                AlertNotif(Operation, "Код активации: " + ex.Message);
            }
        }




        string UpdatePassword = "UPDATE users SET                Password = @Password WHERE        (ID_l_kabinet = @IDKabinet)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand UP = new SqlCommand(UpdatePassword, con);
        UP.Parameters.AddWithValue("@Password", GetHashString(Convert.ToString(tmp)));
        UP.Parameters.AddWithValue("@IDKabinet", IDAccount.Value);
        try
        {
            con.Open();
            UP.ExecuteScalar();
            con.Close();
            LoginVar = "dremlygov@mail.ru";
            PassVar = "224433160a49d26d440d394c4d657fe1";
            try
            {
                MSender(telefon.Value.Replace(" ", string.Empty), "Логин: " + UserName.Value + " Пароль: " + tmp + ActivationText);
                AlertNotif(Operation, "Статус отправки смс: Сообщение успешно отправлено");
            }
            catch (Exception ex)
            {

                AlertNotif(Operation, "Статус отправки смс: " + ex.Message);
            }

            try
            {
                SendMail(email.Value, "Пароль уcпешно изменен. <br/>" + "Логин: " + UserName.Value + " Пароль: " + tmp + ActivationText, "Изминение пароля в системе ТМС");
                AlertNotif(Operation, "Статус отправки e-mail: Сообщение успешно отправлено");
            }
            catch (Exception ex)
            {

                AlertNotif(Operation, "Статус отправки mail: " + ex.Message);
            }

            AlertNotif(Operation, "Пароль успушно изменен на новый: " + Convert.ToString(tmp));
        }
        catch (Exception ex)
        {
            con.Close();
            AlertNotif("Ошибка", ex.Message);
        }


    }


    private void ConversionResults(int idLkabiner)
    {

        var session = DataBase.GetSession();
        if (session != null)
        {
            var tmpResult = 0;
            Dictionary<Voprosy, List<int>> tmp = new Dictionary<Voprosy, List<int>>();
            var s = session.Query<Testirovanie>().Where(testirovanie => testirovanie.Lkabinet == Lkabinet.GetById(idLkabiner)).ToList();
            foreach (var item in s)
            {
                if (tmp.ContainsKey(item.IdVopros))
                {
                    if (item.IdOtvet != null) tmp[item.IdVopros].AddRange(new[] { (int)item.IdOtvet });
                }
                else { if (item.IdOtvet != null) tmp.Add(item.IdVopros, new List<int>() { (int)item.IdOtvet }); }
            }
           
            foreach (var item in tmp)
            {
             
                var otvety =
                    session.Query<Otveti>()
                        .Where(otveti => otveti.IdVoprosy == item.Key.IdVoprosy && otveti.Vernyj == 1)
                        .ToList();
                var countPrOtvet = otvety.Count;
                var countOtvet = item.Value.Select(t => otvety.FirstOrDefault(otveti => otveti.Id == t)).Count(w => w != null);

                if (countPrOtvet==countOtvet)++tmpResult;
              
            }

            ProhozhdenieTesta.UpdateResultProhozhdenieTesta(idLkabiner, tmpResult);
            RadGrid1.DataBind();
            AlertNotifClear();
            AlertNotif("Успех", "Результаты пересчета: " + Convert.ToString(tmpResult) + " правильных ответа");
        }

    }
    protected void result_Click(object sender, EventArgs e)
    {
        ConversionResults(Convert.ToInt32(IDAccount.Value));
        //var session = DataBase.GetSession();
        //if (session != null)
        //{

        //    var l = session.QueryOver<Lpu>().List();
        //    var l2 = session.QueryOver<Lpu>();
        //    var s4 = session.QueryOver<Lkabinet>().List();
        //    //  View(s);
        //    //foreach (var item in s)
        //    //{
        //    //    Debug.WriteLine(item.IdVopros);
        //    //}
        //}
        //AlertNotifClear();
        //int tmp = 0;
        //string ReCountOtvet = "SELECT        COUNT(*) AS Expr1 FROM            testirovanie INNER JOIN otveti ON testirovanie.ID_otvet = otveti.id GROUP BY testirovanie.ID_testiruemyj, otveti.vernyj HAVING        (testirovanie.ID_testiruemyj = @IDKabinet) AND (otveti.vernyj = 1)"; // делаем запрос с введеным в тектовое поле логином
        //SqlCommand RCO = new SqlCommand(ReCountOtvet, con);
        //RCO.Parameters.AddWithValue("@IDKabinet", IDAccount.Value);
        //try
        //{
        //    con.Open();
        //    tmp = Convert.ToInt32(RCO.ExecuteScalar().ToString());
        //    con.Close();

        //    AlertNotif("Успех", "Результаты пересчета: " + Convert.ToString(tmp) + " правильных ответа");
        //    if (tmp >= 70)
        //    {
        //        tmp = 70;
        //    }
        //    string UpdateOtvet = "UPDATE       prohozhdenie_testa SET                rezultat = @result WHERE        (ID_testiruemyj = @IDKabinet)"; // делаем запрос с введеным в тектовое поле логином
        //    SqlCommand UO = new SqlCommand(UpdateOtvet, con);
        //    UO.Parameters.AddWithValue("@result", tmp);
        //    UO.Parameters.AddWithValue("@IDKabinet", IDAccount.Value);
        //    try
        //    {
        //        con.Open();
        //        UO.ExecuteNonQuery();
        //        con.Close();
        //        RadGrid1.DataBind();
        //    }
        //    catch (Exception ex)
        //    {

        //        con.Close();
        //        AlertNotif("Ошибка", ex.Message);
        //    }

        //}
        //catch (Exception ex)
        //{
        //    con.Close();
        //    AlertNotif("Ошибка", ex.Message);

        //}



    }

    protected void Button1_Click1(object sender, EventArgs e)
    {

    }
    protected void Unnamed1_ValueChanged(object sender, EventArgs e)
    {

    }
    //protected void OK_Click(object sender, EventArgs e)
    //{
    //    if (IDAccount.Value != "")
    //    {
    //        if (RadCaptcha1.IsValid)
    //        {
    //            if (ReasonsRemovalTests.Text.Length > 10)
    //            {
    //                string InsertCancellationResults =
    //                    "INSERT INTO CancellationResults (AccountID, date, IDAdmin, Reason) VALUES        (@UserID, GETDATE(), 1,@Reason)";
    //                // делаем запрос с введеным в тектовое поле логином
    //                SqlCommand ICR = new SqlCommand(InsertCancellationResults, con);
    //                ICR.Parameters.AddWithValue("@UserID", IDAccount.Value);
    //                ICR.Parameters.AddWithValue("@Reason", ReasonsRemovalTests.Text);
    //                try
    //                {
    //                    con.Open();
    //                    ICR.ExecuteNonQuery();
    //                    con.Close();
    //                }
    //                catch (Exception ex)
    //                {

    //                    con.Close();
    //                    AlertNotif("Ошибка", ex.Message);
    //                }



    //                int tmp1 = 0;
    //                int tmp2 = 0;
    //                string DeleteProhozhdenieTesta =
    //                    "DELETE FROM prohozhdenie_testa WHERE        (ID_testiruemyj = @IDKabinet) ";
    //                // делаем запрос с введеным в тектовое поле логином
    //                SqlCommand DPT = new SqlCommand(DeleteProhozhdenieTesta, con);
    //                DPT.Parameters.AddWithValue("@IDKabinet", IDAccount.Value);
    //                try
    //                {
    //                    con.Open();
    //                    DPT.ExecuteScalar();
    //                    con.Close();
    //                    tmp1 = 1;
    //                }
    //                catch (Exception ex)
    //                {
    //                    con.Close();
    //                    AlertNotif("Ошибка", ex.Message);

    //                }

    //                string DeleteTestirovanie = "DELETE FROM testirovanie WHERE        (ID_testiruemyj = @IDKabinet)";
    //                // делаем запрос с введеным в тектовое поле логином
    //                SqlCommand DT = new SqlCommand(DeleteTestirovanie, con);
    //                DT.Parameters.AddWithValue("@IDKabinet", IDAccount.Value);
    //                try
    //                {
    //                    con.Open();
    //                    DT.ExecuteScalar();
    //                    con.Close();
    //                    tmp2 = 1;
    //                }
    //                catch (Exception ex)
    //                {
    //                    con.Close();
    //                    AlertNotif("Ошибка", ex.Message);

    //                }

    //                if (tmp1 == 1 & tmp2 == 1)
    //                {

    //                    AlertNotif("Успех", "Тесты для пользователя с ID " + IDAccount.Value + " аннулированы");
    //                    RadGrid1.DataBind();
    //                    ReasonsRemovalTests.Text = string.Empty;
    //                }
    //            }


    //        }
    //        else
    //        {
    //            AlertNotif("Ошибка", "Текст с картинки введен неверно");

    //        }
    //    }
    //    else
    //    {
    //        AlertNotif("Ошибка", "Не выбран пользователь");
    //    }

    //}

    protected void BtnSearch_Click(object sender, ImageClickEventArgs e)
    {
        SqlDataSource2.SelectParameters["FIO"].DefaultValue = SearchTextBox.Text + "%";
        RadGrid1.DataBind();
    }
    protected void SearchTextBox_TextChanged(object sender, EventArgs e)
    {

        //SqlDataSource2.SelectParameters["FIO"].DefaultValue = Request.QueryString["a"] + "%";
        //RadGrid1.DataBind();


        SqlDataSource2.SelectParameters["FIO"].DefaultValue = SearchTextBox.Text.Trim() + "%";
        RadGrid1.DataBind();
    }

    //Проверка блокировок пользователя
    int CheckLock(int UserID)
    {
        int tmp = 0;
        string CheckLockSQL = "SELECT        on_delete FROM            [l-kabinet] WHERE        (ID = @UserID)";
        SqlCommand CLS = new SqlCommand(CheckLockSQL, con);
        CLS.Parameters.AddWithValue("@UserID", UserID);
        try
        {
            con.Open();
            tmp = Convert.ToInt32(CLS.ExecuteScalar());
            con.Close();
            return tmp;
        }
        catch (Exception)
        {

            con.Close();
            return tmp;
        }


    }
    //Блокировка пользователя
    protected void BlackListButton_Click(object sender, EventArgs e)
    {
        string text = string.Empty;

        if (DropDownListBlockReasons.SelectedValue != string.Empty)
        {
            text = DropDownListBlockReasons.SelectedValue;
        }
        else if (BlockPrichina.Text.Length > 10)
        {
            text = BlockPrichina.Text;
        }

        if (text != string.Empty)
        {
            if (CheckLock(Convert.ToInt32(IDAccount.Value)) == 0)
            {
                string BlockAdd =
                    "INSERT INTO BlockedUsers (IDUsers, Blocked, date) VALUES        (@UserID,@Blocked, GETDATE())  UPDATE       [l-kabinet] SET                on_delete = 1 WHERE        (ID = @UserID)";
                SqlCommand BA = new SqlCommand(BlockAdd, con);
                BA.Parameters.AddWithValue("@UserID", IDAccount.Value);
                BA.Parameters.AddWithValue("@Blocked", text);
                try
                {
                    con.Open();
                    BA.ExecuteNonQuery();
                    con.Close();
                    AlertNotif("Успех", "Пользователь с ID " + IDAccount.Value + " заблокирован по причине: " + text);
                    SendMail(email.Value,
                        "Учетная запись " + UserName.Value + " (" + F.Value + " " + I.Value + " " + O.Value +
                        ")  на сайте тестирования медицинских специалистов <a href='tms.miacrh.ru'>tms.miacrh.ru</a> заблокирована по причине: " +
                        text +
                        " <br/> Через 10 дней учетная запись будет удалена. Если у Вас возникла вопросы, свяжитесь с службой технической поддержки по телефону 8 (3902) 295-025.",
                        "Учетная запись " + UserName.Value + " заблокирована");
                    RadGrid1.DataBind();
                }
                catch (Exception ex)
                {
                    con.Close();
                    AlertNotif("Ошибка", ex.Message);
                }
            }
            else
            {
                AlertNotif("Внимание", "Пользователь " + IDAccount.Value + " уже заблокирован");
            }


        }
        else
        {
            AlertNotif("Ошибка", "Не указана причина блокировки пользователя");

        }
        BlockPrichina.Text = string.Empty;
        //    BlockPrichina.DataBind();
        DropDownListBlockReasons.Items.Clear();
        DropDownListBlockReasons.Items.Add(new ListItem("", ""));

        DropDownListBlockReasons.AppendDataBoundItems = true;
        DropDownListBlockReasons.DataBind();
    }
    protected void LinkButton2_Click(object sender, EventArgs e)
    {
        string RemoveLock = "  DELETE FROM BlockedUsers WHERE        (IDUsers = @UserID) UPDATE       [l-kabinet] SET                on_delete = NULL WHERE        (ID = @UserID)";
        SqlCommand RL = new SqlCommand(RemoveLock, con);
        RL.Parameters.AddWithValue("@UserID", IDAccount.Value);
        try
        {
            con.Open();
            RL.ExecuteNonQuery();
            con.Close();
            AlertNotif("Успех", "Блокировка удалена у пользователя с ID " + IDAccount.Value);
            RadGrid1.DataBind();
        }
        catch (Exception ex)
        {

            con.Close();
            AlertNotif("Ошибка", ex.Message);
        }

    }

    //protected void ChangeSpecialtyButton_Click(object sender, EventArgs e)
    //{

    //    if (IDAccount.Value != "")
    //    {
    //        string DeleteProhozhdenieTesta =
    //                    "DELETE FROM prohozhdenie_testa WHERE        (ID_testiruemyj = @IDKabinet) ";
    //        // делаем запрос с введеным в тектовое поле логином
    //        SqlCommand DPT = new SqlCommand(DeleteProhozhdenieTesta, con);
    //        DPT.Parameters.AddWithValue("@IDKabinet", IDAccount.Value);
    //        try
    //        {
    //            con.Open();
    //            DPT.ExecuteScalar();
    //            con.Close();

    //        }
    //        catch (Exception ex)
    //        {
    //            con.Close();
    //            AlertNotif("Ошибка", ex.Message);

    //        }

    //        string DeleteTestirovanie = "DELETE FROM testirovanie WHERE        (ID_testiruemyj = @IDKabinet)";
    //        // делаем запрос с введеным в тектовое поле логином
    //        SqlCommand DT = new SqlCommand(DeleteTestirovanie, con);
    //        DT.Parameters.AddWithValue("@IDKabinet", IDAccount.Value);
    //        try
    //        {
    //            con.Open();
    //            DT.ExecuteScalar();
    //            con.Close();

    //        }
    //        catch (Exception ex)
    //        {
    //            con.Close();
    //            AlertNotif("Ошибка", ex.Message);

    //        }

    //        string UpdateDolz = " UPDATE       [l-kabinet] SET                ID_dolzhnost = @dolzhnost WHERE        (ID = @UserID)";
    //        // делаем запрос с введеным в тектовое поле логином
    //        SqlCommand UD = new SqlCommand(UpdateDolz, con);
    //        UD.Parameters.AddWithValue("@UserID", IDAccount.Value);
    //        UD.Parameters.AddWithValue("@dolzhnost", DropChangeSpec.SelectedValue);
    //        try
    //        {
    //            con.Open();
    //            UD.ExecuteScalar();
    //            con.Close();

    //        }
    //        catch (Exception ex)
    //        {
    //            con.Close();
    //            AlertNotif("Ошибка", ex.Message);

    //        }

    //        AlertNotif("Успех","Специальность обновлена");
    //        RadGrid1.DataBind();

    //    }
    //}
}