//using DLL.FunctionClasses;
//using DLL.FunctionClasses;
//using DLL.PropertyClasses;
using DLL.FunctionClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using UpKeep.ClientDetail;
using UpKeep.Utility;
using User_Login_Master_Property = UpKeep.ClientDetail.User_Login_Master_Property;

namespace UpKeep.Controllers
{
    [SessionExpireFilterAttribute]
    [AuthorizeUserAttribute]
    public class MasterController : Controller
    {
        ClientDetail.Client_ServiceSoapClient clientDetail = new ClientDetail.Client_ServiceSoapClient();
        // GET: Master

        //public bool RightsFromModule()
        //{
        //    if (Session["Login_ID"] != null)
        //    {
        //        int loginid = Convert.ToInt32(Session["Login_ID"].ToString());
        //        //string actionName = this.ControllerContext.RouteData.Values["action"].ToString();
        //        //string controllerName = this.ControllerContext.RouteData.Values["controller"].ToString();

        //        //User_Rights_Master urm = new User_Rights_Master();
        //        ////int moduleid = Convert.ToInt32((urm.PRC_Get_Module_Id_By_Name(actionName)).Rows[0][0]);
        //        //DataTable dtModule = new DataTable();
        //        //dtModule = urm.Get_User_Rights_With_Module(userid, moduleid);
        //        User_Login_Master_Property obj =new User_Login_Master_Property();
        //        obj.Login_ID = loginid;
        //        DataTable dtModule =  clientDetail.Get_User_Rights_With_Module(obj, SessionDetails.ClientSession.connectionString);

        //        string view = "";

        //        if (dtModule.Rows.Count > 0)
        //        {
        //            view = dtModule.Rows[0]["view_s"].ToString();
        //        }
        //        if (view == "1")
        //        {
        //            ViewBag.view = view;
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    else
        //    {
        //        //RedirectToAction("Error");
        //        return false;
        //    }
        //}

        public ActionResult UserMaster()
        {
           
                return View();
           
        }


        public JsonResult GetUser_List()
        {
            DataTable UserMaster = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(UserMaster);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);

            //var RoughMaster = Master.GetRoughMaster();
            //string Str = js.DataTableToJSONWithJavaScriptSerializer(RoughMaster);

