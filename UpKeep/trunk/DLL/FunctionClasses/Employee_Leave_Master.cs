using DLL.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.FunctionClasses
{
    public class Employee_Leave_Master
    {
        InterfaceLayer obj = new InterfaceLayer();
       
        public int EmployeeLeave_Save(Employee_Leave_Property EmployeeLeave, string ConnectionString)
        {
            int IntRes = 0;
            Request Request = new Request();
            Request.AddParams("@Employee_Leave_Id", EmployeeLeave.Employee_Leave_Id, DbType.Int64);
            Request.AddParams("@User_Id", EmployeeLeave.User_Id, DbType.Int32);
            Request.AddParams("@Leave_Date", EmployeeLeave.Leave_Date, DbType.Date);  
            Request.AddParams("@Leave_Reason", EmployeeLeave.Leave_Reason, DbType.String);
            Request.AddParams("@Leave_Type", EmployeeLeave.Leave_Type, DbType.String);
            Request.AddParams("@Active", EmployeeLeave.Active, DbType.Int32);
            Request.AddParams("@Add_By", EmployeeLeave.Add_By, DbType.Int16); //EmployeeLeave.Add_By
            Request.AddParams("@Edit_By", EmployeeLeave.Edit_By, DbType.Int16); //EmployeeLeave.Edit_By
            //Request.AddParams("@Add_Date", EmployeeLeave.Add_Date, DbType.Date); // EmployeeLeave.Add_Date
            //Request.AddParams("@Edit_Date", EmployeeLeave.Edit_Date, DbType.Date); //EmployeeLeave.Edit_Date
            Request.CommandText = "Employee_Leave_Save";
            Request.CommandType = CommandType.StoredProcedure;
            IntRes = obj.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
            return IntRes;
            //return obj.ExecuteNonQuery(ConnectionString, BLL.DBConnections.ProviderName, Request);
        }

        public DataTable Employee_Leave_GetData(string ConnectionString)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.CommandText = "Employee_Leave_GetData";
            Request.CommandType = CommandType.StoredProcedure;
            obj.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

        public DataTable Employee_Leave_GetData_Report(string ConnectionString,int User_Id,string from_date,string to_date)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@User_Id", User_Id, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@from_date", from_date, DbType.DateTime, ParameterDirection.Input);
            Request.AddParams("@to_date", to_date, DbType.DateTime, ParameterDirection.Input);
            Request.CommandText = "Employee_Leave_GetData_For_Report";
            Request.CommandType = CommandType.StoredProcedure;
            obj.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

    }
}
