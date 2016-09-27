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

    private int GetResultTest(int id)
    {
        string sql = "INSERT INTO prohozhdenie_testa_archive " +
                      "(ID_testa, ID_testiruemyj, ID_dolzhnost, rezultat, data, status, naimenovanie_testa, otpravlen, time) " +
"SELECT ID, ID_testiruemyj, ID_dolzhnost, rezultat, data, status, naimenovanie_testa, otpravlen, time " +
        "FROM prohozhdenie_testa " +
            "WHERE(ID_testiruemyj = @ID_testiruemyj) " +
            "SELECT @@IDENTITY AS 'Identity'; ";

        SqlCommand ICR = new SqlCommand(sql);
        ICR.Parameters.AddWithValue("@ID_testiruemyj", id);
        var result = DataBaseExecute.ExecuteReader(ICR);
        if (result.StatusExecute == DataBaseExecute.ReturnResult.Status.Success)
        {
            while (result.DataReader.Read())
            {
                var tmp = result.DataReader["Identity"].ToString();
                if (!string.IsNullOrEmpty(tmp))
                {
                    var idItem = 0;
                    var canParse = int.TryParse(tmp, out idItem);
                    if (canParse && idItem != 0)
                    {
                        return idItem;

                    }
                }

            }
            result.DataReader.Close();
        }
        return 0;

    }

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

        var idAccount = GetIdAccount(idAccountQueryString);
        if (idAccount == 0) ClosePage("Ошибка", "Невозможно распознать ID человека");

        var idResult = GetResultTest(idAccount);
        if (idResult == 0) ClosePage("Ошибка", "Невозможно сохранить результат предыдущего тестирования");

        //Сохраняем старые значения
        ExecuteReturnResult(dataCommand.InsertCancellationResults(idAccount, ReasonsRemovalTests.Text.Trim(), idResult));
        ExecuteReturnResult(dataCommand.DeleteProhozhdenieTesta(idAccount));
        ExecuteReturnResult(dataCommand.DeleteTestirovanie(idAccount));



        //            string DeleteTestirovanie = "DELETE FROM testirovanie WHERE        (ID_testiruemyj = @IDKabinet)";
        //            // делаем запрос с введеным в тектовое поле логином
        //            SqlCommand DT = new SqlCommand(DeleteTestirovanie, con);
        //            DT.Parameters.AddWithValue("@IDKabinet", IDAccount.Value);
        //            try
        //            {
        //                con.Open();
        //                DT.ExecuteScalar();
        //                con.Close();
        //                tmp2 = 1;
        //            }
        //            catch (Exception ex)
        //            {
        //                con.Close();
        //                AlertNotif("Ошибка", ex.Message);

        //            }

        //            if (tmp1 == 1 & tmp2 == 1)
        //            {

        //                AlertNotif("Успех", "Тесты для пользователя с ID " + IDAccount.Value + " аннулированы");
        //                RadGrid1.DataBind();
        //                ReasonsRemovalTests.Text = string.Empty;
        //            }
        //        }


        //    }
        //    else
        //    {
        //        AlertNotif("Ошибка", "Текст с картинки введен неверно");

        //    }
        //}
        //else
        //{
        //    AlertNotif("Ошибка", "Не выбран пользователь");
        //}
    }
}