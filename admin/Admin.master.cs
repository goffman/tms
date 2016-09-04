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
    }

    protected void RadSearchBox1_Search(object sender, Telerik.Web.UI.SearchBoxEventArgs e)
    {
        Session["a"] = e.Text;
        Response.Redirect("/admin/users/search.aspx");
    }
}
