using Ext.Net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_editor_Default : System.Web.UI.Page
{

    private bool cancel;
    private string message;
    private int? insertedValue;


    protected void Store2_Refresh(object sender, StoreReadDataEventArgs e)
    {
        // string id = e.Parameters["ID"];
        string id = e.Parameters["id_voprosy"];
        this.SqlDataSource2.SelectParameters["ID_voprosy"].DefaultValue = id ?? "-1";
        //  this.LinqDataSource2.WhereParameters["SupplierID"].DefaultValue = ;
        //this.Button4.Enable = true;
        this.Button4.Hidden = false;
        this.sel.Text = id;
        this.Store2.DataBind();
    }


    protected void Page_Load(object sender, EventArgs e)
    {
    }


    protected void Store1_BeforeRecordInserted(object sender, BeforeRecordInsertedEventArgs e)
    {
        //object region = e.NewValues["Region"];

        //if (region == null || region.ToString() != "Alabama (AL)")
        //{
        //    e.Cancel = true;
        //    this.cancel = true;
        //    this.message = "The Region must be 'AL'";
        //}
    }

    protected void Store1_AfterRecordInserted(object sender, AfterRecordInsertedEventArgs e)
    {
        if (insertedValue.HasValue)
        {
            e.Keys.Add("id", insertedValue.Value);
            insertedValue = null;
        }
    }

    protected void SqlDataSource1_Inserted(object sender, SqlDataSourceStatusEventArgs e)
    {
        //use e.AffectedRows for ensure success action. The store read this value and set predefined Confirm depend on e.AffectedRows
        //The Confirm can be granted or denied in OnRecord....ed event
        //if (e.AffectedRows > 0 && e.Command.Parameters["@newId"].Value != null)
        //{
        //    insertedValue = (int)e.Command.Parameters["@newId"].Value;
        //}
        //else
        //{
        //    insertedValue = null;
        //}
    }

    protected void Store1_AfterDirectEvent(object sender, AfterDirectEventArgs e)
    {
        if (e.Response.Success)
        {
            // set to .Success to false if we want to return a failure
            e.Response.Success = !cancel;
            e.Response.Message = message;
        }
    }

    protected void Store1_BeforeDirectEvent(object sender, BeforeDirectEventArgs e)
    {
        string emulError = e.Parameters["EmulateError"];

        if (emulError == "1")
        {
            throw new Exception("Emulating error");
        }
    }

    protected void Store1_RefershData(object sender, StoreReadDataEventArgs e)
    {
        this.Store1.DataBind();
    }


    protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["spec"] = "36";
    }
    protected void Button6_Click(object sender, EventArgs e)
    {

        this.Window1.Show();

    }
    protected void Button7_Click(object sender, EventArgs e)
    {
        string InsertOtvet = "INSERT INTO otveti(otvet, vernyj, ID_voprosy) VALUES (@otvet, @vernyj, @ID_voprosy)"; // получаем вопросы из категории
        using (SqlConnection conect = new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString))
        {
            SqlCommand IO = new SqlCommand(InsertOtvet, conect);
            IO.Parameters.AddWithValue("@otvet", this.txtNewOtvet.Text);
            IO.Parameters.AddWithValue("@vernyj", this.chkMark.Value);
            IO.Parameters.AddWithValue("@ID_voprosy", this.sel.Text);
            try
            {
                conect.Open();
                IO.ExecuteNonQuery();
                Window1.Close();
                Notification.Show(new NotificationConfig
        {
            Title = "Сообщение",
            ShowPin = true,
            Pinned = true,
            Html = "Ответ <b>"+this.txtNewOtvet.Text+"</b>" +" успешно добавлен"
        });
                conect.Close();

            }
            catch (Exception ex)
            {

                Notification.Show(new NotificationConfig
        {
            Title = "Сообщение",
            ShowPin = true,
            Pinned = true,
            Html = "Произошла ошибка"
        }
        );
            }
        }


    }
}
