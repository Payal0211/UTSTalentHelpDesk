using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net;
using UTSTalentHelpDesk.Helpers.Common;
using UTSTalentHelpDesk.Models.Models;
using UTSTalentHelpDesk.Models.ViewModels;
using UTSTalentHelpDesk.Repositories.Interfaces;
using static UTSTalentHelpDesk.Config.HubSpotResponseUTSAdmin;

namespace UTSTalentHelpDesk.Controllers
{
    [Route("ZohoInvoice/", Name = "ZohoInvoice")]
    [ApiController]
    public class ZohoInvoiceWebhookController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IConfigurationSection zohoConfig;
        private readonly IZohoInvoice _iZohoInvoice;
        private readonly HttpClient _httpClient;


        public ZohoInvoiceWebhookController(IConfiguration configuration, IHttpClientFactory httpClientFactory, IZohoInvoice iZohoInvoice, HttpClient httpClient)
        {
            _configuration = configuration;
            _httpClientFactory = httpClientFactory;
            zohoConfig = _configuration.GetSection("Zoho");
            _iZohoInvoice = iZohoInvoice;
            _httpClient = httpClient;
           
        }

        [HttpPost]
        public JsonResult ZohoInvoiceUpdateWebhook(ZohoInvoiceWebhook zohoInvoiceWebhook)
        {
            string AllErrorMessages = "";
            bool HasError = false;

            string fileName = Server.MapPath("~\\WebhookFiles") + "\\WebhookZohoInvoiceUpdate_" + zohoInvoiceWebhook.InvoiceID + "_" + DateTime.Now.Ticks + ".txt";
            _commonHelper.SaveRequestInFile(fileName, zohoInvoiceWebhook);


            if (!string.IsNullOrEmpty(zohoInvoiceWebhook.InvoiceID) && !string.IsNullOrEmpty(zohoInvoiceWebhook.Auth_Key) && !string.IsNullOrEmpty(zohoInvoiceWebhook.Auth_Token))
            {
                if (zohoInvoiceWebhook.Auth_Token == "1000.U9F8JM009PPO1XFEZLADIYBV6QXSYH")
                {
                    string zohoContactAPIURL = Config.ProjectAPIURL + "WebhookupdateZohoInvoiceWithLineItem";
                    StreamWriter requestWriter;

                    // Create a new HttpWebRequest object.
                    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(zohoContactAPIURL);
                    if (webRequest != null)
                    {
                        webRequest.Method = "POST";
                        webRequest.ServicePoint.Expect100Continue = false;
                        webRequest.Timeout = 50000;

                        webRequest.ContentType = "application/json";
                        //POST the data.
                        using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                        {
                            string json = JsonConvert.SerializeObject(new { InvoiceID = zohoInvoiceWebhook.InvoiceID, OrganizationID = zohoInvoiceWebhook.Auth_Key });

                            requestWriter.Write(json);

                            requestWriter.Flush();
                            requestWriter.Close();

                        }
                    }

                    HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                    Stream resStream = response.GetResponseStream();
                    StreamReader reader = new StreamReader(resStream);
                    string ResponseJson = reader.ReadToEnd();

                    if (!string.IsNullOrEmpty(ResponseJson))
                    {
                        //When Invoice Is Paid then trigger invoice status to PMS.
                        if (!string.IsNullOrEmpty(zohoInvoiceWebhook.InvoiceStatus) && zohoInvoiceWebhook.InvoiceStatus.ToLower() == "paid")
                        {
                            long? ZohoInvoiceId = string.IsNullOrEmpty(zohoInvoiceWebhook.InvoiceID) == false ? Convert.ToInt64(zohoInvoiceWebhook.InvoiceID) : 0;
                            var newInvoice = db.gen_UPL_Invoice.Where(xy => xy.Zoho_Invoice_ID == ZohoInvoiceId).FirstOrDefault();
                            if (newInvoice != null && newInvoice.ID > 0)
                            {
                                var checkBookingExist = db.gen_UPL_Booking.Where(xy => xy.IsDeleted == false && xy.UPLInvoiceId == newInvoice.ID).FirstOrDefault();
                                if (checkBookingExist == null || checkBookingExist.Id == 0)
                                {
                                    BookinghelperObj.CreateBooking("Invoice Status Updated to Paid", newInvoice, newInvoice.ID, 0);
                                }
                            }

                            var PMSObject = new PMSController().UpdateInvoiceStatusToPMS(zohoInvoiceWebhook.InvoiceID, zohoInvoiceWebhook.InvoiceStatus);
                        }
                        else if (!string.IsNullOrEmpty(zohoInvoiceWebhook.InvoiceStatus) && zohoInvoiceWebhook.InvoiceStatus.ToLower() == "sent")
                        {
                            long? ZohoInvoiceId = string.IsNullOrEmpty(zohoInvoiceWebhook.InvoiceID) == false ? Convert.ToInt64(zohoInvoiceWebhook.InvoiceID) : 0;
                            var newInvoice = db.gen_UPL_Invoice.Where(xy => xy.Zoho_Invoice_ID == ZohoInvoiceId).FirstOrDefault();
                            if (newInvoice != null && newInvoice.ID > 0 && newInvoice.IsCreditNoteDeduct == false)
                            {
                                BookinghelperObj.CreateBooking("Invoice Status Updated to Sent", newInvoice, newInvoice.ID, 0);
                            }
                        }

                        var jSonReponse1 = new
                        {
                            HasError = false,
                            Message = ResponseJson
                        };

                        return Json(jSonReponse1, JsonRequestBehavior.AllowGet);
                    }
                }// end of Auth Token
            }

            if (!string.IsNullOrEmpty(AllErrorMessages))
            {
                HasError = true;
            }

            var jSonReponse = new
            {
                HasError = HasError,
                ErrorMessage = AllErrorMessages
            };

            return Json("Success", JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult ZohoContactUpdateWebhook(ZohoCustomerWebhook zohoCustomerWebhook)
        {         
            try
            {
                if (zohoCustomerWebhook != null)
                {
                    long zohoOrganizationId = 0;
                    long.TryParse(zohoCustomerWebhook.Auth_Key, out zohoOrganizationId);

                    //Check if valid organization then update customer.
                    var ZohoOrganization = db.prg_ZohoOrganizations.Where(xy => xy.ZohoOrganizationID == zohoOrganizationId).FirstOrDefault();
                    if (ZohoOrganization != null && zohoCustomerWebhook.Customer_Id != null)
                    {
                        string zohoContactAPIURL = Config.ProjectAPIURL + "GetZohoContactDetails";
                        StreamWriter requestWriter;

                        // Create a new HttpWebRequest object.
                        HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(zohoContactAPIURL);
                        if (webRequest != null)
                        {
                            webRequest.Method = "POST";
                            webRequest.ServicePoint.Expect100Continue = false;
                            webRequest.Timeout = 50000;

                            webRequest.ContentType = "application/json";
                            //POST the data.
                            using (requestWriter = new StreamWriter(webRequest.GetRequestStream()))
                            {
                                string json = JsonConvert.SerializeObject(new { ZohoCustomerId = zohoCustomerWebhook.Customer_Id, ZohoOrganizationId = zohoOrganizationId });

                                requestWriter.Write(json);

                                requestWriter.Flush();
                                requestWriter.Close();

                            }
                        }

                        //Get response of new Pins
                        HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse();
                        Stream resStream = response.GetResponseStream();
                        StreamReader reader = new StreamReader(resStream);
                        string ResponseJson = reader.ReadToEnd();

                        if (!string.IsNullOrEmpty(ResponseJson))
                        {
                            JObject ResponseJObject = JObject.Parse(ResponseJson);
                            dynamic Response = ResponseJObject;

                            if (Response.Contact != null)
                            {
                                if (Response.Contact.is_taxable == null)
                                {
                                    Response.Contact.is_taxable = false;
                                }

                                ZohoContact zohoContact = JsonConvert.DeserializeObject<ZohoContact>(Convert.ToString(ResponseJObject["Contact"]));

                                string contact_id = Convert.ToString(zohoContact.contact_id);

                                //Check if customer found then update details. Not found then create.
                                gen_ZOHO_Customer localZohoCustomer = db.gen_ZOHO_Customer.Where(xy => xy.Customer_ID == contact_id && xy.Zoho_Organization_ID == ZohoOrganization.ZohoOrganizationID).FirstOrDefault();
                                if (localZohoCustomer == null || localZohoCustomer.ID == 0)
                                {
                                    localZohoCustomer = new gen_ZOHO_Customer();
                                }

                                localZohoCustomer.Zoho_Organization_ID = ZohoOrganization.ZohoOrganizationID;

                                DateTime dtCreatedDateTime = Convert.ToDateTime(CommonFunction.GetCurrentDateTime());
                                DateTime.TryParse(zohoContact.created_time, out dtCreatedDateTime);

                                DateTime dtLastModifiedDateTime = Convert.ToDateTime(CommonFunction.GetCurrentDateTime());
                                DateTime.TryParse(zohoContact.last_modified_time, out dtLastModifiedDateTime);

                                localZohoCustomer.Created_Time = dtCreatedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                                localZohoCustomer.Last_Modified_Time = dtLastModifiedDateTime.ToString("yyyy-MM-dd HH:mm:ss");
                                localZohoCustomer.Customer_ID = Convert.ToString(zohoContact.contact_id);
                                localZohoCustomer.Customer_Name = zohoContact.contact_name;
                                localZohoCustomer.Display_Name = zohoContact.contact_name;
                                localZohoCustomer.Company_Name = zohoContact.company_name;

                                string PrimaryContactEmail = "";

                                //Get primary contact person details
                                var zohoContactPrimaryPerson = zohoContact.contact_persons.Where(xy => xy.is_primary_contact == true).FirstOrDefault();
                                if (zohoContactPrimaryPerson != null)
                                {
                                    localZohoCustomer.Salutation = zohoContactPrimaryPerson.salutation;
                                    localZohoCustomer.First_Name = zohoContactPrimaryPerson.first_name;
                                    localZohoCustomer.Last_Name = zohoContactPrimaryPerson.last_name;
                                    localZohoCustomer.EmailID = zohoContactPrimaryPerson.email;
                                    localZohoCustomer.Phone = zohoContactPrimaryPerson.phone;
                                    localZohoCustomer.MobilePhone = zohoContactPrimaryPerson.mobile;
                                    localZohoCustomer.Department = zohoContactPrimaryPerson.department;
                                    localZohoCustomer.Designation = zohoContactPrimaryPerson.designation;
                                    PrimaryContactEmail = zohoContactPrimaryPerson.email;
                                }

                                localZohoCustomer.Facebook = zohoContact.facebook;
                                localZohoCustomer.Twitter = zohoContact.twitter;
                                localZohoCustomer.Payment_Terms = Convert.ToString(zohoContact.payment_terms);

                                localZohoCustomer.IsActive = false;
                                if (zohoContact.status != null && Convert.ToString(zohoContact.status).ToLower() == "active")
                                {
                                    localZohoCustomer.IsActive = true;
                                }

                                //Find matching payment term label from master table.
                                var PaymentTermLabel = db.prg_UPL_Invoice_Payment_Term.Where(xy => xy.Value == zohoContact.payment_terms).FirstOrDefault();
                                if (PaymentTermLabel != null)
                                {
                                    localZohoCustomer.Payment_Terms_Label = PaymentTermLabel.Payment_Term;
                                }

                                //Find currency code from currency id
                                var CurrencyDetails = (from CM in db.prg_CurrencyConversionFrom
                                                       join ZC in db.prg_ZohoOrganizationCurrencies on CM.ID equals ZC.CurrencyConversionFromId
                                                       where ZC.CurrencyId == zohoContact.currency_id
                                                       select new { CM.CurrencyCode, ZC.CurrencyId }).FirstOrDefault();

                                if (CurrencyDetails != null)
                                {
                                    localZohoCustomer.Currency_Code = CurrencyDetails.CurrencyCode;
                                }

                                localZohoCustomer.Notes = zohoContact.notes;
                                localZohoCustomer.Website = zohoContact.website;

                                if (zohoContact.billing_address != null)
                                {
                                    localZohoCustomer.Billing_Attention = zohoContact.billing_address.attention;
                                    localZohoCustomer.Billing_Address = zohoContact.billing_address.address;
                                    localZohoCustomer.Billing_Street2 = zohoContact.billing_address.street2;
                                    localZohoCustomer.Billing_City = zohoContact.billing_address.city;
                                    localZohoCustomer.Billing_State = zohoContact.billing_address.state;
                                    localZohoCustomer.Billing_Country = zohoContact.billing_address.country;
                                    localZohoCustomer.Billing_Code = zohoContact.billing_address.zip;
                                    localZohoCustomer.Billing_Phone = zohoContact.billing_address.phone;
                                    localZohoCustomer.Billing_Fax = zohoContact.billing_address.fax;
                                }

                                if (zohoContact.shipping_address != null)
                                {
                                    localZohoCustomer.Shipping_Attention = zohoContact.shipping_address.attention;
                                    localZohoCustomer.Shipping_Address = zohoContact.shipping_address.address;
                                    localZohoCustomer.Shipping_Street2 = zohoContact.shipping_address.street2;
                                    localZohoCustomer.Shipping_City = zohoContact.shipping_address.city;
                                    localZohoCustomer.Shipping_State = zohoContact.shipping_address.state;
                                    localZohoCustomer.Shipping_Country = zohoContact.shipping_address.country;
                                    localZohoCustomer.Shipping_Code = zohoContact.shipping_address.zip;
                                    localZohoCustomer.Shipping_Phone = zohoContact.shipping_address.phone;
                                    localZohoCustomer.Shipping_Fax = zohoContact.shipping_address.fax;
                                }

                                if (localZohoCustomer.ID == 0)
                                {
                                    db.gen_ZOHO_Customer.Add(localZohoCustomer);
                                    db.SaveChanges();
                                }
                                else
                                {
                                    db.Entry(localZohoCustomer).State = System.Data.Entity.EntityState.Modified;
                                    db.SaveChanges();
                                }

                                if (zohoContact.contact_persons != null)
                                {
                                    foreach (var contactPerson in zohoContact.contact_persons)
                                    {
                                        string contact_person_id = Convert.ToString(contactPerson.contact_person_id);
                                        //Check if contact person id is exist or not. Not exist then add.
                                        gen_ZOHOContact ContactPersonExist = db.gen_ZOHOContact.Where(xy => xy.Contact_Person_ID == contact_person_id && xy.Customer_ID == localZohoCustomer.Customer_ID).FirstOrDefault();
                                        if (ContactPersonExist == null || ContactPersonExist.ID == 0)
                                        {
                                            ContactPersonExist = new gen_ZOHOContact();
                                        }

                                        ContactPersonExist.Contact_Person_ID = Convert.ToString(contactPerson.contact_person_id);
                                        ContactPersonExist.Customer_ID = localZohoCustomer.Customer_ID;
                                        ContactPersonExist.Customer_Name = localZohoCustomer.Customer_Name;
                                        ContactPersonExist.Display_Name = localZohoCustomer.Customer_Name;
                                        ContactPersonExist.EmailID = contactPerson.email;
                                        ContactPersonExist.First_Name = contactPerson.first_name;
                                        ContactPersonExist.Is_Primary = Convert.ToString(contactPerson.is_primary_contact);
                                        ContactPersonExist.Last_Modified_Time = Convert.ToDateTime(CommonFunction.GetCurrentDateTime()).ToString("yyyy-MM-dd HH:mm:ss");
                                        ContactPersonExist.Last_Name = contactPerson.last_name;
                                        ContactPersonExist.MobilePhone = contactPerson.mobile;
                                        ContactPersonExist.Phone = contactPerson.phone;
                                        ContactPersonExist.Salutation = contactPerson.salutation;
                                        ContactPersonExist.Designation = contactPerson.designation;
                                        ContactPersonExist.Department = contactPerson.department;

                                        if (ContactPersonExist.ID == 0)
                                        {
                                            db.gen_ZOHOContact.Add(ContactPersonExist);
                                            db.SaveChanges();
                                        }
                                        else
                                        {
                                            db.Entry(ContactPersonExist).State = System.Data.Entity.EntityState.Modified;
                                            db.SaveChanges();
                                        }
                                    }
                                }

                                //Update ZohoCustomerId in gen_Contact table when ZohoCustomerId is null.
                                var contactDetails = db.gen_Contact.Where(xy => xy.EmailID == PrimaryContactEmail && xy.ZohoOrganization_ID == zohoOrganizationId).FirstOrDefault();
                                if (contactDetails != null)
                                {
                                    contactDetails.ZOHO_Customer_ID = Convert.ToString(zohoContact.contact_id);
                                    db.Entry(contactDetails).State = System.Data.Entity.EntityState.Modified;
                                    db.SaveChanges();

                                    //Update ZohoCustomerId in gen_Company table when ZOHO_Primary_Customer_ID is null.
                                    var companyDetails = db.gen_Company.Where(xy => xy.CompanyID == contactDetails.CompanyID).FirstOrDefault();
                                    if (companyDetails != null)
                                    {
                                        companyDetails.ZOHO_Primary_Customer_ID = Convert.ToString(zohoContact.contact_id);

                                        companyDetails.WalletBalance = zohoContact.unused_credits_receivable_amount;
                                        companyDetails.IsWallet = zohoContact.unused_credits_receivable_amount > 0 ? true : false;


                                        db.Entry(companyDetails).State = System.Data.Entity.EntityState.Modified;
                                        db.SaveChanges();

                                        var CompanyZohoMappingTable = db.gen_CompanyMapping_ZohoCustomers.Where(xy => xy.CompanyID == companyDetails.CompanyID && xy.ZohoOrganization_ID == zohoOrganizationId).FirstOrDefault();
                                        if (CompanyZohoMappingTable != null)
                                        {
                                            CompanyZohoMappingTable.ZOHO_Primary_Customer_ID = Convert.ToString(zohoContact.contact_id);
                                            db.Entry(CompanyZohoMappingTable).State = System.Data.Entity.EntityState.Modified;
                                            db.SaveChanges();
                                        }
                                        else
                                        {
                                            CompanyZohoMappingTable = new gen_CompanyMapping_ZohoCustomers();
                                            CompanyZohoMappingTable.ZOHO_Primary_Customer_ID = Convert.ToString(zohoContact.contact_id);
                                            CompanyZohoMappingTable.ZohoOrganization_ID = zohoOrganizationId;
                                            CompanyZohoMappingTable.CompanyID = companyDetails.CompanyID;
                                            db.gen_CompanyMapping_ZohoCustomers.Add(CompanyZohoMappingTable);
                                            db.SaveChanges();
                                        }
                                    }
                                }

                            }
                        }
                    }
                }

                return Json("Success");
            }
            catch (Exception ex)
            {
                _commonHelper.SaveRequestInFile(errorFileName, ex.Message);

                return Json("Error");
            }
        }

        //[HttpPost]
        //public JsonResult GetZohoContactDetails(string ZohoCustomerId, string ZohoOrganizationId)
        //{
        //    if (!string.IsNullOrEmpty(ZohoCustomerId))
        //    {
        //        string ZohoBookApi = Config.ZohoApi + "/contacts/" + ZohoCustomerId + "?";

        //        var JsonList = ZohoInvoiceConfiguration.WebClinetZohoAPI(ZohoBookApi, "get", "", "Contact", "", ZohoOrganizationId);

        //        if (JsonList != null && JsonList["code"] != null && JsonList["code"].ToString() == "0")
        //        {
        //            if (JsonList != null && JsonList["contact"] != null && JsonList["contact"].Count() > 0)
        //            {
        //                ContactAPI FoundContact = JsonConvert.DeserializeObject<ContactAPI>(Convert.ToString(JsonList["contact"]));

        //                if (FoundContact != null)
        //                {
        //                    var apiJSonResponse = new
        //                    {
        //                        Contact = FoundContact,
        //                    };

        //                    return Json(apiJSonResponse, JsonRequestBehavior.AllowGet);
        //                }
        //                else
        //                {
        //                    var apiJSonResponse = new
        //                    {
        //                        Code = "",
        //                        ErrorMessage = ""
        //                    };

        //                    return Json(apiJSonResponse, JsonRequestBehavior.AllowGet);
        //                }
        //            }
        //            else
        //            {
        //                var apiJSonResponse = new
        //                {
        //                    Code = "",
        //                    ErrorMessage = "Contact not found."
        //                };

        //                return Json(apiJSonResponse, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            var apiJSonResponse = new
        //            {
        //                Code = "",
        //                ErrorMessage = "!OOPS, Something went wrong."
        //            };

        //            return Json(apiJSonResponse, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    else
        //    {
        //        var apiJSonResponse = new
        //        {
        //            Code = "",
        //            ErrorMessage = "Please provide valid contact details."
        //        };

        //        return Json(apiJSonResponse, JsonRequestBehavior.AllowGet);
        //    }
        //}

        //[HttpPost]
        //public JsonResult ZohoCreateContactPerson(ContactPerson contactperson, string ZohoOrganizationId)
        //{
        //    try
        //    {
        //        if (contactperson == null)
        //        {
        //            //contact.contact_id = 0;

        //            contactperson =
        //                new ContactPerson
        //                {
        //                    //contact_person_id = 460000000026051,
        //                    salutation = "Mr",
        //                    first_name = "Mihir",
        //                    last_name = "Mistry",
        //                    email = "mihir.m@uplers.in",
        //                    phone = "12345",
        //                    mobile = "9662029787",
        //                    is_primary_contact = true
        //                };
        //        }

        //        if (contactperson != null)
        //        {
        //            var jsonContact = JsonConvert.SerializeObject(contactperson, Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

        //            string ZohoBookApi = Config.ZohoApi + "/contacts/contactpersons?";

        //            var JsonList = ZohoInvoiceConfiguration.WebClinetZohoAPI(ZohoBookApi, "post", jsonContact, "Contact", "CREATE", ZohoOrganizationId);

        //            if (JsonList != null && JsonList["code"] != null && JsonList["code"].ToString() == "0")
        //            {
        //                if (JsonList != null && JsonList["contact_person"] != null && JsonList["contact_person"].Count() > 0)
        //                {
        //                    ContactPerson newlyCreatedContact = JsonConvert.DeserializeObject<ContactPerson>(Convert.ToString(JsonList["contact_person"]));

        //                    if (newlyCreatedContact != null)
        //                    {
        //                        var apiJSonResponse = new
        //                        {
        //                            ContactPerson = newlyCreatedContact,
        //                        };

        //                        return Json(apiJSonResponse, JsonRequestBehavior.AllowGet);
        //                    }
        //                    else
        //                    {
        //                        //var apiJSonResponse = new
        //                        //{
        //                        //    Code = "",
        //                        //    ErrorMessage = ""
        //                        //};

        //                        return Json("No Records Found", JsonRequestBehavior.AllowGet);
        //                    }
        //                }
        //                else
        //                {
        //                    var apiJSonResponse = new
        //                    {
        //                        Code = "",
        //                        ErrorMessage = "Contact Person not found."
        //                    };

        //                    return Json(apiJSonResponse, JsonRequestBehavior.AllowGet);
        //                }
        //            }
        //            else
        //            {
        //                string Code = "";
        //                string errorMessage = "!OOPS, Something went wrong.";

        //                if (JsonList != null && JsonList["Message"] != null)
        //                {
        //                    errorMessage = Convert.ToString(JsonList["Message"]);
        //                }

        //                if (JsonList != null && JsonList["Code"] != null)
        //                {
        //                    Code = Convert.ToString(JsonList["Code"]);
        //                }

        //                var apiJSonResponse = new
        //                {
        //                    Code = Code,
        //                    ErrorMessage = errorMessage
        //                };

        //                return Json(apiJSonResponse, JsonRequestBehavior.AllowGet);
        //            }
        //        }
        //        else
        //        {
        //            var apiJSonResponse = new
        //            {
        //                Code = "",
        //                ErrorMessage = "Please provide valid contact details."
        //            };

        //            return Json(apiJSonResponse, JsonRequestBehavior.AllowGet);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(ex.Message, JsonRequestBehavior.AllowGet);
        //    }
        //}
    }
}
