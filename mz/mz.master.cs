using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Admin : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "~/scripts/jquery-2.1.1.min.js",

        });

        UserNameAdmin.Text = Session["UserID"].ToString();
    }


    protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
    {
    
        Session["a"] = SearcAt.Value;
        Response.Redirect("/mz/search.aspx");
    }
}
