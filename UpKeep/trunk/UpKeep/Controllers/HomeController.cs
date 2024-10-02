using DLL.FunctionClasses;
using DLL.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpKeep.Models;
using UpKeep.Models.MainMaster;
using UpKeep.Utility;

namespace UpKeep.Controllers
{

    public class HomeController : Controller
    {
        ClientMaster.Master_ServiceSoapClient clientMas = new ClientMaster.Master_ServiceSoapClient();
        ClientDetail.Client_ServiceSoapClient clientDetail = new ClientDetail.Client_ServiceSoapClient();
        public ActionResult Login()
        {
            var urlBuilder = new System.UriBuilder(Request.Url.AbsoluteUri)
            {
                Path = Url.Action("Action", "Controller"),
                Query = null,
            };
            string host = urlBuilder.Host;
            if (host.Contains("useupkeep") == false)
            {
                if (host.Contains("localhost") == false)
                {
                    if (host.Contains("www") == false)
                    {
                        host = "www." + host;
                    }
                }
            }
            else if (host.Contains("useupkeep") == true)
            {
                if (host.Contains("tech") == true)
                {
                    host = "tech.useupkeep.com";
                }
            }
            else if (host.Contains("shyammotors") == true)
            {
                host = "www.shyammotors.com";
            }
            //host = "192.168.1.7";

            DataTable dt = clientMas.getClientConnectionString(host);
            if (dt.Rows.Count > 0)
            {
                Client objClient = new Models.MainMaster.Client();
                objClient.ID = Convert.ToInt32(dt.Rows[0]["Client_ID"].ToString());
                //objClient.Login_ID = Convert.ToInt32(dt.Rows[0]["Login_ID"].ToString());
                objClient.UserName = dt.Rows[0]["UserName"].ToString();
                objClient.Password = dt.Rows[0]["Password"].ToString();
                objClient.ServerIP = dt.Rows[0]["Database_ServerIP"].ToString();
                objClient.DataBaseName = dt.Rows[0]["Database_Name"].ToString();
                //objClient.connectionString = "Data Source=" + objClient.ServerIP + ";Initial Catalog=" + objClient.DataBaseName + ";Integrated Security=True";
                objClient.connectionString = "Data Source=" + objClient.ServerIP + ";Initial Catalog=" + objClient.DataBaseName + ";User ID=" + objClient.UserName + ";Password=" + objClient.Password;
                objClient.Logo_Path = dt.Rows[0]["Logo_Path"].ToString();
                objClient.City_ID = Convert.ToInt32(dt.Rows[0]["City_ID"].ToString());
                objClient.State_ID = Convert.ToInt32(dt.Rows[0]["State_ID"].ToString());
                objClient.Country_ID = Convert.ToInt32(dt.Rows[0]["Country_ID"].ToString());
                objClient.Client_Name = dt.Rows[0]["Client_Name"].ToString();
                SessionDetails.ClientSession = objClient;
                ViewBag.Logo_Path = objClient.Logo_Path;
                ViewBag.Title = objClient.Client_Name;
                Session["Logo_Path"] = objClient.Logo_Path;
            }
            else
            {
                ViewBag.Logo_Path = "";
                ViewBag.Title = "UseUpkeep";
                //ModelState.AddModelError("", "Login Failed..!!");
            }
            return View();
        }
        [SessionExpireFilterAttribute]
        [AuthorizeUserAttribute]

