using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Web;
using System.Web.Services;
using System.Configuration;
using System.Data;
using System.Web.Services.Protocols;
using System.Data.SqlClient;
using System.Xml;
using System.Web.Services.Description;


/// <summary>
/// Summary description for WebService
/// </summary>
[WebService(Namespace = "PhoneBookInWeb")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
// [System.Web.Script.Services.ScriptService]
public class WebService : System.Web.Services.WebService {

   string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

    public WebService () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]//атрибут для веб метода
    public DataSet GetAllPersonSQL()
    {
        DataSet ds = new DataSet();
        try
        {

            string select = "SELECT * FROM Person;";
            SqlDataAdapter da = new SqlDataAdapter(select, this.connectionString);

            da.Fill(ds);
        }
        catch
        {
        }

        finally
        {
            

        }

       return ds;
    }
    
    [WebMethod]//атрибут для веб метода
    public string GetAllPersonXML()
    {
        SqlConnection sqlConn;
        XmlReader rdr;
        string ret = "";
        try
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            sqlConn = new SqlConnection();
            sqlConn.Open();
            //возвращаем XML-данные 
            string sqlString = "SELECT * FROM Person;";
            SqlCommand command = new SqlCommand(sqlString,sqlConn);
            //выполняем SQl-запрос и получаем XML B XML-Reader
            rdr = command.ExecuteXmlReader();
            //В цыкле считываем обьект для чтения и получаем XML
            rdr.Read();
            while (rdr.ReadState != System.Xml.ReadState.EndOfFile)
            {
                ret += rdr.ReadOuterXml();
            }

            //добавляем корневой элемент
            sqlConn.Close();
            rdr.Close();          
        }
           catch
            {

            }

        return ret;
    }
}
