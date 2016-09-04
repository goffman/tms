using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_SpisokAttestuemyh : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Add_Click(object sender, EventArgs e)
    {
        string InsertAttestuemy = "INSERT INTO SpisokAttestuemyh (F, I, O, DolzhnostID, LPUID) VALUES        (@F,@I,@O,@DolzhnostID,@LPUID)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand IA = new SqlCommand(InsertAttestuemy, con);
        IA.Parameters.AddWithValue("@F", F.Text.Replace(" ", string.Empty));
        IA.Parameters.AddWithValue("@I", I.Text.Replace(" ", string.Empty));
        IA.Parameters.AddWithValue("@O", O.Text.Replace(" ", string.Empty));
        IA.Parameters.AddWithValue("@DolzhnostID", DropDownList2.Text);
        IA.Parameters.AddWithValue("@LPUID", LPU.Text);
        try
        {
            con.Open();
            IA.ExecuteNonQuery();
            con.Close();
            Label1.Text = "Add new people sussces";
            F.Text = string.Empty;
            I.Text = string.Empty;
            O.Text = string.Empty;
            GridView1.DataBind();
        }
        catch (Exception)
        {
            con.Close();
            Label1.Text = "Add new people error";

        }

       
    }
}