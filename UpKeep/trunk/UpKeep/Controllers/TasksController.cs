using DLL.FunctionClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpKeep.Utility;

namespace UpKeep.Controllers
{
    [SessionExpireFilterAttribute]
    [AuthorizeUserAttribute]
    public class TasksController : Controller
    {
        ClientDetail.Client_ServiceSoapClient clientDetail = new ClientDetail.Client_ServiceSoapClient();
        // GET: Tasks
        public ActionResult AssignTasks(string Task_ID)
        {
            if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '6'").Count() > 0)
            {

                if (Task_ID == "0" || Task_ID == null)
                {
                    List<Module_Master> ModuleList = new List<Module_Master>();
                    ModuleList = (from DataRow dr in clientDetail.ModuleMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
                                  select new Module_Master()
                                  {
                                      Module_Id = Convert.ToInt32(dr["Module_ID"]),
                                      Module_Name = dr["Module_Name"].ToString()
                                  }).ToList();

                    ViewBag.ModuleList = new MultiSelectList(ModuleList, "Module_ID", "Module_Name");

                    List<Assessment_Master> AssessmentList = new List<Assessment_Master>();
                    AssessmentList = (from DataRow dr in clientDetail.Assesment_GetData(SessionDetails.ClientSession.connectionString).Rows
                                      select new Assessment_Master()
                                      {
                                          Assessment_ID = Convert.ToInt32(dr["Assessment_ID"]),
                                          Assessment_Name = dr["Assessment_Name"].ToString()
                                      }).ToList();

                    ViewBag.AssessmentList = new MultiSelectList(AssessmentList, "Assessment_ID", "Assessment_Name");

                    List<Sub_Assessment_Master_Property> Sub_AssessmentList = new List<Sub_Assessment_Master_Property>();
                    Sub_AssessmentList = (from DataRow dr in clientDetail.SubAssesment_GetData(SessionDetails.ClientSession.connectionString).Rows
                                          select new Sub_Assessment_Master_Property()
                                          {
                                              Sub_Assessment_ID = Convert.ToInt32(dr["Sub_Assessment_ID"]),
                                              Sub_Assessment_Name = dr["Sub_Assessment_Name"].ToString()
                                          }).ToList();

                    ViewBag.SubAssessmentList = new MultiSelectList(Sub_AssessmentList, "Sub_Assessment_ID", "Sub_Assessment_Name");

                    List<Location_Master> LocationList = new List<Location_Master>();
                    LocationList = (from DataRow dr in clientDetail.Location_GetData(SessionDetails.ClientSession.connectionString).Rows
                                    select new Location_Master()
                                    {
                                        Location_ID = Convert.ToInt32(dr["Location_ID"]),
                                        Location_Name = dr["Location_Name"].ToString()
                                    }).ToList();

                    ViewBag.LocationList = new MultiSelectList(LocationList, "Location_ID", "Location_Name");

                    List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
                    UserList = (from DataRow dr in clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString).Rows
                                select new User_Login_Master_Property()
                                {
                                    Login_ID = Convert.ToInt32(dr["Login_ID"]),
                                    UserName = dr["UserName"].ToString()
                                }).ToList();

                    ViewBag.UserList = new MultiSelectList(UserList, "Login_ID", "UserName");

                    List<Frequency_Master_Property> FrequencyList = new List<Frequency_Master_Property>();
                    FrequencyList = (from DataRow dr in clientDetail.Frequency_GetData(SessionDetails.ClientSession.connectionString).Rows
                                     select new Frequency_Master_Property()
                                     {
                                         Frequency_ID = Convert.ToInt32(dr["Frequency_ID"]),
                                         Frequency_Name = dr["Frequency_Name"].ToString()
                                     }).ToList();

                    ViewBag.FrequencyList = new MultiSelectList(FrequencyList, "Frequency_ID", "Frequency_Name");

                    List<Priority_Master_Property> PriorityList = new List<Priority_Master_Property>();
                    PriorityList = (from DataRow dr in clientDetail.PriorityMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
                                    select new Priority_Master_Property()
                                    {
                                        Priority_ID = Convert.ToInt32(dr["Priority_ID"]),
                                        Priority_Name = dr["Priority_Name"].ToString()
                                    }).ToList();

                    ViewBag.PriorityList = new MultiSelectList(PriorityList, "Priority_ID", "Priority_Name");

                }
                else
                {
                    List<Module_Master> ModuleList = new List<Module_Master>();
                    ModuleList = (from DataRow dr in clientDetail.ModuleMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
                                  select new Module_Master()
                                  {
                                      Module_Id = Convert.ToInt32(dr["Module_ID"]),
                                      Module_Name = dr["Module_Name"].ToString()
                                  }).ToList();

                    ViewBag.ModuleList = new MultiSelectList(ModuleList, "Module_ID", "Module_Name");

                    List<Assessment_Master> AssessmentList = new List<Assessment_Master>();
                    AssessmentList = (from DataRow dr in clientDetail.Assesment_GetData(SessionDetails.ClientSession.connectionString).Rows
                                      select new Assessment_Master()
                                      {
                                          Assessment_ID = Convert.ToInt32(dr["Assessment_ID"]),
                                          Assessment_Name = dr["Assessment_Name"].ToString()
                                      }).ToList();

                    ViewBag.AssessmentList = new MultiSelectList(AssessmentList, "Assessment_ID", "Assessment_Name");

                    List<Sub_Assessment_Master_Property> Sub_AssessmentList = new List<Sub_Assessment_Master_Property>();
                    Sub_AssessmentList = (from DataRow dr in clientDetail.SubAssesment_GetData(SessionDetails.ClientSession.connectionString).Rows
                                          select new Sub_Assessment_Master_Property()
                                          {
                                              Sub_Assessment_ID = Convert.ToInt32(dr["Sub_Assessment_ID"]),
                                              Sub_Assessment_Name = dr["Sub_Assessment_Name"].ToString()
                                          }).ToList();

                    ViewBag.SubAssessmentList = new MultiSelectList(Sub_AssessmentList, "Sub_Assessment_ID", "Sub_Assessment_Name");

                    List<Location_Master> LocationList = new List<Location_Master>();
                    LocationList = (from DataRow dr in clientDetail.Location_GetData(SessionDetails.ClientSession.connectionString).Rows
                                    select new Location_Master()
                                    {
                                        Location_ID = Convert.ToInt32(dr["Location_ID"]),
                                        Location_Name = dr["Location_Name"].ToString()
                                    }).ToList();

                    ViewBag.LocationList = new MultiSelectList(LocationList, "Location_ID", "Location_Name");

                    //List<Assessment_Master> AssessmentDropList = new List<Assessment_Master>();
                    //AssessmentDropList = (from DataRow dr in clientDetail.Assessment_GetData(SessionDetails.ClientSession.connectionString).Rows
                    //                select new Location_Master()
                    //                {
                    //                    Location_ID = Convert.ToInt32(dr["Assessment_ID"]),
                    //                    Location_Name = dr["Assessment_Name"].ToString()
                    //                }).ToList();

                    //ViewBag.AssessmentDropList = new MultiSelectList(AssessmentDropList, "Assessment_ID", "Assessment_Name");

                    List<User_Login_Master_Property> UserList = new List<User_Login_Master_Property>();
                    UserList = (from DataRow dr in clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString).Rows
                                select new User_Login_Master_Property()
                                {
                                    Login_ID = Convert.ToInt32(dr["Login_ID"]),
                                    UserName = dr["UserName"].ToString()
                                }).ToList();

                    ViewBag.UserList = new MultiSelectList(UserList, "Login_ID", "UserName");

                    List<Frequency_Master_Property> FrequencyList = new List<Frequency_Master_Property>();
                    FrequencyList = (from DataRow dr in clientDetail.Frequency_GetData(SessionDetails.ClientSession.connectionString).Rows
                                     select new Frequency_Master_Property()
                                     {
                                         Frequency_ID = Convert.ToInt32(dr["Frequency_ID"]),
                                         Frequency_Name = dr["Frequency_Name"].ToString()
                                     }).ToList();

                    ViewBag.FrequencyList = new MultiSelectList(FrequencyList, "Frequency_ID", "Frequency_Name");

                    List<Priority_Master_Property> PriorityList = new List<Priority_Master_Property>();
                    PriorityList = (from DataRow dr in clientDetail.PriorityMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
                                    select new Priority_Master_Property()
                                    {
                                        Priority_ID = Convert.ToInt32(dr["Priority_ID"]),
                                        Priority_Name = dr["Priority_Name"].ToString()
                                    }).ToList();

                    ViewBag.PriorityList = new MultiSelectList(PriorityList, "Priority_ID", "Priority_Name");

                    DataTable dt_Task = clientDetail.Task_GetDataByid(Task_ID, SessionDetails.ClientSession.connectionString);

                    for (int i = 0; i < dt_Task.Rows.Count; i++)
                    {
                        ViewBag.Task_ID = Convert.ToInt32(dt_Task.Rows[i]["Task_ID"]);
                        ViewBag.Module_ID = Convert.ToInt32(dt_Task.Rows[i]["Module_ID"]);
                        ViewBag.Assessment_ID = Convert.ToInt32(dt_Task.Rows[i]["Assessment_ID"]);
                        ViewBag.Location_ID = Convert.ToInt32(dt_Task.Rows[i]["Location_ID"]);
                        ViewBag.Sub_Assessment_ID = Convert.ToInt32(dt_Task.Rows[i]["Sub_Assessment_ID"]);
                    }
                }
                return View();
            }
            else
            {
                return RedirectToAction("Error", "Master");
            }
        }

        [HttpPost]
        public JsonResult DeleteTask(UpKeep.ClientDetail.Task_Master_Property TaskMasterProperty)
        {
            try
            {
                string msg = "";

                clientDetail.Assign_Task_Delete(TaskMasterProperty, SessionDetails.ClientSession.connectionString);
                msg = "Task Delete successfully";

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
                    message = "Item saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetTask_List()
        {
            DataTable dt_Task = clientDetail.Task_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(dt_Task);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Task_SaveForm(UpKeep.ClientDetail.Task_Master_Property Task_Master_Property)
        {
            try
            {
                DateTime FD = (DateTime)Task_Master_Property.Start_Time;
                DateTime FD1 = (DateTime)Task_Master_Property.Start_Date;
                DateTime FromDate = new DateTime(FD1.Year, FD1.Month, FD1.Day, FD.Hour, FD.Minute, FD.Second);
                DateTime TD = (DateTime)Task_Master_Property.End_Time;
                DateTime TD1 = (DateTime)Task_Master_Property.End_Date;
                DateTime ToDate = new DateTime(TD1.Year, TD1.Month, TD1.Day, TD.Hour, TD.Minute, TD.Second);

                if (ToDate < FromDate)
                {
                    return Json(new
                    {
                        success = false,
                        message = "From Date Not Graterthen To Date."
                    }, JsonRequestBehavior.AllowGet);
                }
                //Task_Master_Property.Task_Login_ID = SessionDetails.UserSession.Login_ID;
                int TaskId = clientDetail.Task_Master_Save(Task_Master_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "Task Saved successfully",
                    TaskId = TaskId.ToString()
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Task saved failed! - " + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult TaskTransaction_SaveForm(UpKeep.ClientDetail.Task_Transaction_Property Task_Transaction_Property)
        {
            try
            {
                int TaskId = clientDetail.TaskTransaction_Master_Save(Task_Transaction_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "Task Saved successfully",
                    TaskId = TaskId.ToString()
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Task saved failed! - " + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }
        public JsonResult Uploads()
        {
            if (Request.Files.Count > 0)
            {
                string filepath1 = "";
                string filepath2 = "";
                string filepath3 = "";
                string filepath4 = "";
                string filepath5 = "";
                try
                {
                    HttpFileCollectionBase files = Request.Files;
                    for (int i = 0; i < files.Count; i++)
                    {
                        HttpPostedFileBase file = files[i];
                        string fname;
                        if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        {
                            string[] testfiles = file.FileName.Split(new char[] { '\\' });
                            fname = testfiles[testfiles.Length - 1];
                        }
                        else
                        {
                            fname = file.FileName;
                        }
                        var uploadRootFolderInput = Server.MapPath("\\Uploads");
                        Directory.CreateDirectory(uploadRootFolderInput);
                        var directoryFullPathInput = uploadRootFolderInput;
                        //fname = Path.Combine(directoryFullPathInput, fname);
                        FileInfo fi = new FileInfo(fname);
                        Guid Guid = Guid.NewGuid();
                        fname = Path.Combine(directoryFullPathInput, Guid.ToString() + fi.Extension);
                        file.SaveAs(fname);
                        if (i == 0)
                        {
                            filepath1 = fname;
                        }
                        else if (i == 1)
                        {
                            filepath2 = fname;
                        }
                        else if (i == 2)
                        {
                            filepath3 = fname;
                        }
                        else if (i == 3)
                        {
                            filepath4 = fname;
                        }
                        else if (i == 4)
                        {
                            filepath5 = fname;
                        }
                    }
                    return Json(new
                    {
                        success = true,
                        msg = "File Upload Successfully ",
                        data1 = filepath1,
                        data2 = filepath2,
                        data3 = filepath3,
                        data4 = filepath4,
                        data5 = filepath5
                    }, JsonRequestBehavior.AllowGet);
                }
                catch (Exception ex)
                {
                    //   return Json("Error occurred. Error details: " + ex.Message);
                    return Json(new
                    {
                        success = false,
                        msg = ex,
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {

                return Json(new
                {
                    success = false,
                    msg = "No files selected.",
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult DownloadFile(string directoryFullPathInput)
        {
            directoryFullPathInput = directoryFullPathInput.Replace("\\\\", "\\");
            string fullName = System.IO.Path.Combine(Server.MapPath("~") + directoryFullPathInput);
            //string fullName = Server.MapPath(directoryFullPathInput).Replace("E:\\Abhi\\UpKeep\\trunk\\UpKeep\\", "");
            //string fullName = Server.MapPath(directoryFullPathInput).Replace("E:","").Replace(@"\" , "").Replace("Abhi" , "").Replace("UpKeep" , "").Replace("trunk" , "").Replace("uploads" , "");

            byte[] fileBytes = GetFile(directoryFullPathInput);
            return File(
                fileBytes, System.Net.Mime.MediaTypeNames.Application.Octet, directoryFullPathInput);
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

        public JsonResult GetAssessment()
        {
            DataTable dtAreaMas = new DataTable();

            dtAreaMas = clientDetail.Assesment_GetData(SessionDetails.ClientSession.connectionString);

            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(dtAreaMas);

            return Json(new
            {
                success = true,
                List = List
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSubAssessment()
        {
            DataTable dtAreaMas = new DataTable();

            dtAreaMas = clientDetail.SubAssesment_GetData(SessionDetails.ClientSession.connectionString);

            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(dtAreaMas);

            return Json(new
            {
                success = true,
                List = List
            }, JsonRequestBehavior.AllowGet);
        }
    }
}