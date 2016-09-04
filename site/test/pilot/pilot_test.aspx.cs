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
        if (Session["UserID"] == null)
        {
            Response.Redirect("/default.aspx");
        }
        system_info.Visible = false;

        if (!IsPostBack)
        {

            //проверка работоспособности таймера
            //if (!Timer1.Enabled)
            //{
            //    Timer1.Enabled = true;

            //    if (ViewState["timeLeft"] == null)
            //    {
            //        ViewState["timeLeft"] = Convert.ToString(Convert.ToInt32(Decrypt(Request.QueryString["time"])));
            //        Log("Пользователь: " + Session["UserID"].ToString() + " Установлено время " + ViewState["timeLeft"]);
            //    }
            //}

            //вывод вопроса если он еще не отобразился
            if (LblVopros.Text != null)
            {
                nextvopros();
            }

            // получаем количество отвеченых вопросов
            string GetNumberQueris = "SELECT    (15 - COUNT(*)) AS Expr1 FROM          proba_testirovanie GROUP BY ID_testiruemyj, ID_otvet HAVING      (ID_testiruemyj = @ID) AND (ID_otvet IS NULL)";
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
                        Potveta.Parameters.AddWithValue("@ID_voprosy", ViewState["vopros"]);
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
                        //string CountVoprosNull = "SELECT     COUNT(*) AS Count FROM         testirovanie WHERE     (ID_testiruemyj = @ID_testiruemyj) AND (ID_vopros = @ID_vopros) AND (ID_otvet IS NULL)"; // получаем вопросы из категории
                        //SqlCommand CVoprosNull = new SqlCommand(CountVoprosNull, con);
                        //CVoprosNull.Parameters.AddWithValue("@ID_testiruemyj", Session["UserID"]);
                        //CVoprosNull.Parameters.AddWithValue("@ID_vopros", ViewState["vopros"]);

                        //try
                        //{
                        //    con.Open();
                        //    int tmp1 = Convert.ToInt32(CVoprosNull.ExecuteScalar().ToString());
                        //    con.Close();
                        //    if (tmp1 == 1)
                        //    {


                        //        string UpdateOtvet = "UPDATE    testirovanie SET ID_otvet = @ID_Otvet WHERE     (ID_testiruemyj = @ID_testiruemyj) AND (ID_vopros = @ID_vopros)"; // получаем вопросы из категории
                        //        SqlCommand UOtvet = new SqlCommand(UpdateOtvet, con);
                        //        UOtvet.Parameters.AddWithValue("@ID_Otvet", CheckGroupOtvet.Items[i].Value);
                        //        UOtvet.Parameters.AddWithValue("@ID_testiruemyj", Session["UserID"]);
                        //        UOtvet.Parameters.AddWithValue("@ID_vopros", ViewState["vopros"]);
                        //        try
                        //        {
                        //            con.Open();
                        //            UOtvet.ExecuteNonQuery();
                        //            con.Close();
                        //        }
                        //        catch (Exception er)
                        //        {
                        //            con.Close();
                        //            Response.Redirect("~/error.aspx?error=104"); //Невозможно произвести запись контрольных сумм в таблицу!
                        //        }


                        //    }
                        //    else
                        //    {


                        //        string InsertOtvet = "INSERT INTO testirovanie (ID_testiruemyj, ID_vopros, ID_otvet, ID_test) VALUES     (@ID_testiruemyj,@ID_vopros,@ID_otvet, @ID_test)"; // получаем вопросы из категории
                        //        SqlCommand IOtvet = new SqlCommand(InsertOtvet, con);
                        //        IOtvet.Parameters.AddWithValue("@ID_otvet", CheckGroupOtvet.Items[i].Value);
                        //        IOtvet.Parameters.AddWithValue("@ID_testiruemyj", Session["UserID"]);
                        //        IOtvet.Parameters.AddWithValue("@ID_vopros", ViewState["vopros"]);
                        //        IOtvet.Parameters.AddWithValue("@ID_test", Request.QueryString["testID"].ToString());

                        //        try
                        //        {
                        //            con.Open();
                        //            IOtvet.ExecuteNonQuery();
                        //            con.Close();
                        //        }
                        //        catch (Exception er)
                        //        {
                        //            Response.Redirect("~/error.aspx?error=104"); //Невозможно произвести запись контрольных сумм в таблицу!
                        //        }

                        //    }
                        //}
                        //catch
                        //{
                        //}

                        //---ЗАПИСЬ ВЫБРАННЫХ ВАРИАНТОВ ОТВЕТА В БАЗУ ДАННЫХ
                       // con.Open();
                        string InsertOtvet = "UPDATE proba_testirovanie SET  ID_otvet = 1 WHERE     (ID_vopros = @ID_vopros) AND (ID_testiruemyj = @ID)"; // получаем вопросы из категории
                        SqlCommand IOtvet = new SqlCommand(InsertOtvet, con);
                        IOtvet.Parameters.AddWithValue("@ID", Session["UserID"]);
                        IOtvet.Parameters.AddWithValue("@ID_vopros", ViewState["vopros"]);
                        try
                        {
                            con.Open();
                            IOtvet.ExecuteNonQuery();
                            con.Close();
                        }
                        catch (Exception er)
                        {
                            con.Close();
                            Response.Redirect("~/error.aspx?error=104"); //Невозможно произвести запись контрольных сумм в таблицу!
                        }
                    }

                }
            }
            if (Pravilnyj > 0)
            {
              
                ////запись результата в таблицу прохождение теста
                //string UpdateResultTest = "UPDATE    prohozhdenie_testa SET              rezultat = @result WHERE     (ID = @ID_test)"; // получаем вопросы из категории
                //SqlCommand UresultTest = new SqlCommand(UpdateResultTest, con);
                //UresultTest.Parameters.AddWithValue("@result", OpredeleniePravelnixOtvetov() + 1);
                //UresultTest.Parameters.AddWithValue("@ID_test", Request.QueryString["testID"].ToString());
                //try
                //{
                //    con.Open();
                //    UresultTest.ExecuteNonQuery();
                //    con.Close();
                //}
                //catch (Exception er)
                //{
                //    Response.Redirect("~/error.aspx?error=104"); //Невозможно произвести запись контрольных сумм в таблицу!
                //}
                //finally
                //{
                //    con.Open();
                //    txtPravelOtv.Text = Convert.ToString(OpredeleniePravelnixOtvetov());
                //    con.Close();
                //}
                txtPravelOtv.Text = Convert.ToString((Convert.ToInt32(txtPravelOtv.Text) + 1));

            }

            //// ---КОНЕЦ---


            ////Вносим время в БД

            //string UpdateTime = " UPDATE    prohozhdenie_testa SET              time = @time WHERE     (ID = @ID_test)"; // получаем вопросы из категории
            //SqlCommand UT = new SqlCommand(UpdateTime, con);
            //UT.Parameters.AddWithValue("@time", Convert.ToInt32(ViewState["timeLeft"].ToString()));
            //UT.Parameters.AddWithValue("@ID_test", Request.QueryString["testID"].ToString());
            //con.Open();
            //try
            //{
            //    UT.ExecuteNonQuery();
            //    Log("УСПУШНО! Запись времени для ID теста: " + Request.QueryString["testID"].ToString() + ". Время: " + ViewState["timeLeft"].ToString());
            //    con.Close();
            //}
            //catch (Exception er)
            //{
            //    con.Close();
            //    Log("ОШИБКА! Запись времени для ID теста: " + Request.QueryString["testID"].ToString() + ". Время: " + ViewState["timeLeft"].ToString());
            //}




            CheckGroupOtvet.Items.Clear();
            CheckGroupOtvet.DataBind();
            nextvopros();
            NumberVopros.Text = Convert.ToString(Convert.ToInt32(NumberVopros.Text) + 1);
         //   Progress.Attributes["style"] = "width:" + ((Convert.ToDouble(NumberVopros.Text) / 70) * 100) + "%";
        }
        else
        {
            system_info.Visible = true;
            system_info.Text = "Ответ не выбран";
        }
    }
    protected void Timer1_Tick(object sender, EventArgs e)
    {
        //if (Convert.ToInt32(ViewState["timeLeft"]) > 0)
        //{
        //    ViewState["timeLeft"] = Convert.ToInt32(ViewState["timeLeft"]) - 1;
        //    txtTimer.Text = Convert.ToString(Math.Floor((Math.Sqrt(Convert.ToInt32(ViewState["timeLeft"].ToString()))) / 60)) + ":" + Convert.ToString(Math.Round((Math.Sqrt(Convert.ToInt32(ViewState["timeLeft"].ToString()))) % 60, 0));
        //}
        //else
        //{
        //    txtTimer.Text = "Время вышло!";
        //    CloseTest(); //завершение теста
        //}
    }

    private void nextvopros()
    {
        string SelectVoprosy = "SELECT  TOP (1)   ID_vopros FROM         proba_testirovanie WHERE     (ID_otvet IS NULL) AND (ID_testiruemyj = @ID)"; // получаем вопросы из категории
        using (SqlConnection conect = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString))
        {
            SqlCommand SVoprosy = new SqlCommand(SelectVoprosy, conect);
            SVoprosy.Parameters.AddWithValue("@ID", Session["UserID"]);
            try
            {
                conect.Open();
                ViewState["vopros"] = SVoprosy.ExecuteScalar().ToString();
                Label1.Text = ViewState["vopros"].ToString();

                conect.Close();

            }
            catch (Exception ex) 
            {
                con.Close();
                CloseTest(); 
            }
        }

        if (ViewState["vopros"] != null)
        {
            if (LblVopros.Text != null)
            {
                string SelectVopros = "SELECT     vopros FROM         voprosy WHERE     (id_voprosy = @IDVopros)"; // получаем вопросы из категории
                SqlCommand SVopros = new SqlCommand(SelectVopros, con);
                SVopros.Parameters.AddWithValue("@IDVopros", ViewState["vopros"]);
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

            //Вывод на экран сообщения " Вопрос может содержать несколько ответов"
            //---НАЧАЛО---
            SqlCommand command = con.CreateCommand();
            command.CommandText = "CountTrueOtvet";
            command.CommandType = CommandType.StoredProcedure;
            SqlParameter IDVoros = new SqlParameter("@IDVoros", ViewState["vopros"]);
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
            catch
            {

            }
            //---КОНЕЦ---
        }


    }

    string OpredelenieIdOtveta(string otvet)
    {
        //con.Open();
        string OpredelenieOtveta = "SELECT     id FROM         otveti WHERE     (otvet = @otvet) AND (ID_voprosy = @ID_vopros)"; // получаем вопросы из категории
        SqlCommand OOtveta = new SqlCommand(OpredelenieOtveta, conFunc);
        OOtveta.Parameters.AddWithValue("@otvet", otvet);
        OOtveta.Parameters.AddWithValue("@ID_vopros", ViewState["vopros"]);
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
        OPO.Parameters.AddWithValue("@ID_test", Request.QueryString["testID"].ToString());


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

    private void CloseTest()
    {
        DateTime saveNow = DateTime.Now; //Считываем текущую дату
        string DellProbaTest = "DELETE FROM proba_testirovanie WHERE     (ID_testiruemyj = @ID)"; // получаем вопросы из категории
        SqlCommand DPT = new SqlCommand(DellProbaTest, con);
        DPT.Parameters.AddWithValue("@ID", Session["UserID"]);
        try
        {
            con.Open();
            DPT.ExecuteNonQuery();
            con.Close();
            Log("УВЕДОМЛЕНИЕ Тест пользователя: " + Session["UserID"].ToString() + " завершен");
            Session["time"] = null;
            Session["Id_vopros"] = null;

            string UpdateProba = "UPDATE    [l-kabinet] SET              proba_test = 1 WHERE     (ID = @ID)"; // случайныйм образом выбираем вопросы из базы данных
            SqlCommand UProba = new SqlCommand(UpdateProba, con);
            UProba.Parameters.AddWithValue("@id", Session["UserID"].ToString());
            try
            {
                con.Open();
                UProba.ExecuteNonQuery();
                con.Close();

                Response.Redirect("/site/test/result.aspx?result=" + txtPravelOtv.Text+"&f=1");
            }
            catch
            {
                con.Close();
            }
            

        }
        catch (Exception er)
        {
            con.Close();
          //  Response.Redirect("~/error.aspx?error=105"); //Невозможно произвести запись контрольных сумм в таблицу!
            Log("ОШИБКА Тест пользователя: " + Session["UserID"].ToString() + " завершен. Невозможно произвести запись результатов в БД");
        }
    }
    //private void EndTest() //---ПРОЦЕДУРА ВЫПОЛНЯЕМОЯ ПОСЛЕ ПРОХОЖДЕНИЯ ТЕСТА
    //{

    //}



}