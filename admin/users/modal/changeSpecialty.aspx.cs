using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_users_modal_changeSpecialty : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/scripts/jquery-2.1.1.min.js",

        });


        //TextBox1.Text = 


    }


    protected void ChangeSpecialtyButton_Click(object sender, EventArgs e)
    {
        string idAccount = Request.QueryString["id"].ToString();

        Dictionary<string, string> Alert = new Dictionary<string, string>();
        Alert.Clear();
        if (idAccount != null)
        {
            if (ChangeSpecialtyCaptcha.IsValid)
            {


                string DeleteProhozhdenieTesta =
                            "DELETE FROM prohozhdenie_testa WHERE        (ID_testiruemyj = @IDKabinet) ";
                // делаем запрос с введеным в тектовое поле логином
                SqlCommand DPT = new SqlCommand(DeleteProhozhdenieTesta, con);
                DPT.Parameters.AddWithValue("@IDKabinet", idAccount);
                try
                {
                    con.Open();
                    DPT.ExecuteScalar();
                    con.Close();

                }
                catch (Exception ex)
                {
                    con.Close();
                    Alert.Add("Ошибка", ex.Message);
                    //  AlertNotif("Ошибка", ex.Message);

                }

                string DeleteTestirovanie = "DELETE FROM testirovanie WHERE        (ID_testiruemyj = @IDKabinet)";
                // делаем запрос с введеным в тектовое поле логином
                SqlCommand DT = new SqlCommand(DeleteTestirovanie, con);
                DT.Parameters.AddWithValue("@IDKabinet", idAccount);
                try
                {
                    con.Open();
                    DT.ExecuteScalar();
                    con.Close();

                }
                catch (Exception ex)
                {
                    con.Close();
                    Alert.Add("Ошибка", ex.Message);

                }

                string UpdateDolz = " UPDATE       [l-kabinet] SET                ID_dolzhnost = @dolzhnost WHERE        (ID = @UserID)";
                // делаем запрос с введеным в тектовое поле логином
                SqlCommand UD = new SqlCommand(UpdateDolz, con);
                UD.Parameters.AddWithValue("@UserID", idAccount);
                UD.Parameters.AddWithValue("@dolzhnost", DropChangeSpec.SelectedValue);
                try
                {
                    con.Open();
                    UD.ExecuteScalar();
                    con.Close();

                }
                catch (Exception ex)
                {
                    con.Close();
                    Alert.Add("Ошибка", ex.Message);

                }
                Alert.Add("Успех", "Специальность обновлена");

                //    RadGrid1.DataBind();
                foreach (KeyValuePair<string, string> kvp in Alert)
                {
                    Page.ClientScript.RegisterStartupScript(this.GetType(), "calling", String.Format("returnToParent('{0}','{1}');", kvp.Key, kvp.Value), true);
                }
               
            }
            else
            {
                Label1.Text = "Код введен неверно!";
            }
        }

       

    }
}