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
        //работа с сессией
      
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
            if (temp >= 15)
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

        //Определяем ID должности

        string SelectDolznID = "SELECT     ID_dolzhnost FROM         [l-kabinet] WHERE     (ID = @ID)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand SDolznID = new SqlCommand(SelectDolznID, con);
        SDolznID.Parameters.AddWithValue("@ID", Session["UserID"].ToString());
        try
        {
            con.Open();
            string dolzn = SDolznID.ExecuteScalar().ToString();
            con.Close();


            // В SQL сервере для создания запроса использовался конструктор с типом запроса: Вставить результат


            string FormirovanieVoprosov = "INSERT INTO proba_testirovanie (ID_testiruemyj, ID_vopros) SELECT    TOP (15) [l-kabinet].ID, voprosy.id_voprosy FROM         [dolzhnost-specialnost] INNER JOIN specialnost ON [dolzhnost-specialnost].specialnost = specialnost.id_specialnost INNER JOIN voprosy ON specialnost.id_specialnost = voprosy.specialnost INNER JOIN dolzhnost ON [dolzhnost-specialnost].dolzhnost = dolzhnost.ID INNER JOIN [l-kabinet] ON dolzhnost.ID = [l-kabinet].ID_dolzhnost WHERE     ([l-kabinet].ID = @ID) AND (dolzhnost.ID = @dolzhnost)  ORDER BY NEWID()"; // случайныйм образом выбираем вопросы из базы данных
            SqlCommand FVopros = new SqlCommand(FormirovanieVoprosov, con);
            FVopros.Parameters.AddWithValue("@dolzhnost", dolzn);
            FVopros.Parameters.AddWithValue("@id", Session["UserID"].ToString());
            try
            {
                con.Open();
                FVopros.ExecuteNonQuery();
                con.Close();


                string SelectProbaTesta = "SELECT     proba_test FROM         [l-kabinet] WHERE     (ID = @ID)"; // делаем запрос с введеным в тектовое поле логином
                SqlCommand SProbaTesta = new SqlCommand(SelectProbaTesta, con);
                SProbaTesta.Parameters.AddWithValue("@ID", Session["UserID"].ToString());

                try
                {
                    con.Open();
                    int tmp = Convert.ToInt32(SProbaTesta.ExecuteScalar().ToString());
                    con.Close();
                    if (tmp != 1)
                    {
                        Response.Redirect("/site/test/pilot/pilot_test.aspx");
                    }
                    else
                    {
                        TextTest.InnerText = "Вы уже проходили пробное тестирование";
                        //  begin_test.Enabled = false;
                    }
                  
                }
                catch (Exception er)
                {

                }

            }
            catch (Exception er)
            {
                con.Close();
                //Response.Redirect("~/error.aspx?error=100"); //Невозможно произвести запись выборки вопросов в таблицу!

            }

        }
        catch
        {
            con.Close();
        }

    }
}