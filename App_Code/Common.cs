using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

/// <summary>
/// Сводное описание для Common
/// </summary>
public static class Common
{
    public static class Email
    {
        public static string EmailSystem = WebConfigurationManager.AppSettings["email_system"];
        public static string EmailSystemSmtp = WebConfigurationManager.AppSettings["email_system_smtp"];
        public static string EmailSystemPass = WebConfigurationManager.AppSettings["email_system_pass"];
    }

    public class ResultExecute
    {

        public Status StatusExecute { get; set; }
        public string ErrorExecute { get; set; }
        public string Callbacks { get; set; }
        public enum Status
        {
            Error,
            Success
        }
    }

}