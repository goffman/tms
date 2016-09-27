using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для dataCommand
/// </summary>
public static class dataCommand
{
    public static DataBaseExecute.ReturnResult InsertCancellationResults(int idAccount, string ReasonsRemovalTests, int idResult)
    {

        // делаем запрос с введеным в тектовое поле логином
        SqlCommand command = new SqlCommand(SQLQuery.InsertCancellationResults);
        command.Parameters.AddWithValue("@UserID", idAccount);
        command.Parameters.AddWithValue("@Reason", ReasonsRemovalTests);
        command.Parameters.AddWithValue("@prohozhdenie_testa_archive", idResult);
        return DataBaseExecute.ExecuteNonQuery(command);
    }

    public static DataBaseExecute.ReturnResult DeleteProhozhdenieTesta(int idKabinet)
    {
        if (idKabinet==0) return new DataBaseExecute.ReturnResult() {StatusExecute = DataBaseExecute.ReturnResult.Status.Error, ErrorMsg = "Значение idKabinet указано неверно" };
        SqlCommand command = new SqlCommand(SQLQuery.DeleteProhozhdenieTesta);
        command.Parameters.AddWithValue("@IDKabinet", idKabinet);
        return DataBaseExecute.ExecuteNonQuery(command);
    }

    public static DataBaseExecute.ReturnResult DeleteTestirovanie(int accountId)
    {
        if (accountId == 0) return new DataBaseExecute.ReturnResult() { StatusExecute = DataBaseExecute.ReturnResult.Status.Error, ErrorMsg = "Значение idKabinet указано неверно" };
        SqlCommand command = new SqlCommand(SQLQuery.DeleteProhozhdenieTesta);
        command.Parameters.AddWithValue("@IDtestiruemyj", accountId);
        return DataBaseExecute.ExecuteNonQuery(command);
    }


    public static class SQLQuery
    {
        public const string DeleteProhozhdenieTesta =
            "DELETE FROM prohozhdenie_testa WHERE(ID_testiruemyj = @IDKabinet)";

        public const string DeleteTestirovanie = "DELETE FROM testirovanie WHERE (ID_testiruemyj = @IDtestiruemyj)";
        public const string InsertCancellationResults =
                       "INSERT INTO CancellationResults (AccountID, date, IDAdmin, Reason, prohozhdenie_testa_archive) VALUES        (@UserID, GETDATE(), 1,@Reason,@prohozhdenie_testa_archive)";
    }
}