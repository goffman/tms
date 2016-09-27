using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Сводное описание для DataBaseExecute
/// </summary>
public static class DataBaseExecute
{
    static SqlConnection con =
            new SqlConnection(ConfigurationManager.ConnectionStrings["tmsConnectionString"].ConnectionString);
        //производим соединение с БД

    public static ReturnResult ExecuteNonQuery(SqlCommand sqlCommand)
    {
        try
        {
            con.Open();
            sqlCommand.Connection = con;
            sqlCommand.ExecuteNonQuery();
            con.Close();
            return new ReturnResult() {StatusExecute = ReturnResult.Status.Success};
        }
        catch (Exception ex)
        {
            
          return new ReturnResult() {ErrorMsg = ex.Message, StatusExecute = ReturnResult.Status.Error};
        }
    }

    public static ReturnResult ExecuteReader(SqlCommand sqlCommand)
    {
        try
        {
            con.Open();
            sqlCommand.Connection = con;
            SqlDataReader reader = sqlCommand.ExecuteReader();
            con.Close();
            return new ReturnResult() {StatusExecute = ReturnResult.Status.Success, DataReader = reader};
        }
        catch (Exception ex)
        {

            return new ReturnResult() {ErrorMsg = ex.Message, StatusExecute = ReturnResult.Status.Error};
        }
    }
    public class ReturnResult
    {
        public Status StatusExecute;
        public string ErrorMsg;
        public SqlDataReader DataReader;
        public int CollbackId;
        public enum Status
        {
            Success,
            Error
        }
    }
}