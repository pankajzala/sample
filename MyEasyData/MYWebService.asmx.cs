using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace MyEasyData
{
    /// <summary>
    /// Summary description for MYWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be cal  led from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class MYWebService : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["conn"].ConnectionString);
        SqlDataAdapter da;
        SqlCommand cmd;
        DataSet ds;

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string AddNewUser(string name, string detail,byte[] image,int price)
        {
            cmd = new SqlCommand("AddNewUser", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ac_name", name);
            cmd.Parameters.AddWithValue("@ac_detail", detail);
            cmd.Parameters.AddWithValue("@ac_image", image[]);
            cmd.Parameters.AddWithValue("@ac_price", price);

            con.Open();
            bool Status = Convert.ToBoolean(cmd.ExecuteNonQuery());
            con.Close();
            if (Status)
            {
                return "Record Saved";
            }
            else
            {
                return "Error";
            }
        }

    }
}
