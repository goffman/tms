using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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

    public static ReturnResult ExecuteNonQuery(SqlCommand sqlCommand, bool IDENTITY)
    {
        try
        {
            var result = new ReturnResult();
            if (con.State!=ConnectionState.Open) con.Open();

            sqlCommand.Connection = con;
            if (IDENTITY)
            {
                SqlDataReader read = sqlCommand.ExecuteReader();
                while (read.Read())
                {
                    if (!string.IsNullOrEmpty(read["Identity"].ToString()))
                    result.CollbackId = Convert.ToInt32(read["Identity"]);
                }
                read.Close();

            } else sqlCommand.ExecuteNonQuery();
            con.Close();
            result.StatusExecute = ReturnResult.Status.Success;
            return result;
        }
        catch (Exception ex)
        {
            if (con.State == ConnectionState.Open) con.Close();
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
           
            var dataTable = new DataTable();
            dataTable.Load(reader);
            reader.Close();
            con.Close();
            return new ReturnResult() {StatusExecute = ReturnResult.Status.Success, dataTable = dataTable };
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
        public DataTable dataTable;
        public int CollbackId;
        public enum Status
        {
            Success,
            Error
        }
    }
}