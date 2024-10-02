using DLL.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using UpKeep.Utility;

namespace UpKeep.Controllers
{
    [SessionExpireFilterAttribute]
    [AuthorizeUserAttribute]
    public class SalesController : Controller
    {
        // GET: Sales
        ClientDetail.Client_ServiceSoapClient clientDetail = new ClientDetail.Client_ServiceSoapClient();
        public ActionResult SalesEntry()
        {
            if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '6'").Count() > 0)
            {

                IList<SelectListItem> Payment_Type = new List<SelectListItem>();
                Payment_Type.Add(new SelectListItem { Text = "CREDIT", Value = "CREDIT" });
                Payment_Type.Add(new SelectListItem { Text = "DEBIT", Value = "DEBIT" });
                SelectList SelPayment_Type = new SelectList(Payment_Type, "Value", "Text", "CREDIT");
                ViewBag.Payment_Type = SelPayment_Type;


                List<Ledger_Master_Property> FormPartyNameList = new List<Ledger_Master_Property>();
                DataTable dtPartyMaster = clientDetail.Ledger_GetData(SessionDetails.ClientSession.connectionString);
                FormPartyNameList = (from DataRow dr in dtPartyMaster.Rows
                                     select new Ledger_Master_Property()
                                     {
                                         Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
                                         Ledger_Name = dr["Ledger_Name"].ToString()
                                     }).ToList();

                ViewBag.Party_Name = new MultiSelectList(FormPartyNameList, "Ledger_Code", "Ledger_Name");
                Session["PartyMaster"] = dtPartyMaster;

                List<Item_Master_Property> FormItemNameList = new List<Item_Master_Property>();
                DataTable dtItemMaster = clientDetail.Item_GetData(SessionDetails.ClientSession.connectionString);
                FormItemNameList = (from DataRow dr in dtItemMaster.Rows
                                    select new Item_Master_Property()
                                    {
                                        Item_Code = Convert.ToInt32(dr["Item_Code"]),
                                        Item_Name = dr["Item_Name"].ToString()
                                    }).ToList();

                ViewBag.Item_Name = new MultiSelectList(FormItemNameList, "Item_Code", "Item_Name");
                Session["State_Code"] = SessionDetails.ClientSession.State_ID;
                Session["ItemMaster"] = dtItemMaster;

                List<JobCard_Master_Property> FormJobCardList = new List<JobCard_Master_Property>();
                DataTable dtJobCard = clientDetail.JobCard_Dropdown(SessionDetails.ClientSession.connectionString);
                FormJobCardList = (from DataRow dr in dtJobCard.Rows
                                   select new JobCard_Master_Property()
                                   {
                                       Job_ID = Convert.ToInt32(dr["Job_ID"]),
                                       Registration_No = dr["Registration_No"].ToString()
                                   }).ToList();

                ViewBag.Card_Type = new MultiSelectList(FormJobCardList, "Job_ID", "Registration_No");
                Session["JobCard_Master"] = dtJobCard;

                List<Unit_Master_Property> FormUnitList = new List<Unit_Master_Property>();
                FormUnitList = (from DataRow dr in clientDetail.Unit_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                select new Unit_Master_Property()
                                {
                                    Unit_ID = Convert.ToInt32(dr["Unit_ID"]),
                                    Unit_Name = dr["Unit_Name"].ToString()
                                }).ToList();

                ViewBag.FormUnitList = new MultiSelectList(FormUnitList, "Unit_ID", "Unit_Name");

                return View();

            }
            else
            {
                return RedirectToAction("Error", "Master");
            }
        }

