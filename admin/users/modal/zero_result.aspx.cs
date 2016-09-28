using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Hibernate;
using Hibernate.Domain;

public partial class admin_users_modal_zero_result : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private void ClosePage(string t, string m)
    {
        Page.ClientScript.RegisterStartupScript(this.GetType(), "calling", String.Format("returnToParent('{0}','{1}');", t, m), true);
    }

    //private int GetResultTest(int id)
    //{
       

    //    SqlCommand ICR = new SqlCommand(sql);
    //    ICR.Parameters.AddWithValue("@ID_testiruemyj", id);
    //    var result = DataBaseExecute.ExecuteReader(ICR);
    //    if (result.StatusExecute == DataBaseExecute.ReturnResult.Status.Success)
    //    {
           
    //        while (result.DataReader.Read())
    //        {
    //            var tmp = result.DataReader["Identity"].ToString();
    //            if (!string.IsNullOrEmpty(tmp))
    //            {
    //                var idItem = 0;
    //                var canParse = int.TryParse(tmp, out idItem);
    //                if (canParse && idItem != 0)
    //                {
    //                    return idItem;

    //                }
    //            }

    //        }
    //        result.DataReader.Close();
    //    }
    //    return 0;

    //}

    private int GetIdAccount(string idAccountString)
    {
        int id = 0;
        bool canUserId = int.TryParse(idAccountString, out id);
        return id;

    }


    private void ExecuteReturnResult(DataBaseExecute.ReturnResult result)
    {
        if (result.StatusExecute == DataBaseExecute.ReturnResult.Status.Error) ClosePage("Ошибка", result.ErrorMsg);
    }

    protected void OK_Click(object sender, EventArgs e)
    {
        string idAccountQueryString = Request.QueryString["id"].ToString();

        if (string.IsNullOrEmpty(idAccountQueryString)) ClosePage("Ошибка", "Отсуствует ID человека");
        if (string.IsNullOrEmpty(ReasonsRemovalTests.Text)) ClosePage("Ошибка", "Причина не указана");
        var idAccount = GetIdAccount(idAccountQueryString);
        if (idAccount == 0) ClosePage("Ошибка", "Невозможно распознать ID человека");

        var idResult = dataCommand.prohozhdenie_testa_archive(idAccount);
        if (idResult.CollbackId == 0) ClosePage("Ошибка", "Невозможно сохранить результат предыдущего тестирования");

        //Сохраняем старые значения
        ExecuteReturnResult(dataCommand.InsertCancellationResults(idAccount, ReasonsRemovalTests.Text.Trim(), idResult.CollbackId));
        ExecuteReturnResult(dataCommand.DeleteProhozhdenieTesta(idAccount));
        ExecuteReturnResult(dataCommand.DeleteTestirovanie(idAccount));
        ClosePage("Успех", String.Format("Тесты для пользователя с ID {0} аннулированы", idAccount));
    }
}