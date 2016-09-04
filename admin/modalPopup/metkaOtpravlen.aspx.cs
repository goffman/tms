using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_modalPopup_metkaOtpravlen : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        String[] v = TextBox1.Text.Split(new String[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
        //   SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["testConnectionString2"].ConnectionString); //производим соединение с БД

        for (int i = 0; i <= v.Length - 1; i++)
        {

            string strusername = "UPDATE       prohozhdenie_testa SET                otpravlen = 1 WHERE        (ID_testiruemyj = @UserID)"; // делаем запрос с введеным в тектовое поле логином
            SqlCommand selectuser = new SqlCommand(strusername, con);
            selectuser.Parameters.AddWithValue("@UserID", v[i].ToString());
            try
            {
                con.Open();
                selectuser.ExecuteNonQuery();
                con.Close();
                notif.Visible = true;
                Text.Text = "Результаты успешно отмечены как отправленные";

            }
            catch (Exception er)
            {
                Text.Text = Convert.ToString(er);
                notif.Visible = true;
                con.Close();
            }
        }
    }
}