        public ActionResult EstimateEntry()
        {
            if (((DataTable)Session["ModuleTable"]).Select("Module_ID = '6'").Count() > 0)
            {

                IList<SelectListItem> Payment_Type = new List<SelectListItem>();
                Payment_Type.Add(new SelectListItem { Text = "CREDIT", Value = "CREDIT" });
                Payment_Type.Add(new SelectListItem { Text = "DEBIT", Value = "DEBIT" });
                SelectList SelPayment_Type = new SelectList(Payment_Type, "Value", "Text", "CREDIT");
                ViewBag.Payment_Type = SelPayment_Type;

                //IList<SelectListItem> Card_Type = new List<SelectListItem>();
                //Card_Type.Add(new SelectListItem { Text = "3", Value = "3" });
                //Card_Type.Add(new SelectListItem { Text = "4", Value = "4" });
                //Card_Type.Add(new SelectListItem { Text = "5", Value = "5" });
                //SelectList SelCard_Type = new SelectList(Card_Type, "Value", "Text", "1");
                //ViewBag.Card_Type = SelCard_Type;


                List<JobCard_Master_Property> FormJobCardList = new List<JobCard_Master_Property>();
                DataTable dtJobCard = clientDetail.JobCard_Dropdown(SessionDetails.ClientSession.connectionString);
                FormJobCardList = (from DataRow dr in dtJobCard.Rows
                                   select new JobCard_Master_Property()
                                   {
                                       Job_ID = Convert.ToInt32(dr["Job_ID"]),
                                       Registration_No = dr["Registration_No"].ToString()
                                   }).ToList();

                ViewBag.Card_Type = new MultiSelectList(FormJobCardList, "Job_ID", "Registration_No");
                Session["JobCard_Master"] = dtJobCard;

                List<Ledger_Master_Property> FormPartyNameList = new List<Ledger_Master_Property>();
                DataTable dtPartyMaster = clientDetail.Ledger_GetData(SessionDetails.ClientSession.connectionString);
                FormPartyNameList = (from DataRow dr in dtPartyMaster.Rows
                                     select new Ledger_Master_Property()
                                     {
                                         Ledger_Code = Convert.ToInt32(dr["Ledger_Code"]),
                                         Ledger_Name = dr["Ledger_Name"].ToString()
                                     }).ToList();

                ViewBag.Party_Name = new MultiSelectList(FormPartyNameList, "Ledger_Code", "Ledger_Name");
                Session["PartyMaster"] = dtPartyMaster;

                List<Item_Master_Property> FormItemNameList = new List<Item_Master_Property>();
                DataTable dtItemMaster = clientDetail.Item_GetData(SessionDetails.ClientSession.connectionString);
                FormItemNameList = (from DataRow dr in dtItemMaster.Rows
                                    select new Item_Master_Property()
                                    {
                                        Item_Code = Convert.ToInt32(dr["Item_Code"]),
                                        Item_Name = dr["Item_Name"].ToString()
                                    }).ToList();

                ViewBag.Item_Name = new MultiSelectList(FormItemNameList, "Item_Code", "Item_Name");
                Session["State_Code"] = SessionDetails.ClientSession.State_ID;
                Session["ItemMaster"] = dtItemMaster;

                List<Unit_Master_Property> FormUnitList = new List<Unit_Master_Property>();
                FormUnitList = (from DataRow dr in clientDetail.Unit_Master_GetData(SessionDetails.ClientSession.connectionString).Rows
                                select new Unit_Master_Property()
                                {
                                    Unit_ID = Convert.ToInt32(dr["Unit_ID"]),
                                    Unit_Name = dr["Unit_Name"].ToString()
                                }).ToList();

                ViewBag.FormUnitList = new MultiSelectList(FormUnitList, "Unit_ID", "Unit_Name");

                return View();
            }
            else
            {
                return RedirectToAction("Error", "Master");
            }
        }

