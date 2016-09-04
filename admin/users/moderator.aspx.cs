using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_users_moderator : System.Web.UI.Page
{

    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Unnamed1_ValueChanged(object sender, EventArgs e)
    {

    }

    protected void AlertNotif(string title, string text)
    {
        alert.Visible = true;
        AlertText.Text = text;
        AlertTitle.Text = title;

    }


    protected void Approve_Click(object sender, EventArgs e)
    {

        string ApproveModeration = "UPDATE       users SET                Moderacija = 1 FROM            [l-kabinet] INNER JOIN users ON [l-kabinet].ID = users.ID_l_kabinet WHERE        ([l-kabinet].ID = @ID)";
                    // делаем запрос с введеным в тектовое поле логином
        SqlCommand AM = new SqlCommand(ApproveModeration, con);
        AM.Parameters.AddWithValue("@ID", IDAccount.Value);
        try
        {
            con.Open();
            AM.ExecuteNonQuery();
            con.Close();
            AlertNotif("Успех", "Пользователь с ID "+IDAccount.Value+ " одобрен для прохождения теста"); 
            RadGrid1.DataBind();
        }
        catch (Exception ex)
        {
            con.Close();
           AlertNotif("Ошибка",ex.Message); 
            //throw;
        }
                    

         
        
    }
    protected void BlockButton_Click(object sender, EventArgs e)
    {
        string BlockUsers = "UPDATE       users SET                Moderacija = 2 FROM            [l-kabinet] INNER JOIN users ON [l-kabinet].ID = users.ID_l_kabinet WHERE        ([l-kabinet].ID = @ID) INSERT INTO ModerationAccount (UserID, Answer) VALUES        (@ID,@Answer)";
        // делаем запрос с введеным в тектовое поле логином
        SqlCommand BU = new SqlCommand(BlockUsers, con);
        BU.Parameters.AddWithValue("@ID", IDAccount.Value);
        BU.Parameters.AddWithValue("@Answer", BlockText.Text);
        
        try
        {
            con.Open();
            BU.ExecuteNonQuery();
            con.Close();
            AlertNotif("Успех", "Пользователь с ID " + IDAccount.Value + " не прошел моджерацию по причине: "+BlockText.Text);
            RadGrid1.DataBind();
            BlockText.Text = string.Empty;
        }
        catch (Exception ex)
        {
            con.Close();
            AlertNotif("Ошибка", ex.Message);
            //throw;
        }
    }
    protected void BlockUsersRemove_Click(object sender, EventArgs e)
    {
        string BlockUsers = "UPDATE       users SET                Moderacija = 2 FROM            [l-kabinet] INNER JOIN users ON [l-kabinet].ID = users.ID_l_kabinet WHERE        ([l-kabinet].ID = @ID)" +
                            " INSERT INTO ModerationAccount (UserID, Answer) VALUES        (@ID,@Answer) ";
        // делаем запрос с введеным в тектовое поле логином
        SqlCommand BU = new SqlCommand(BlockUsers, con);
        BU.Parameters.AddWithValue("@ID", IDAccount.Value);
        BU.Parameters.AddWithValue("@Answer", BlockText.Text);

        try
        {
            con.Open();
            BU.ExecuteNonQuery();
            con.Close();
            AlertNotif("Успех", "Пользователь с ID " + IDAccount.Value + " не прошел моджерацию по причине: " + BlockText.Text);
            RadGrid1.DataBind();
            BlockText.Text = string.Empty;
        }
        catch (Exception ex)
        {
            con.Close();
            AlertNotif("Ошибка", ex.Message);
            //throw;
        }
    }
    protected void BlockUsersAndRemoveButton_Click(object sender, EventArgs e)
    {
        string BlockUsers = "UPDATE       users SET                Moderacija = 2 FROM            [l-kabinet] INNER JOIN users ON [l-kabinet].ID = users.ID_l_kabinet WHERE        ([l-kabinet].ID = @ID) " +
                            "INSERT INTO ModerationAccount (UserID, Answer) VALUES        (@ID,@Answer) " +
                            "INSERT INTO BlockedUsers (IDUsers, Blocked, date) VALUES        (@ID,@Answer, GETDATE()) " +
                            "UPDATE       [l-kabinet] SET                on_delete = 1 WHERE        (ID = @ID)";
        // делаем запрос с введеным в тектовое поле логином
        SqlCommand BU = new SqlCommand(BlockUsers, con);
        BU.Parameters.AddWithValue("@ID", IDAccount.Value);
        BU.Parameters.AddWithValue("@Answer", BlockUsersAndRemoveText.Text);

        try
        {
            con.Open();
            BU.ExecuteNonQuery();
            con.Close();
            AlertNotif("Успех", "Пользователь с ID " + IDAccount.Value + " не прошел модерацию по причине и заблокирован по причине: " + BlockUsersAndRemoveText.Text);
            RadGrid1.DataBind();
            BlockUsersAndRemoveText.Text = string.Empty;
        }
        catch (Exception ex)
        {
            con.Close();
            AlertNotif("Ошибка", ex.Message);
            //throw;
        }
    }
}