            //return Json(Str, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UserMaster_SaveForm(UpKeep.ClientDetail.User_Master_Property User_Master_Property)
        {
            try
            {
                string msg = "";

                clientDetail.UserMaster_Save(User_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "User Saved successfully";

                return Json(new
                {
                    success = true,
                    message = msg
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "User saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #region Country_Master
        public ActionResult Country_Master()
        {
            
                return View();
            
        }

        public JsonResult GetCountry_List()
        {
            DataTable Country_Master = clientDetail.CountryMaster_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Country_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        //[HttpPost]
        //public JsonResult Country_SaveForm(UpKeep.ClientDetail.Country_Master_Property Country_Master_Property)
        //{
        //    try
        //    {
        //        string msg = "";
        //        Country_Master ObJCountry = new Country_Master();

        //        clientDetail.CountryMaster_Save(Country_Master_Property, SessionDetails.ClientSession.connectionString);
        //        msg = "Country Saved successfully";

        //        return Json(new
        //        {
        //            success = true,
        //            message = msg
        //        }, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception ex)
        //    {
        //        //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
        //        return Json(new
        //        {
        //            success = false,
        //            message = "Country saved failed"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //}

        #endregion

        #region State_Master

        //public ActionResult State_Master()
        //{
           
        //        Country_Master Country = new Country_Master();
        //        List<Country_Master> FormDisplayNameList = new List<Country_Master>();
        //        FormDisplayNameList = (from DataRow dr in clientDetail.CountryMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                               select new Country_Master()
        //                               {
        //                                   Country_Id = Convert.ToInt32(dr["Country_Id"]),
        //                                   Country_Name = dr["Country_Name"].ToString()
        //                               }).ToList();

        //        ViewBag.FormDisplayNameList = new MultiSelectList(FormDisplayNameList, "Country_Id", "Country_Name");

        //        return View();
           
        //}

        public JsonResult GetState_List()
        {
            DataTable State_Master = clientDetail.StateMaster_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(State_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult State_SaveForm(UpKeep.ClientDetail.State_Master_Property State_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.StateMaster_Save(State_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "State Saved successfully";

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
                    message = "State saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region City_Master

        //public ActionResult City_Master()
        //{
            

        //        City_Master City = new City_Master();
        //        List<City_Master> FormDisplayNameList = new List<City_Master>();
        //        FormDisplayNameList = (from DataRow dr in clientDetail.CountryMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                               select new City_Master()
        //                               {
        //                                   Country_Id = Convert.ToInt32(dr["Country_Id"]),
        //                                   Country_Name = dr["Country_Name"].ToString()
        //                               }).ToList();

        //        ViewBag.FormDisplayNameList = new MultiSelectList(FormDisplayNameList, "Country_Id", "Country_Name");

        //        List<City_Master> FormDisplayStateName = new List<City_Master>();
        //        FormDisplayStateName = (from DataRow dr in clientDetail.StateMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                                select new City_Master()
        //                                {
        //                                    State_Id = Convert.ToInt32(dr["State_Id"]),
        //                                    State_Name = dr["State_Name"].ToString()
        //                                }).ToList();

        //        ViewBag.FormDisplayStateName = new MultiSelectList(FormDisplayStateName, "State_Id", "State_Name");

        //        //City_Master City = new City_Master();


        //        return View();
            
        //}

        public JsonResult GetCity_List()
        {
            DataTable City_Master = clientDetail.CityMaster_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(City_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult City_SaveForm(UpKeep.ClientDetail.City_Master_Property City_Master_Property)
        {
            try
            {
                string msg = "";

                clientDetail.CityMaster_Save(City_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "City Saved successfully";

                return Json(new
                {
                    success = true,
                    message = msg
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "City saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Priority_Master
        public ActionResult Priority_Master()
        {
            
                return View();
            
        }

        public JsonResult GetPriority_List()
        {
            DataTable Priority_Master = clientDetail.PriorityMaster_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Priority_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Priority_SaveForm(UpKeep.ClientDetail.Priority_Master_Property Priority_Master_Property)
        {
            try
            {
                clientDetail.Priority_Master_Save(Priority_Master_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "Priority Saved successfully"
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Priority saved failed!" + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region User_Category_Master
        public ActionResult User_Category_Master()
        {
            
                return View();
           
        }

        #endregion

        #region Category_Master
        public ActionResult Category_Master()
        {
           
                return View();
            
        }

        public JsonResult GetCategory_List()
        {
            DataTable Category_Master = clientDetail.CategoryMaster_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Category_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Category_SaveForm(ClientDetail.Category_Master_Property Category_Master_Property)
        {
            try
            {
                string msg = "";
                //clientDetail.Catagory_Master_Save()
                clientDetail.Catagory_Master_Save(Category_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Category Saved successfully";

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
                    message = "Category saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region WeekllyOff_Master
        public ActionResult WeekllyOff_Master()
        {
            
                return View();
           
        }

        public JsonResult GetWeekllyOff_List()
        {
            DataTable Priority_Master = clientDetail.WeekllyOffMaster_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Priority_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Work_Status_Master
        public ActionResult Work_Status_Master()
        {
            
                return View();
            
        }

        public JsonResult GetWork_Status_List()
        {
            DataTable Work_Status = clientDetail.Work_StatusMaster_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Work_Status);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult WorkStatus_SaveForm(UpKeep.ClientDetail.Work_Status_Master_Property Work_Status_Master_Property)
        {
            try
            {
                clientDetail.WorkStatus_Save(Work_Status_Master_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "WorkStatus Saved successfully"
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "WorkStatus saved failed!" + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Request_Status_Master
        public ActionResult Request_Status_Master()
        {
           
                return View();
            
        }

        [HttpPost]
        public JsonResult Request_Status_SaveForm(UpKeep.ClientDetail.Request_Status_Master_Property Request_Status_Master_Property)
        {
            try
            {
                string msg = "";

                clientDetail.Request_Master_Save(Request_Status_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Request Status Saved successfully";

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
                    message = "Request Status saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetRequest_Status_List()
        {
            DataTable Request_Status = clientDetail.Request_StatusMaster_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Request_Status);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region Module_Master
        public ActionResult Module_Master()
        {
              return View();
           
        }
        public JsonResult GetModule_Master_List()
        {
            DataTable Module_Master = clientDetail.Module_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Module_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Module_SaveForm(UpKeep.ClientDetail.Module_Master_Property Module_Master_Property)
        {
            try
            {
                clientDetail.Module_Master_Save(Module_Master_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "Module Saved successfully"
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Module saved failed! - " + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Location_Master
        public ActionResult Location_Master()
        {
          
                return View();
            
        }
        public JsonResult GetLocation_Master_List()
        {
            DataTable Location_Master = clientDetail.Location_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Location_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Location_SaveForm(UpKeep.ClientDetail.Location_Master_Property Location_Master_Property)
        {
            try
            {
                string msg = "";
                // Location_Master ObJLocation = new Location_Master();

                clientDetail.LocationMaster_Save(Location_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Location Saved successfully";

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
                    message = "Location saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region IDProof_Master
        public ActionResult IDProof_Master()
        {
            
                return View();
            
        }
        public JsonResult GetIDProof_Master_List()
        {
            DataTable IDProof_Master = clientDetail.IDProof_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(IDProof_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult IDProof_SaveForm(UpKeep.ClientDetail.IDProof_Master_Property IDProof_Master_Property)
        {
            try
            {
                clientDetail.IDProof_Master_Save(IDProof_Master_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "IDProof Saved successfully"
                }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "IDProof saved failed! - " + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }


        #endregion

        #region Frequency_Master
        public ActionResult Frequency_Master()
        {
           
                return View();
           
        }
        public JsonResult GetFrequency_Master_List()
        {
            DataTable Frequency_Master = clientDetail.Frequency_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Frequency_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Frequency_SaveForm(UpKeep.ClientDetail.Frequency_Master_Property Frequency_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Frequency_Master_Save(Frequency_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Frequency Saved successfully";

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
                    message = "Frequency saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Assessment_Master

        public ActionResult Assessment_Master()
        {
           

                Module_Master Module = new Module_Master();
                List<Module_Master> FormDisplayNameList = new List<Module_Master>();
                FormDisplayNameList = (from DataRow dr in clientDetail.ModuleMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
                                       select new Module_Master()
                                       {
                                           Module_Id = Convert.ToInt32(dr["Module_ID"]),
                                           Module_Name = dr["Module_Name"].ToString()
                                       }).ToList();

                ViewBag.FormDisplayNameList = new MultiSelectList(FormDisplayNameList, "Module_ID", "Module_Name");

                return View();
           
        }

        public JsonResult GetAssessment_Master_List()
        {
            DataTable Assessment_Master = clientDetail.Assessment_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Assessment_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Assessment_SaveForm(UpKeep.ClientDetail.Assessment_Master_Property Assessment_Master_Property)
        {
            try
            {
                clientDetail.Assesment_Master_Save(Assessment_Master_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "Assessment Saved successfully"
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Assessment saved failed! - " + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Sub_Assessment_Master

        public ActionResult Sub_Assessment_Master()
        {
            
                Module_Master Module = new Module_Master();
                List<Module_Master> FormDisplayNameList = new List<Module_Master>();
                FormDisplayNameList = (from DataRow dr in clientDetail.ModuleMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
                                       select new Module_Master()
                                       {
                                           Module_Id = Convert.ToInt32(dr["Module_ID"]),
                                           Module_Name = dr["Module_Name"].ToString()
                                       }).ToList();

                ViewBag.FormDisplayNameList = new MultiSelectList(FormDisplayNameList, "Module_ID", "Module_Name");

                Assessment_Master Assessment = new Assessment_Master();
                List<Assessment_Master> FormDisplayAssessmentList = new List<Assessment_Master>();
                FormDisplayAssessmentList = (from DataRow dr in clientDetail.Assessment_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                             select new Assessment_Master()
                                             {
                                                 Assessment_ID = Convert.ToInt32(dr["Assessment_ID"]),
                                                 Assessment_Name = dr["Assessment_Name"].ToString()
                                             }).ToList();

                ViewBag.FormDisplayAssessmentList = new MultiSelectList(FormDisplayAssessmentList, "Assessment_ID", "Assessment_Name");

                Location_Master Location = new Location_Master();
                List<Location_Master> FormDisplaLocationList = new List<Location_Master>();
                FormDisplaLocationList = (from DataRow dr in clientDetail.Location_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                          select new Location_Master()
                                          {
                                              Location_ID = Convert.ToInt32(dr["Location_ID"]),
                                              Location_Name = dr["Location_Name"].ToString()
                                          }).ToList();

                ViewBag.FormDisplaLocationList = new MultiSelectList(FormDisplaLocationList, "Location_ID", "Location_Name");

                return View();
            
        }

        public JsonResult GetSubAssessment_Master_List()
        {
            DataTable Sub_Assessment_Master = clientDetail.Sub_Assessment_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Sub_Assessment_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Sub_Assessment_SaveForm(UpKeep.ClientDetail.Sub_Assessment_Master_Property Sub_Assessment_Master_Property)
        {
            try
            {
                clientDetail.SubAssesment_Master_Save(Sub_Assessment_Master_Property, SessionDetails.ClientSession.connectionString);
                return Json(new
                {
                    success = true,
                    message = "SubAssessment Saved successfully"
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "SubAssessment saved failed! - " + ex.ToString()
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Holiday_Master
        public ActionResult Holiday_Master()
        {
            
                return View();
           
        }
        public JsonResult GetHoliday_Master_List()
        {
            DataTable Holiday_Master = clientDetail.Holiday_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Holiday_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Holiday_SaveForm(UpKeep.ClientDetail.Holiday_Master_Property Holiday_Master_Property)
        {
            try
            {
                string msg = "";
                // Location_Master ObJLocation = new Location_Master();

                clientDetail.Holiday_Master_Save(Holiday_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Holiday Saved successfully";

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
                    message = "Holiday saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Unit_Master
        public ActionResult Unit_Master()
        {
           
                return View();
            
        }
        public JsonResult GetUnit_Master_List()
        {
            DataTable Unit_Master = clientDetail.Unit_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Unit_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Unit_SaveForm(UpKeep.ClientDetail.Unit_Master_Property Unit_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Unit_Master_Save(Unit_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Unit Saved successfully";

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
                    message = "Unit saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Item_Group_Master
        public ActionResult Item_Group_Master()
        {
           
                return View();
           
        }
        public JsonResult GetItem_Group_Master_List()
        {
            DataTable Item_Group_Master = clientDetail.Item_Group_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Item_Group_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Item_Group_SaveForm(UpKeep.ClientDetail.Item_Group_Master_Property Item_Group_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Item_Group_Master_Save(Item_Group_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Item Saved successfully";

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

        #endregion

        #region Item Hsn Master
        public ActionResult Item_Hsn_Master()
        {
            
                return View();
           
        }
        public JsonResult GetItem_Hsn_Master_List()
        {
            DataTable Item_Hsn_Master = clientDetail.Item_Hsn_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Item_Hsn_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Item_Hsn_SaveForm(UpKeep.ClientDetail.Item_Hsn_Master_Property Item_Hsn_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Item_Hsn_Master_Save(Item_Hsn_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Item Saved successfully";

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

        #endregion

        #region Item Category Master
        public ActionResult Item_Category_Master()
        {
            
                return View();
            
        }
        public JsonResult GetItem_Category_Master_List()
        {
            DataTable Item_Category_Master = clientDetail.Item_Category_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Item_Category_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Item_Category_SaveForm(UpKeep.ClientDetail.Item_Category_Master_Property Item_Category_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Item_Category_Master_Save(Item_Category_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Item Saved successfully";

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
        #endregion

        #region Item Master

        public ActionResult Item_Master()
        {
           
                //City_Master City = new City_Master();
                List<Company_Master_Property> FormDisplayNameList = new List<Company_Master_Property>();
                FormDisplayNameList = (from DataRow dr in clientDetail.Company_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                       select new Company_Master_Property()
                                       {
                                           Company_code = Convert.ToInt32(dr["Company_code"]),
                                           Company_name = dr["Company_name"].ToString()
                                       }).ToList();

                ViewBag.FormDisplayNameList = new MultiSelectList(FormDisplayNameList, "Company_code", "Company_name");

                List<Location_Master_Property> FormLocationList = new List<Location_Master_Property>();
                FormLocationList = (from DataRow dr in clientDetail.Location_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                    select new Location_Master_Property()
                                    {
                                        Location_ID = Convert.ToInt32(dr["Location_ID"]),
                                        Location_Name = dr["Location_Name"].ToString()
                                    }).ToList();

                ViewBag.FormLocationList = new MultiSelectList(FormLocationList, "Location_ID", "Location_Name");

                List<Branch_Master_Property> FormBranchList = new List<Branch_Master_Property>();
                FormBranchList = (from DataRow dr in clientDetail.Branch_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                  select new Branch_Master_Property()
                                  {
                                      Branch_Code = Convert.ToInt32(dr["Branch_Code"]),
                                      Branch_Name = dr["Branch_Name"].ToString()
                                  }).ToList();

                ViewBag.FormBranchList = new MultiSelectList(FormBranchList, "Branch_Code", "Branch_Name");

                List<Item_Group_Master_Property> FormGroupCodeList = new List<Item_Group_Master_Property>();
                FormGroupCodeList = (from DataRow dr in clientDetail.Item_Group_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                     select new Item_Group_Master_Property()
                                     {
                                         Item_Group_Code = Convert.ToInt32(dr["Item_Group_Code"]),
                                         Item_Group_Name = dr["Item_Group_Name"].ToString()
                                     }).ToList();

                ViewBag.FormGroupCodeList = new MultiSelectList(FormGroupCodeList, "Item_Group_Code", "Item_Group_Name");

                List<Item_Category_Master_Property> FormCategoryCodeList = new List<Item_Category_Master_Property>();
                FormCategoryCodeList = (from DataRow dr in clientDetail.Item_Category_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                        select new Item_Category_Master_Property()
                                        {
                                            Item_Category_Code = Convert.ToInt32(dr["Item_Category_Code"]),
                                            Item_Category_Name = dr["Item_Category_Name"].ToString()
                                        }).ToList();

                ViewBag.FormCategoryCodeList = new MultiSelectList(FormCategoryCodeList, "Item_Category_Code", "Item_Category_Name");

                List<Unit_Master_Property> FormUnitList = new List<Unit_Master_Property>();
                FormUnitList = (from DataRow dr in clientDetail.Unit_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                select new Unit_Master_Property()
                                {
                                    Unit_ID = Convert.ToInt32(dr["Unit_ID"]),
                                    Unit_Name = dr["Unit_Name"].ToString()
                                }).ToList();

                ViewBag.FormUnitList = new MultiSelectList(FormUnitList, "Unit_ID", "Unit_Name");


                List<Item_Hsn_Master_Property> HSNList = new List<Item_Hsn_Master_Property>();
                HSNList = (from DataRow dr in clientDetail.Item_Hsn_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                           select new Item_Hsn_Master_Property()
                           {
                               Hsn_ID = Convert.ToInt32(dr["Hsn_ID"]),
                               Hsn_Code = dr["Hsn_Code"].ToString()
                           }).ToList();

                ViewBag.HSNList = new MultiSelectList(HSNList, "Hsn_ID", "Hsn_Code");

            return View();
        }
        public JsonResult GetItem_Master_List()
        {
            DataTable Item_Master = clientDetail.Item_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Item_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Item_SaveForm(UpKeep.ClientDetail.Item_Master_Property Item_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Item_Master_Save(Item_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Item Saved successfully";

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

        [HttpPost]
        public JsonResult Item_DeleteForm(UpKeep.ClientDetail.Item_Master_Property Item_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Item_Master_Delete(Item_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Item Delete successfully";

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
        #endregion

        #region Item Detail 
        public ActionResult Item_Detail()
        {
           
                List<Location_Master_Property> FormLocationList = new List<Location_Master_Property>();
                FormLocationList = (from DataRow dr in clientDetail.Location_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                    select new Location_Master_Property()
                                    {
                                        Location_ID = Convert.ToInt32(dr["Location_ID"]),
                                        Location_Name = dr["Location_Name"].ToString()
                                    }).ToList();

                ViewBag.FormLocationList = new MultiSelectList(FormLocationList, "Location_ID", "Location_Name");

                List<Item_Master_Property> FormItemList = new List<Item_Master_Property>();
                FormItemList = (from DataRow dr in clientDetail.Item_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                select new Item_Master_Property()
                                {
                                    Item_Code = Convert.ToInt32(dr["Item_Code"]),
                                    Item_Name = dr["Item_Name"].ToString()
                                }).ToList();

                ViewBag.FormItemList = new MultiSelectList(FormItemList, "Item_Code", "Item_Name");
                return View();
           
        }
        public JsonResult GetItem_Detail_List()
        {
            DataTable Item_Detail = clientDetail.Item_Detail_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Item_Detail);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Item_Detail_SaveForm(UpKeep.ClientDetail.Item_Detail_Property Item_Detail_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Item_Detail_Save(Item_Detail_Property, SessionDetails.ClientSession.connectionString);
                msg = "Item Saved successfully";

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
        #endregion

        #region Company Master
        //public ActionResult Company_Master()
        //{
            

        //        City_Master City = new City_Master();
        //        List<City_Master> FormCountryNameList = new List<City_Master>();
        //        FormCountryNameList = (from DataRow dr in clientDetail.CountryMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                               select new City_Master()
        //                               {
        //                                   Country_Id = Convert.ToInt32(dr["Country_Id"]),
        //                                   Country_Name = dr["Country_Name"].ToString()
        //                               }).ToList();

        //        ViewBag.FormCountryNameList = new MultiSelectList(FormCountryNameList, "Country_Id", "Country_Name");

        //        List<City_Master> FormStateName = new List<City_Master>();
        //        FormStateName = (from DataRow dr in clientDetail.StateMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                         select new City_Master()
        //                         {
        //                             State_Id = Convert.ToInt32(dr["State_Id"]),
        //                             State_Name = dr["State_Name"].ToString()
        //                         }).ToList();

        //        ViewBag.FormStateName = new MultiSelectList(FormStateName, "State_Id", "State_Name");

        //        List<City_Master> FormCityNameList = new List<City_Master>();
        //        FormCityNameList = (from DataRow dr in clientDetail.CityMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                            select new City_Master()
        //                            {
        //                                City_Id = Convert.ToInt32(dr["City_Id"]),
        //                                City_Name = dr["City_Name"].ToString()
        //                            }).ToList();

        //        ViewBag.FormCityNameList = new MultiSelectList(FormCityNameList, "City_Id", "City_Name");

        //        return View();
            
        //}
        public JsonResult GetCompany_Master_List()
        {
            DataTable Company_Master = clientDetail.Company_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Company_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Company_SaveForm(UpKeep.ClientDetail.Company_Master_Property Company_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Company_Master_Save(Company_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Company Saved successfully";

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
                    message = "Company saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region Branch Master
        //public ActionResult Branch_Master()
        //{
           
        //        City_Master City = new City_Master();
        //        List<City_Master> FormCountryNameList = new List<City_Master>();
        //        FormCountryNameList = (from DataRow dr in clientDetail.CountryMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                               select new City_Master()
        //                               {
        //                                   Country_Id = Convert.ToInt32(dr["Country_Id"]),
        //                                   Country_Name = dr["Country_Name"].ToString()
        //                               }).ToList();

        //        ViewBag.FormCountryNameList = new MultiSelectList(FormCountryNameList, "Country_Id", "Country_Name");

        //        List<City_Master> FormStateName = new List<City_Master>();
        //        FormStateName = (from DataRow dr in clientDetail.StateMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                         select new City_Master()
        //                         {
        //                             State_Id = Convert.ToInt32(dr["State_Id"]),
        //                             State_Name = dr["State_Name"].ToString()
        //                         }).ToList();

        //        ViewBag.FormStateName = new MultiSelectList(FormStateName, "State_Id", "State_Name");

        //        List<City_Master> FormCityNameList = new List<City_Master>();
        //        FormCityNameList = (from DataRow dr in clientDetail.CityMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                            select new City_Master()
        //                            {
        //                                City_Id = Convert.ToInt32(dr["City_Id"]),
        //                                City_Name = dr["City_Name"].ToString()
        //                            }).ToList();

        //        ViewBag.FormCityNameList = new MultiSelectList(FormCityNameList, "City_Id", "City_Name");

        //        List<Company_Master_Property> FormDisplayNameList = new List<Company_Master_Property>();
        //        FormDisplayNameList = (from DataRow dr in clientDetail.Company_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                               select new Company_Master_Property()
        //                               {
        //                                   Company_code = Convert.ToInt32(dr["Company_code"]),
        //                                   Company_name = dr["Company_name"].ToString()
        //                               }).ToList();

        //        ViewBag.FormCompanyList = new MultiSelectList(FormDisplayNameList, "Company_code", "Company_name");

        //        List<Location_Master_Property> FormLocationList = new List<Location_Master_Property>();
        //        FormLocationList = (from DataRow dr in clientDetail.Location_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                            select new Location_Master_Property()
        //                            {
        //                                Location_ID = Convert.ToInt32(dr["Location_ID"]),
        //                                Location_Name = dr["Location_Name"].ToString()
        //                            }).ToList();

        //        ViewBag.FormLocationList = new MultiSelectList(FormLocationList, "Location_ID", "Location_Name");
        //        return View();
           
        //}
        public JsonResult GetBranch_Master_List()
        {
            DataTable Branch_Master = clientDetail.Branch_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Branch_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Branch_SaveForm(UpKeep.ClientDetail.Branch_Master_Property Branch_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Branch_Master_Save(Branch_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Branch Saved successfully";

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
                    message = "Branch saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion



        public ActionResult User_cMaster()
        {
            
                Module_Master Module = new Module_Master();
                List<Module_Master> FormDisplayNameList = new List<Module_Master>();
                FormDisplayNameList = (from DataRow dr in clientDetail.ModuleMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
                                       select new Module_Master()
                                       {
                                           Module_Id = Convert.ToInt32(dr["Module_ID"]),
                                           Module_Name = dr["Module_Name"].ToString()
                                       }).ToList();

                ViewBag.FormDisplayNameList = new MultiSelectList(FormDisplayNameList, "Module_ID", "Module_Name");

                User_Login_Master User = new User_Login_Master();
                List<User_Login_Master> FormDisplayUserList = new List<User_Login_Master>();
                FormDisplayUserList = (from DataRow dr in clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString).Rows
                                       select new User_Login_Master()
                                       {
                                           Login_ID = Convert.ToInt32(dr["Login_ID"]),
                                           UserName = dr["UserName"].ToString()
                                       }).ToList();

                ViewBag.FormDisplayUserList = new MultiSelectList(FormDisplayUserList, "Login_ID", "UserName");

                return View();
            
        }

            #region User_Rights_Master

        public ActionResult User_Rights_Master()
        {
            
                Module_Master Module = new Module_Master();
                List<Module_Master> FormDisplayNameList = new List<Module_Master>();
                FormDisplayNameList = (from DataRow dr in clientDetail.ModuleMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
                                       select new Module_Master()
                                       {
                                           Module_Id = Convert.ToInt32(dr["Module_ID"]),
                                           Module_Name = dr["Module_Name"].ToString()
                                       }).ToList();

                ViewBag.FormDisplayNameList = new MultiSelectList(FormDisplayNameList, "Module_ID", "Module_Name");

                User_Login_Master User = new User_Login_Master();
                List<User_Login_Master> FormDisplayUserList = new List<User_Login_Master>();
                FormDisplayUserList = (from DataRow dr in clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString).Rows
                                       select new User_Login_Master()
                                       {
                                           Login_ID = Convert.ToInt32(dr["Login_ID"]),
                                           UserName = dr["UserName"].ToString()
                                       }).ToList();

                ViewBag.FormDisplayUserList = new MultiSelectList(FormDisplayUserList, "Login_ID", "UserName");
                return View();
            
        }

        public JsonResult GetUser_Rights_Master_List()
        {
            DataTable User_Rights_Master = clientDetail.User_Right_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(User_Rights_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult UserRights_Master_Save(UpKeep.ClientDetail.User_Rights_Master_Property User_Rights_Master_Property)
        {
            try
            {
                string msg = "";
                //User_Rights_Master ObJCountry = new User_Rights_Master();

                clientDetail.User_Rights_Master_Save(User_Rights_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "User Rights Saved successfully";

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
                    message = "User Rights saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult DeleteUserRights(UpKeep.ClientDetail.User_Rights_Master_Property User_Rights_MasterProperty)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.User_Rights_Delete(User_Rights_MasterProperty, SessionDetails.ClientSession.connectionString);
                msg = "Item Delete successfully";

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

        [HttpPost]
        public JsonResult UserRightsMaster_Save(UpKeep.ClientDetail.User_Rights_Master_Property UserRights_Master_Property)
        {
            try
            {
                string msg = "";

                clientDetail.User_Rights_Master_Save(UserRights_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "UserRights Saved successfully";

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
                    message = "UserRights saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Ledger_Master
        //public ActionResult Ledger_Master()
        //{
            

        //        City_Master City = new City_Master();
        //        List<City_Master> FormCountryNameList = new List<City_Master>();
        //        FormCountryNameList = (from DataRow dr in clientDetail.CountryMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                               select new City_Master()
        //                               {
        //                                   Country_Id = Convert.ToInt32(dr["Country_Id"]),
        //                                   Country_Name = dr["Country_Name"].ToString()
        //                               }).ToList();

        //        ViewBag.FormCountryNameList = new MultiSelectList(FormCountryNameList, "Country_Id", "Country_Name");

        //        List<City_Master> FormStateName = new List<City_Master>();
        //        FormStateName = (from DataRow dr in clientDetail.StateMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                         select new City_Master()
        //                         {
        //                             State_Id = Convert.ToInt32(dr["State_Id"]),
        //                             State_Name = dr["State_Name"].ToString()
        //                         }).ToList();

        //        ViewBag.FormStateName = new MultiSelectList(FormStateName, "State_Id", "State_Name");

        //        List<City_Master> FormCityNameList = new List<City_Master>();
        //        FormCityNameList = (from DataRow dr in clientDetail.CityMaster_GetData(SessionDetails.ClientSession.connectionString).Rows
        //                            select new City_Master()
        //                            {
        //                                City_Id = Convert.ToInt32(dr["City_Id"]),
        //                                City_Name = dr["City_Name"].ToString()
        //                            }).ToList();

        //        ViewBag.FormCityNameList = new MultiSelectList(FormCityNameList, "City_Id", "City_Name");

        //        IList<SelectListItem> PartyType = new List<SelectListItem>();
        //        PartyType.Add(new SelectListItem { Text = "Vendor", Value = "Vendor" });
        //        PartyType.Add(new SelectListItem { Text = "Labour", Value = "Labour" });
        //        PartyType.Add(new SelectListItem { Text = "Supplier", Value = "Supplier" });
        //        PartyType.Add(new SelectListItem { Text = "Self", Value = "Self" });
        //        SelectList SelPartyType = new SelectList(PartyType, "Value", "Text", "Vendor");
        //        ViewBag.FormPartyTypeList = SelPartyType;
        //        return View();
            
        //}
        public JsonResult GetLedger_Master_List()
        {
            DataTable Ledger_Master = clientDetail.Ledger_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Ledger_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Ledger_SaveForm(UpKeep.ClientDetail.Ledger_Master_Property Ledger_Master_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Ledger_Master_Save(Ledger_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Ledger Saved successfully";

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
                    message = "Ledger saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Ledger_Opening
        public ActionResult Ledger_Opening()
        {
           
                List<Ledger_Master_Property> FormLedgerList = new List<Ledger_Master_Property>();
                FormLedgerList = (from DataRow dr in clientDetail.Ledger_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                  select new Ledger_Master_Property()
                                  {
                                      Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
                                      Ledger_Name = dr["Ledger_Name"].ToString()
                                  }).ToList();

                ViewBag.FormLedgerList = new MultiSelectList(FormLedgerList, "Ledger_Code", "Ledger_Name");

                List<Company_Master_Property> FormDisplayNameList = new List<Company_Master_Property>();
                FormDisplayNameList = (from DataRow dr in clientDetail.Company_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                       select new Company_Master_Property()
                                       {
                                           Company_code = Convert.ToInt32(dr["Company_code"]),
                                           Company_name = dr["Company_name"].ToString()
                                       }).ToList();

                ViewBag.FormCompanyList = new MultiSelectList(FormDisplayNameList, "Company_code", "Company_name");

                List<Location_Master_Property> FormLocationList = new List<Location_Master_Property>();
                FormLocationList = (from DataRow dr in clientDetail.Location_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                    select new Location_Master_Property()
                                    {
                                        Location_ID = Convert.ToInt32(dr["Location_ID"]),
                                        Location_Name = dr["Location_Name"].ToString()
                                    }).ToList();

                ViewBag.FormLocationList = new MultiSelectList(FormLocationList, "Location_ID", "Location_Name");

                List<Branch_Master_Property> FormBranchList = new List<Branch_Master_Property>();
                FormBranchList = (from DataRow dr in clientDetail.Branch_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                  select new Branch_Master_Property()
                                  {
                                      Branch_Code = Convert.ToInt32(dr["Branch_Code"]),
                                      Branch_Name = dr["Branch_Name"].ToString()
                                  }).ToList();

                ViewBag.FormBranchList = new MultiSelectList(FormBranchList, "Branch_Code", "Branch_Name");



                return View();
           
        }
        public JsonResult GetLedger_Opening_List()
        {
            DataTable Ledger_Opening = clientDetail.Ledger_Opening_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Ledger_Opening);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Opening_SaveForm(UpKeep.ClientDetail.Ledger_Opening_Property Ledger_Opening_Property)
        {
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Ledger_Opening_Save(Ledger_Opening_Property, SessionDetails.ClientSession.connectionString);
                msg = "Ledger Saved successfully";

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
                    message = "Ledger saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Financial Year Master
        public ActionResult Financial_Year_Master()
        {
            
                return View();
            
        }
        public JsonResult GetFinancial_YearList()
        {
            DataTable Financial_Year_Master = clientDetail.Financial_Year_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Financial_Year_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Financial_SaveForm(UpKeep.ClientDetail.Financial_Year_Master_Property Financial_Year_Master_Property)
        {
           
            try
            {
                string msg = "";
                //Country_Master ObJCountry = new Country_Master();

                clientDetail.Financial_Year_Master_Save(Financial_Year_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Financial Year Saved successfully";

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
                    message = "Financial Year saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion

        #region JobCard Master
        public ActionResult JobCard_Master()
        {
            return View();
        }
        #endregion

        #region Bank Master

        public ActionResult Bank_Master()
        {
            return View();
        }

        public JsonResult GetBank_Master_List()
        {
            DataTable Bank_Master = clientDetail.Bank_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(Bank_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Bank_SaveForm(UpKeep.ClientDetail.Country_Master_Property Country_Master_Property)
        {
            try
            {
                string msg = "";

                clientDetail.BankMaster_Save(Country_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Bank Saved successfully";

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
                    message = "Bank saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        #endregion

        #region Employee Leave

        public ActionResult Employee_Leave()
        {
             DataTable ds_Result = clientDetail.UserLogin_GetData(SessionDetails.ClientSession.connectionString);
             List<UpKeep.ClientDetail.User_Login_Master_Property> UserList = new List<UpKeep.ClientDetail.User_Login_Master_Property>();
             for (int i = 0; i < ds_Result.Rows.Count; i++)
             {
                 UpKeep.ClientDetail.User_Login_Master_Property objUserLogin = new UpKeep.ClientDetail.User_Login_Master_Property();
                 objUserLogin.Login_ID = Convert.ToInt64(ds_Result.Rows[i]["Login_ID"]);
                 objUserLogin.UserID = ds_Result.Rows[i]["UserID"].ToString();
                 UserList.Add(objUserLogin);
             }
             if (SessionDetails.UserSession.Category_ID == 1)
                 ViewBag.UserList = new MultiSelectList(UserList, "Login_ID", "UserID");
             else
                 ViewBag.UserList = new MultiSelectList(UserList.Where(x => x.Login_ID == SessionDetails.UserSession.Login_ID).ToList(), "Login_ID", "UserID");

             return View();
        }

        //public JsonResult Save_Employee_Leave(DLL.PropertyClasses.Employee_Leave_Property EmployeeLeave, string ConnectionString)
        //{
        //    if(EmployeeLeave.Leave_Type == "0" || EmployeeLeave.Leave_Type == null || EmployeeLeave.Leave_Type == "")
        //    {
        //        return Json(new
        //        {
        //            success = false,
        //            msg = "Please select leave type.",
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //    Employee_Leave_Master obj = new Employee_Leave_Master();
        //    int sel = 0;
        //    string msg = "";
        //    EmployeeLeave.Add_By = Convert.ToInt32(SessionDetails.UserSession.Login_ID);
        //    EmployeeLeave.Edit_By = Convert.ToInt32(SessionDetails.UserSession.Login_ID);
        //    sel = obj.EmployeeLeave_Save(EmployeeLeave, SessionDetails.ClientSession.connectionString);
        //    if (sel == 1)
        //    {
        //        msg = "Data saved successfully..";
        //    }
        //    else
        //    {
        //        msg = "Something Went Wrong In Saving Data..";
        //    }
        //    return Json(new
        //    {
        //        success = sel == 1 ? true : false,
        //        msg = msg,
        //    }, JsonRequestBehavior.AllowGet);
        //}

        //public JsonResult Get_Employee_Leave() ///int User_Id)
        //{
        //    Employee_Leave_Master obj = new Employee_Leave_Master();
        //    DataTable sqlDt = new DataTable();
        //    sqlDt = obj.Employee_Leave_GetData(SessionDetails.ClientSession.connectionString);   //User_Id,

        //    if (SessionDetails.UserSession.Category_ID != 1)
        //    {
        //        DataView dv = new DataView(sqlDt);
        //        dv.RowFilter = "Login_ID = '" + Convert.ToInt32(SessionDetails.UserSession.Login_ID) + "'";
        //        sqlDt = new DataTable();
        //        sqlDt = dv.ToTable();
        //    }
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

        [HttpPost]
        public JsonResult WeekllyOff_SaveForm(UpKeep.ClientDetail.WeekllyOff_Master_Property WeekllyOff_Master_Property)
        {
            try
            {
                string msg = "";

                clientDetail.WeekllyOff_Master_Save(WeekllyOff_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Weeklly Off Saved successfully";

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
                    message = "Weeklly Off saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}