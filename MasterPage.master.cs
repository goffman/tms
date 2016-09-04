using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{

  
    protected void Page_Load(object sender, EventArgs e)
    {

        ScriptManager.ScriptResourceMapping.AddDefinition("jquery", new ScriptResourceDefinition
        {
            Path = "http://yandex.st/jquery/2.1.0/jquery.min.js",

        });
        //Response.Write(Page.Header.Title);

        //string tmp = Convert.ToString(System.Web.HttpContext.Current.Request.Url.GetHashCode());
        //if (!(tmp == "-1878163145" || tmp == "-1154615326" || tmp == "-607758282" || tmp == "1242980962" || tmp == "-1154615326-1154615326"))
        //{
        //    if (Session["UserID"] == null)
        //    {
        //        Response.Redirect("/default.aspx");
        //    }
        //}
    }
}