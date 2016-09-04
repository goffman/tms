using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class help : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

     public static string Decrypt()
     {
         HttpContext.Current.Response.Redirect("Main.aspx", true);
         return null;
     }
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        Decrypt();
    }
}