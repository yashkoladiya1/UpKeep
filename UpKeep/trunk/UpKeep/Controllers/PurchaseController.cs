using DLL.PropertyClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UpKeep.Utility;

namespace UpKeep.Controllers
{
    [SessionExpireFilterAttribute]
    [AuthorizeUserAttribute]
    public class PurchaseController : Controller
    {
        // GET: Purchase
        ClientDetail.Client_ServiceSoapClient clientDetail = new ClientDetail.Client_ServiceSoapClient();

        public ActionResult PurchaseItem()
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

                return View();
            }
            else
            {
                return RedirectToAction("Error", "Master");
            }
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
                            Rate = dr[0]["Last_Purchase_Rate"].ToString();
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

        public JsonResult Purchase_Master_Save(UpKeep.ClientDetail.PurchaseMaster_Property PurchaseMaster_Property)
        {
            try
            {
                int Purchase_ID = 0;
                string msg = "";
                Purchase_ID = clientDetail.PurchaseMaster_Save(PurchaseMaster_Property, SessionDetails.ClientSession.connectionString);
                msg = "Purchase Saved successfully";
                return Json(new
                {
                    success = true,
                    message = msg,
                    Purchase_ID = Purchase_ID.ToString()
                }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception ex)
            {
                return Json(new
                {
                    success = false,
                    message = "Purchase saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult Purchase_Detail_Save(UpKeep.ClientDetail.PurchaseMaster_Property PurchaseMaster_Property)
        {
            try
            {
                string msg = "";
                clientDetail.PurchaseDetail_Save(PurchaseMaster_Property, SessionDetails.ClientSession.connectionString);
                msg = "Purchase Detail Saved successfully";

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
                    message = "Purchase saved failed"
                }, JsonRequestBehavior.AllowGet);
            }
        }


        public JsonResult GetPurchaseDetails(string From_Date, string To_Date)
        {
            DataTable TransSummary = clientDetail.Purchase_Sale_GetData("P", From_Date, To_Date, SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(TransSummary);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPurchaseDetailEdit(string PurchaseMasterID)
        {
            DataTable TransSummary = clientDetail.GetSalesDetailEdit("P", PurchaseMasterID, SessionDetails.ClientSession.connectionString);
            DataTableToList DataTableToList = new DataTableToList();
            var List = DataTableToList.ToDynamicList(TransSummary);
            int totalRecords = List.Count;

            return Json(new
            {
                List
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Transaction_Detail_Delete(string From_Type, string ItemMasterID, string ItemDetailID)
        {
            try
            {
                string msg = "";
                int Sales_ID = 0;

                Sales_ID = clientDetail.Transaction_Detail_Delete(From_Type, Convert.ToInt32(ItemMasterID), Convert.ToInt32(ItemDetailID), SessionDetails.ClientSession.connectionString);
                msg = "Purchase Detail deleted successfully!";

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
                    message = "Purchase Detail delete failed!"
                }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}