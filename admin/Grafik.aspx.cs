using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Grafik : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        string InsertAt = "INSERT INTO attestacija (dolzhnost, data) VALUES        (@dolzhnost,@data)"; // получаем вопросы из категории
              SqlCommand IAT = new SqlCommand(InsertAt, con);
              IAT.Parameters.AddWithValue("@dolzhnost", DropDownList1.Text);
              IAT.Parameters.AddWithValue("@data", Calendar1.SelectedDate);
              try
              {
                  con.Open();
                  IAT.ExecuteNonQuery();
                  con.Close();
                  TextBox1.Text = " Запись " + DropDownList1.SelectedItem.ToString() + " " + DropDownList1.SelectedValue.ToString() + " Дата: " + Calendar1.SelectedDate.ToString();
                  GridView1.DataBind();
              }
              catch (Exception er)
              {
                  TextBox1.Text = Convert.ToString(er);
              }

        


    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}