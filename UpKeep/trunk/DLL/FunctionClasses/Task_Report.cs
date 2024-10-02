using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DLL.FunctionClasses
{
    public class Task_Report
    {
        InterfaceLayer obj = new InterfaceLayer();

        public DataTable Task_GetData_Report(string ConnectionString, int Login_ID, string from_date, string to_date)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@Login_ID", Login_ID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@from_date", from_date, DbType.DateTime, ParameterDirection.Input);
            Request.AddParams("@to_date", to_date, DbType.DateTime, ParameterDirection.Input);
            Request.CommandText = "Task_Transaction_GetData_By_User";
            Request.CommandType = CommandType.StoredProcedure;
            obj.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }

    }
}
