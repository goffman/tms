using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_users_result : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString); //производим соединение с БД
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void SMP_Click(object sender, EventArgs e)
    {
        DateTime saveNow = DateTime.Now;
        //  Create a dummy GridView
        GridView GridView2 = new GridView();
        GridView2.AllowPaging = false;
        GridView2.DataSource = SqlDataSource2;
        GridView2.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + saveNow.ToString() + "c" + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        for (int i = 0; i < GridView2.Rows.Count; i++)
        {
            //Apply text style to each Row
            GridView2.Rows[i].Attributes.Add("class", "textmode");
        }
        GridView2.RenderControl(hw);

        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    protected void VR_Click(object sender, EventArgs e)
    {
        DateTime saveNow = DateTime.Now;
        //  Create a dummy GridView
        GridView GridView1 = new GridView();
        GridView1.AllowPaging = false;
        GridView1.DataSource = SqlDataSource1;
        GridView1.DataBind();

        Response.Clear();
        Response.Buffer = true;
        Response.AddHeader("content-disposition", "attachment;filename=" + saveNow.ToString() + "в" + ".xls");
        Response.Charset = "";
        Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
        StringWriter sw = new StringWriter();
        HtmlTextWriter hw = new HtmlTextWriter(sw);

        for (int i = 0; i < GridView1.Rows.Count; i++)
        {
            //Apply text style to each Row
            GridView1.Rows[i].Attributes.Add("class", "textmode");
        }
        GridView1.RenderControl(hw);

        //style to format numbers to string
        string style = @"<style> .textmode { mso-number-format:\@; } </style>";
        Response.Write(style);
        Response.Output.Write(sw.ToString());
        Response.Flush();
        Response.End();
    }
    protected void Send_Click(object sender, EventArgs e)
    {

    }
    protected void Send_Click1(object sender, EventArgs e)
    {
        
    }

}