        public ActionResult DashBoard()
        {
                //List<Company_Master_Property> CompanyList = new List<Company_Master_Property>();
                //DataTable dtCompanyMaster = clientDetail.Company_Master_GetData(SessionDetails.ClientSession.connectionString);
                //CompanyList = (from DataRow dr in dtCompanyMaster.Rows
                //               select new Company_Master_Property()
                //               {
                //                   Company_code = Convert.ToInt32(dr["Company_Code"]),
                //                   Company_name = dr["Company_name"].ToString()
                //               }).ToList();

                //ViewBag.Company = new MultiSelectList(CompanyList, "Company_Code", "Company_name");

                List<Work_Status_Master_Property> StatusList = new List<Work_Status_Master_Property>();
                StatusList.Add(new Work_Status_Master_Property { Status_Name = "Select Status", Status_ID = 0 });
                DataTable dtStatusMaster = clientDetail.WorkStatus_Master_GetData(SessionDetails.ClientSession.connectionString);
                StatusList = (from DataRow dr in dtStatusMaster.Rows
                              select new Work_Status_Master_Property()
                              {
                                  Status_ID = Convert.ToInt32(dr["Status_ID"]),
                                  Status_Name = dr["Status_Name"].ToString()
                              }).ToList();

                ViewBag.StatusList = new SelectList(StatusList, "Status_ID", "Status_Name");
                return View();
        }

