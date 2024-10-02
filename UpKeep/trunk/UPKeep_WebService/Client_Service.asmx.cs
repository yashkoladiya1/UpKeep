using DLL;
using DLL.FunctionClasses;
using DLL.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Text;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;

namespace UPKeep_WebService
{
    /// <summary>
    /// Summary description for Client_Service
    /// </summary>
    [WebService(Namespace = "http://useupkeep.com/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class Client_Service : System.Web.Services.WebService
    {
        SProc objSproc = new SProc();
        InterfaceLayer Ope = new InterfaceLayer();
        string ConnectionString_Global = ConfigurationManager.ConnectionStrings["UpKeep_Global_ConnectionString"].ConnectionString;

        #region "User Login" 
        [WebMethod]
        public DataTable UserLogin_Login(string UserName, string Password, string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("User");

            Request.AddParams("@UserName", UserName, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Password", Password, DbType.String, ParameterDirection.Input);

            Request.CommandText = "User_Login_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string UserLogin_Login_Json(string UserName, string Password, string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("User");

            Request.AddParams("@UserName", UserName, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Password", Password, DbType.String, ParameterDirection.Input);

            Request.CommandText = "User_Login_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            //DataTableToList DataTableToList = new DataTableToList();
            return DataTableToJSONWithJavaScriptSerializer(DTab);
            //var List = DataTableToList.ToDynamicList(DTab);
            //int totalRecords = List.Count;
            //return List.ToString();

            //return DTab;
        }
        [WebMethod]
        public DataTable UserLogin_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("User");
            //Request.AddParams("@UserName", UserName, DbType.String, ParameterDirection.Input);
            Request.CommandText = "User_Login_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int UserMaster_Save(User_Master_Property objUser_Master_Property, string ConnectionString)
        {
            int IntRes = 0;
            Request Request = new Request();
            Request.CommandText = "User_Master_Save";

            Request.AddParams("@LoginID", objUser_Master_Property.LoginID, DbType.String);
            Request.AddParams("@UserName", objUser_Master_Property.UserName, DbType.String);
            Request.AddParams("@UserID", objUser_Master_Property.UserID, DbType.String);
            Request.AddParams("@Password", objUser_Master_Property.Password, DbType.String);
            Request.AddParams("@EmailID", objUser_Master_Property.EmailID, DbType.String);
            Request.AddParams("@Mobile", objUser_Master_Property.MobileNo, DbType.String);
            Request.AddParams("@Status", objUser_Master_Property.Active, DbType.Int64);
            Request.AddParams("@Emp_ID", objUser_Master_Property.Emp_ID, DbType.Int64);
            Request.AddParams("@ClientID", objUser_Master_Property.ClientID, DbType.Int64);

            Request.CommandType = CommandType.StoredProcedure;
            IntRes += Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);

            //Request = new Request();
            //Request.CommandText = "Country_Master_Save";

            //Request.AddParams("@Country_ID", Country.Country_ID, DbType.Int32);
            //Request.AddParams("@Country_Name", Country.Country_Name, DbType.String);
            //Request.AddParams("@Active", Country.Active, DbType.Int32);
            //Request.AddParams("@Remark", Country.Remark, DbType.String);

            //Request.CommandType = CommandType.StoredProcedure;
            //IntRes = Ope.ExecuteNonQuery(ConnectionString_Global, BLL.DBConnections.ProviderName, Request);
            return IntRes;
        }
        #endregion



        [WebMethod]
        public DataTable CountryMaster_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Country");
            Request.CommandText = "Country_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString_Global, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable StateMaster_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("State");
            Request.CommandText = "State_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString_Global, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable CityMaster_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("City");
            Request.CommandText = "City_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString_Global, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public int CityMaster_Save(City_Master_Property City, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "City_Master_Save";

        //    Request.AddParams("@City_ID", City.City_ID, DbType.Int32);
        //    Request.AddParams("@City_Name", City.City_Name, DbType.String);
        //    Request.AddParams("@State_ID", City.State_ID, DbType.Int32);
        //    Request.AddParams("@Country_ID", City.Country_ID, DbType.Int32);
        //    Request.AddParams("@Active", City.Active, DbType.Int32);
        //    Request.AddParams("@Remark", City.Remark, DbType.String);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes += Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    Request = new Request();
        //    Request.CommandText = "City_Master_Save";

        //    Request.AddParams("@City_ID", City.City_ID, DbType.Int32);
        //    Request.AddParams("@City_Name", City.City_Name, DbType.String);
        //    Request.AddParams("@State_ID", City.State_ID, DbType.Int32);
        //    Request.AddParams("@Country_ID", City.Country_ID, DbType.Int32);
        //    Request.AddParams("@Active", City.Active, DbType.Int32);
        //    Request.AddParams("@Remark", City.Remark, DbType.String);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Ope.ExecuteNonQuery(ConnectionString_Global, BLL.DBConnections.ProviderName, Request);
        //    return IntRes;
        //}



        //[WebMethod]
        //public int CountryMaster_Save(Country_Master_Property Country, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "Country_Master_Save";

        //    Request.AddParams("@Country_ID", Country.Country_ID, DbType.Int32);
        //    Request.AddParams("@Country_Name", Country.Country_Name, DbType.String);
        //    Request.AddParams("@Active", Country.Active, DbType.Int32);
        //    Request.AddParams("@Remark", Country.Remark, DbType.String);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes += Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);

        //    Request = new Request();
        //    Request.CommandText = "Country_Master_Save";

        //    Request.AddParams("@Country_ID", Country.Country_ID, DbType.Int32);
        //    Request.AddParams("@Country_Name", Country.Country_Name, DbType.String);
        //    Request.AddParams("@Active", Country.Active, DbType.Int32);
        //    Request.AddParams("@Remark", Country.Remark, DbType.String);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Ope.ExecuteNonQuery(ConnectionString_Global, BLL.DBConnections.ProviderName, Request);
        //    return IntRes;
        //}

        [WebMethod]
        public int LocationMaster_Save(Location_Master_Property Location, string ConnectionString)
        {
            int IntRes = 0;
            Request Request = new Request();
            Request.CommandText = "Location_Master_Save";

            Request.AddParams("@Location_ID", Location.Location_ID, DbType.Int32);
            Request.AddParams("@Location_Name", Location.Location_Name, DbType.String);
            Request.AddParams("@Active", Location.Active, DbType.Int32);
            Request.AddParams("@Remark", Location.Remark, DbType.String);

            Request.CommandType = CommandType.StoredProcedure;
            IntRes = Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);

            return IntRes;
        }

        //[WebMethod]
        //public int StateMaster_Save(State_Master_Property State, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "State_Master_Save";

        //    Request.AddParams("@State_ID", State.State_ID, DbType.Int32);
        //    Request.AddParams("@State_Name", State.State_Name, DbType.String);
        //    Request.AddParams("@Active", State.Active, DbType.Int32);
        //    Request.AddParams("@Remark", State.Remark, DbType.String);
        //    Request.AddParams("@Country_Code", State.Country_ID, DbType.Int32);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes += Ope.ExecuteNonQuery(ConnectionString_Global, BLL.DBConnections.ProviderName, Request);

        //    Request = new Request();
        //    Request.CommandText = "State_Master_Save";

        //    Request.AddParams("@State_ID", State.State_ID, DbType.Int32);
        //    Request.AddParams("@State_Name", State.State_Name, DbType.String);
        //    Request.AddParams("@Active", State.Active, DbType.Int32);
        //    Request.AddParams("@Remark", State.Remark, DbType.String);
        //    Request.AddParams("@Country_Code", State.Country_ID, DbType.Int32);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    return IntRes;
        //}


        [WebMethod]
        public DataTable PriorityMaster_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Priority");
            Request.CommandText = "Priority_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable CategoryMaster_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Category");
            Request.CommandText = "Category_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable WeekllyOffMaster_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("WeekllyOff");
            Request.CommandText = "WeekllyOff_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Work_StatusMaster_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Work Status");
            Request.CommandText = "Work_Status_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Request_StatusMaster_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Request Status");
            Request.CommandText = "Request_Status_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Module_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Module Master");
            Request.CommandText = "Module_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Location_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Location Master");
            Request.CommandText = "Location_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable IDProof_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("IDProof Master");
            Request.CommandText = "IDProof_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public int IDProof_Master_Save(IDProof_Master_Property pclsProperty, string ConnectionString)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();
        //    Request.AddParams("@IDProof_ID", pclsProperty.IDProof_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@IDProof_Name", pclsProperty.IDProof_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = objSproc.IDProof_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        //}

        [WebMethod]
        public DataTable Frequency_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Frequency Master");
            Request.CommandText = "Frequency_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable ModuleMaster_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Module");
            Request.CommandText = "Module_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Assessment_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Assessment Master");
            Request.CommandText = "Assessment_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable User_Right_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("User Rights Master");
            Request.CommandText = "User_Rights_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int User_Rights_Delete(User_Rights_Master_Property pclsProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();

            Request.AddParams("@Rights_ID", pclsProperty.Rights_ID, DbType.Int64, ParameterDirection.Input);
            Request.CommandText = objSproc.User_Rights_Delete;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }

        [WebMethod]
        public DataTable Sub_Assessment_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Sub Assessment Master");
            Request.CommandText = "Sub_Assessment_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        #region "Assesment Master"



        [WebMethod]
        public DataTable Assesment_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Assessment_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int Assesment_Master_Save(Assessment_Master_Property pclsProperty, string ConnectionString)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@Assessment_ID", pclsProperty.Assessment_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Module_ID", pclsProperty.Module_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Assessment_Name", pclsProperty.Assessment_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pclsProperty.Remarks, DbType.String, ParameterDirection.Input);
            Request.CommandText = objSproc.Assesment_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        #endregion

        #region "Catagory Master"
        [WebMethod]
        public DataTable Catagory_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Category_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Catagory_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Category_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public int Catagory_Master_Save(Category_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();
        //    Request.AddParams("@Category_ID", pclsProperty.Category_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Category_Name", pclsProperty.Category_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Category_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}
        #endregion

        #region "Frequency Master"
        [WebMethod]
        public DataTable Frequency_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("FrequencyMaster");

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Frequency_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Frequency_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Frequency_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public int Frequency_Master_Save(Frequency_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();
        //    Request.AddParams("@Frequency_ID", pclsProperty.Frequency_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Frequency_Name", pclsProperty.Frequency_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Frequency_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}

        #endregion

        #region "Holiday Master"
        [WebMethod]
        public DataTable Holiday_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Holiday Master");
            Request.CommandText = "Holiday_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Holiday_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Holiday_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Holiday_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Holiday_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public int Holiday_Master_Save(Holiday_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Holiday_ID", pclsProperty.Holiday_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Holiday_Name", pclsProperty.Holiday_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Start_Date", pclsProperty.Start_Date, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@End_Date", pclsProperty.End_Date, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Holiday_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}

        #endregion

        #region "Location Master"
        [WebMethod]
        public DataTable Location_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("LocationMaster");

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Location_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public DataTable Assessment_GetData(string ConnectionString)
        //{
        //    Request Request = new Request();
        //    DataTable DTab = new DataTable("AssessmentMaster");

        //    Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
        //    Request.CommandText = objSproc.Assessment_DropDown_GetData;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}


        [WebMethod]
        public DataTable Location_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Location_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int Location_Master_Save(Location_Master_Property pclsProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();

            Request.AddParams("@Location_ID", pclsProperty.Location_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Location_Name", pclsProperty.Location_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
            Request.CommandText = objSproc.Location_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }

        #endregion

        #region "Metting Room Master"
        public DataTable Metting_Room_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Metting_Room_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Metting_Room_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Metting_Room_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public int Metting_Room_Save(Metting_Room_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Metting_ID", pclsProperty.Metting_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Module_ID", pclsProperty.Module_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Assessment_ID", pclsProperty.Assessment_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Location_ID", pclsProperty.Location_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Sub_Assessment_ID", pclsProperty.Sub_Assessment_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Metting_Name", pclsProperty.Metting_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Login_ID", pclsProperty.Login_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Description", pclsProperty.Description, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Start_Date", pclsProperty.Start_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@End_Date", pclsProperty.End_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@Start_Time", pclsProperty.Start_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@End_Time", pclsProperty.End_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = objSproc.Metting_Room_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}

        #endregion

        #region "Module Master"
        [WebMethod]
        public DataTable Module_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Module_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public DataTable ModuleSearch_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Module_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int Module_Master_Save(Module_Master_Property pclsProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();

            Request.AddParams("@Module_ID", pclsProperty.Module_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Module_Name", pclsProperty.Module_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Remark", pclsProperty.Module_Name, DbType.String, ParameterDirection.Input);

            Request.CommandText = objSproc.Module_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }

        #endregion

        #region "Priority Type Master"

        [WebMethod]
        public DataTable Priority_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Priority_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public DataTable PrioritySearch_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Priority_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int Priority_Master_Save(Priority_Master_Property pclsProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();

            Request.AddParams("@Priority_ID", pclsProperty.Priority_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Priority_Name", pclsProperty.Priority_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = objSproc.Priority_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }

        #endregion

        #region "Request Status Master"
        [WebMethod]
        public DataTable Request_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Request_Status_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public DataTable RequestSearch_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Request_Status_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public int Request_Master_Save(Request_Status_Master_Property rsmpProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Request_Status_ID", rsmpProperty.Request_Status_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Request_Status_Name", rsmpProperty.Request_Status_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", rsmpProperty.Active, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Remark", rsmpProperty.Remark, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Request_Status_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}
        #endregion

        #region "Shedule Master"
        [WebMethod]
        public DataTable Shedule_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Schedule_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public DataTable SheduleSearch_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Schedule_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        //[WebMethod]
        //public int Shedule_Master_Save(Schedule_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Schedule_ID", pclsProperty.Schedule_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Task_ID", pclsProperty.Task_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Login_ID", pclsProperty.Login_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Start_Date", pclsProperty.Start_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@End_Date", pclsProperty.End_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@Start_Time", pclsProperty.Start_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@End_Time", pclsProperty.End_Time, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Status", pclsProperty.Status, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int16, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Schedule_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}
        #endregion

        [WebMethod]
        public DataTable Assesment_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Assessment Master");
            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Assesment_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public DataTable GetAssessmentDataList(int Module_ID, string ConnectionString)
        //{
        //    Request Request = new Request();
        //    DataTable DTab = new DataTable("Assessment Master");
        //    Request.AddParams("@ModuleID", Module_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.CommandText = objSproc.Assessment_DropDown_GetData;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        #region "SubAssesment Master"

        [WebMethod]
        public DataTable SubAssesment_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Sub Assesment Master");

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Sub_Assessment_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable SubAssesmentSearch_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Sub_Assessment_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public int SubAssesment_Master_Save(Sub_Assessment_Master_Property pclsProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();

            Request.AddParams("@Sub_Assessment_ID", pclsProperty.Sub_Assessment_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Module_ID", pclsProperty.Module_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Assesment_ID", pclsProperty.Assesment_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Location_ID", pclsProperty.Location_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Sub_Assessment_Name", pclsProperty.Sub_Assessment_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int16, ParameterDirection.Input);
            Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = objSproc.Sub_Assessment_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region "Task Master"
        [WebMethod]
        public DataTable Task_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("TaskList");

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Task_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public DataTable Task_GetDataByid(string Task_ID, string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("TaskList");

            //Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Task_ID", Task_ID, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Task_Master_GetData_ByIds;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable TaskSearch_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Task_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int Task_Master_Save(Task_Master_Property pclsProperty, string Connection_String)
        {
            int IntRes = 0;
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@Task_ID", pclsProperty.Task_ID, DbType.Int64);
            Request.AddParams("@Module_ID", pclsProperty.Module_ID, DbType.Int64);
            Request.AddParams("@Assessment_ID", pclsProperty.Assessment_ID, DbType.Int64);
            Request.AddParams("@Location_ID", pclsProperty.Location_ID, DbType.Int64);
            Request.AddParams("@Sub_Assessment_ID", pclsProperty.Sub_Assessment_ID, DbType.Int64);
            Request.AddParams("@Task_Name", pclsProperty.Task_Name, DbType.String);
            Request.AddParams("@Description", pclsProperty.Description, DbType.String);
            Request.AddParams("@Login_ID", pclsProperty.Login_ID, DbType.Int64);
            Request.AddParams("@Task_Login_ID", pclsProperty.Task_Login_ID, DbType.Int64);
            Request.AddParams("@Frequency_ID", pclsProperty.Frequency_ID, DbType.Int64);
            Request.AddParams("@Priority_ID", pclsProperty.Priority_ID, DbType.Int64);
            Request.AddParams("@Start_Date", pclsProperty.Start_Date, DbType.Date);
            Request.AddParams("@End_Date", pclsProperty.End_Date, DbType.Date);
            Request.AddParams("@Start_Time", pclsProperty.Start_Time, DbType.DateTime);
            Request.AddParams("@End_Time", pclsProperty.End_Time, DbType.DateTime);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int16);
            Request.AddParams("@Remark", pclsProperty.Remark, DbType.String);
            Request.AddParams("@Flaged", pclsProperty.Flaged, DbType.Int32);
            Request.AddParams("@Task_Image_1", pclsProperty.Task_Image_1 == null ? "" : pclsProperty.Task_Image_1, DbType.String);
            Request.AddParams("@Task_Image_2", pclsProperty.Task_Image_2 == null ? "" : pclsProperty.Task_Image_2, DbType.String);
            Request.AddParams("@Task_Image_3", pclsProperty.Task_Image_3 == null ? "" : pclsProperty.Task_Image_3, DbType.String);
            Request.AddParams("@Task_Image_4", pclsProperty.Task_Image_4 == null ? "" : pclsProperty.Task_Image_4, DbType.String);
            Request.AddParams("@Task_Image_5", pclsProperty.Task_Image_5 == null ? "" : pclsProperty.Task_Image_5, DbType.String);
            Request.CommandText = objSproc.Task_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            IntRes = Convert.ToInt32(Ope.ExecuteScalar(Connection_String, BLL.DBConnections.ProviderName, Request));
            return IntRes;
        }

        [WebMethod]
        public int Assign_Task_Delete(Task_Master_Property atmProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();
            Request.AddParams("@Task_ID", atmProperty.Task_ID, DbType.Int64, ParameterDirection.Input);
            Request.CommandText = objSproc.Assign_Task_Delete;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region "Task Transaction Master"
        [WebMethod]
        public DataTable TaskTransaction_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Task_Transaction_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable TaskTransactionSearch_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Task_Transaction_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable TaskTransaction_User_GetData(int Login_ID, string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Tasks");
            Request.AddParams("@Login_ID", Login_ID, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Task_Transaction_User_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable GetProjectTaskCount(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Tasks");
            Request.CommandText = objSproc.SP_getProjectTaskCount;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable TaskTransaction_AllUser_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Tasks");
            Request.CommandText = objSproc.Task_Transaction_AllUser_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public int TaskTransaction_User_Update(Task_Transaction_Property pclsProperty, string ConnectionString)
        {
            Request Request = new Request();
            Request.AddParams("@Transaction_ID", pclsProperty.Transaction_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Flaged", pclsProperty.Flaged, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Status_ID", pclsProperty.Status_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Remarks", pclsProperty.Remarks, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Testing_Done", pclsProperty.Testing_Done, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@EmpExpectedHours", pclsProperty.EmpExpectedHours, DbType.String, ParameterDirection.Input);

            Request.CommandText = objSproc.Task_User_Update;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);

        }

        [WebMethod]
        public int TaskTransaction_UserTested_Update(Task_Transaction_Property pclsProperty, string ConnectionString)
        {
            Request Request = new Request();
            Request.AddParams("@TaskID", pclsProperty.Task_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Tested", pclsProperty.Tested, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = objSproc.Task_UserTested_Update;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);

        }
        [WebMethod]
        public int TaskTransaction_Username_Update(string TaskID, string LoginID, string ConnectionString)
        {
            Request Request = new Request();
            Request.AddParams("@Task_ID", TaskID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Login_ID", LoginID, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = objSproc.UpdateUserName;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);

        }


        [WebMethod]
        public DataTable GetUserWorkingHours(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Tasks");
            Request.CommandText = objSproc.GetUserWorkingHours;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //GetUserWorkingHours

        [WebMethod]
        public int TaskTransaction_User_UpdateStartStop(Task_Transaction_Property pclsProperty, string ConnectionString)
        {
            Request Request = new Request();
            Request.AddParams("@Transaction_ID", pclsProperty.Transaction_ID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@Flaged", pclsProperty.Flaged, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = objSproc.Task_User_UpdateStartStop;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);

        }

        [WebMethod]
        public DataTable GetUserTaskAssignedHours(string ConnectionString)
        {

            Request Request = new Request();
            DataTable DTab = new DataTable("Tasks");
            Request.CommandText = objSproc.GetUserTaskAssignedHours;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        [WebMethod]
        public int TaskTransaction_Master_Save(Task_Transaction_Property pclsProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();

            Request.AddParams("@Transaction_ID", pclsProperty.Transaction_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Task_ID", pclsProperty.Task_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Module_ID", pclsProperty.Module_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Schedule_ID", pclsProperty.Schedule_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Status_ID", pclsProperty.Status_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remarks", pclsProperty.Remarks, DbType.String, ParameterDirection.Input);
            Request.AddParams("@StartDate", pclsProperty.Start_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@EndDate", pclsProperty.End_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Complete_Date", pclsProperty.Complete_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Complete_Time", pclsProperty.Complete_Time, DbType.DateTime, ParameterDirection.Input);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = objSproc.Task_Transaction_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region "User Catagory Master"
        [WebMethod]
        public DataTable UserCatagory_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.User_Catogry_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public DataTable User_Catogry_Master_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Task_Transaction_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        //[WebMethod]
        //public int User_Catogry_Master_Save(User_Catogry_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Catogry_ID", pclsProperty.Catogry_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Catogry_Name", pclsProperty.Catogry_Name, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int32, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Task_Transaction_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}
        #endregion

        #region "User Rights Master"
        //[WebMethod]
        //public DataTable User_Rights_Master_GetData(string ConnectionString)
        //{
        //    Request Request = new Request();
        //    DataTable DTab = new DataTable();

        //    Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
        //    Request.CommandText = objSproc.User_Catogry_Master_GetData;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        [WebMethod] 
        public int User_Rights_Master_Save(User_Rights_Master_Property urmProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();

            Request.AddParams("@Rights_ID", urmProperty.Rights_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Login_ID", urmProperty.Login_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Module_ID", urmProperty.Module_ID, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = objSproc.User_Rights_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region "Weeklly Of Rights Master"
        [WebMethod]
        public DataTable WeekllyOff_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.WeekllyOff_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public DataTable WeekllyOff_Master_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.WeekllyOff_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        //[WebMethod]
        //public int WeekllyOff_Master_Save(WeekllyOff_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@WeekllyOff_ID", pclsProperty.WeekllyOff_ID, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@WeekllyOff_Day", pclsProperty.WeekllyOff_Day, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = objSproc.WeekllyOff_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}
        #endregion

        #region "Work Request Master"
        [WebMethod]
        public DataTable Work_Request_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Work_Request_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public DataTable Work_Request_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Work_Request_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public int Work_Request_Save(Work_Request_Property pclsProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();

            Request.AddParams("@Status_ID", pclsProperty.Request_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Request_Name", pclsProperty.Request_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Request_By", pclsProperty.Request_By, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Request_To", pclsProperty.Request_To, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Request_Module_By", pclsProperty.Request_Module_By, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Request_Module_To", pclsProperty.Request_Module_To, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Category_ID", pclsProperty.Category_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Priority_ID", pclsProperty.Priority_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Request_Status_ID", pclsProperty.Request_Status_ID, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Remarks", pclsProperty.Remarks, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Complete_Date", pclsProperty.Complete_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Complete_Time", pclsProperty.Complete_Time, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int32, ParameterDirection.Input);

            Request.CommandText = objSproc.Work_Request_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region "Work Status Master"
        [WebMethod]
        public DataTable WorkStatus_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("WorkStatus");

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Work_Status_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public DataTable WorkStatus_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Work_Status_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public int WorkStatus_Save(Work_Status_Master_Property pclsProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();

            Request.AddParams("@Status_ID", pclsProperty.Status_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Status_Name", pclsProperty.Status_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

            Request.CommandText = objSproc.Work_Status_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region "Visitor Master"
        [WebMethod]
        public DataTable Visitor_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Visitor_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public DataTable Visitor_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = objSproc.Visitor_Master_Search_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        [WebMethod]
        public int Visitor_Save(Visitor_Master_Property pclsProperty, string Connection_String)
        {
            Request Request = new Request();
            DataTable dt = new DataTable();

            Request.AddParams("@Visitor_ID", pclsProperty.Visitor_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Module_ID", pclsProperty.Module_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Assessment_ID", pclsProperty.Assessment_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Location_ID", pclsProperty.Location_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Sub_Assessment_ID", pclsProperty.Sub_Assessment_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Visitor_Name", pclsProperty.Visitor_Name, DbType.String, ParameterDirection.Input);
            Request.AddParams("@IDProof_ID", pclsProperty.IDProof_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@IDProff_Detail", pclsProperty.IDProff_Detail, DbType.String, ParameterDirection.Input);
            Request.AddParams("@IDProff_Image", pclsProperty.IDProff_Image, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Visitor_Image", pclsProperty.Visitor_Image, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Mobile_No", pclsProperty.Mobile_No, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Visit_In_Date", pclsProperty.Visit_In_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Visit_Out_Date", pclsProperty.Visit_Out_Date, DbType.Date, ParameterDirection.Input);
            Request.AddParams("@Intime", pclsProperty.Intime, DbType.String, ParameterDirection.Input);
            Request.AddParams("@OutTime", pclsProperty.OutTime, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Address", pclsProperty.Address, DbType.String, ParameterDirection.Input);
            Request.AddParams("@City_ID", pclsProperty.City_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@State_ID", pclsProperty.State_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Country_ID", pclsProperty.Country_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@Pincode", pclsProperty.Pincode, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Contact_Person", pclsProperty.Contact_Person, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Remarks", pclsProperty.Remarks, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Active", pclsProperty.Active, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Visitor_Master_Save;
            Request.CommandType = CommandType.StoredProcedure;
            return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        }
        #endregion

        #region "Unit Master"
        [WebMethod]
        public DataTable Unit_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Unit Master");
            Request.CommandText = "Unit_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Unit_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Unit_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //[WebMethod]
        //public int Unit_Master_Save(Unit_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Unit_ID", pclsProperty.Unit_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Unit_Name", pclsProperty.Unit_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Unit_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}


        #endregion

        #region "Item Group Master"
        [WebMethod]
        public DataTable Item_Group_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Item Group Master");
            Request.CommandText = "Item_Group_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Item_Group_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Item_Group_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //[WebMethod]
        //public int Item_Group_Master_Save(Item_Group_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Item_Group_Code", pclsProperty.Item_Group_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Item_Group_Name", pclsProperty.Item_Group_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Item_Group_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}


        #endregion


        #region "Item Hsn Master"
        [WebMethod]
        public DataTable Item_Hsn_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Item Hsn Master");
            Request.CommandText = "Item_Hsn_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Item_Hsn_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Item_Hsn_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //[WebMethod]
        //public int Item_Hsn_Master_Save(Item_Hsn_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Hsn_ID", pclsProperty.Hsn_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Hsn_Code", pclsProperty.Hsn_Code, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Hsn_Name", pclsProperty.Hsn_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Igst_Date", pclsProperty.Igst_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@Igst_Rate", pclsProperty.Igst_Rate, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Sgst_Date", pclsProperty.Sgst_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@Sgst_Rate", pclsProperty.Sgst_Rate, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Cgst_Date", pclsProperty.Cgst_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@Cgst_Rate", pclsProperty.Cgst_Rate, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Item_Hsn_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}


        #endregion

        #region "Item Category Master"
        [WebMethod]
        public DataTable Item_Category_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Item Category Master");
            Request.CommandText = "Item_Category_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Item_Category_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Item_Category_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //[WebMethod]
        //public int Item_Category_Master_Save(Item_Category_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Item_Category_Code", pclsProperty.Item_Category_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Item_Category_Name", pclsProperty.Item_Category_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@IS_Consumable", pclsProperty.IS_Consumable, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@IS_Repairable", pclsProperty.IS_Repairable, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Item_Category_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}


        #endregion


        #region "Item Master"
        [WebMethod]
        public DataTable Item_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Item Master");
            Request.CommandText = "Item_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Item_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Item Master");

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Item_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //[WebMethod]
        //public int Item_Master_Save(Item_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Item_Code", pclsProperty.Item_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Company_Code", pclsProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Branch_Code", pclsProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Location_Code", pclsProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Item_Name", pclsProperty.Item_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Item_Shortname", pclsProperty.Item_Shortname, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Item_Group_Code", pclsProperty.Item_Group_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Item_Category_Code", pclsProperty.Item_Category_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Reorder_Level", pclsProperty.Reorder_Level, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Unit_Code", pclsProperty.Unit_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Last_Purchase_Rate", pclsProperty.Last_Purchase_Rate, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Item_Codification", pclsProperty.Item_Codification, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Disc_Per", pclsProperty.Disc_Per, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Hsn_ID", pclsProperty.Hsn_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Sale_Rate", pclsProperty.Sale_Rate, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Stock_Limit", pclsProperty.Stock_Limit, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Pcs_In_Box", pclsProperty.Pcs_In_Box, DbType.Int64, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Item_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}

        //[WebMethod]
        //public int Item_Master_Delete(Item_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Item_Code", pclsProperty.Item_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.CommandText = objSproc.Item_Master_Delete;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}

        #endregion


        #region "Item Detail"
        [WebMethod]
        public DataTable Item_Detail_Search_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Item Detail");
            Request.CommandText = "Item_Detail_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Item_Detail_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Item Detail");


            Request.CommandText = objSproc.Item_Detail_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //[WebMethod]
        //public int Item_Detail_Save(Item_Detail_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Item_Detail_ID", pclsProperty.Item_Detail_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Item_Code", pclsProperty.Item_Code, DbType.Int64, ParameterDirection.Input);

        //    Request.AddParams("@Location_Code", pclsProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Reorder_Level", pclsProperty.Reorder_Level, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Maximum_Reorder_Period", pclsProperty.Maximum_Reorder_Period, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Maximum_Consumption", pclsProperty.Maximum_Consumption, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Noofdaysofstock", pclsProperty.Noofdaysofstock, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Ordring_Qty", pclsProperty.Ordring_Qty, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Fin_Year_Code", pclsProperty.Fin_Year_Code, DbType.Int64, ParameterDirection.Input);


        //    Request.CommandText = objSproc.Item_Detail_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}




        #endregion

        #region "Company Master"
        [WebMethod]
        public DataTable Company_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Company_Master");
            Request.CommandText = "Company_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Company_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Company_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //[WebMethod]
        //public int Company_Master_Save(Company_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Company_Code", pclsProperty.Company_code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Company_Name", pclsProperty.Company_name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Contact_Person", pclsProperty.Contact_Person, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Website", pclsProperty.Website, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@EmailID", pclsProperty.EmailID, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Address", pclsProperty.Address, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Country_Code", pclsProperty.Country_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@State_Code", pclsProperty.State_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@City_Code", pclsProperty.City_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@ZipCode", pclsProperty.ZipCode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Phone", pclsProperty.Phone, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Company_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}


        #endregion

        #region "Branch Master"
        [WebMethod]
        public DataTable Branch_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Branch_Master");
            Request.CommandText = "Branch_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Branch_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Branch_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //[WebMethod]
        //public int Branch_Master_Save(Branch_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Branch_Code", pclsProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Branch_Name", pclsProperty.Branch_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Location_Code", pclsProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Company_Code", pclsProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Address", pclsProperty.Address, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Country_Code", pclsProperty.Country_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@State_Code", pclsProperty.State_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@City_Code", pclsProperty.City_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Pincode", pclsProperty.Pincode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Phoneno", pclsProperty.Phoneno, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remark, DbType.String, ParameterDirection.Input);


        //    Request.CommandText = objSproc.Branch_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}


        #endregion

        #region "Ledger Master"
        [WebMethod]
        public DataTable Ledger_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Ledger Master");
            Request.CommandText = "Ledger_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Ledger_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Ledger Master");

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Ledger_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //[WebMethod]
        //public int Ledger_Master_Save(Ledger_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Ledger_Code", pclsProperty.Ledger_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Ledger_Name", pclsProperty.Ledger_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Party_Address", pclsProperty.Party_Address, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Party_Pincode", pclsProperty.Party_Pincode, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Party_City_Code", pclsProperty.Party_City_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Party_State_Code", pclsProperty.Party_State_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Party_Country_Code", pclsProperty.Party_Country_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Party_Phone", pclsProperty.Party_Phone, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Party_Mobile", pclsProperty.Party_Mobile, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Party_Email", pclsProperty.Party_Email, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Bank_Name", pclsProperty.Bank_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Bank_Branch", pclsProperty.Bank_Branch, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Bank_IFSC", pclsProperty.Bank_IFSC, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Bank_AccountNo", pclsProperty.Bank_AccountNo, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Party_PanNo", pclsProperty.Party_PanNo, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Party_Type", pclsProperty.Party_Type, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Remark", pclsProperty.Remarks, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@GSTIN", pclsProperty.GSTIN, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@GSTIN_Effective_Date", pclsProperty.GSTIN_Effective_Date, DbType.String, ParameterDirection.Input);
        //    Request.CommandText = objSproc.Ledger_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}


        #endregion

        #region "Ledger Opening"
        [WebMethod]
        public DataTable Ledger_Opening_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Ledger Opening");
            Request.CommandText = "Ledger_Opening_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Opening_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Ledger_Opening_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }


        //[WebMethod]
        //public int Ledger_Opening_Save(Ledger_Opening_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@Ledger_Opening_ID", pclsProperty.Ledger_Opening_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Ledger_Code", pclsProperty.Ledger_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Company_Code", pclsProperty.Company_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Branch_Code", pclsProperty.Branch_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Location_Code", pclsProperty.Location_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@FIN_Year_Code", pclsProperty.FIN_Year_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Debit_AMT", pclsProperty.Debit_AMT, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Credit_AMT", pclsProperty.Credit_AMT, DbType.Decimal, ParameterDirection.Input);
        //    Request.AddParams("@Opening_Date", pclsProperty.Opening_Date, DbType.DateTime, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Ledger_Opening_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}


        #endregion

        #region "FIN Year Master"
        [WebMethod]
        public DataTable Financial_Year_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Financial Year Master");
            Request.CommandText = "Financial_Master_Search_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Financial_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();

            Request.AddParams("@Active", 1, DbType.Int32, ParameterDirection.Input);
            Request.CommandText = objSproc.Financial_Year_Master_GetData;
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public int Financial_Year_Master_Save(Financial_Year_Master_Property pclsProperty, string Connection_String)
        //{
        //    Request Request = new Request();
        //    DataTable dt = new DataTable();

        //    Request.AddParams("@FIN_Year_Code", pclsProperty.FIN_Year_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Financial_Year", pclsProperty.Financial_Year, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Start_Date", pclsProperty.Start_Date, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@End_Date", pclsProperty.End_Date, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Short_Name", pclsProperty.Short_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Active", pclsProperty.Active, DbType.Int32, ParameterDirection.Input);
        //    Request.AddParams("@Start_Yearmonth", pclsProperty.Start_Yearmonth, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@End_Yearmonth", pclsProperty.End_Yearmonth, DbType.Int64, ParameterDirection.Input);

        //    Request.CommandText = objSproc.Financial_Year_Master_Save;
        //    Request.CommandType = CommandType.StoredProcedure;
        //    return Ope.ExecuteNonQuery(Connection_String, BLL.DBConnections.ProviderName, Request);
        //}

        #endregion

        #region "Purchase Master"
        //[WebMethod]
        //public int PurchaseMaster_Save(PurchaseMaster_Property Purchase, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "Purchase_Master_Save";

        //    Request.AddParams("@ItemPurchaseMasterID", Purchase.Purchase_Master_ID, DbType.Int32);
        //    Request.AddParams("@Invoice_Date", Purchase.Invoice_Date, DbType.Date);
        //    Request.AddParams("@Tran_Date", Purchase.Tran_Date, DbType.Date);
        //    Request.AddParams("@Invoice_No", Purchase.Invoice_No, DbType.String);
        //    Request.AddParams("@Payment_Type", Purchase.Payment_Type, DbType.String);
        //    Request.AddParams("@Challan_No", Purchase.Challan_No, DbType.String);
        //    Request.AddParams("@Party_Code", Purchase.Party_Code, DbType.Int64);
        //    Request.AddParams("@Terms", Purchase.Terms, DbType.Int64);
        //    Request.AddParams("@Term_Date", Purchase.DueDate, DbType.Date);
        //    Request.AddParams("@Remarks", Purchase.Remarks, DbType.String);
        //    Request.AddParams("@IsTaxPayable", Purchase.IsTaxPayable, DbType.Boolean);


        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Convert.ToInt32(Ope.ExecuteScalar(ConnectionString, BLL.DBConnections.ProviderName, Request));
        //    return IntRes;
        //}

        //[WebMethod]
        //public int PurchaseDetail_Save(PurchaseMaster_Property Purchase, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "Purchase_Detail_Save";

        //    Request.AddParams("@Purchase_Detail_ID", Purchase.Purchase_Detail_ID, DbType.Int32);
        //    Request.AddParams("@Purchase_Master_ID", Purchase.Purchase_Master_ID, DbType.Int32);
        //    Request.AddParams("@Item_Code", Purchase.Item_Code, DbType.Int64);
        //    Request.AddParams("@HSN", Purchase.HSN, DbType.Int64);
        //    Request.AddParams("@Unit", Purchase.Unit, DbType.Int64);
        //    Request.AddParams("@QTY", Purchase.QTY, DbType.Int64);
        //    Request.AddParams("@Rate", Purchase.Rate, DbType.Decimal);
        //    Request.AddParams("@Amount", Purchase.Amount, DbType.Decimal);
        //    Request.AddParams("@Disc", Purchase.Disc, DbType.Decimal);

        //    Request.AddParams("@SGSTRate", Purchase.SGSTRate, DbType.Decimal);
        //    Request.AddParams("@SGSTAmt", Purchase.SGSTAmt, DbType.Decimal);

        //    Request.AddParams("@CGSTRate", Purchase.CGSTRate, DbType.Decimal);
        //    Request.AddParams("@CGSTAmt", Purchase.CGSTAmt, DbType.Decimal);

        //    Request.AddParams("@IGSTRate", Purchase.IGSTRate, DbType.Decimal);
        //    Request.AddParams("@IGSTAmt", Purchase.IGSTAmt, DbType.Decimal);

        //    Request.AddParams("@NetAmt", Purchase.Net_Amt, DbType.Decimal);
        //    Request.AddParams("@Remarks", Purchase.Remarks, DbType.String);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Convert.ToInt32(Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request));
        //    return IntRes;
        //}

        #endregion

        public string DataTableToJSONWithStringBuilder(DataTable table)
        {
            var JSONString = new StringBuilder();
            if (table.Rows.Count > 0)
            {
                JSONString.Append("[");
                for (int i = 0; i < table.Rows.Count; i++)
                {
                    JSONString.Append("{");
                    for (int j = 0; j < table.Columns.Count; j++)
                    {
                        if (j < table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\",");
                        }
                        else if (j == table.Columns.Count - 1)
                        {
                            JSONString.Append("\"" + table.Columns[j].ColumnName.ToString() + "\":" + "\"" + table.Rows[i][j].ToString() + "\"");
                        }
                    }
                    if (i == table.Rows.Count - 1)
                    {
                        JSONString.Append("}");
                    }
                    else
                    {
                        JSONString.Append("},");
                    }
                }
                JSONString.Append("]");
            }
            return JSONString.ToString();
        }

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

        //[WebMethod]
        //public int SalesMaster_Save(Sales_Master_Property Sales, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "Sales_Master_Save";

        //    Request.AddParams("@ItemSaleMasterID", Sales.ItemSaleMasterID, DbType.Int64);
        //    Request.AddParams("@Ledger_Code", Sales.From_Party_Code, DbType.Int32);
        //    Request.AddParams("@Invoice_Date", Sales.Invoice_Date, DbType.Date);
        //    Request.AddParams("@Inovice_No", Sales.Invoice_No, DbType.String);
        //    Request.AddParams("@Payment_Type", Sales.Payment_Mode, DbType.String);
        //    Request.AddParams("@Terms", Sales.Payment_Days, DbType.String);
        //    Request.AddParams("@Term_Date", Sales.Payment_Date, DbType.Date);
        //    Request.AddParams("@Trans_Date", Sales.Transaction_Date, DbType.Date);
        //    Request.AddParams("@Is_Reverse", Sales.IS_Reverse, DbType.Int32);
        //    Request.AddParams("@Challan_No", Sales.Challan_No, DbType.String);
        //    Request.AddParams("@Mobile_No", Sales.Party_Mobile, DbType.String);
        //    Request.AddParams("@Registration_No", Sales.Registration_No, DbType.String);
        //    Request.AddParams("@Model_No", Sales.Model_No, DbType.String);
        //    Request.AddParams("@KiloMeter", Sales.Kilometer, DbType.String);


        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Convert.ToInt32(Ope.ExecuteScalar(ConnectionString, BLL.DBConnections.ProviderName, Request));
        //    return IntRes;
        //}
        //[WebMethod]
        //public int EstimateMaster_Save(Sales_Master_Property Sales, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "Estimate_Master_Save";

        //    Request.AddParams("@ItemEstimateMasterID", Sales.ItemSaleMasterID, DbType.Int64);
        //    Request.AddParams("@Ledger_Code", Sales.From_Party_Code, DbType.String);
        //    Request.AddParams("@Invoice_Date", Sales.Invoice_Date, DbType.Date);
        //    Request.AddParams("@Inovice_No", Sales.Invoice_No, DbType.String);
        //    Request.AddParams("@Payment_Type", Sales.Payment_Mode, DbType.String);
        //    Request.AddParams("@Terms", Sales.Payment_Days, DbType.String);
        //    Request.AddParams("@Term_Date", Sales.Payment_Date, DbType.Date);
        //    Request.AddParams("@Trans_Date", Sales.Transaction_Date, DbType.Date);
        //    Request.AddParams("@Is_Reverse", Sales.IS_Reverse, DbType.Int32);
        //    Request.AddParams("@Challan_No", Sales.Challan_No, DbType.String);
        //    Request.AddParams("@Mobile_No", Sales.Party_Mobile, DbType.String);
        //    Request.AddParams("@Registration_No", Sales.Registration_No, DbType.String);
        //    Request.AddParams("@Model_No", Sales.Model_No, DbType.String);
        //    Request.AddParams("@KiloMeter", Sales.Kilometer, DbType.String);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Convert.ToInt32(Ope.ExecuteScalar(ConnectionString, BLL.DBConnections.ProviderName, Request));
        //    return IntRes;
        //}

        //[WebMethod]
        //public int Estimate_Detail_Save(Sales_Master_Property Sales, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "Estimate_Detail_SAVE";
        //    Request.AddParams("@ItemEstimateDetailID", Sales.ItemSaleDetailID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@ItemEstimateMasterID", Sales.ItemSaleMasterID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Item_Code", Sales.Item_Name, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@HSN_ID", Sales.HSN_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Unit_Code", Sales.unitCode, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Quantity", Sales.Quantity, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Rate", Sales.Rate, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Gross_Amt", Sales.Gross_Amt, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Discount", Sales.Disc_Per, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@SGST_Rate", Sales.SGST, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@SGST_Amt", Sales.SGST_Amt, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@CGST_Rate", Sales.CGST, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@CGST_Amt", Sales.CGST_Amt, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@IGST_Rate", Sales.IGST, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@IGST_Amt", Sales.IGST_Amt, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@NetAmount", Sales.Net_Amt, DbType.Double, ParameterDirection.Input);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    return IntRes;
        //}

        //[WebMethod]
        //public int Estimate_Detail_SaveXML(Sales_Master_Property[] Sales, string ConnectionString)
        //{
        //    string Msg = string.Empty;
        //    string XMLStr = "<root>";
        //    XMLStr = XMLStr + "<EstimateDetail>";
        //    foreach (Sales_Master_Property prop in Sales)
        //    {
        //        XMLStr = XMLStr + "<ItemDetail>" +
        //                "<ItemEstimateDetailID>" + prop.ItemSaleDetailID + "</ItemEstimateDetailID>" +
        //                "<ItemEstimateMasterID>" + prop.ItemSaleMasterID + "</ItemEstimateMasterID>" +
        //                "<Item_Code>" + prop.Item_Name + "</Item_Code>" +
        //                "<HSN_ID>" + prop.HSN_ID + "</HSN_ID>" +
        //                "<Unit_Code>" + prop.unitCode + "</Unit_Code>" +
        //                "<Quantity>" + prop.Quantity + "</Quantity>" +
        //                "<Rate>" + prop.Rate + "</Rate>" +
        //                "<Gross_Amt>" + prop.Gross_Amt + "</Gross_Amt>" +
        //                "<Discount>" + prop.Disc_Per + "</Discount>" +
        //                "<SGST_Rate>" + prop.SGST + "</SGST_Rate>" +
        //                "<SGST_Amt>" + prop.SGST_Amt + "</SGST_Amt>" +
        //                "<CGST_Rate>" + prop.CGST + "</CGST_Rate>" +
        //                "<CGST_Amt>" + prop.CGST_Amt + "</CGST_Amt>" +
        //                "<IGST_Rate>" + prop.IGST + "</IGST_Rate>" +
        //                "<IGST_Amt>" + prop.IGST_Amt + "</IGST_Amt>" +
        //                "<NetAmount>" + prop.Net_Amt + "</NetAmount>" +
        //                "</ItemDetail>";
        //    }
        //    XMLStr = XMLStr + "</EstimateDetail>";
        //    XMLStr = XMLStr + "</root>";
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "Estimate_Detail_SAVE_XML";
        //    Request.AddParams("@XMLdata", XMLStr, DbType.Xml, ParameterDirection.Input);
        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    return IntRes;
        //}

        //[WebMethod]
        //public int Sales_Detail_Save(Sales_Master_Property Sales, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "Sales_Detail_Save";
        //    Request.AddParams("@ItemSalesDetailID", Sales.ItemSaleDetailID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@ItemSalesMasterID", Sales.ItemSaleMasterID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Item_Code", Sales.Item_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@HSN_ID", Sales.HSN_ID, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Unit_Code", Sales.unitCode, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Quantity", Sales.Quantity, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Rate", Sales.Rate, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Gross_Amt", Sales.Gross_Amt, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@Discount", Sales.Disc_Per, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@SGST_Rate", Sales.SGST, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@SGST_Amt", Sales.SGST_Amt, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@CGST_Rate", Sales.CGST, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@CGST_Amt", Sales.CGST_Amt, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@IGST_Rate", Sales.IGST, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@IGST_Amt", Sales.IGST_Amt, DbType.Double, ParameterDirection.Input);
        //    Request.AddParams("@NetAmount", Sales.Net_Amt, DbType.Double, ParameterDirection.Input);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    return IntRes;
        //}

        //[WebMethod]
        //public int Sales_Detail_SaveXML(Sales_Master_Property[] Sales, string ConnectionString)
        //{
        //    string Msg = string.Empty;
        //    string XMLStr = "<root>";
        //    XMLStr = XMLStr + "<SaleDetail>";
        //    foreach (Sales_Master_Property prop in Sales)
        //    {
        //        XMLStr = XMLStr + "<ItemDetail>" +
        //                "<ItemSalesDetailID>" + prop.ItemSaleDetailID + "</ItemSalesDetailID>" +
        //                "<ItemSalesMasterID>" + prop.ItemSaleMasterID + "</ItemSalesMasterID>" +
        //                "<Item_Code>" + prop.Item_Code + "</Item_Code>" +
        //                "<HSN_ID>" + prop.HSN_ID + "</HSN_ID>" +
        //                "<Unit_Code>" + prop.unitCode + "</Unit_Code>" +
        //                "<Quantity>" + prop.Quantity + "</Quantity>" +
        //                "<Rate>" + prop.Rate + "</Rate>" +
        //                "<Gross_Amt>" + prop.Gross_Amt + "</Gross_Amt>" +
        //                "<Discount>" + prop.Disc_Per + "</Discount>" +
        //                "<SGST_Rate>" + prop.SGST + "</SGST_Rate>" +
        //                "<SGST_Amt>" + prop.SGST_Amt + "</SGST_Amt>" +
        //                "<CGST_Rate>" + prop.CGST + "</CGST_Rate>" +
        //                "<CGST_Amt>" + prop.CGST_Amt + "</CGST_Amt>" +
        //                "<IGST_Rate>" + prop.IGST + "</IGST_Rate>" +
        //                "<IGST_Amt>" + prop.IGST_Amt + "</IGST_Amt>" +
        //                "<NetAmount>" + prop.Net_Amt + "</NetAmount>" +
        //                "</ItemDetail>";
        //    }
        //    XMLStr = XMLStr + "</SaleDetail>";
        //    XMLStr = XMLStr + "</root>";
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "Sale_Detail_SAVE_XML";
        //    Request.AddParams("@XMLdata", XMLStr, DbType.Xml, ParameterDirection.Input);
        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    return IntRes;
        //}

        [WebMethod]
        public int Transaction_Detail_Delete(string From_Type, int ItemMasterID, int ItemDetailID, string ConnectionString)
        {
            int IntRes = 0;
            Request Request = new Request();
            Request.CommandText = objSproc.Item_Invoice_Detail_Delete;
            Request.AddParams("@From_Type", From_Type, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ItemMasterID", ItemMasterID, DbType.Int64, ParameterDirection.Input);
            Request.AddParams("@ItemDetailID", ItemDetailID, DbType.Int64, ParameterDirection.Input);
            Request.CommandType = CommandType.StoredProcedure;
            IntRes = Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
            return IntRes;
        }


        //[WebMethod]
        //public DataTable Sales_ReportGet(Sales_Master_Property Sales, string ConnectionString)
        //{
        //    DataTable DTab = new DataTable("Sales_Report_GetData");

        //    Request Request = new Request();
        //    Request.CommandText = "Acc_purchase_entry_print";

        //    Request.AddParams("@INVOICE_DATE", Sales.Invoice_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@INVOICE_NO", Sales.Invoice_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@TRN_ID", Sales.Trn_Id, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@TRN_TYPE", "S", DbType.String, ParameterDirection.Input);


        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        //[WebMethod]
        //public DataTable Estimate_ReportGet(Sales_Master_Property Sales, string ConnectionString)
        //{
        //    DataTable DTab = new DataTable("Estimate_Report_GetData");

        //    Request Request = new Request();
        //    Request.CommandText = "Acc_purchase_entry_print";

        //    Request.AddParams("@INVOICE_DATE", Sales.Invoice_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@INVOICE_NO", Sales.Invoice_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@TRN_ID", Sales.Trn_Id, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@TRN_TYPE", "ES", DbType.String, ParameterDirection.Input);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        //[WebMethod]
        //public DataTable Purchase_ReportGet(Sales_Master_Property Sales, string ConnectionString)
        //{
        //    DataTable DTab = new DataTable("Purchase_Report_GetData");

        //    Request Request = new Request();
        //    Request.CommandText = "Acc_purchase_entry_print";

        //    Request.AddParams("@INVOICE_DATE", Sales.Invoice_Date, DbType.Date, ParameterDirection.Input);
        //    Request.AddParams("@INVOICE_NO", Sales.Invoice_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@TRN_ID", Sales.Trn_Id, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@TRN_TYPE", "P", DbType.String, ParameterDirection.Input);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        [WebMethod]
        public DataTable Purchase_Sale_GetData(string Form_Type, string From_Date, string To_Date, string ConnectionString)
        {

            DataTable DTab = new DataTable("TransSummary");
            Request Request = new Request();

            Request.AddParams("@From_Type", Form_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@From_Date", From_Date, DbType.String, ParameterDirection.Input);
            Request.AddParams("@To_Date", To_Date, DbType.String, ParameterDirection.Input);

            Request.CommandText = "Purchase_Sale_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable GetSalesDetailEdit(string Form_Type, string SaleMasterID, string ConnectionString)
        {

            DataTable DTab = new DataTable("TransDetail");
            Request Request = new Request();

            Request.AddParams("@From_Type", Form_Type, DbType.String, ParameterDirection.Input);
            Request.AddParams("@Master_ID", Convert.ToInt32(SaleMasterID), DbType.Int32, ParameterDirection.Input);

            Request.CommandText = "Purchase_Sale_Detail_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public DataTable GetSales_SummaryReport(Sales_Master_Property pclsProperty, string ConnectionString)
        //{
        //    DataTable DTab = new DataTable("Sales_Master");
        //    Request Request = new Request();

        //    Request.AddParams("@FromDate", pclsProperty.From_Date, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@ToDate", pclsProperty.To_Date, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Party_Code", pclsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Payment_Type", pclsProperty.Type, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Invoice_No", pclsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Challan_No", pclsProperty.Challan_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Vehicle_No", pclsProperty.Registration_No, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = "Summary_Sales_Master_Getdata";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        //[WebMethod]
        //public DataTable GetEstimate_SummaryReport(Sales_Master_Property pclsProperty, string ConnectionString)
        //{
        //    DataTable DTab = new DataTable("Estimate_Master");
        //    Request Request = new Request();

        //    Request.AddParams("@FromDate", pclsProperty.From_Date, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@ToDate", pclsProperty.To_Date, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Party_Code", pclsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Payment_Type", pclsProperty.Type, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Invoice_No", pclsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Challan_No", pclsProperty.Challan_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Vehicle_No", pclsProperty.Registration_No, DbType.String, ParameterDirection.Input);


        //    Request.CommandText = "Summary_Estimate_Master_Getdata";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        //[WebMethod]
        //public DataTable GetEstimate_DetailsReport(Sales_Master_Property pclsProperty, string ConnectionString)
        //{
        //    DataTable DTab = new DataTable("Estimate_Details");
        //    Request Request = new Request();

        //    Request.AddParams("@FromDate", pclsProperty.From_Date, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@ToDate", pclsProperty.To_Date, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Party_Code", pclsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Payment_Type", pclsProperty.Type, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Invoice_No", pclsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Challan_No", pclsProperty.Challan_No, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = "Summary_Estimate_Details_Getdata";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}



        //[WebMethod]
        //public DataTable GetSales_DetailsReport(Sales_Master_Property pclsProperty, string ConnectionString)
        //{
        //    DataTable DTab = new DataTable("Sales_Details");
        //    Request Request = new Request();

        //    Request.AddParams("@FromDate", pclsProperty.From_Date, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@ToDate", pclsProperty.To_Date, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Party_Code", pclsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Payment_Type", pclsProperty.Type, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Invoice_No", pclsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Challan_No", pclsProperty.Challan_No, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = "Summary_Sales_Details_Getdata";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        //[WebMethod]
        //public DataTable GetPurchase_SummaryReport(Sales_Master_Property pclsProperty, string ConnectionString)
        //{
        //    DataTable DTab = new DataTable("Purchase_Master");
        //    Request Request = new Request();

        //    Request.AddParams("@FromDate", pclsProperty.From_Date, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@ToDate", pclsProperty.To_Date, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Party_Code", pclsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Payment_Type", pclsProperty.Type, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Invoice_No", pclsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Challan_No", pclsProperty.Challan_No, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = "Summary_Purchase_Master_Getdata";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        //[WebMethod]
        //public DataTable GetPurchase_DetailsReport(Sales_Master_Property pclsProperty, string ConnectionString)
        //{
        //    DataTable DTab = new DataTable("Purchase_Details");
        //    Request Request = new Request();

        //    Request.AddParams("@FromDate", pclsProperty.From_Date, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@ToDate", pclsProperty.To_Date, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Party_Code", pclsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@Payment_Type", pclsProperty.Type, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@Invoice_No", pclsProperty.Invoice_No, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@Challan_No", pclsProperty.Challan_No, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = "Summary_Purchase_Details_Getdata";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        //[WebMethod]
        //public int JobCardMaster_Save(JobCard_Master_Property JobCard, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
        //    Request.CommandText = "JobCard_Master_Save";

        //    Request.AddParams("@Job_ID", JobCard.Job_ID, DbType.Int32);
        //    Request.AddParams("@Entry_Date", JobCard.Entry_Date, DbType.Date);
        //    Request.AddParams("@Party_Code", JobCard.Party_Code, DbType.Int64);
        //    Request.AddParams("@Contact_Person", JobCard.Contact_Person, DbType.String);
        //    Request.AddParams("@Registration_No", JobCard.Registration_No, DbType.String);
        //    Request.AddParams("@Milage", JobCard.Milage, DbType.String);
        //    Request.AddParams("@Chassis_No", JobCard.Chassis_No, DbType.String);
        //    Request.AddParams("@Engine_No", JobCard.Engine_No, DbType.String);
        //    Request.AddParams("@Model_No", JobCard.Model_No, DbType.String);
        //    Request.AddParams("@Customer_Request", JobCard.Customer_Request, DbType.String);
        //    Request.AddParams("@Primary_Job", JobCard.Primary_Job, DbType.String);
        //    Request.AddParams("@Additional_Job", JobCard.Additional_Job, DbType.String);
        //    Request.AddParams("@Secondary_Job", JobCard.Secondary_Job, DbType.String);
        //    Request.AddParams("@Additional_Job_Time", System.DateTime.Now.ToShortTimeString(), DbType.String);
        //    Request.AddParams("@Additional_Job_Date", JobCard.Entry_Date, DbType.Date);
        //    Request.AddParams("@Promised_Date", JobCard.Promised_Date, DbType.Date);
        //    Request.AddParams("@Promised_Time", JobCard.Promised_Time, DbType.String);
        //    Request.AddParams("@Additional_Job_Confirm", JobCard.Additional_Job_Confirm, DbType.Int32);
        //    Request.AddParams("@Estimated_Amount", JobCard.Estimated_Amount, DbType.Double);
        //    Request.AddParams("@Service_Advisor", JobCard.Service_Advisor, DbType.String);
        //    Request.AddParams("@Remarks", JobCard.Remarks, DbType.String);
        //    Request.AddParams("@IS_Service_Box", JobCard.IS_Service_Box, DbType.Int32);
        //    Request.AddParams("@IS_Toolkit", JobCard.IS_Toolkit, DbType.Int32);
        //    Request.AddParams("@IS_Spare_Wheel", JobCard.IS_Spare_Wheel, DbType.Int32);
        //    Request.AddParams("@IS_Jack", JobCard.IS_Jack, DbType.Int32);
        //    Request.AddParams("@IS_Jack_Handle", JobCard.IS_Jack_Handle, DbType.Int32);
        //    Request.AddParams("@IS_Car_Perfume", JobCard.IS_Car_Perfume, DbType.Int32);
        //    Request.AddParams("@IS_Clock", JobCard.IS_Clock, DbType.Int32);
        //    Request.AddParams("@IS_Stereo", JobCard.IS_Stereo, DbType.Int32);
        //    Request.AddParams("@IS_CD_Player", JobCard.IS_CD_Player, DbType.Int32);
        //    Request.AddParams("@IS_Mouth_Pieces", JobCard.IS_Mouth_Pieces, DbType.Int32);
        //    Request.AddParams("@IS_CD_Changer", JobCard.IS_CD_Changer, DbType.Int32);
        //    Request.AddParams("@IS_Battery", JobCard.IS_Battery, DbType.Int32);
        //    Request.AddParams("@Typers", JobCard.Typers, DbType.String);
        //    Request.AddParams("@Idols_Nos", JobCard.Idols_Nos, DbType.Int32);
        //    Request.AddParams("@Wheel_Cover_Nos", JobCard.Wheel_Cover_Nos, DbType.Int32);
        //    Request.AddParams("@Wheels_Cap_Nos", JobCard.Wheels_Cap_Nos, DbType.Int32);
        //    Request.AddParams("@Mud_Flaps_Nos", JobCard.Mud_Flaps_Nos, DbType.Int32);
        //    Request.AddParams("@Dicky_Mat_Nos", JobCard.Dicky_Mat_Nos, DbType.Int32);
        //    Request.AddParams("@Cigaret_Higher", JobCard.Cigaret_Higher, DbType.Int32);
        //    Request.AddParams("@Speaker_RR_Nos", JobCard.Speaker_RR_Nos, DbType.Int32);
        //    Request.AddParams("@Speaker_FR_Nos", JobCard.Speaker_FR_Nos, DbType.Int32);
        //    Request.AddParams("@Tweeter_Nos", JobCard.Tweeter_Nos, DbType.Int32);
        //    Request.AddParams("@Exl_Warranty", JobCard.Exl_Warranty, DbType.Int32);
        //    Request.AddParams("@ItemSaleMasterID", JobCard.ItemSaleMasterID, DbType.Int64);

        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes += Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    return IntRes;
        //}

        [WebMethod]
        public DataTable JobCard_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("JobCard_Master");
            Request.CommandText = "JobCard_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable JobCard_Dropdown(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("JobCard_Master");
            Request.CommandText = "JobCard_Dropdown";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable JobCard_Fill(string ConnectionString, string job_id)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("JobCard_Master");
            Request.AddParams("@Job_ID", job_id, DbType.Int32);
            Request.CommandText = "JobCard_Fill";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        //[WebMethod]
        //public DataTable ItemUnit_Fill(string ConnectionString , string Item_Code)
        //{
        //    Request Request = new Request();
        //    DataTable DTab = new DataTable("Item_Master");
        //    Request.AddParams("@Item_Code", Item_Code, DbType.Int32);
        //    Request.CommandText = "ItemUnit_Fill";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        [WebMethod]
        public DataTable JobCard_Master_CardRpt(Int64 jobid, string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("JobCard_Master");
            Request.CommandText = "JobCard_Master_CardRpt";
            Request.CommandType = CommandType.StoredProcedure;
            Request.AddParams("@Job_ID", jobid, DbType.Int64);
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public DataTable GetItem_Stock_Report(Sales_Master_Property pclsProperty, string ConnectionString)
        //{
        //    DataTable DTab = new DataTable("Item_Stock");
        //    Request Request = new Request();

        //    Request.AddParams("@FROM_DATE", pclsProperty.From_Date, DbType.String, ParameterDirection.Input);
        //    Request.AddParams("@TO_DATE", pclsProperty.To_Date, DbType.String, ParameterDirection.Input);

        //    Request.AddParams("@ITEM_CODE", pclsProperty.From_Party_Code, DbType.Int64, ParameterDirection.Input);
        //    Request.AddParams("@CATEGORY_CODE", pclsProperty.Type, DbType.String, ParameterDirection.Input);

        //    Request.CommandText = "RP_ITEM_STOCK_DETAIL_CURR";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}

        //[WebMethod]
        //public int BankMaster_Save(Country_Master_Property Country, string ConnectionString)
        //{
        //    int IntRes = 0;
        //    Request Request = new Request();
            

        //    Request.AddParams("@ID", Country.ID, DbType.Int64);
        //    Request.AddParams("@Bank_Name", Country.Bank_Name, DbType.String);
        //    Request.AddParams("@Bank_IFSC", Country.Bank_IFSC, DbType.String);
        //    Request.AddParams("@Bank_Address", Country.Bank_Address, DbType.String);
        //    Request.AddParams("@Bank_Branch", Country.Bank_Branch, DbType.String);

        //    Request.CommandText = "Bank_Master_SAVE";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    IntRes = Ope.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        //    return IntRes;
        //}

        [WebMethod]
        public DataTable Bank_Master_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Bank Master");
            Request.CommandText = "Bank_Master_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable Get_user_Rights(User_Login_Master_Property objUser_Login_Master_Property, string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Rights_get");
            Request.AddParams("@Login_ID", objUser_Login_Master_Property.Login_ID, DbType.String);
            Request.CommandText = "select_rights";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable PRC_Get_Module_Id_By_Name(Module_Master_Property objModule_Master_Property, string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Rights_get");
            Request.AddParams("@Module_Name", objModule_Master_Property.Module_Name, DbType.String);
            Request.CommandText = "PRC_Get_Module_Id_By_Name";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        [WebMethod]
        public DataTable PRC_Get_Mst_User_Rights_With_Module(User_Login_Master_Property objUser_Login_Master_Property, string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable("Rights_get");
            Request.AddParams("@Login_ID", objUser_Login_Master_Property.Login_ID, DbType.String);
            Request.AddParams("@Module_ID", objUser_Login_Master_Property.Module_ID, DbType.String);
            Request.CommandText = "PRC_Get_Mst_User_Rights_With_Module";
            Request.CommandType = CommandType.StoredProcedure;
            Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        //[WebMethod]
        //public DataTable Get_User_Rights_With_Module(User_Login_Master_Property objUser_Login_Master_Property, string ConnectionString)
        //{
        //    Request Request = new Request();
        //    DataTable DTab = new DataTable("Rights_get");
        //    Request.AddParams("@Login_ID", objUser_Login_Master_Property.Login_ID, DbType.String);
        //    Request.AddParams("@Module_ID", objUser_Login_Master_Property.Module_ID, DbType.String);
        //    Request.CommandText = "select_rights";
        //    Request.CommandType = CommandType.StoredProcedure;
        //    Ope.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
        //    return DTab;
        //}
    }
}
