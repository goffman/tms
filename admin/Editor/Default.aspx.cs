using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class Editor_Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ID"] == null)
        {
            Response.Redirect("/admin/Editor/login.aspx");
        }
    }
    protected void Dropkat_DataBound(object sender, EventArgs e)
    {

    }
    protected void Dropspec_DataBound(object sender, EventArgs e)
    {
        Dropspec.DataBind();
    }
    protected void Dropspec_DataBinding(object sender, EventArgs e)
    {

    }

    protected void DropNaprav_SelectedIndexChanged(object sender, EventArgs e)
    {
        Dropspec.Items.Clear();
        //Dropspec.AppendDataBoundItems = true;
        //  Dropspec.Items.Insert(0, new ListItem(String.Empty, String.Empty));

        Dropspec.Items.Add(new ListItem("Выберите специальность", ""));

        Dropspec.AppendDataBoundItems = true;
    }
    protected void RadAjaxManager1_AjaxRequest(object sender, AjaxRequestEventArgs e)
    {
        if (e.Argument == "Rebind")
        {
            RadGrid1.MasterTableView.SortExpressions.Clear();
            RadGrid1.MasterTableView.GroupByExpressions.Clear();
            RadGrid1.Rebind();
        }
        else if (e.Argument == "RebindAndNavigate")
        {
            RadGrid1.MasterTableView.SortExpressions.Clear();
            RadGrid1.MasterTableView.GroupByExpressions.Clear();
            RadGrid1.MasterTableView.CurrentPageIndex = RadGrid1.MasterTableView.PageCount - 1;
            RadGrid1.Rebind();
        }
    }

    protected void Dropspec_SelectedIndexChanged(object sender, EventArgs e)
    {
        //Random r = new Random();
        Response.Redirect("/admin/Editor/Default.aspx" + "?D="+ Dropspec.SelectedValue);
     //   Session["ID"] = ;
       // Response.Write(Dropspec.SelectedItem);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Request.QueryString["d"] = "15";
    }
}