        public JsonResult GetSalesDetails(string From_Date, string To_Date)
        {
            DataTable TransSummary = clientDetail.Purchase_Sale_GetData("S", From_Date, To_Date, SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(TransSummary);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSalesDetailEdit(string SaleMasterID)
        {
            DataTable TransSummary = clientDetail.GetSalesDetailEdit("S", SaleMasterID, SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(TransSummary);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetItemDetails(string itemCode, string PartyCode)
        {
            try
            {
                string unitCode = "";
                string unitName = "";
                string HSN = "";
                string HSNID = "";
                string Rate = "";
                string SGST = "";
                string CGST = "";
                string IGST = "";
                DataTable dtItemMaster = (DataTable)Session["ItemMaster"];
                DataTable dtPartyMaster = (DataTable)Session["PartyMaster"];
                if (dtItemMaster.Rows.Count > 0)
                {
                    DataRow[] dr = dtItemMaster.Select("Item_Code = " + Convert.ToInt32(itemCode));
                    DataRow[] dr_party = dtPartyMaster.Select("Ledger_Code = " + Convert.ToInt32(PartyCode));
                    if (dr != null)
                    {
                        if (dr.Length > 0)
                        {
                            unitCode = dr[0]["Unit_Code"].ToString();
                            unitName = dr[0]["Unit_Name"].ToString();
                            HSN = dr[0]["Hsn_Code"].ToString();
                            HSNID = dr[0]["Hsn_ID"].ToString();
                            Rate = dr[0]["Sale_Rate"].ToString();
                            if (dr_party != null)
                            {
                                if (dr_party.Length > 0)
                                {
                                    if (dr_party[0]["Party_State_Code"].ToString() == Convert.ToInt32(Session["State_Code"].ToString()).ToString())
                                    {
                                        SGST = dr[0]["Sgst_Rate"].ToString();
                                        CGST = dr[0]["Cgst_Rate"].ToString();
                                        IGST = "0";
                                    }
                                    else
                                    {
                                        SGST = "0";
                                        CGST = "0";
                                        IGST = dr[0]["Igst_Rate"].ToString();
                                    }
                                }
                            }
                        }
                    }
                }
                return Json(new
                {
                    success = true,
                    unitCode = unitCode.ToString(),
                    unitName = unitName,
                    HSN = HSN,
                    HSNID = HSNID,
                    Rate = Rate,
                    SGST = SGST,
                    CGST = CGST,
                    IGST = IGST,
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

        #region JOBCARD
        [HttpPost]
        public JsonResult onjobcardchange(string Job_ID, string PartyCode)
        {
            try
            {

                string Ledger_Code = "";
                 string MobileNo = "";
                string RegNo = "";
                string Model = "";
                string KM = "";
               

                //DataTable dtJobCard = (DataTable)Session["JobCard_Master"];
                DataTable dtPartyMaster = (DataTable)Session["PartyMaster"];
                DataTable dtJobCard = clientDetail.JobCard_Fill(SessionDetails.ClientSession.connectionString, Job_ID);
                if (dtJobCard.Rows.Count > 0)
                {
                    DataRow[] dr = dtJobCard.Select("Job_ID = " + Convert.ToInt32(Job_ID));
                    //DataRow[] dr_party = dtPartyMaster.Select("Ledger_Code = " + Convert.ToInt32(PartyCode));
                    if (dr != null)
                    {
                        if (dr.Length > 0)
                        {

                            Ledger_Code = dr[0]["Ledger_Code"].ToString();
                            MobileNo = dr[0]["Contact_Person"].ToString();
                            RegNo = dr[0]["Registration_No"].ToString();
                            Model = dr[0]["Model_No"].ToString();
                            KM = dr[0]["Milage"].ToString();
                            


                           
                        }
                    }
                }
                return Json(new
                {
                    success = true,

                    Ledger_Code = Ledger_Code,
                    MobileNo = MobileNo,
                    RegNo = RegNo,
                    Model = Model,
                    KM = KM,
                   


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
        #endregion

        //public JsonResult OnItemUnitChange(string Item_Code)
        //{
        //    try
        //    {

        //        string Unit_Code = "";



        //        //DataTable dtJobCard = (DataTable)Session["JobCard_Master"];
        //        DataTable dtPartyMaster = (DataTable)Session["PartyMaster"];
        //        DataTable dtItemMaster = clientDetail.ItemUnit_Fill(SessionDetails.ClientSession.connectionString, Item_Code);
        //        if (dtItemMaster.Rows.Count > 0)
        //        {
        //            DataRow[] dr = dtItemMaster.Select("Item_Code = " + Convert.ToInt32(Item_Code));
        //            //DataRow[] dr_party = dtPartyMaster.Select("Ledger_Code = " + Convert.ToInt32(PartyCode));
        //            if (dr != null)
        //            {
        //                if (dr.Length > 0)
        //                {

        //                    Unit_Code = dr[0]["Unit_Code"].ToString();





        //                }
        //            }
        //        }
        //        return Json(new
        //        {
        //            success = true,

        //            Unit_Code = Unit_Code,



        //        }, JsonRequestBehavior.AllowGet);

        //    }
        //    catch (Exception ex)
        //    {
        //        //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
        //        return Json(new
        //        {
        //            success = false,
        //            message = "Sales saved failed"
        //        }, JsonRequestBehavior.AllowGet);
        //    }
        //}


        [HttpPost]
        public JsonResult Sales_SaveForm(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            try
            {
                string msg = "";
                int Sales_ID = 0;

                Sales_ID = clientDetail.SalesMaster_Save(Sales_Master_Property, SessionDetails.ClientSession.connectionString);
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

        [HttpPost]
        public JsonResult Sales_Detail_Save(IList<UpKeep.ClientDetail.Sales_Master_Property> Sales_Master_Property)
        {
            try
            {
                if (Sales_Master_Property != null)
                {
                    string msg = "";
                    int Sales_ID = 0;
//                    for (int i = 0; i < Sales_Master_Property.Count; i++)
                    {
                       // Sales_ID = clientDetail.Sales_Detail_Save(Sales_Master_Property[i], SessionDetails.ClientSession.connectionString);
                        Sales_ID = clientDetail.Sales_Detail_SaveXML(Sales_Master_Property.ToArray(), SessionDetails.ClientSession.connectionString);

                    }
                    msg = "Sales Saved successfully";

                    return Json(new
                    {
                        success = true,
                        message = msg,
                    }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new
                    {
                        success = true,
                        message = "Null Property",
                    }, JsonRequestBehavior.AllowGet);
                }
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

        [HttpPost]
        public JsonResult Transaction_Detail_Delete(string From_Type, string ItemMasterID, string ItemDetailID)
        {
            try
            {
                string msg = "";
                int Sales_ID = 0;

                Sales_ID = clientDetail.Transaction_Detail_Delete(From_Type, Convert.ToInt32(ItemMasterID), Convert.ToInt32(ItemDetailID), SessionDetails.ClientSession.connectionString);
                msg = "Sales Detail deleted successfully!";

                return Json(new
                {
                    success = true,
                    message = msg,
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Sales Detail delete failed!"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Estimate_SaveForm(UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property)
        {
            try
            {
                string msg = "";
                int Sales_ID = 0;

                Sales_ID = clientDetail.EstimateMaster_Save(Sales_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = "Estimate Saved successfully";

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
                    message = "Estimate saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }
        //UpKeep.ClientDetail.Sales_Master_Property Sales_Master_Property UpKeep.ClientDetail.Sales_Master_Property[]
        [HttpPost]
        public JsonResult Estimate_Detail_Save(IList<UpKeep.ClientDetail.Sales_Master_Property>  Sales_Master_Property)
        {
            try
            {
                string msg = "";
                int Sales_ID = 0;
                //for (int i = 0; i < Sales_Master_Property.Count; i++)
                {
                   // Sales_ID = clientDetail.Estimate_Detail_Save(Sales_Master_Property[i], SessionDetails.ClientSession.connectionString);
                    Sales_ID = clientDetail.Estimate_Detail_SaveXML(Sales_Master_Property.ToArray(), SessionDetails.ClientSession.connectionString);

                }
                msg = "Estimate Saved successfully";

                return Json(new
                {
                    success = true,
                    message = msg,
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                //ErrorLogger.ErrorLog(ex, System.Web.HttpContext.Current);
                return Json(new
                {
                    success = false,
                    message = "Estimate saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetEstimateDetails(string From_Date, string To_Date)
        {
            DataTable TransSummary = clientDetail.Purchase_Sale_GetData("ES", From_Date, To_Date, SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(TransSummary);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetEstimateDetailEdit(string SaleMasterID)
        {
            DataTable TransSummary = clientDetail.GetSalesDetailEdit("ES", SaleMasterID, SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(TransSummary);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult Ledger_SaveForm( string Party_Name,string Mobile_No)
        {
            try
            {
                UpKeep.ClientDetail.Ledger_Master_Property Ledger_Master_Property=new  ClientDetail.Ledger_Master_Property();
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

        public JsonResult ItemUniSaveForm(string Item_Name , string Unit_Code)
        {
            try
            {
                UpKeep.ClientDetail.Item_Master_Property Item_Master_Property = new ClientDetail.Item_Master_Property();
                
                string msg = "";
                int Sales_ID = 0;

                Item_Master_Property.Unit_Code = Unit_Code;
                Item_Master_Property.Item_Name = Item_Name;
                Item_Master_Property.Active = 1;
                Item_Master_Property.Company_Code = 1;
                Item_Master_Property.Branch_Code = 1;
                Item_Master_Property.Location_Code = 1;
                Item_Master_Property.Item_Group_Code = 3;
                Item_Master_Property.Item_Category_Code = 2;



               
                Sales_ID = clientDetail.Item_Master_Save(Item_Master_Property, SessionDetails.ClientSession.connectionString);
                msg = " Saved successfully";

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
        [HttpGet]
        public ActionResult GetItemUnitMaster()
        {
            DataTable dtItemMaster = clientDetail.Item_Master_GetData(SessionDetails.ClientSession.connectionString);
            IEnumerable<SelectListItem> Itemnamelist = (from DataRow dr in dtItemMaster.Rows select new SelectListItem() { Value = dr["Item_Code"].ToString(), Text = Convert.ToString(dr["Item_Name"]) });
            var result = new SelectList(Itemnamelist, "Value", "Text");
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult GetPartyMobileNo(string PartyCode)
        {
            
            DataTable dtPartyMaster = clientDetail.Ledger_GetData(SessionDetails.ClientSession.connectionString);
            string mob = "";
            if (PartyCode != "")
            {
                DataRow[] dr = dtPartyMaster.Select("Ledger_Code=" + PartyCode + "");

                mob = dr[0]["Party_Mobile"].ToString();
            }
                return Json(new
            {

                success = true,
                mob = mob
                
                
            }, JsonRequestBehavior.AllowGet);
        }



    }

    
}