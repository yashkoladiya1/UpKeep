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
    public class ShyamMotorsController : Controller
    {
        // GET: ShyamMotors
        ClientDetail.Client_ServiceSoapClient clientDetail = new ClientDetail.Client_ServiceSoapClient();
        public ActionResult ClientJobCard()
        {
            if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '23'").Count() > 0)
            {

                List<Ledger_Master_Property> FormPartyNameList = new List<Ledger_Master_Property>();
                FormPartyNameList = (from DataRow dr in clientDetail.Ledger_GetData(SessionDetails.ClientSession.connectionString).Rows
                                     select new Ledger_Master_Property()
                                     {
                                         Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
                                         Ledger_Name = dr["Ledger_Name"].ToString()
                                     }).ToList();

                ViewBag.FormPartyNameList = new MultiSelectList(FormPartyNameList, "Ledger_Code", "Ledger_Name");

                return View();
            }
            else
            {
                return RedirectToAction("Error", "Master");
            }
        }

        [HttpPost]
        public JsonResult JobCard_SaveForm(UpKeep.ClientDetail.JobCard_Master_Property JobCard_Master_Property)
        {
            try
            {
                string msg = "";

                clientDetail.JobCardMaster_Save(JobCard_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "JobCard Saved successfully";

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
                    message = "JobCard saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult JobCard_Master_GetData()
        {
            DataTable JobCard_Master = clientDetail.JobCard_Master_GetData(SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(JobCard_Master);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Ledger_SaveForm(string Party_Name, string Mobile_No)
        {
            try
            {
                UpKeep.ClientDetail.Ledger_Master_Property Ledger_Master_Property = new ClientDetail.Ledger_Master_Property();
                string msg = "";
                int Sales_ID = 0;

                Ledger_Master_Property.Party_Mobile = Mobile_No;
                Ledger_Master_Property.Ledger_Name = Party_Name;
                Ledger_Master_Property.Active = 1;
                Ledger_Master_Property.Party_City_Code = 2;
                Ledger_Master_Property.Party_State_Code = 1;
                Ledger_Master_Property.Party_Country_Code = 1;
                Sales_ID = clientDetail.Ledger_Master_Save(Ledger_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Sales Saved successfully";

                return Json(new
                {
                    success = true,
                    message = msg,
                    Sales_ID = Sales_ID.ToString()
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Sales saved failed"
                }, JsonRequestBehavior.AllowGet);
            }


        }
        [HttpGet]
        public ActionResult GetLedgerMaster()
        {
            DataTable dtPartyMaster = clientDetail.Ledger_GetData(SessionDetails.ClientSession.connectionString);
            IEnumerable<SelectListItem> Partnamelist = (from DataRow dr in dtPartyMaster.Rows select new SelectListItem() { Value = dr["Ledger_Code"].ToString(), Text = Convert.ToString(dr["Ledger_Name"]) });
            var result = new SelectList(Partnamelist, "Value", "Text");
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetPartyMobileNo(string PartyCode)
        {

            DataTable dtPartyMaster = clientDetail.Ledger_GetData(SessionDetails.ClientSession.connectionString);
            DataRow[] dr = dtPartyMaster.Select("Ledger_Code=" + PartyCode + "");

            string mob = dr[0]["Party_Mobile"].ToString();
            return Json(new
            {

                success = true,
                mob = mob


            }, JsonRequestBehavior.AllowGet);
        }

    }
}
