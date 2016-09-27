using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_users_search2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void SearchTextBox_TextChanged(object sender, EventArgs e)
    {
        SqlDataSource2.SelectParameters["FIO"].DefaultValue = SearchTextBox.Text.Trim() + "%";
        RadGrid1.DataBind();
    }

    protected void RadGrid1_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    }
}