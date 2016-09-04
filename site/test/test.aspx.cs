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
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class site_test_test : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    SqlConnection conFunc = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    int i = 0;
    DateTime date1 = DateTime.Now;

    //---НАЧАЛО
    //ШИФРОВАНИЕ
    static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("kUyX2jHm");//ключ для шифрования
    public static string Decrypt(string cryptedString)
    {
        //try
        //{

        //    if (String.IsNullOrEmpty(cryptedString))
        //    {
        //        throw new ArgumentNullException
        //           ("Строка, которая должна быть расшифрована не может быть пустой");
        //    }
        //    DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        //    MemoryStream memoryStream = new MemoryStream
        //            (Convert.FromBase64String(cryptedString));
        //    CryptoStream cryptoStream = new CryptoStream(memoryStream,
        //        cryptoProvider.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
        //    StreamReader reader = new StreamReader(cryptoStream);
        //    return reader.ReadToEnd();
        //}
        //catch (Exception e)
        //{
        //    return Error(Convert.ToString(e));
        //}
        return cryptedString;
    }

    public static string Error(string mes) //Останавливает выполнение страницы если произошла обивка по выполнении функции
    {
        HttpContext.Current.Response.Redirect("/site/instruction.aspx?error=опаньки, ошибка", true);
        return null;
    }


    public static string Encrypt(string originalString)
    {
        //if (String.IsNullOrEmpty(originalString))
        //{
        //    throw new ArgumentNullException
        //           ("Строка, которая должна быть защифрована не может быть пустой.");
        //}
        //DESCryptoServiceProvider cryptoProvider = new DESCryptoServiceProvider();
        //MemoryStream memoryStream = new MemoryStream();
        //CryptoStream cryptoStream = new CryptoStream(memoryStream,
        //    cryptoProvider.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
        //StreamWriter writer = new StreamWriter(cryptoStream);
        //writer.Write(originalString);
        //writer.Flush();
        //cryptoStream.FlushFinalBlock();
        //writer.Flush();
        //return Convert.ToBase64String(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
        return originalString;
    }
    //---КОНЕЦ



    protected void Log(string log_mes)
    {
        //StreamWriter LogStream = new StreamWriter(@"C:\inetpub\wwwproject\log\test.txt", true);

        //try
        //{
        //    LogStream.WriteLine(Convert.ToString(date1) + " " + log_mes);
        //    LogStream.Close();
        //}
        //catch
        //{
        //}
    }


    protected void message(string mes) //вывод сообщений
    {

        LblVopros.Text = null;
        LblVopros.Text = mes;
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


    protected void Page_Load(object sender, EventArgs e)
    {
        Response.AppendHeader("Last-Modified", "-1");
        Response.AppendHeader("Expires", "-1");
        Response.AppendHeader("Cache-Control", "no-store, no-cache, must-revalidate");
        Response.AppendHeader("Cache-Control", "post-check=0, pre-check=0");
        Response.AddHeader("Pragma", "no-cache");
          double time=0;
        if (Session["UserID"] == null)
        {
            Response.Redirect("/default.aspx");
        }
        system_info.Visible = false;

        if (!IsPostBack)
        {

            //проверка работоспособности таймера
            if (!Timer1.Enabled)
            {
                Timer1.Enabled = true;

                if (Session["timeLeft"] == null)
                {
                    string LookTime2 = "SELECT     time FROM         prohozhdenie_testa WHERE     (ID_testiruemyj = @ID)"; // получаем вопросы из категории
                    SqlCommand LTime2 = new SqlCommand(LookTime2, con);
                    LTime2.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
                    try
                    {
                        con.Open();
                        int tmp = Convert.ToInt32(LTime2.ExecuteScalar().ToString());
                        con.Close();
                         if (tmp == 0)
                         {
                              time = 95 * 95;
                         }
                         else
                         {
                             time=tmp;
                         }
                        Session["timeLeft"] = Convert.ToString(time);
                    Log("Пользователь: " + Session["UserID"].ToString() + " Установлено время " + Session["timeLeft"]);
                    }
                    catch
                    {
                        con.Close();
                    }

                   
                }
              
            }

            //вывод вопроса если он еще не отобразился
            if (LblVopros.Text != null)
            {
                nextvopros();
            }

            // получаем количество отвеченых вопросов
            string GetNumberQueris = "SELECT    (70 - COUNT(*)) AS Expr1 FROM         testirovanie GROUP BY ID_testiruemyj, ID_otvet HAVING      (ID_testiruemyj = @ID) AND (ID_otvet IS NULL)";
            SqlCommand GNQ = new SqlCommand(GetNumberQueris, con);
            GNQ.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
            try
            {
                con.Open();
                NumberVopros.Text = GNQ.ExecuteScalar().ToString();
                Progress.Attributes["style"] = "width:" + ((Convert.ToDouble(NumberVopros.Text) / 70) * 100) + "%";
                con.Close();
            }
            catch
            {
                con.Close();
                Log("ОШИБКА Не удалось получить количество отвеченых вопросов для пользователя: " + Session["UserID"].ToString());
            }

            //получаем количество правильных ответов

            string GetTruOtvet = "SELECT     rezultat FROM         prohozhdenie_testa WHERE     (ID_testiruemyj = @ID)";
            SqlCommand GTO = new SqlCommand(GetTruOtvet, con);
            GTO.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
            try
            {
                con.Open();
                txtPravelOtv.Text = GTO.ExecuteScalar().ToString();
               
                con.Close();
            }
            catch
            {
                con.Close();
                Log("ОШИБКА Не удалось получить количество отвеченых вопросов для пользователя: " + Session["UserID"].ToString());
            }
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

    }
    protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
    {

    }
    protected void CheckGroupOtvet_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void btnNextVopros_Click(object sender, EventArgs e)
    {
        //Проверка на правильность выбранных вариантов
        //---НАЧАЛО---
        Boolean statusCK = false; //тру если выбран один из чекетов
        for (int g = 0; g < CheckGroupOtvet.Items.Count; g++)
        {
            if (CheckGroupOtvet.Items[g].Selected)
            {
                statusCK = true;

                break;
            }
        }


        if (statusCK == true)
        {
            int Pravilnyj = 0;
            if (LblVopros.Text != "")
            {
                for (int i = 0; i < CheckGroupOtvet.Items.Count; i++)
                {
                    if (CheckGroupOtvet.Items[i].Selected)
                    {
                        //---ЗАПРОС НА ОПЕРЕДЕЛЕНИЯ ПРАВИЛЬНОГО ВЫБРАННОГО ВАРИАНТА ОТВЕТА

                        string ProverkaOrveta = "SELECT     vernyj FROM         otveti WHERE     (ID_voprosy = @ID_voprosy) AND (id = @IDotvet)"; // получаем вопросы из категории
                        SqlCommand Potveta = new SqlCommand(ProverkaOrveta, con);
                        Potveta.Parameters.AddWithValue("@IDotvet", CheckGroupOtvet.Items[i].Value);
                        Potveta.Parameters.AddWithValue("@ID_voprosy", Session["vopros"]);
                        try
                        {
                            con.Open();
                            int tmp = Convert.ToInt32(Potveta.ExecuteScalar());
                            con.Close();

                            if (tmp == 1)
                            {
                                Pravilnyj++;
                            }
                            else
                            {
                                Pravilnyj--;
                            }
                        }
                        catch
                        {
                            con.Close();
                        }


                        //---ЗАПИСЬ ВЫБРАННЫХ ВАРИАНТОВ ОТВЕТА В БАЗУ ДАННЫХ
                        string CountVoprosNull = "SELECT     COUNT(*) AS Count FROM         testirovanie WHERE     (ID_testiruemyj = @ID_testiruemyj) AND (ID_vopros = @ID_vopros) AND (ID_otvet IS NULL)"; // получаем вопросы из категории
                        SqlCommand CVoprosNull = new SqlCommand(CountVoprosNull, con);
                        CVoprosNull.Parameters.AddWithValue("@ID_testiruemyj", Session["UserID"]);
                        CVoprosNull.Parameters.AddWithValue("@ID_vopros", Session["vopros"]);

                        try
                        {
                            con.Open();
                            int tmp1 = Convert.ToInt32(CVoprosNull.ExecuteScalar().ToString());
                            con.Close();
                            if (tmp1 == 1)
                            {


                                string UpdateOtvet = "UPDATE    testirovanie SET ID_otvet = @ID_Otvet WHERE     (ID_testiruemyj = @ID_testiruemyj) AND (ID_vopros = @ID_vopros)"; // получаем вопросы из категории
                                SqlCommand UOtvet = new SqlCommand(UpdateOtvet, con);
                                UOtvet.Parameters.AddWithValue("@ID_Otvet", CheckGroupOtvet.Items[i].Value);
                                UOtvet.Parameters.AddWithValue("@ID_testiruemyj", Session["UserID"]);
                                UOtvet.Parameters.AddWithValue("@ID_vopros", Session["vopros"]);
                                try
                                {
                                    con.Open();
                                    UOtvet.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch (Exception er)
                                {
                                    con.Close();
                                    Response.Redirect("~/error.aspx?error=104"); //Невозможно произвести запись контрольных сумм в таблицу!
                                }


                            }
                            else
                            {


                                string InsertOtvet = "INSERT INTO testirovanie (ID_testiruemyj, ID_vopros, ID_otvet, ID_test) VALUES     (@ID_testiruemyj,@ID_vopros,@ID_otvet, @ID_test)"; // получаем вопросы из категории
                                SqlCommand IOtvet = new SqlCommand(InsertOtvet, con);
                                IOtvet.Parameters.AddWithValue("@ID_otvet", CheckGroupOtvet.Items[i].Value);
                                IOtvet.Parameters.AddWithValue("@ID_testiruemyj", Session["UserID"]);
                                IOtvet.Parameters.AddWithValue("@ID_vopros", Session["vopros"]);
                                IOtvet.Parameters.AddWithValue("@ID_test", Request.QueryString["testID"].ToString());

                                try
                                {
                                    con.Open();
                                    IOtvet.ExecuteNonQuery();
                                    con.Close();
                                }
                                catch (Exception er)
                                {
                                    Response.Redirect("~/error.aspx?error=104"); //Невозможно произвести запись контрольных сумм в таблицу!
                                }

                            }
                        }
                        catch
                        {
                        }
                    }

                }
            }
            if (Pravilnyj > 0)
            {
                con.Open();
                //запись результата в таблицу прохождение теста
                string UpdateResultTest = "UPDATE    prohozhdenie_testa SET              rezultat = @result WHERE     (ID = @ID_test)"; // получаем вопросы из категории
                SqlCommand UresultTest = new SqlCommand(UpdateResultTest, con);
                UresultTest.Parameters.AddWithValue("@result", OpredeleniePravelnixOtvetov() + 1);
                UresultTest.Parameters.AddWithValue("@ID_test", Request.QueryString["testID"].ToString());
                try
                {
                    UresultTest.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception er)
                {
                    Response.Redirect("~/error.aspx?error=104"); //Невозможно произвести запись контрольных сумм в таблицу!
                }
                finally
                {
                    con.Open();
                    txtPravelOtv.Text = Convert.ToString(OpredeleniePravelnixOtvetov());
                    con.Close();
                }

            }

            // ---КОНЕЦ---


            //Вносим время в БД

            string UpdateTime = " UPDATE    prohozhdenie_testa SET              time = @time WHERE     (ID = @ID_test)"; // получаем вопросы из категории
            SqlCommand UT = new SqlCommand(UpdateTime, con);
            UT.Parameters.AddWithValue("@time", Convert.ToInt32(Session["timeLeft"].ToString()));
            UT.Parameters.AddWithValue("@ID_test", Request.QueryString["testID"].ToString());
            con.Open();
            try
            {
                UT.ExecuteNonQuery();
                Log("УСПУШНО! Запись времени для ID теста: " + Request.QueryString["testID"].ToString() + ". Время: " + Session["timeLeft"].ToString());
                con.Close();
            }
            catch (Exception er)
            {
                con.Close();
                Log("ОШИБКА! Запись времени для ID теста: " + Request.QueryString["testID"].ToString() + ". Время: " + Session["timeLeft"].ToString());
            }




            CheckGroupOtvet.Items.Clear();
            CheckGroupOtvet.DataBind();
            nextvopros();
            NumberVopros.Text = Convert.ToString(Convert.ToInt32(NumberVopros.Text) + 1);
          //  Progress.Attributes["style"] = "width:" + ((Convert.ToDouble(NumberVopros.Text) / 70) * 100) + "%";
            Response.Redirect("/site/test/test.aspx?testID=" + Request.QueryString["testID"].ToString());
        }
        else
        {
            system_info.Visible = true;
            system_info.Text = "Ответ не выбран";
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        if (Convert.ToInt32(Session["timeLeft"]) > 0)
        {
            Session["timeLeft"] = Convert.ToInt32(Session["timeLeft"]) - 1;
            txtTimer.Text = Convert.ToString(Math.Floor((Math.Sqrt(Convert.ToInt32(Session["timeLeft"].ToString()))) / 60)) + ":" + Convert.ToString(Math.Round((Math.Sqrt(Convert.ToInt32(Session["timeLeft"].ToString()))) % 60, 0));
        }
        else
        {
            txtTimer.Text = "Время вышло!";
            CloseTest(); //завершение теста
        }
    }

    private void nextvopros()
    {
        Session["vopros"] = null;
        SqlCommand GetIdVopros = con.CreateCommand();
        GetIdVopros.CommandText = "GetIdVopros";
        GetIdVopros.CommandType = CommandType.StoredProcedure;
        SqlParameter _ID_user = new SqlParameter("@ID_user", Session["UserID"].ToString());
        GetIdVopros.Parameters.Add(_ID_user);
        try
        {

            con.Open();
            Session["vopros"] = GetIdVopros.ExecuteScalar().ToString();
            con.Close();
            Label1.Text = Session["vopros"].ToString();
            Log("Пользователь: " + Session["UserID"] + "Номер вопроса: " + Session["vopros"]);



        }
        catch
        {
            con.Close();
        }

        if (Session["vopros"] != null)
        {
            if (LblVopros.Text != null)
            {
                string SelectVopros = "SELECT     vopros FROM         voprosy WHERE     (id_voprosy = @IDVopros)"; // получаем вопросы из категории
                SqlCommand SVopros = new SqlCommand(SelectVopros, con);
                SVopros.Parameters.AddWithValue("@IDVopros", Session["vopros"]);
                try
                {
                    con.Open();
                    message(SVopros.ExecuteScalar().ToString());
                    con.Close();
                }
                catch
                {
                    con.Close();
                    Log("Вопросы не были получены");
                }
            }
            else
            {
                CloseTest();
            }

            //Вывод на экран сообщения "Вопрос может содержать несколько ответов"
            //---НАЧАЛО---
            SqlCommand command = con.CreateCommand();
            command.CommandText = "CountTrueOtvet";
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter IDVoros = new SqlParameter("@IDVoros", Session["vopros"]);
            command.Parameters.Add(IDVoros);
            try
            {
                con.Open();
                if (Convert.ToInt32(command.ExecuteScalar().ToString()) > 1)
                {
                    system_info.Visible = true;
                    con.Close();
                }
                else
                {
                    system_info.Visible = false;
                    con.Close();
                }

            }
            catch (Exception ex)
            {
                con.Close();
                
            }
            //---КОНЕЦ---
        }
        else
        {
            CloseTest();
        }


    }

    string OpredelenieIdOtveta(string otvet)
    {
        //con.Open();
        string OpredelenieOtveta = "SELECT     id FROM         otveti WHERE     (otvet = @otvet) AND (ID_voprosy = @ID_vopros)"; // получаем вопросы из категории
        SqlCommand OOtveta = new SqlCommand(OpredelenieOtveta, conFunc);
        OOtveta.Parameters.AddWithValue("@otvet", otvet);
        OOtveta.Parameters.AddWithValue("@ID_vopros", Session["vopros"]);
        try
        {
            conFunc.Open();
            string tmp = OOtveta.ExecuteScalar().ToString();
            conFunc.Close();
            return tmp;
        }
        catch
        {
            conFunc.Close();
            return null; // здесь нужно подумать чего возвращать
        }


    }

    int OpredeleniePravelnixOtvetov()
    {
        //con.Open();
        string OpredeleniePravelnixOtvetov = "SELECT     rezultat FROM         prohozhdenie_testa WHERE     (ID = @ID_test)"; // получаем вопросы из категории
        SqlCommand OPO = new SqlCommand(OpredeleniePravelnixOtvetov, conFunc);
        OPO.Parameters.AddWithValue("@ID_test", Request.QueryString["testID"]);


        try
        {
            conFunc.Open();
            int tmp = Convert.ToInt32(OPO.ExecuteScalar());
            conFunc.Close();
            return tmp;
        }
        catch
        {
            conFunc.Close();
            return 0; //доработать функцию
        }

    }

    int OpredelenieSpec()
    {

        //con.Open();
        string SelectSpec = "SELECT     ID_dolzhnost FROM         [l-kabinet] WHERE     (ID =@ID)"; // получаем вопросы из категории
        SqlCommand SSpec = new SqlCommand(SelectSpec, conFunc);
        SSpec.Parameters.AddWithValue("@ID", Session["UserID"]);
        try
        {
            conFunc.Open();
            int tmp = (int)SSpec.ExecuteScalar();
            conFunc.Close();
            return tmp;
        }
        catch
        {
            conFunc.Close();
            return 0; // здесь нужно подумать чего возвращать
        }
    }


    int GetResultTest()
    {
        int tmp = 0;
        string GetResultSql = "SELECT        rezultat FROM            prohozhdenie_testa WHERE        (ID_testiruemyj = @ID_testiruemyj)"; // получаем вопросы из категории
        SqlCommand GRSQL = new SqlCommand(GetResultSql, con);
        GRSQL.Parameters.AddWithValue("@ID_testiruemyj", Session["UserID"]);
        try
        {

            con.Open();
            tmp = Convert.ToInt32(GRSQL.ExecuteScalar().ToString());
            con.Close();
        }
        catch (Exception)
        {
            con.Close();

        }

        return tmp;
    }
    private void CloseTest()
    {

        DateTime saveNow = DateTime.Now; //Считываем текущую дату
        string InsertFinishTest = "UPDATE    prohozhdenie_testa SET              status =@status, data =@data, rezultat =@rezultat WHERE     (ID = @ID_testa) AND (ID_testiruemyj = @ID_testiruemyj)"; // получаем вопросы из категории
        SqlCommand IFinishTest = new SqlCommand(InsertFinishTest, con);
        IFinishTest.Parameters.AddWithValue("@ID_testiruemyj", Session["UserID"]);
        IFinishTest.Parameters.AddWithValue("@status", 1);
        IFinishTest.Parameters.AddWithValue("@rezultat", GetResultTest());
        IFinishTest.Parameters.AddWithValue("@data", saveNow);
        IFinishTest.Parameters.AddWithValue("@ID_testa", Request.QueryString["testID"]);
        try
        {
            con.Open();
            IFinishTest.ExecuteNonQuery();
            con.Close();
            Log("УВЕДОМЛЕНИЕ Тест пользователя: " + Session["UserID"].ToString() + " завершен");
            Session["time"] = null;
            Session["Id_vopros"] = null;
            Response.Redirect("/site/test/result.aspx?test=" + Request.QueryString["testID"].ToString());
        }
        catch (Exception er)
        {
            con.Close();
           // Response.Redirect("~/error.aspx?error=105"); //Невозможно произвести запись контрольных сумм в таблицу!
            Log("ОШИБКА Тест пользователя: " + Session["UserID"].ToString() + " завершен. Невозможно произвести запись результатов в БД");
        }
    }
    //private void EndTest() //---ПРОЦЕДУРА ВЫПОЛНЯЕМОЯ ПОСЛЕ ПРОХОЖДЕНИЯ ТЕСТА
    //{

    //}



}