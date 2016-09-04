using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms.VisualStyles;

public partial class admin_Editor_EditModal : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    protected void Page_Load(object sender, EventArgs e)
    {


        string InsertAttestuemy = "SELECT        vopros FROM            voprosy WHERE        (id_voprosy = @id_voprosy)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand IA = new SqlCommand(InsertAttestuemy, con);
        IA.Parameters.AddWithValue("@id_voprosy", Request.QueryString["id_voprosy"]);
        try
        {
            con.Open();
            Vorpos.Text = IA.ExecuteScalar().ToString();
            con.Close();
        }
        catch (Exception)
        {
            con.Close();
            throw;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Panel1.Visible = true;

    }
    protected void SaveNew_Click(object sender, EventArgs e)
    {
        int vr = 0;
        if (CheckBox1.Checked)
        {
            vr = 1;
        }
        string InsertAttestuemy = "INSERT INTO otveti (otvet, vernyj, ID_voprosy) VALUES        (@otvet,@vernyj,@ID_voprosy)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand IA = new SqlCommand(InsertAttestuemy, con);
        IA.Parameters.AddWithValue("@id_voprosy", Request.QueryString["id_voprosy"]);
        IA.Parameters.AddWithValue("@otvet", TextBox1.Text);
        IA.Parameters.AddWithValue("@vernyj", vr);
        try
        {
            con.Open();
            IA.ExecuteNonQuery();
            con.Close();
            GridView1.DataBind();
            Panel1.Visible = false;
        }
        catch (Exception)
        {
            con.Close();
            throw;
        }

    }
    protected void Save_Click(object sender, EventArgs e)
    {


        string InsertAttestuemy = "UPDATE       voprosy SET                vopros = @vopros WHERE        (id_voprosy = @id_voprosy)"; // делаем запрос с введеным в тектовое поле логином
        SqlCommand IA = new SqlCommand(InsertAttestuemy, con);
        IA.Parameters.AddWithValue("@id_voprosy", Request.QueryString["id_voprosy"]);
        IA.Parameters.AddWithValue("@vopros", Vorpos.Text);
        try
        {
            con.Open();
            IA.ExecuteNonQuery();
            con.Close();
            ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);
        }
        catch (Exception)
        {
            con.Close();
            throw;
        }
    }
    protected void Close_Click(object sender, EventArgs e)
    {
        ClientScript.RegisterStartupScript(Page.GetType(), "mykey", "CloseAndRebind();", true);

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Panel1.Visible = false;
    }
}