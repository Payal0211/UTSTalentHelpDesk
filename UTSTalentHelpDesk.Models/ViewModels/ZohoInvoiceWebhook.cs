using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTSTalentHelpDesk.Models.ViewModels
{
    public class ZohoInvoiceWebhook
    {
        public WebhookInvoice invoice { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);    

    public class ContactCommunicationPreference
    {
        public bool is_email_enabled { get; set; }
    } 

    public class ContactPersonsAssociated
    {
        public string zcrm_contact_id { get; set; }
        public string phone { get; set; }
        public string mobile { get; set; }
        public string last_name { get; set; }
        public string contact_person_id { get; set; }
        public string contact_person_name { get; set; }
        public string first_name { get; set; }
        public ContactCommunicationPreference communication_preference { get; set; }
        public string contact_person_email { get; set; }
    }

    public class ContactPersonsDetail
    {
        public string phone { get; set; }
        public string mobile { get; set; }
        public string last_name { get; set; }
        public string contact_person_id { get; set; }
        public bool is_primary_contact { get; set; }
        public string photo_url { get; set; }
        public string first_name { get; set; }
        public string email { get; set; }
    }  

    public class CustomFieldHash
    {
        public string cf_number_of_invoice_unformatted { get; set; }
        public string cf_first_repeat_invoice_unformatted { get; set; }
        public string cf_invoice_generator_unformatted { get; set; }
        public string cf_inbound { get; set; }
        public string cf_geo { get; set; }
        public string cf_invoice_generator { get; set; }
        public bool cf_inbound_unformatted { get; set; }
        public string cf_outbound { get; set; }
        public string cf_payment_model_unformatted { get; set; }
        public string cf_first_repeat_invoice { get; set; }
        public string cf_payment_model { get; set; }
        public bool cf_outbound_unformatted { get; set; }
        public string cf_geo_unformatted { get; set; }
        public string cf_number_of_invoice { get; set; }
    }

    public class WebhookInvoice
    {
        public bool can_send_in_mail { get; set; }
        
        public string submitted_by_email { get; set; }
        public string bcy_shipping_charge_tax { get; set; }
        public string tax_reg_no { get; set; }
        public bool stop_reminder_until_payment_expected_date { get; set; }        
        public bool inprocess_transaction_present { get; set; }
        public string submitted_date_formatted { get; set; }
        public string estimate_id { get; set; }     
        public string status_formatted { get; set; }
        public string shipping_charge_tax_id { get; set; }
        public string ecomm_operator_name { get; set; }
        public bool is_autobill_enabled { get; set; }
        public string tax_treatment_formatted { get; set; }
        public string shipping_charge_tax_name { get; set; }
       
        public decimal tax_total { get; set; }
        
        public bool is_viewed_by_client { get; set; }
        public string salesorder_id { get; set; }
        public string last_reminder_sent_date_formatted { get; set; }
        public string client_viewed_time_formatted { get; set; }
        public string email { get; set; }       
        public string adjustment_description { get; set; }
        public string currency_symbol { get; set; }
        public bool ach_supported { get; set; }        
        public string transaction_rounding_type { get; set; }
      
        public List<ContactPersonsDetail> contact_persons_details { get; set; }
        public string template_name { get; set; }
        public string salesorder_number { get; set; }
        public string template_id { get; set; }
        public string customer_name { get; set; }
        public string total_formatted { get; set; }
        public string discount_total_formatted { get; set; }
        public string payment_terms_label { get; set; }
        public bool show_no_of_copies { get; set; }
        public string notes { get; set; }
        public string client_viewed_time { get; set; }
        public string ecomm_operator_id { get; set; }
        public string early_payment_discount_due_days { get; set; }
        public string tds_override_preference { get; set; }
        
        public string payment_discount_formatted { get; set; }
        public string invoice_id { get; set; }
        public string contact_category { get; set; }
        public string template_type { get; set; }
        public string recurring_invoice_id { get; set; }
        public bool can_send_invoice_sms { get; set; }       
        public string shipping_charge_tax { get; set; }
        public DateTime created_time { get; set; }
        public string created_date_formatted { get; set; }
        public bool is_inclusive_tax { get; set; }
        public string early_payment_discount_amount_formatted { get; set; }        
        
        public string sub_total_inclusive_of_tax_formatted { get; set; }
       
        public string submitted_by_photo_url { get; set; }
        public string tax_treatment { get; set; }
          
        public string shipping_charge_tax_percentage { get; set; }
        public string zcrm_potential_name { get; set; }
        
        public string current_sub_status { get; set; }
        public string due_date_formatted { get; set; }
        public bool is_progress_invoice { get; set; }
        public string shipping_charge_inclusive_of_tax_formatted { get; set; }
        public string merchant_id { get; set; }
        public string invoice_source { get; set; }
        public string shipping_charge_exclusive_of_tax_formatted { get; set; }
        public List<ContactPersonsAssociated> contact_persons_associated { get; set; }
        public string current_sub_status_id { get; set; }
        public CustomFieldHash custom_field_hash { get; set; }          
        public string next_reminder_date_formatted { get; set; }
        public string shipping_charge_tax_type { get; set; }
        public string subject_content { get; set; }
        public string shipping_charge_account_name { get; set; }
        public string payment_expected_date { get; set; } 
        public bool allow_partial_payments { get; set; }        
        public string currency_id { get; set; }
        public bool includes_package_tracking_info { get; set; }
        public string zcrm_potential_id { get; set; }
        //public int discount { get; set; }
        //public List<object> taxes { get; set; }
        public bool is_client_review_settings_enabled { get; set; }
        public BillingAddress billing_address { get; set; }
        //public List<LineItem> line_items { get; set; }
        public bool can_show_kit_return { get; set; }
        public string payment_expected_date_formatted { get; set; }
        public double balance { get; set; }
        public string terms { get; set; }       
        public string credits_applied_formatted { get; set; }
        public string invoice_number { get; set; }       
        public decimal sub_total_inclusive_of_tax { get; set; }
        public decimal exchange_rate { get; set; }
        public string invoice_source_formatted { get; set; }
        public string approver_id { get; set; }
        public string merchant_name { get; set; }
        public string sales_channel { get; set; }
        public string shipping_charge_formatted { get; set; }
        public string total_retention_amount_formatted { get; set; }
        public string reference_number { get; set; }
        public string shipping_charge_account_id { get; set; }       
        public string page_height { get; set; }
        public string status { get; set; }
        public string unprocessed_payment_amount_formatted { get; set; }
        public bool reader_offline_payment_initiated { get; set; }
        public string schedule_time_formatted { get; set; }
        public string adjustment_formatted { get; set; }
        public string balance_formatted { get; set; }
        public string currency_code { get; set; }
        public string page_width { get; set; }
        public string tax_override_preference { get; set; }
        public double bcy_total { get; set; }
        public string date_formatted { get; set; }
        public string tax_rounding { get; set; }
        public DateTime last_modified_time { get; set; }
        public bool is_kit_partial_return { get; set; }
        public string discount_type { get; set; }
        public bool is_early_payment_discount_applicable { get; set; }       
        public string schedule_time { get; set; }
        public string retention_override_preference { get; set; }
        public string customer_id { get; set; }
        public string roundoff_value_formatted { get; set; }
        public string unused_retainer_payments_formatted { get; set; }
        public string date { get; set; }
        public string submitted_date { get; set; }       
        public string template_type_formatted { get; set; }        
        public string currency_name_formatted { get; set; }
        public string created_by_name { get; set; }
        public string last_modified_by_id { get; set; }
        public string write_off_amount_formatted { get; set; }
        public string color_code { get; set; }
        public decimal bcy_tax_total { get; set; }
        public string last_payment_date_formatted { get; set; }        
        public string last_payment_date { get; set; }      
        public string current_sub_status_formatted { get; set; }
        public string tds_calculation_type { get; set; }
        public string submitted_by_name { get; set; }
        public string created_by_id { get; set; }
        public string is_backorder { get; set; }
        public bool is_last_child_invoice { get; set; }
        public bool is_discount_before_tax { get; set; }
        public string attachment_name { get; set; }
        public bool ach_payment_initiated { get; set; }
        public string last_reminder_sent_date { get; set; }
        public int payment_terms { get; set; }        
        public decimal total { get; set; }
        public string tax_total_formatted { get; set; }
        public string sub_total_formatted { get; set; }
        public string tax_amount_withheld_formatted { get; set; }            
        public string shipping_charge_tax_formatted { get; set; }       
        public string orientation { get; set; }        
        public string due_date { get; set; }
        public string submitter_id { get; set; }
        public string submitted_by { get; set; }
        public int no_of_copies { get; set; }
        public string payment_made_formatted { get; set; }
        public double bcy_sub_total { get; set; }
       
        public string salesperson_name { get; set; }
        public string salesperson_id { get; set; }
       
        public double sub_total { get; set; }
        public string computation_type { get; set; }
        public string created_date { get; set; }
        public string invoice_url { get; set; }
        public bool payment_reminder_enabled { get; set; }
    }
    public class LineItem
    {
        public string discount_amount_formatted { get; set; }
        public double bcy_rate { get; set; }
        public string item_total_formatted { get; set; }
        public string salesorder_item_id { get; set; }
        public string line_item_id { get; set; }
        public string discount_account_name { get; set; }
        public string rate_formatted { get; set; }
        public string header_id { get; set; }
        public int discount_amount { get; set; }
        public string item_type { get; set; }
        public string item_type_formatted { get; set; }
        public string discount_account_id { get; set; }
        public string description { get; set; }
        public int discount { get; set; }
        public int item_order { get; set; }
        public string internal_name { get; set; }
        public string sales_rate_formatted { get; set; }
        public double rate { get; set; }
        public string project_id { get; set; }
        public string pricing_scheme { get; set; }
        public int sales_rate { get; set; }
        public string pricebook_id { get; set; }
        public string bcy_rate_formatted { get; set; }
        public int quantity { get; set; }
        public string image_document_id { get; set; }
        public string item_id { get; set; }
        public string expense_receipt_name { get; set; }
        public string tax_name { get; set; }
        public double item_total { get; set; }
        public string header_name { get; set; }
        public List<object> item_custom_fields { get; set; }
        public string tax_id { get; set; }
        public int markup_percent { get; set; }
        public string unit { get; set; }
        public int cost_amount { get; set; }
        public string tax_type { get; set; }
        public string cost_amount_formatted { get; set; }
        public string name { get; set; }
        public int tax_percentage { get; set; }
        public string markup_percent_formatted { get; set; }
        public string expense_id { get; set; }
    }

}
