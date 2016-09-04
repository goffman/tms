using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Editor_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if ((TextBox1.Text == "рд57") && (TextBox2.Text == "470157"))
        {
            Session["ID"] = "true";
            Response.Redirect("/admin/Editor/Default.aspx");
        }
        else
        {
            Label1.Text = "Логин и пароль указаны неверно";
        }
    }
}