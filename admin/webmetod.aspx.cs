using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Services;

public partial class admin_webmetod : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }



    [WebMethod]
    public static string[] GetFam(string keyword)
    {
        List<string> country = new List<string>();
        string query = string.Format(" SELECT DISTINCT F FROM            [l-kabinet]  WHERE F LIKE '%{0}%'", keyword);

        using (SqlConnection con =
                new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    country.Add(reader.GetString(0));
                }
                con.Close();
            }
        }
        return country.ToArray();
    }
}