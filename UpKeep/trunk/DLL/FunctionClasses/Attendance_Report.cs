using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DLL.FunctionClasses
{
    public class Attendance_Report
    {
        InterfaceLayer obj = new InterfaceLayer();

        public DataTable Attendance_Report_GetData(string ConnectionString,int EmpID,string from_date,string to_date)
        {
            Request Request = new Request();
            DataTable DTab = new DataTable();
            Request.AddParams("@EmpID", EmpID, DbType.Int32, ParameterDirection.Input);
            Request.AddParams("@from_date", from_date, DbType.DateTime, ParameterDirection.Input);
            Request.AddParams("@to_date", to_date, DbType.DateTime, ParameterDirection.Input);
            Request.CommandText = "TechRhombusAc.dbo.rpt_MonthlyHourSummary_Report_new";  //"TechRhombusAc.dbo.rpt_MonthlyHourSummary_Report";
            Request.CommandType = CommandType.StoredProcedure;
            //obj.GetDataTable(BLL.DBConnections.ConnectionString, BLL.DBConnections.ProviderName, DTab, Request);
            obj.GetDataTable(ConnectionString, BLL.DBConnections.ProviderName, DTab, Request, "");
            return DTab;
        }
        
    }
}
