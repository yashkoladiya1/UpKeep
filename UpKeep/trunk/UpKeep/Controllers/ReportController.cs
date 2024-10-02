using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using DLL.FunctionClasses;
using DLL.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using UpKeep.Utility;

namespace UpKeep.Controllers
{
    [SessionExpireFilterAttribute]
    [AuthorizeUserAttribute]
    public class ReportController : Controller
    {
        // GET: Report
        ClientDetail.Client_ServiceSoapClient clientDetail = new ClientDetail.Client_ServiceSoapClient();
        public ActionResult Report()
        {
            if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '16'").Count() > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Master");
            }
        }

        public ActionResult Estimate_Report()
        {
            if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '15'").Count() > 0)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Master");
            }
        }

        //public ActionResult Sales_Invoice_Summary()
        //{
        //    if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '15'").Count() > 0)
        //    {

        //        IList<SelectListItem> Payment_Type = new List<SelectListItem>();
        //        Payment_Type.Add(new SelectListItem { Text = "CREDIT", Value = "CREDIT" });
        //        Payment_Type.Add(new SelectListItem { Text = "DEBIT", Value = "DEBIT" });
        //        SelectList SelPayment_Type = new SelectList(Payment_Type, "Value", "Text", "CREDIT");
        //        ViewBag.Payment_Type = SelPayment_Type;

        //        List<Ledger_Master_Property> FormPartyNameList = new List<Ledger_Master_Property>();
        //        FormPartyNameList = (from DataRow dr in clientDetail.Ledger_GetData(Utility.SessionDetails.ClientSession.connectionString).Rows
        //                             select new Ledger_Master_Property()
        //                             {
        //                                 Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
        //                                 Ledger_Name = dr["Ledger_Name"].ToString()
        //                             }).ToList();
        //        ViewBag.Party_Name = new MultiSelectList(FormPartyNameList, "Ledger_Code", "Ledger_Name");

        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error", "Master");
        //    }
        //}

        //public ActionResult Estimate_Invoice_Summary()
        //{
        //    if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '18'").Count() > 0)
        //    {

        //        IList<SelectListItem> Payment_Type = new List<SelectListItem>();
        //        Payment_Type.Add(new SelectListItem { Text = "CREDIT", Value = "CREDIT" });
        //        Payment_Type.Add(new SelectListItem { Text = "DEBIT", Value = "DEBIT" });
        //        SelectList SelPayment_Type = new SelectList(Payment_Type, "Value", "Text", "CREDIT");
        //        ViewBag.Payment_Type = SelPayment_Type;

        //        List<Ledger_Master_Property> FormPartyNameList = new List<Ledger_Master_Property>();
        //        FormPartyNameList = (from DataRow dr in clientDetail.Ledger_GetData(Utility.SessionDetails.ClientSession.connectionString).Rows
        //                             select new Ledger_Master_Property()
        //                             {
        //                                 Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
        //                                 Ledger_Name = dr["Ledger_Name"].ToString()
        //                             }).ToList();
        //        ViewBag.Party_Name = new MultiSelectList(FormPartyNameList, "Ledger_Code", "Ledger_Name");

        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error", "Master");
        //    }
        //}

        //public ActionResult Sales_Invoice_Details()
        //{
        //    if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '14'").Count() > 0)
        //    {

        //        IList<SelectListItem> Payment_Type = new List<SelectListItem>();
        //        Payment_Type.Add(new SelectListItem { Text = "CREDIT", Value = "CREDIT" });
        //        Payment_Type.Add(new SelectListItem { Text = "DEBIT", Value = "DEBIT" });
        //        SelectList SelPayment_Type = new SelectList(Payment_Type, "Value", "Text", "CREDIT");
        //        ViewBag.Payment_Type = SelPayment_Type;

        //        List<Ledger_Master_Property> FormPartyNameList = new List<Ledger_Master_Property>();
        //        FormPartyNameList = (from DataRow dr in clientDetail.Ledger_GetData(Utility.SessionDetails.ClientSession.connectionString).Rows
        //                             select new Ledger_Master_Property()
        //                             {
        //                                 Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
        //                                 Ledger_Name = dr["Ledger_Name"].ToString()
        //                             }).ToList();
        //        ViewBag.Party_Name = new MultiSelectList(FormPartyNameList, "Ledger_Code", "Ledger_Name");

        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error", "Master");
        //    }
        //}

        //public ActionResult Estimate_Invoice_Details()
        //{
        //    if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '17'").Count() > 0)
        //    {
        //        DataTable dt_Rights = (DataTable)Session[""];
        //        if (dt_Rights.Rows.Count > 0)
        //        {
        //            if (dt_Rights.Select("ModuleID = 1 and View = 1").Count() > 0)
        //            {

        //            }
        //            else
        //            {

        //            }
        //        }
        //        IList<SelectListItem> Payment_Type = new List<SelectListItem>();
        //        Payment_Type.Add(new SelectListItem { Text = "CREDIT", Value = "CREDIT" });
        //        Payment_Type.Add(new SelectListItem { Text = "DEBIT", Value = "DEBIT" });
        //        SelectList SelPayment_Type = new SelectList(Payment_Type, "Value", "Text", "CREDIT");
        //        ViewBag.Payment_Type = SelPayment_Type;

        //        List<Ledger_Master_Property> FormPartyNameList = new List<Ledger_Master_Property>();
        //        FormPartyNameList = (from DataRow dr in clientDetail.Ledger_GetData(Utility.SessionDetails.ClientSession.connectionString).Rows
        //                             select new Ledger_Master_Property()
        //                             {
        //                                 Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
        //                                 Ledger_Name = dr["Ledger_Name"].ToString()
        //                             }).ToList();
        //        ViewBag.Party_Name = new MultiSelectList(FormPartyNameList, "Ledger_Code", "Ledger_Name");

        //        return View();

        //    }
        //    else
        //    {
        //        return RedirectToAction("Error", "Master");
        //    }
        //}

        //public ActionResult Purchase_Invoice_Summary()
        //{
        //    if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '21'").Count() > 0)
        //    {

        //        IList<SelectListItem> Payment_Type = new List<SelectListItem>();
        //        Payment_Type.Add(new SelectListItem { Text = "CREDIT", Value = "CREDIT" });
        //        Payment_Type.Add(new SelectListItem { Text = "DEBIT", Value = "DEBIT" });
        //        SelectList SelPayment_Type = new SelectList(Payment_Type, "Value", "Text", "CREDIT");
        //        ViewBag.Payment_Type = SelPayment_Type;

        //        List<Ledger_Master_Property> FormPartyNameList = new List<Ledger_Master_Property>();
        //        FormPartyNameList = (from DataRow dr in clientDetail.Ledger_GetData(Utility.SessionDetails.ClientSession.connectionString).Rows
        //                             select new Ledger_Master_Property()
        //                             {
        //                                 Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
        //                                 Ledger_Name = dr["Ledger_Name"].ToString()
        //                             }).ToList();
        //        ViewBag.Party_Name = new MultiSelectList(FormPartyNameList, "Ledger_Code", "Ledger_Name");

        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error", "Master");
        //    }
        //}

        //public ActionResult Purchase_Invoice_Details()
        //{
        //    if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '20'").Count() > 0)
        //    {

        //        IList<SelectListItem> Payment_Type = new List<SelectListItem>();
        //        Payment_Type.Add(new SelectListItem { Text = "CREDIT", Value = "CREDIT" });
        //        Payment_Type.Add(new SelectListItem { Text = "DEBIT", Value = "DEBIT" });
        //        SelectList SelPayment_Type = new SelectList(Payment_Type, "Value", "Text", "CREDIT");
        //        ViewBag.Payment_Type = SelPayment_Type;

        //        List<Ledger_Master_Property> FormPartyNameList = new List<Ledger_Master_Property>();
        //        FormPartyNameList = (from DataRow dr in clientDetail.Ledger_GetData(Utility.SessionDetails.ClientSession.connectionString).Rows
        //                             select new Ledger_Master_Property()
        //                             {
        //                                 Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
        //                                 Ledger_Name = dr["Ledger_Name"].ToString()
        //                             }).ToList();
        //        ViewBag.Party_Name = new MultiSelectList(FormPartyNameList, "Ledger_Code", "Ledger_Name");

        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error", "Master");
        //    }
        //}

        //public ActionResult Item_Stock()
        //{
        //    if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '22'").Count() > 0)
        //    {

        //        IList<SelectListItem> Payment_Type = new List<SelectListItem>();
        //        Payment_Type.Add(new SelectListItem { Text = "CREDIT", Value = "CREDIT" });
        //        Payment_Type.Add(new SelectListItem { Text = "DEBIT", Value = "DEBIT" });
        //        SelectList SelPayment_Type = new SelectList(Payment_Type, "Value", "Text", "CREDIT");
        //        ViewBag.Payment_Type = SelPayment_Type;

        //        List<Ledger_Master_Property> FormPartyNameList = new List<Ledger_Master_Property>();
        //        FormPartyNameList = (from DataRow dr in clientDetail.Ledger_GetData(Utility.SessionDetails.ClientSession.connectionString).Rows
        //                             select new Ledger_Master_Property()
        //                             {
        //                                 Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
        //                                 Ledger_Name = dr["Ledger_Name"].ToString()
        //                             }).ToList();
        //        ViewBag.Party_Name = new MultiSelectList(FormPartyNameList, "Ledger_Code", "Ledger_Name");

        //        return View();
        //    }
        //    else
        //    {
        //        return RedirectToAction("Error", "Master");
        //    }
        //}

        [HttpPost]
        public JsonResult Sales_ReportGet(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            try
            {
                string msg = "";

                DataTable DTab = clientDetail.Sales_ReportGet(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);
                System.Web.HttpContext.Current.Session["rptSource"] = DTab;
                System.Web.HttpContext.Current.Session["ReportName"] = "ShyamMotors\\Shyam_Sales.rpt";
                return Json(new
                {
                    success = true,
                    message = msg
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Sales getdata failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Estimate_ReportGet(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            try
            {
                string msg = "";

                DataTable DTab = clientDetail.Estimate_ReportGet(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);
                System.Web.HttpContext.Current.Session["rptSource"] = DTab;

                if (DTab.Rows[0]["CGST_AMT"].ToString() == "0" || DTab.Rows[0]["CGST_AMT"].ToString() == "0" || DTab.Rows[0]["CGST_AMT"].ToString() == "0")
                {
                    System.Web.HttpContext.Current.Session["ReportName"] = "ShyamMotors\\Shyam_Estimate.rpt";
                }
                else
                {
                    System.Web.HttpContext.Current.Session["ReportName"] = "ShyamMotors\\Shyam_Estimate_With_GST.rpt";
                }
                for (int i = DTab.Rows.Count; i < 20; i++)
                {
                    DTab.Rows.Add();
                }


                return Json(new
                {
                    success = true,
                    message = msg
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Sales getdata failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Purchase_ReportGet(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            try
            {
                string msg = "";

                //DataTable DTab = clientDetail.Purchase_ReportGet(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);
                //System.Web.HttpContext.Current.Session["rptSource"] = DTab;
                System.Web.HttpContext.Current.Session["ReportName"] = "ShyamMotors\\Shyam_Purchase.rpt";
                return Json(new
                {
                    success = true,
                    message = msg
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Purchase getdata failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult JobCard_ReportGet(string jobid)
        {
            try
            {
                string msg = "";

                DataTable DTab = clientDetail.JobCard_Master_CardRpt(Convert.ToInt64(jobid), Utility.SessionDetails.ClientSession.connectionString);
                System.Web.HttpContext.Current.Session["rptSource"] = DTab;
                System.Web.HttpContext.Current.Session["ReportName"] = "JobWork.rpt";
                return Json(new
                {
                    success = true,
                    message = msg
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Sales getdata failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public void ShowGenericRpt(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            try
            {
                bool isValid = true;

                string strReportName = System.Web.HttpContext.Current.Session["ReportName"].ToString();    // Setting ReportName 
                string strFromDate = System.Web.HttpContext.Current.Session["rptFromDate"].ToString();     // Setting FromDate  
                string strToDate = System.Web.HttpContext.Current.Session["rptToDate"].ToString();         // Setting ToDate     
                var rptSource = clientDetail.Sales_ReportGet(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);

                if (string.IsNullOrEmpty(strReportName))
                {
                    isValid = false;
                }

                if (isValid)
                {
                    ReportDocument rd = new ReportDocument();
                    string strRptPath = System.Web.HttpContext.Current.Server.MapPath("~/") + "Rpts//" + strReportName;
                    rd.Load(strRptPath);
                    if (rptSource != null && rptSource.GetType().ToString() != "System.String")
                        rd.SetDataSource(rptSource);
                    if (!string.IsNullOrEmpty(strFromDate))
                        rd.SetParameterValue("fromDate", strFromDate);
                    if (!string.IsNullOrEmpty(strToDate))
                        rd.SetParameterValue("toDate", strFromDate);
                    rd.ExportToHttpResponse(ExportFormatType.PortableDocFormat, System.Web.HttpContext.Current.Response, false, "crReport");


                    // Clear all sessions value 
                    Session["ReportName"] = null;
                    Session["rptFromDate"] = null;
                    Session["rptToDate"] = null;
                    Session["rptSource"] = null;
                }
                else
                {
                    Response.Write("<H2>Nothing Found; No Report name found</H2>");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.ToString());
            }
        }

        [HttpPost]
        public JsonResult GetSales_Summary_List(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            DataTable Unit_Master = clientDetail.GetSales_SummaryReport(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Unit_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetEstimate_Summary_List(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            DataTable Unit_Master = clientDetail.GetEstimate_SummaryReport(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Unit_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetSales_Details_List(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            DataTable Unit_Master = clientDetail.GetSales_DetailsReport(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Unit_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetEstimate_Details_List(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            DataTable Unit_Master = clientDetail.GetEstimate_DetailsReport(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Unit_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPurchase_Summary_List(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            DataTable Unit_Master = clientDetail.GetPurchase_SummaryReport(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Unit_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPurchase_Details_List(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            DataTable Unit_Master = clientDetail.GetPurchase_DetailsReport(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Unit_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetItem_Stock_List(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            DataTable Item_Stock = clientDetail.GetItem_Stock_Report(Sales_Master_Property, Utility.SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Item_Stock);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        #region Attendance Report
        public ActionResult Attendance_Report()
        {
            if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '24'").Count() > 0)
            {

                if (SessionDetails.UserSession.Category_ID == 1) //&& SessionDetails.UserSession.Category_Name == "admin")
                {
                    DataTable ds_Result = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
                    List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
                    for (int i = 0; i < ds_Result.Rows.Count; i++)
                    {
                        User_Login_Master_Property objUserLogin = new User_Login_Master_Property();
                        objUserLogin.Login_ID = Convert.ToInt64(ds_Result.Rows[i]["Login_ID"]);
                        objUserLogin.Emp_ID = Convert.ToInt32(ds_Result.Rows[i]["Emp_ID"]);
                        objUserLogin.UserID = ds_Result.Rows[i]["UserID"].ToString();
                        //SessionDetails.UserSession = objUserLogin;
                        UserList.Add(objUserLogin);
                    }
                    ViewBag.UserList = new MultiSelectList(UserList, "Emp_ID", "UserID");  //Login_ID
                }
                else
                {
                    DataTable ds_Result = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
                    List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
                    for (int i = 0; i < ds_Result.Rows.Count; i++)
                    {
                        User_Login_Master_Property objUserLogin = new User_Login_Master_Property();
                        //objUserLogin.Category_ID = Convert.ToInt64(ds_Result.Rows[i]["Category_ID"]);
                        objUserLogin.Login_ID = Convert.ToInt64(ds_Result.Rows[i]["Login_ID"]);
                        objUserLogin.Emp_ID = Convert.ToInt32(ds_Result.Rows[i]["Emp_ID"]);
                        objUserLogin.UserID = ds_Result.Rows[i]["UserID"].ToString();
                        if (SessionDetails.UserSession.Login_ID == objUserLogin.Login_ID)
                        {
                            UserList.Add(objUserLogin);
                        }
                        //UserList.Add(objUserLogin);
                    }
                    ViewBag.UserList = new MultiSelectList(UserList, "Emp_ID", "UserID");   //Login_ID
                }
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Master");
            }
        }

        //public JsonResult Get_Attendance_Report(int EmpID, string from_date, string to_date)
        //{
        //    Attendance_Report obj = new Attendance_Report();
        //    DataTable sqlDt = new DataTable();
        //    sqlDt = obj.Attendance_Report_GetData(SessionDetails.ClientSession.connectionString, EmpID, from_date, to_date);

        //    List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
        //    Dictionary<string, object> item;
        //    foreach (DataRow row in sqlDt.Rows)
        //    {
        //        item = new Dictionary<string, object>();
        //        foreach (DataColumn col in sqlDt.Columns)
        //        {
        //            item.Add(col.ColumnName, (row[col]));
        //        }
        //        lst.Add(item);
        //    }
        //    return Json(new
        //    {
        //        List = lst
        //    }, JsonRequestBehavior.AllowGet);
        //}

        #endregion

        #region Leave Report

        public ActionResult Leave_Report()
        {
            if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '25'").Count() > 0)
            {

                if (SessionDetails.UserSession.Category_ID == 1)
                {
                    DataTable ds_Result = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
                    List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
                    for (int i = 0; i < ds_Result.Rows.Count; i++)
                    {
                        User_Login_Master_Property objUserLogin = new User_Login_Master_Property();
                        objUserLogin.Login_ID = Convert.ToInt64(ds_Result.Rows[i]["Login_ID"]);
                        objUserLogin.Emp_ID = Convert.ToInt32(ds_Result.Rows[i]["Emp_ID"]);
                        objUserLogin.UserID = ds_Result.Rows[i]["UserID"].ToString();
                        UserList.Add(objUserLogin);
                    }
                    ViewBag.UserList = new MultiSelectList(UserList, "Emp_ID", "UserID");  //Login_ID
                }
                else
                {
                    DataTable ds_Result = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
                    List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
                    for (int i = 0; i < ds_Result.Rows.Count; i++)
                    {
                        User_Login_Master_Property objUserLogin = new User_Login_Master_Property();
                        objUserLogin.Login_ID = Convert.ToInt64(ds_Result.Rows[i]["Login_ID"]);
                        objUserLogin.Emp_ID = Convert.ToInt32(ds_Result.Rows[i]["Emp_ID"]);
                        objUserLogin.UserID = ds_Result.Rows[i]["UserID"].ToString();
                        if (SessionDetails.UserSession.Login_ID == objUserLogin.Login_ID)
                        {
                            UserList.Add(objUserLogin);
                        }
                    }
                    ViewBag.UserList = new MultiSelectList(UserList, "Emp_ID", "UserID");  //Login_ID
                }
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Master");
            }
        }

        //public JsonResult Get_Leave_Report(int User_Id, string from_date, string to_date)
        //{
        //    Employee_Leave_Master objLeave = new Employee_Leave_Master();
        //    DataTable sqlDt = new DataTable();
        //    sqlDt = objLeave.Employee_Leave_GetData_Report(SessionDetails.ClientSession.connectionString, User_Id, from_date, to_date);

        //    List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
        //    Dictionary<string, object> item;
        //    foreach (DataRow row in sqlDt.Rows)
        //    {
        //        item = new Dictionary<string, object>();
        //        foreach (DataColumn col in sqlDt.Columns)
        //        {
        //            item.Add(col.ColumnName, (row[col]));
        //        }
        //        lst.Add(item);
        //    }
        //    return Json(new
        //    {
        //        List = lst
        //    }, JsonRequestBehavior.AllowGet);
        //}


        #endregion

        #region Leave Report

        public ActionResult Task_Report()
        {
            if (SessionDetails.UserSession.Category_ID == 1)
            {
                DataTable ds_Result = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
                List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
                for (int i = 0; i < ds_Result.Rows.Count; i++)
                {
                    User_Login_Master_Property objUserLogin = new User_Login_Master_Property();
                    objUserLogin.Login_ID = Convert.ToInt64(ds_Result.Rows[i]["Login_ID"]);
                    //objUserLogin.Emp_ID = Convert.ToInt32(ds_Result.Rows[i]["Emp_ID"]);
                    objUserLogin.UserID = ds_Result.Rows[i]["UserID"].ToString();
                    UserList.Add(objUserLogin);
                }
                ViewBag.UserList = new MultiSelectList(UserList, "Login_ID", "UserID");  //Emp_ID
            }
            else
            {
                DataTable ds_Result = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
                List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
                for (int i = 0; i < ds_Result.Rows.Count; i++)
                {
                    User_Login_Master_Property objUserLogin = new User_Login_Master_Property();
                    objUserLogin.Login_ID = Convert.ToInt64(ds_Result.Rows[i]["Login_ID"]);
                    //objUserLogin.Emp_ID = Convert.ToInt32(ds_Result.Rows[i]["Emp_ID"]);
                    objUserLogin.UserID = ds_Result.Rows[i]["UserID"].ToString();
                    if (SessionDetails.UserSession.Login_ID == objUserLogin.Login_ID)
                    {
                        UserList.Add(objUserLogin);
                    }
                }
                ViewBag.UserList = new MultiSelectList(UserList, "Login_ID", "UserID");  //Emp_ID
            }
            return View();
        }

        public JsonResult Get_Task_Report(int Login_ID, string from_date, string to_date)
        {
            Task_Report objTask = new Task_Report();
            DataTable sqlDt = new DataTable();
            sqlDt = objTask.Task_GetData_Report(SessionDetails.ClientSession.connectionString, Login_ID, from_date, to_date);

            List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
            Dictionary<string, object> item;
            foreach (DataRow row in sqlDt.Rows)
            {
                item = new Dictionary<string, object>();
                foreach (DataColumn col in sqlDt.Columns)
                {
                    item.Add(col.ColumnName, (row[col]));
                }
                lst.Add(item);
            }
            return Json(new
            {
                List = lst
            }, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult Get_Task_Report(string from_date, string to_date)
        //{
        //    DataTable sqlDt = clientDetail.TaskTransaction_GetData_ByUser(SessionDetails.ClientSession.connectionString,from_date, to_date, Convert.ToInt64(SessionDetails.UserSession.Login_ID));

        //    List<Dictionary<string, object>> lst = new List<Dictionary<string, object>>();
        //    Dictionary<string, object> item;
        //    foreach (DataRow row in sqlDt.Rows)
        //    {
        //        item = new Dictionary<string, object>();
        //        foreach (DataColumn col in sqlDt.Columns)
        //        {
        //            item.Add(col.ColumnName, (row[col]));
        //        }
        //        lst.Add(item);
        //    }
        //    return Json(new
        //    {
        //        List = lst
        //    }, JsonRequestBehavior.AllowGet);
        //}

        #endregion

    }
}