        [SessionExpireFilterAttribute]
        [AuthorizeUserAttribute]
        public ActionResult AdminDashBoard()
        {
            List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
            DataTable dtUser = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
            UserList = (from DataRow dr in dtUser.Rows
                        select new User_Login_Master_Property()
                        {
                            Login_ID = Convert.ToInt32(dr["Login_ID"]),
                            UserName = dr["UserName"].ToString()
                        }).ToList();

            ViewBag.User = new SelectList(UserList, "Login_ID", "UserName");
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        [HttpPost]
        public JsonResult CheckLogin(string UserName, string Password, bool IsRemind)
        {
            try
            {
                DataTable ds_Result = clientDetail.UserLogin_Login(UserName, Password, SessionDetails.ClientSession.connectionString);
                if (ds_Result.Rows.Count > 0)
                {
                    User_Login_Master_Property objUserLogin = new User_Login_Master_Property();
                    objUserLogin.Login_ID = Convert.ToInt64(ds_Result.Rows[0]["Login_ID"].ToString());
                    objUserLogin.Client_ID = Convert.ToInt64(ds_Result.Rows[0]["Client_ID"].ToString());
                    objUserLogin.UserName = ds_Result.Rows[0]["UserName"].ToString();
                    objUserLogin.EmailID = ds_Result.Rows[0]["EmailID"].ToString();
                    objUserLogin.Mac_ID = ds_Result.Rows[0]["Mac_ID"].ToString();
                    objUserLogin.Tokan = ds_Result.Rows[0]["Tokan"].ToString();
                    objUserLogin.Mobile = Convert.ToInt64(ds_Result.Rows[0]["Mobile"].ToString());
                    objUserLogin.Category_ID = Convert.ToInt64(ds_Result.Rows[0]["Category_ID"].ToString());
                    objUserLogin.User_Image = ds_Result.Rows[0]["User_Image"].ToString();

                    Session["Login_ID"] = Convert.ToString(ds_Result.Rows[0]["Login_ID"]);

                    SessionDetails.UserSession = objUserLogin;

                    Rights_get();

                    if (ds_Result.Rows.Count > 0)
                    {
                        return Json(new
                        {
                            success = true,
                            message = "Login done successfully",
                            redirect_controller = "Home",
                            redirect_action = "DashBoard"
                            //redirect_controller = dt_Employee.Rows[0]["Controller"].ToString(),
                            //redirect_action = dt_Employee.Rows[0]["Action"].ToString()
                        }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new
                        {
                            success = false,
                            message = "Username or Password is invalid"
                        }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new
                    {
                        success = false,
                        message = "Username or Password is invalid"
                    }, JsonRequestBehavior.AllowGet);
                }
                //    SessionFacade.IsPersistent = IsRemind;

                //    DataTable dt_Employee = ds_Result.Tables[0];
                //    DataTable dt_FormPermission = ds_Result.Tables[1];

                //    DataTable dt_Settings = home_repository.GetData_Single_User_General_Preferences_Settings(Convert.ToInt32(dt_Employee.Rows[0]["EMPLOYEE_CODE"]));

                //    Employee_Master employee_master = new Employee_Master();
                //    employee_master.ID = Convert.ToInt32(dt_Employee.Rows[0]["EMPLOYEE_CODE"]);
                //    employee_master.UserName = Convert.ToString(dt_Employee.Rows[0]["USERNAME"]);
                //    employee_master.FirstName = Convert.ToString(dt_Employee.Rows[0]["EMPLOYEE_FNAME"]);
                //    employee_master.MiddleName = Convert.ToString(dt_Employee.Rows[0]["EMPLOYEE_MNAME"]);
                //    employee_master.LastName = Convert.ToString(dt_Employee.Rows[0]["EMPLOYEE_SURNAME"]);

                //    employee_master.Company_Code = Convert.ToInt32(dt_Employee.Rows[0]["COMPANY_CODE"]);
                //    employee_master.Company_Name = Convert.ToString(dt_Employee.Rows[0]["COMPANY_NAME"]);
                //    employee_master.Branch_Code = Convert.ToInt32(dt_Employee.Rows[0]["BRANCH_CODE"]);
                //    employee_master.Branch_ShortName = Convert.ToString(dt_Employee.Rows[0]["BRANCH_SHORTNAME"]);
                //    employee_master.Branch_Name = Convert.ToString(dt_Employee.Rows[0]["BRANCH_NAME"]);
                //    employee_master.Location_Code = Convert.ToInt32(dt_Employee.Rows[0]["LOCATION_CODE"]);
                //    employee_master.Location_ShortName = Convert.ToString(dt_Employee.Rows[0]["LOCATION_SHORT_NAME"]);
                //    employee_master.Location_Name = Convert.ToString(dt_Employee.Rows[0]["LOCATION_NAME"]);
                //    employee_master.Department_Code = Convert.ToInt32(dt_Employee.Rows[0]["DEPARTMENT_CODE"]);
                //    employee_master.Department_Name = Convert.ToString(dt_Employee.Rows[0]["DEPARTMENT_NAME"]);

                //    if (Convert.ToString(dt_Employee.Rows[0]["DOB"]) != "")
                //    {
                //        employee_master.DOB = Convert.ToDateTime(dt_Employee.Rows[0]["DOB"]);
                //    }
                //    if (dt_Settings.Rows.Count > 0)
                //    {
                //        if (dt_Settings.Rows[0]["SHOW_ORDER_QTY_AND_DIFF"].ToString() == "")
                //        {
                //            employee_master.SHOW_ORDER_QTY_AND_DIFF = 0;
                //        }
                //        else
                //        {
                //            employee_master.SHOW_ORDER_QTY_AND_DIFF = Convert.ToInt32(dt_Settings.Rows[0]["SHOW_ORDER_QTY_AND_DIFF"].ToString());
                //        }
                //    }
                //    employee_master.RoleId = Convert.ToInt32(dt_Employee.Rows[0]["ROLEID"]);
                //    employee_master.Email = Convert.ToString(dt_Employee.Rows[0]["EMAIL"]);

                //    SessionFacade.UserSession = employee_master;

                //    List<Form_Permission> form_permission_list = new List<Form_Permission>();

                //    foreach (DataRow dr in dt_FormPermission.Rows)
                //    {
                //        Form_Permission form_permission = new Form_Permission();

                //        form_permission.Controller = Convert.ToString(dr["Controller"]);
                //        form_permission.Action = Convert.ToString(dr["Action"]);
                //        form_permission.IsView = Convert.ToBoolean(dr["IsView"]);
                //        form_permission.IsInsert = Convert.ToBoolean(dr["IsInsert"]);
                //        form_permission.IsUpdate = Convert.ToBoolean(dr["IsUpdate"]);
                //        form_permission.IsDelete = Convert.ToBoolean(dr["IsDelete"]);
                //        form_permission.IsEmail = Convert.ToBoolean(dr["IsEmail"]);
                //        form_permission.IsPrint = Convert.ToBoolean(dr["IsPrint"]);

                //        form_permission_list.Add(form_permission);
                //    }

                //    Trident.Repository.Service.global_Trident._IPAddress = GetIPAddress();
                //    SessionFacade.MACAddr = Trident.Repository.Service.global_Trident.GetMACAddress();
                //    SessionFacade.FormPermissionList = form_permission_list;
                //    AdminMenuManager admin_menu_manager = new AdminMenuManager();
                //    SessionFacade.MenuList = admin_menu_manager.GetSitemMenuItems(Convert.ToInt32(employee_master.RoleId));

                //    home_repository.Insert_Login_History(UserName, Request.UserHostAddress.ToString());//Request.UserHostAddress.ToString()

                //    if (IsRemind)
                //    {
                //        //HttpCookie cookie = new HttpCookie(“YourAppLogin”);
                //        //cookie.Values.Add(“username”, txtUsername.Text);
                //        //cookie.Expires = DateTime.Now.AddDays(15);
                //        //Response.Cookies.Add(cookie);
                //    }


                //}
                //else
                //{
                //    return Json(new
                //    {
                //        success = false,
                //        message = "Username or Password is invalid"
                //    }, JsonRequestBehavior.AllowGet);
                //}

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Login failed"//, Error:-" + ex.Message
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public DataTable Rights_get()
            {
            UpKeep.ClientDetail.User_Login_Master_Property objUser_Login_Master_Property = new UpKeep.ClientDetail.User_Login_Master_Property();
            objUser_Login_Master_Property.Login_ID = Convert.ToInt32(SessionDetails.UserSession.Login_ID);

            DataTable dt = clientDetail.Get_user_Rights(objUser_Login_Master_Property, SessionDetails.ClientSession.connectionString);
            //DataSet ds_Result = new DataSet();
            //DataTable dt = objLogin.Get_user_Rights(Convert.ToInt32(objUser_Login_Master_Property));

            //foreach (DataRow row in dt.Rows)
            //{
            //    Session["ModuleID"] = Convert.ToString(dt.Rows[0]["ModuleID"]);
            //}

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Session["Module_ID"] = Convert.ToString(dt.Rows[i]["Module_ID"]);
                Session["Login_ID"] = Convert.ToString(dt.Rows[i]["Login_ID"]);
            }
            Session["ModuleTable"] = dt;
            Session["LoginTable"] = dt;
            return dt;
        }

        [SessionExpireFilterAttribute]
        [AuthorizeUserAttribute]
        [HttpPost]
        public JsonResult GetWork_Status_List()
        {
            DataTable TaskList = clientDetail.TaskTransaction_User_GetData(Convert.ToInt32(SessionDetails.UserSession.Login_ID), SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(TaskList);
            int totalRecords = List.Count;
            Session["total_Records"] = Convert.ToString(totalRecords);
            return Json(new
            {
                List,
                totalRecords
            }, JsonRequestBehavior.AllowGet);
        }

        [SessionExpireFilterAttribute]
        [AuthorizeUserAttribute]
        [HttpPost]
        public JsonResult GetProjectTaskCount()
        {
            DataTable TaskList = clientDetail.GetProjectTaskCount(SessionDetails.ClientSession.connectionString);

            //List<TaskCount> TaskCountList = new List<TaskCount>();
            //var TaskModuleList = (from DataRow dr in TaskList.Rows
            //                   select new TaskCount()
            //                   {
            //                       ModuleName = dr["Module_Name"].ToString()
            //                   }).ToList();

            //var TaskTotalTaskList = (from DataRow dr in TaskList.Rows
            //                      select new TaskCount()
            //                      {
            //                          TotalTask = dr["TotalTask"].ToString()
            //                      }).ToList();

            //var TaskCompletedTaskList = (from DataRow dr in TaskList.Rows
            //                      select new TaskCount()
            //                      {
            //                          CompletedTask = dr["CompletedTask"].ToString()
            //}).ToList();
            string TaskModuleList = string.Empty;
            string TaskTotalTaskList = string.Empty;
            string TaskCompletedTaskList = string.Empty;
            if (TaskList.Rows.Count > 0)
            {
                for (int i = 0; i < TaskList.Rows.Count; i++)
                {
                    TaskModuleList = TaskModuleList + TaskList.Rows[i]["Module_Name"].ToString() + ",";
                    TaskTotalTaskList = TaskTotalTaskList + TaskList.Rows[i]["TotalTask"].ToString() + ",";
                    TaskCompletedTaskList = TaskCompletedTaskList + TaskList.Rows[i]["CompletedTask"].ToString() + ",";
                }
            }
            if (TaskModuleList.Length > 0)
            {
                TaskModuleList = TaskModuleList.Substring(0, TaskModuleList.Length - 1);
                TaskTotalTaskList = TaskTotalTaskList.Substring(0, TaskTotalTaskList.Length - 1);
                TaskCompletedTaskList = TaskCompletedTaskList.Substring(0, TaskCompletedTaskList.Length - 1);
            }
            List<object> iData = new List<object>();
            //ViewBag.ModuleList = string.Join(",", TaskModuleList[0]);
            //ViewBag.TotalTaskList = string.Join(",", TaskTotalTaskList);
            //ViewBag.CompletedTaskList = string.Join(",", TaskCompletedTaskList);

            foreach (DataColumn dc in TaskList.Columns)
            {
                List<object> x = new List<object>();
                x = (from DataRow drr in TaskList.Rows select drr[dc.ColumnName]).ToList();
                iData.Add(x);
            }
            ViewBag.ChartData = iData;
            //Source data returned as JSON    
            return Json(iData, JsonRequestBehavior.AllowGet);

            //DataTableToList DataTableToList = new DataTableToList();
            //var List = DataTableToList.ToDynamicList(TaskList);
            //int totalRecords = List.Count;

            //return Json(new
            //{
            //    success = true,
            //    ModuleList = TaskModuleList,
            //    TotalTask = TaskTotalTaskList,
            //    CompletedTask = TaskCompletedTaskList,
            //    message = "Updated successfully"
            //}, JsonRequestBehavior.AllowGet);
            //return Json(new
            //{
            //    List
            //}, JsonRequestBehavior.AllowGet);
        }

        //
        [SessionExpireFilterAttribute]
        [AuthorizeUserAttribute]
        [HttpPost]
        public JsonResult GetUserWorkingHours()
        {
            DataTable TaskList = clientDetail.GetUserWorkingHours(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(TaskList);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }
        //GetUserWorkingHours

        //GetAllWork_Status_List
        [SessionExpireFilterAttribute]
        [AuthorizeUserAttribute]
        [HttpPost]
        public JsonResult GetAllWork_Status_List()
        {
            DataTable TaskList = clientDetail.TaskTransaction_AllUser_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(TaskList);
            int totalRecords = List.Count;
            List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
            DataTable dtUser = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
            UserList = (from DataRow dr in dtUser.Rows
                        select new User_Login_Master_Property()
                        {
                            Login_ID = Convert.ToInt32(dr["Login_ID"]),
                            UserName = dr["UserName"].ToString()
                        }).ToList();
            return Json(new
            {
                List,
                UserList
            }, JsonRequestBehavior.AllowGet);
        }
        [SessionExpireFilterAttribute]
        [AuthorizeUserAttribute]
        [HttpPost]
        public JsonResult GetUserTaskAssignedHours()
        {
            DataTable TaskList = clientDetail.GetUserTaskAssignedHours(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(TaskList);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }
        [SessionExpireFilterAttribute]
        [AuthorizeUserAttribute]
        [HttpPost]
        public JsonResult UpdateFlag(UpKeep.ClientDetail.Task_Transaction_Property Task_Transaction_Property)
        {
            try
            {
                clientDetail.TaskTransaction_User_Update(Task_Transaction_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "Updated successfully"
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Updation failed!" + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [SessionExpireFilterAttribute]
        [AuthorizeUserAttribute]
        [HttpPost]
        public JsonResult UpdateTestFlag(UpKeep.ClientDetail.Task_Transaction_Property Task_Transaction_Property)
        {
            try
            {
                clientDetail.TaskTransaction_UserTested_Update(Task_Transaction_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "Updated successfully"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Updation failed!" + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Updateuser(string TaskID, string LoginID)
        {
            try
            {
                clientDetail.TaskTransaction_Username_Update(TaskID, LoginID, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "Updated successfully"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Updation failed!" + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [SessionExpireFilterAttribute]
        [AuthorizeUserAttribute]
        [HttpPost]
        public JsonResult UpdateStartStop(UpKeep.ClientDetail.Task_Transaction_Property Task_Transaction_Property)
        {
            try
            {
                clientDetail.TaskTransaction_User_UpdateStartStop(Task_Transaction_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "Updated successfully"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Updation failed!" + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DownloadFileDashboard(string filepath)
        {
            var fullName = System.IO.Path.Combine(Server.MapPath("~") , filepath);
            //string fullName = Server.MapPath(directoryFullPathInput).Replace("E:\\Abhi\\UpKeep\\trunk\\UpKeep\\", "");
            //string fullName = Server.MapPath(directoryFullPathInput).Replace("E:","").Replace(@"\" , "").Replace("Abhi" , "").Replace("UpKeep" , "").Replace("trunk" , "").Replace("uploads" , "");
            byte[] fileBytes = GetFile(fullName);
            return File(
                fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, filepath);
        }
        
        byte[] GetFile(string s)
        {
            System.IO.FileStream fs = System.IO.File.OpenRead(s);
            byte[] data = new byte[fs.Length];
            int br = fs.Read(data, 0, data.Length);
            if (br != fs.Length)
                throw new System.IO.IOException(s);
            return data;
        }
        public JsonResult GetDataUser()
        {
            List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
            DataTable dtUser = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
            UserList = (from DataRow dr in dtUser.Rows
                        select new User_Login_Master_Property()
                        {
                            Login_ID = Convert.ToInt32(dr["Login_ID"]),
                            UserName = dr["UserName"].ToString()
                        }).ToList();
            ViewBag.User = new MultiSelectList(UserList, "Login_ID", "UserName");

            return Json(new
            {
                success = true,
            }, JsonRequestBehavior.AllowGet);
        }

        public bool RightsFromModule(int ModuleID, string actionName)
        {
            if (Session["Login_ID"] != null)
            {
                UpKeep.ClientDetail.User_Login_Master_Property objUser_Login_Master_Property = new UpKeep.ClientDetail.User_Login_Master_Property();
                objUser_Login_Master_Property.Login_ID = Convert.ToInt32(SessionDetails.UserSession.Login_ID);

                //string actionName = actionName;// this.ControllerContext.RouteData.Values["action"].ToString();
                //string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

                //int ModuleID = clientDetail.PRC_Get_Module_Id_By_Name(actionName)).Rows[0][0]);
                //DataTable dtModule = new DataTable();
                DataTable dtModule = (DataTable)Session[""]; //clientDetail.PRC_Get_Mst_User_Rights_With_Module();

                string view = "";
                string insert = "";
                string update = "";
                string delete = "";
                if (dtModule.Rows.Count > 0)
                {
                    view = dtModule.Rows[0]["view_s"].ToString();
                    insert = dtModule.Rows[0]["insert_s"].ToString();
                    update = dtModule.Rows[0]["update_s"].ToString();
                    delete = dtModule.Rows[0]["delete_s"].ToString();
                }
                if (view == "1")
                {
                    ViewBag.view = view;
                    ViewBag.insert = insert;
                    ViewBag.update = update;
                    ViewBag.delete = delete;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public string SetSession(string sessionval)
        {
            Session["ActiveMenu"] = sessionval;
            return sessionval;
        }
    }
}
