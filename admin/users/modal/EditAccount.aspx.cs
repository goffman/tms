using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net.Utilities;
using Hibernate;
using Hibernate.Domain;
using NHibernate.Linq;

public partial class admin_users_modal_EditAccount : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    protected void Page_Load(object sender, EventArgs e)
    {
        string idAccount = Request.QueryString["id"].ToString();
        var session = DataBase.GetSession();
        if (session != null)
        {
        var s=    session.Query<Lkabinet>().Where(lkabinet => lkabinet.Id == Convert.ToInt32(idAccount));
        }
       
        string SelectAccount = " SELECT        F, I, O, stazh, ID_lpu, email, telefon FROM            [l-kabinet] WHERE        (ID = @UserID)";
        SqlCommand SA = new SqlCommand(SelectAccount, con);
        SA.Parameters.AddWithValue("@UserID", idAccount);
        try
        {
            con.Open();
            SqlDataReader reader = SA.ExecuteReader();
            while (reader.Read())
            {
                F.Text=reader["F"].ToString();
                I.Text = reader["I"].ToString();
                O.Text = reader["O"].ToString();
                Sazh.Text = reader["stazh"].ToString();
                LPU.Text = reader["ID_lpu"].ToString();
                email.Text = reader["email"].ToString();
                telefon.Text = reader["telefon"].ToString();
            }
            con.Close();
            reader.Close();
        }
        catch (Exception)
        {
            
            throw;
        }
    }
    protected void ChangeSpecialtyButton_Click(object sender, EventArgs e)
    {
        Dictionary<string, string> Alert = new Dictionary<string, string>();
        Alert.Clear();
        string idAccount = Request.QueryString["id"].ToString();
        string SelectAccount = "UPDATE       [l-kabinet] SET                F = @F, I = @I, O = @O, stazh = @stazh, ID_lpu = @ID_lpu, email = @email, telefon = @telefon WHERE        (ID = @UserID)";
        SqlCommand SA = new SqlCommand(SelectAccount, con);
        SA.Parameters.AddWithValue("@UserID", idAccount);
        SA.Parameters.AddWithValue("@F", F.Text);
        SA.Parameters.AddWithValue("@I", I.Text);
        SA.Parameters.AddWithValue("@O", O.Text);
        SA.Parameters.AddWithValue("@stazh", Sazh.Text);
        SA.Parameters.AddWithValue("@ID_lpu", LPU.Text);
        SA.Parameters.AddWithValue("@email", email.Text);
        SA.Parameters.AddWithValue("@telefon", telefon.Text);
        try
        {
            con.Open();
            SA.ExecuteNonQuery();
            con.Close();
            Alert.Add("Успех", "Данные о пользователе обновлены");
        }
        catch (Exception ex)
        {
            Alert.Add("Ошибка", ex.Message);
            con.Close();
            
         //   throw;
        }

        foreach (KeyValuePair<string, string> kvp in Alert)
        {
            Page.ClientScript.RegisterStartupScript(this.GetType(), "calling", String.Format("returnToParent('{0}','{1}');", kvp.Key, kvp.Value), true);
        }
        
    }
}