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

public partial class site_instruction : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    protected void Log(string log_mes)
    {
        //StreamWriter LogStream = new StreamWriter(@"C:\inetpub\wwwproject\log\reg.txt", true);

        //try
        //{
        //    LogStream.WriteLine(log_mes);
        //    LogStream.Close();
        //}
        //catch
        //{
        //}
    }

    string dolz;
    static byte[] bytes = ASCIIEncoding.ASCII.GetBytes("kUyX2jHm");//ключ для шифрования
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

        if (!IsPostBack)
        {
            // проверка сопастовления номера теста и ИД пользователя
            if (Request.QueryString["testID"] != null)
            {
                SqlCommand command = con.CreateCommand();
                command.CommandText = "CheckTestIDUserID";
                command.CommandType = CommandType.StoredProcedure;
                SqlParameter TestID = new SqlParameter("@TestID", Request.QueryString["testID"].ToString());
                SqlParameter UserID = new SqlParameter("@UserID", Session["UserID"]);
                command.Parameters.Add(TestID);
                command.Parameters.Add(UserID);
                //    con.Open();
                try
                {
                    con.Open();
                    int tmp = Convert.ToInt32(command.ExecuteScalar().ToString());
                    con.Close();
                    if (tmp == 1)
                    {
                        Button1.Visible = true;
                        ////Определяем название должности
                        //string SelectDolzn = "SELECT     dolzhnost.dolzhnost FROM         prohozhdenie_testa INNER JOIN dolzhnost ON prohozhdenie_testa.ID_dolzhnost = dolzhnost.ID WHERE     (prohozhdenie_testa.ID = @prohozhdenie_testa)"; // делаем запрос с введеным в тектовое поле логином
                        //SqlCommand SDolzn = new SqlCommand(SelectDolzn, con);
                        //SDolzn.Parameters.AddWithValue("@prohozhdenie_testa", Request.QueryString["testID"].ToString());

                        //Вывод сообщение информационное сообщение о тесте
                        //   lblMessage.Text = SystemQuery("instruction") + SystemQuery("time_test") + " мин." + "<br> Специальность: <b>" + SDolzn.ExecuteScalar().ToString() + "</b>";


                    }
                    else
                    {
                        Response.Redirect("/site/Default.aspx?error=ProverkaNull");
                        Log("Проверка завершилась неудачно");
                        //     lblMessage.Text = "Проверка завершилась неудачно";
                    }
                    {
                    }
                }
                catch (Exception er)
                {
                    con.Close();
                    Response.Redirect("/site/Default.aspx?error=" + er);

                }
            }
            else
            {
                Response.Redirect("/site/Default.aspx?error=NullTestID");
            }
        }
    }

    int proverkavoprosov() //проверка наличи вопросов для тестирования
    {

        string SelectVoprosTest = "SELECT     COUNT(*) AS Expr1 FROM         testirovanie GROUP BY ID_testiruemyj, ID_test HAVING      (ID_testiruemyj = @ID) AND (ID_test = @ID_test)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand SVoprosTest = new SqlCommand(SelectVoprosTest, con);
        SVoprosTest.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
        SVoprosTest.Parameters.AddWithValue("@ID_test", Request.QueryString["testID"].ToString());
        try
        {
            con.Open();
            SVoprosTest.ExecuteNonQuery();
            int temp = Convert.ToInt32(SVoprosTest.ExecuteScalar().ToString());
            con.Close();
            if (temp >= 70)
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
            con.Close();
            return 0;
        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["vopros"] = null;
        Session["timeLeft"] = null;
        Boolean status = true;
        double time = 0;
        if (proverkavoprosov() == 0)
        {

            /*
             * Генерация md5 хэш суммы. Запись в таблицу исходного значения по которому производилась генерация
             * после чего происходит перенаправления на страницу тестирования, где происходит сверка этой
             * суммы
             */
            //Random rand = new Random(); //если такой логин присутвует в базе, то производим генерацию рандомного числа и лобавляем его в конец логина
            //int Kontrol = rand.Next(10000); //переменная содержащая контрольную сумму

            //string SelectStatus = "INSERT INTO status ([id-l-kabinet], kontrol) VALUES     (@ID, @Kontrol)"; // производим запись котрольной суммы в базу данных
            //SqlCommand Status = new SqlCommand(SelectStatus, con);
            //Status.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
            //Status.Parameters.AddWithValue("@Kontrol", Kontrol);
            //try
            //{
            //    con.Open();
            //    Status.ExecuteNonQuery();
            //    con.Close();
            //    Log("Запись контрольной суммы в БД " + Kontrol + "-" + Session["UserID"]);

            string SelectDolznID = "SELECT     [l-kabinet].ID_dolzhnost FROM         [l-kabinet] INNER JOIN prohozhdenie_testa ON [l-kabinet].ID = prohozhdenie_testa.ID_testiruemyj WHERE     ([l-kabinet].ID = @ID) AND (prohozhdenie_testa.ID = @prohozhdenie_testa_id)"; // делаем запрос с введеным в тектовое поле логином
            SqlCommand SDolznID = new SqlCommand(SelectDolznID, con);
            SDolznID.Parameters.AddWithValue("@prohozhdenie_testa_id", Request.QueryString["testID"].ToString());
            SDolznID.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
            try
            {
                con.Open();
                string dolzn = SDolznID.ExecuteScalar().ToString();
                con.Close();

                // В SQL сервере для создания запроса использовался конструктор с типом запроса: Вставить результат
                string FormirovanieVoprosov = "INSERT INTO testirovanie (ID_vopros, ID_testiruemyj, ID_test) SELECT     TOP (70) voprosy.id_voprosy, [l-kabinet].ID, prohozhdenie_testa.ID AS Expr1 FROM         specialnost INNER JOIN voprosy ON specialnost.id_specialnost = voprosy.specialnost INNER JOIN [dolzhnost-specialnost] ON specialnost.id_specialnost = [dolzhnost-specialnost].specialnost CROSS JOIN prohozhdenie_testa INNER JOIN [l-kabinet] ON prohozhdenie_testa.ID_testiruemyj = [l-kabinet].ID WHERE     ([l-kabinet].ID = @ID) AND (prohozhdenie_testa.ID = @ID_prohozhdenie_testa) AND ([dolzhnost-specialnost].dolzhnost = @dolzhnost) ORDER BY NEWID()"; // случайныйм образом выбираем вопросы из базы данных
                SqlCommand FVopros = new SqlCommand(FormirovanieVoprosov, con);
                FVopros.Parameters.AddWithValue("@dolzhnost", dolzn);
                FVopros.Parameters.AddWithValue("@id", Session["UserID"].ToString());
                FVopros.Parameters.AddWithValue("@ID_prohozhdenie_testa", Request.QueryString["testID"].ToString());

                try
                {
                    con.Open();
                    FVopros.ExecuteNonQuery();
                    con.Close();

                    //// В SQL сервере для создания запроса использовался конструктор с типом запроса: Вставить результат
                    //string SelectDolz = " SELECT     ID_dolzhnost FROM         [l-kabinet] WHERE     (ID = @ID)"; // случайныйм образом выбираем вопросы из базы данных
                    //SqlCommand SDolz = new SqlCommand(SelectDolz, con);
                    //SDolz.Parameters.AddWithValue("@id", Session["Name_user"].ToString());

                    //string LookTime = "SELECT     time FROM         prohozhdenie_testa WHERE     (ID_testiruemyj = @ID)"; // получаем вопросы из категории
                    //SqlCommand LTime = new SqlCommand(LookTime, con);
                    //LTime.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
                    //try
                    //{
                    //    con.Open();
                    //    int tmp = Convert.ToInt32(LTime.ExecuteScalar().ToString());
                    //    con.Close();

                    //    if (tmp == 0)
                    //    {
                    //        time = 95 * 95;
                    //    }
                    //    else
                    //    {
                    //        string SelectTestTime = " SELECT     time FROM         prohozhdenie_testa WHERE     (ID_testiruemyj = @ID)"; // получаем вопросы из категории
                    //        SqlCommand STT = new SqlCommand(SelectTestTime, con);
                    //        STT.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
                    //        try
                    //        {
                    //            con.Open();
                    //            time = Convert.ToDouble(STT.ExecuteScalar().ToString());
                    Response.Redirect("/site/test/test.aspx?testID=" + Request.QueryString["testID"].ToString() + "&p=0");
                    //            con.Close();
                    //        }
                    //        catch
                    //        {
                    //            con.Close();
                    //        }
                    //    }
                    //}
                    //catch
                    //{
                    //    con.Close();
                    //}
                }
                catch
                {
                    con.Close();
                }
            }
            catch
            {
                con.Close();
            }
            //}
            //catch
            //{
            //    con.Close();
            //}
        }
        else
        {
            Response.Redirect("/site/test/test.aspx?testID=" + Request.QueryString["testID"].ToString() + "&p=1");
            //    //// В SQL сервере для создания запроса использовался конструктор с типом запроса: Вставить результат
            //    //string SelectDolz = " SELECT     ID_dolzhnost FROM         [l-kabinet] WHERE     (ID = @ID)"; // случайныйм образом выбираем вопросы из базы данных
            //    //SqlCommand SDolz = new SqlCommand(SelectDolz, con);
            //    //SDolz.Parameters.AddWithValue("@id", Session["Name_user"].ToString());


            //    //string LookTime2 = "SELECT     time FROM         prohozhdenie_testa WHERE     (ID_testiruemyj = @ID)"; // получаем вопросы из категории
            //    //SqlCommand LTime2 = new SqlCommand(LookTime2, con);
            //    //LTime2.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
            //    //try
            //    //{
            //    //    con.Open();
            //    //    int tmp = Convert.ToInt32(LTime2.ExecuteScalar().ToString());
            //    //    con.Close();
            //    //    if (tmp == 0)
            //    //    {
            //    //        time = 95 * 95;
            //    //    }
            //    //    else
            //    //    {
            //    //        string SelectTestTime2 = " SELECT     time FROM         prohozhdenie_testa WHERE     (ID_testiruemyj = @ID)"; // получаем вопросы из категории
            //    //        SqlCommand STT2 = new SqlCommand(SelectTestTime2, con);
            //    //        STT2.Parameters.AddWithValue("@ID", Session["UserID"].ToString());

            //    //            con.Open();
            //    //            time = Convert.ToDouble(STT2.ExecuteScalar().ToString());
            //    //            con.Close();
            //    //    }


            //        //string SelectStatus = "SELECT     kontrol FROM         status WHERE     ([id-l-kabinet] = @ID)"; // получаем вопросы из категории
            //        //SqlCommand SStatus = new SqlCommand(SelectStatus, con);
            //        //SStatus.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
            //        //int status = Convert.ToInt32(SStatus.ExecuteScalar());
            //        //  double time = 95 * 95 + 120.65;
            //     //   Response.Redirect("/site/test/test.aspx?testID=" + Request.QueryString["testID"].ToString() + "&time=" + Encrypt(Convert.ToString(time)) + "&p=1");
            //        //status = false;
        }
        //catch (Exception er)
        //{
        //    con.Close();
        //    //Log(Session["UserID"] + " Невозможно произвести запись контрольных сумм в таблицу! ");
        // Response.Redirect("/site/Default.aspx?error="+er); //Невозможно произвести запись контрольных сумм в таблицу!
        //}
        //if (status == false)
        //{

        //}

        //}

    }
}