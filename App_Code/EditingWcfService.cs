
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web.Script.Serialization;
using Telerik.Web.UI;
using System.Text.RegularExpressions;
using System.Web;

/// <summary>
/// Сводное описание для EditingWcfService
/// </summary>
[ServiceKnownType(typeof(ServiceCustomer))]
[ServiceContract]
[AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
public class EditingWcfService
{
    [WebGet]
    [AspNetCacheProfile("NoCache")]
    public CustomersResult GetCustomers()
    {
        return new CustomersResult() {F = "Test", ID = 58};
    }
}

public class CustomersResult:ServiceCustomer
{

}

public class ServiceCustomer
{
    public int ID;
    public string F;
}