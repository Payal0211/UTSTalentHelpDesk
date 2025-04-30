using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class ZohoWebhookCustomer
    {
        public WebhookContact contact { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class BillingAddress
    {
        public string zip { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string address_id { get; set; }
        public string county { get; set; }
        public string country_code { get; set; }
        public string phone { get; set; }
        public string phone_formatted { get; set; }
        public string attention { get; set; }
        public string street2 { get; set; }
        public string state { get; set; }
        public string state_code { get; set; }
        public string fax { get; set; }
    }

    public class CommunicationPreference
    {
        public bool is_email_enabled { get; set; }
    }

    public class WebhookContact
    {
        public string owner_id { get; set; }
        public bool is_client_review_settings_enabled { get; set; }
        public BillingAddress billing_address { get; set; }
        public string outstanding_receivable_amount_formatted { get; set; }
        public string submitted_by_email { get; set; }
        public string source_formatted { get; set; }
        public bool is_credit_limit_migration_completed { get; set; }
        public string language_code { get; set; }
        public string twitter { get; set; }
        public string unused_credits_receivable_amount_formatted { get; set; }
        public string zcrm_contact_id { get; set; }
        public int unused_credits_receivable_amount_bcy { get; set; }
        public string contact_tax_information { get; set; }
        public string unused_credits_receivable_amount_bcy_formatted { get; set; }
        public string tax_reg_no { get; set; }
        public string entity_address_id { get; set; }
        public string pricebook_id { get; set; }
        public int outstanding_receivable_amount { get; set; }
        public string customer_sub_type { get; set; }
        public string zcrm_account_id { get; set; }
        public string approver_id { get; set; }
        public string submitted_date_formatted { get; set; }
        public string sales_channel { get; set; }
        public int unused_credits_receivable_amount { get; set; }
        public bool has_transaction { get; set; }
        public string status_formatted { get; set; }
        public string phone { get; set; }
        public string company_name { get; set; }
        public bool is_consent_agreed { get; set; }
        public string tax_treatment_formatted { get; set; }
        public string outstanding_receivable_amount_bcy_formatted { get; set; }
        public string crm_owner_id { get; set; }
        public string status { get; set; }
        public string opening_balance_amount_formatted { get; set; }
        public string contact_category_formatted { get; set; }
        public string currency_code { get; set; }
        public string tax_name_formatted { get; set; }
        public string email { get; set; }
        public string contact_name { get; set; }
        public string website { get; set; }
        public string siret_number { get; set; }
        public DateTime last_modified_time { get; set; }       
        public string company_id { get; set; }
        public string currency_symbol { get; set; }
        public bool ach_supported { get; set; }
        public string facebook { get; set; }
        public string last_name { get; set; }
        public string contact_salutation { get; set; }
        public string unused_retainer_payments_formatted { get; set; }
        public string payment_terms_label { get; set; }
        public string submitted_date { get; set; }
        public bool is_crm_customer { get; set; }      
        public string notes { get; set; }       
        public int credit_limit_exceeded_amount { get; set; }
        public string portal_status { get; set; }
        public bool is_linked_with_zohocrm { get; set; }    
        public string source { get; set; }
        public string created_by_name { get; set; }
        public int outstanding_receivable_amount_bcy { get; set; }
        public string contact_category { get; set; }
        public bool associated_with_square { get; set; }
        public List<ZohoContactPerson> contact_persons { get; set; }
        public DateTime created_time { get; set; }
        public string created_date_formatted { get; set; }
        public string owner_name { get; set; }
        public string tax_reg_label { get; set; }       
        public string credit_limit_exceeded_amount_formatted { get; set; }
        public string tax_id { get; set; }
        public string pricebook_name { get; set; }
        public int price_precision { get; set; }
        public string primary_contact_id { get; set; }       
        public string label_for_company_id { get; set; }
        public string submitted_by_photo_url { get; set; }
        public string tax_treatment { get; set; }        
        public string designation { get; set; }
        public string submitted_by_name { get; set; }       
        public string contact_id { get; set; }
        public int payment_terms { get; set; }
        public string contact_type { get; set; }
        public bool is_sms_enabled { get; set; }       
        public string payment_terms_id { get; set; }
        public ShippingAddress shipping_address { get; set; }
        public string department { get; set; }
        public string first_name { get; set; }
        public string zohopeople_client_id { get; set; }
        public List<CustomerCurrencySummary> customer_currency_summaries { get; set; }
        public bool is_client_review_asked { get; set; }
        public string customer_sub_type_formatted { get; set; }
        public string language_code_formatted { get; set; }
        public string tax_name { get; set; }
        public string mobile { get; set; }
        public string submitted_by { get; set; }
        public string submitter_id { get; set; }
        public string portal_status_formatted { get; set; }
        public string invited_by { get; set; }
        public int unused_retainer_payments { get; set; }
        public int opening_balance_amount { get; set; }
        public int portal_receipt_count { get; set; }
        public bool is_bcy_only_contact { get; set; }
        public string tax_percentage { get; set; }
        public string consent_date { get; set; }       
        public string created_date { get; set; }
        public string currency_id { get; set; }
        public bool payment_reminder_enabled { get; set; }
    }

    public class ZohoContactPerson
    {
        public bool can_invite { get; set; }
        public string mobile { get; set; }
        public bool is_added_in_portal { get; set; }
        public string last_name { get; set; }
        public string contact_person_id { get; set; }
        public string mobile_code_formatted { get; set; }
        public bool is_primary_contact { get; set; }
        public string mobile_country_code { get; set; }
        public CommunicationPreference communication_preference { get; set; }
        public bool is_portal_invitation_accepted { get; set; }
        public string skype { get; set; }
        public string zcrm_contact_id { get; set; }
        public string mobile_formatted { get; set; }
        public string phone { get; set; }
        public string phone_formatted { get; set; }
        public string salutation { get; set; }
        public string designation { get; set; }
        public string photo_url { get; set; }
        public string department { get; set; }
        public string fax { get; set; }
        public string first_name { get; set; }
        public string email { get; set; }
        public bool is_portal_mfa_enabled { get; set; }
        public bool is_sms_enabled_for_cp { get; set; }
    }

    public class CustomerCurrencySummary
    {
        public int outstanding_receivable_amount { get; set; }
        public string unused_credits_receivable_amount_formatted { get; set; }
        public string currency_symbol { get; set; }
        public bool is_base_currency { get; set; }
        public string currency_name_formatted { get; set; }
        public int unused_credits_receivable_amount { get; set; }
        public string currency_id { get; set; }
        public string currency_code { get; set; }
        public string outstanding_receivable_amount_formatted { get; set; }
        public int price_precision { get; set; }
    }    
    public class ShippingAddress
    {
        public string zip { get; set; }
        public string country { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string latitude { get; set; }
        public string address_id { get; set; }
        public string county { get; set; }
        public string country_code { get; set; }
        public string phone { get; set; }
        public string phone_formatted { get; set; }
        public string attention { get; set; }
        public string street2 { get; set; }
        public string state { get; set; }
        public string state_code { get; set; }
        public string fax { get; set; }
        public string longitude { get; set; }
    }
}
