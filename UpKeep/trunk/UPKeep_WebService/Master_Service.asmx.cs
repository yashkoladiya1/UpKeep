using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using DLL;
using System.Data;
using System.Configuration;
using System.Web.Services.Protocols;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Net.Mail;
using System.Net;

namespace UPKeep_WebService
{
    /// <summary>
    /// Summary description for Master_Service
    /// </summary>
    [WebService(Namespace = "http://useupkeep.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Master_Service : System.Web.Services.WebService
    {

        //public AuthHeader Credentials = new AuthHeader();

        

        SProc objSproc = new SProc();
        InterfaceLayer Ope = new InterfaceLayer();
        Request Request = new Request();
        
        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string getClientReference(string url)
        {
            return "";
        }

        [WebMethod]
        public DataTable getClientConnectionString(string url)
        {
        //    if (Credentials.UserName.ToLower() != "Sidd" ||
        //Credentials.Password.ToLower() != "Sidd@123")
        //    {
        //        throw new SoapException("Unauthorized",
        //        SoapException.ClientFaultCode);
        //    }
        //    else
        //    {

                BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
                Request Request = new Request();
                DataTable dt = new DataTable("ClientDetails");
                Request.AddParams("@url", url, DbType.String, ParameterDirection.Input);
                Request.CommandText = objSproc.CLIENT_CONFIG_MASTERSELECT;
                Request.CommandType = CommandType.StoredProcedure;
                Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
                //Session["Client"] = dt;
                return dt;
            //}
            //return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request).ToString();
        }

        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string getClientConnectionString_mobile(string mobile)
        {
            //    if (Credentials.UserName.ToLower() != "Sidd" ||
            //Credentials.Password.ToLower() != "Sidd@123")
            //    {
            //        throw new SoapException("Unauthorized",
            //        SoapException.ClientFaultCode);
            //    }
            //    else
            //    {

            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable dt = new DataTable("ClientDetails");
            Request.AddParams("@mobile", mobile, DbType.String, ParameterDirection.Input);
            Request.CommandText = objSproc.Client_Config_Mobile_Select;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            return DataTableToJSONWithJavaScriptSerializer(dt);
            //}
            //return Ope.ExecuteScalar(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request).ToString();
        }

        // UpKeep Global Master

        
        [WebMethod]
        public DataTable Get_Client_Module_Rights(Int32 Client_ID)
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable dt = new DataTable("RightsDetails");
            Request.AddParams("@Client_ID", Client_ID, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Get_Client_Module_Rights;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            return dt;
        }

        #region Country Master Global Code

        [WebMethod]
        public DataTable Country_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Country_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Country_Search_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = "Country_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int Country_Master_Save(Int32 Country_ID,string Country_Name,Int32 Active,string Remark)
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@Country_ID", Country_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Country_Name", Country_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", Remark, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Country_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region State  Master Global Code

        [WebMethod]
        public DataTable State_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "State_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable State_Search_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = "State_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int State_Master_Save(Int32 State_ID, string State_Name, Int32 Active, string Remark,Int32 Country_Code)
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@State_ID", State_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@State_Name", State_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", Remark, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Country_Code", Country_Code, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "State_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region IDProof Master Global Code

        [WebMethod]
        public DataTable IDProof_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "IDProof_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable IDProof_Search_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = "IDProof_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int IDProof_Master_Save(Int32 IDProof_ID, string IDProof_Name, Int32 Active, string Remark)
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@IDProof_ID", IDProof_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IDProof_Name", IDProof_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", Remark, DbType.String, ParameterDirection.Input);
            Request.CommandText = "IDProof_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region Module Master Global Code

        [WebMethod]
        public DataTable Module_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Module_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Module_Search_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = "Module_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int Module_Master_Save(Int32 Module_ID, string Module_Name, Int32 Active, string Remark)
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@Module_ID", Module_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Module_Name", Module_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", Remark, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Module_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region Client Master Global Code

        [WebMethod]
        public DataTable Client_Master_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Client_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Client_Master_Search_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = "Client_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int Client_Master_Save(Int32 Client_ID, string Client_Name,string Client_Address,Int32 City_ID, Int32 State_ID, Int32 Country_ID,Int32 PIN_No,Int32 Mobile_No,Int32 Phone,string Email_ID,string Billing_Address,string Pan_No,Int32 ID_Proff_ID,string ID_Proff_Detail, Int32 Active, string Remark)
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@Client_ID", Client_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Client_Name", Client_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Client_Address", Client_Address, DbType.String, ParameterDirection.Input);
            Request.AddParams("@City_ID", City_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@State_ID", State_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Country_ID", Country_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@PIN_No", PIN_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Mobile_No", Mobile_No, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Phone", Phone, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Email_ID", Email_ID, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Billing_Address", Billing_Address, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Pan_No", Pan_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@ID_Proff_ID", ID_Proff_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@ID_Proff_Detail", ID_Proff_Detail, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", Remark, DbType.String, ParameterDirection.Input);
            Request.CommandText = "Client_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            //Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, dt, Request);
            //Session["Client"] = dt;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region "City Master"
        [WebMethod]
        public DataTable City_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "Country_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable City_Search_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = "City_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int City_Master_Save(Int32 City_ID, string City_Name, Int32 Active, string Remark)
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@City_ID", City_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@City_Name", City_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", Remark, DbType.String, ParameterDirection.Input);
            Request.CommandText = "City_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        #endregion

        #region "Client Config Master"

        [WebMethod]
        public DataTable ClientConfig_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "ClientConfig_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable ClientConfig_Search_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = "ClientConfig_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int ClientConfig_Save(Int32 Config_ID, string Config_Name, string User_Name, string Password, bool Is_Link_To_Exists, string Web_service_IP,
            string URL, string Android_App_Name, string Android_App_URL, string Apple_App_Name, string Apple_App_URL, string Theme_Name,
            Int32 Active, string Remark)
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@Config_ID", Config_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Config_Name", Config_Name, DbType.String, ParameterDirection.Input);

            Request.AddParams("@UserName", User_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Password", Password, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Is_Link_To_ExistSoftware", Is_Link_To_Exists, DbType.String, ParameterDirection.Input);
            Request.AddParams("@WebService_ServerIP", Web_service_IP, DbType.String, ParameterDirection.Input);
            Request.AddParams("@URL", URL, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Android_App_Name", Android_App_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Android_App_URL", Android_App_URL, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Apple_App_Name", Apple_App_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Apple_App_URL", Apple_App_URL, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Theme_Name", Theme_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", Remark, DbType.String, ParameterDirection.Input);
            Request.CommandText = "ClientConfig_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        #endregion

        #region "Module Rights Master"

        [WebMethod]
        public DataTable ModuleRights_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = "ModuleRights_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable ModuleRights_Search_GetData()
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = "ModuleRights_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int ModuleRights_Save(int Rights_ID, int Module_ID, int Client_ID, string Module_Start_Date, string Module_End_Date, string Demo_Start_Date, string Demo_End_Date, int Alert_Days, int Active, string Remark)
        {
            BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@Rights_ID", Rights_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Module_ID ", Module_ID, DbType.String, ParameterDirection.Input);

            Request.AddParams("@Client_ID", Client_ID, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Module_StartDate date", Module_Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Module_EndDate", Module_End_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Demo_StartDate", Demo_Start_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Demo_EndDate", Demo_End_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Alert_Days", Alert_Days, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", Active, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Remarks", Remark, DbType.String, ParameterDirection.Input);
            Request.CommandText = "ModuleRights_Master_Save";
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, Request);
        }


        #endregion

        // UpKeep Local Master
        public string DataTableToJSONWithJavaScriptSerializer(DataTable table)
        {
            JavaScriptSerializer jsSerializer = new JavaScriptSerializer();
            List<Dictionary<string, object>> parentRow = new List<Dictionary<string, object>>();
            Dictionary<string, object> childRow;
            foreach (DataRow row in table.Rows)
            {
                childRow = new Dictionary<string, object>();
                foreach (DataColumn col in table.Columns)
                {
                    childRow.Add(col.ColumnName, row[col]);
                }
                parentRow.Add(childRow);
            }
            return jsSerializer.Serialize(parentRow);
        }


        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Send_Email(string To, string Subject, string Body, string cdt, string privateKey)
        {
            DataTable dt = new DataTable("SendEmail");
            //if (ValSave(cdt, privateKey) == false)
            //{
            //    // return;
            //}
            //else
            //{
                //BLL.DBConnections.ConnectionString = ConfigurationManager.ConnectionStrings["AllIsWell_ConnectionString"].ConnectionString;

                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("developer1.developers@gmail.com");
                message.To.Add(new MailAddress(To));
                message.Subject = Subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = Body;

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("developer1.developers@gmail.com", "Develop@123");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);
                smtp.Dispose();
            //}
            return DataTableToJSONWithJavaScriptSerializer(dt);
        }
    }
}
