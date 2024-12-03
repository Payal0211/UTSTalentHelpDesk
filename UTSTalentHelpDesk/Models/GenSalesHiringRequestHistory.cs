﻿using System;
using System.Collections.Generic;

namespace TalentConnectAdminAPI.Models
{
    public partial class GenSalesHiringRequestHistory
    {
        public long Id { get; set; }
        public long? HiringRequestId { get; set; }
        public long? SalesUserId { get; set; }
        public long? ContactId { get; set; }
        public string? RequestForTalent { get; set; }
        public string? Discription { get; set; }
        public string? Jdfilename { get; set; }
        public string? Jdurl { get; set; }
        public decimal? MonthDuration { get; set; }
        public int? NoofTalents { get; set; }
        public int? StatusId { get; set; }
        public string? OurObservation { get; set; }
        public string? Remark { get; set; }
        public int? CreatedById { get; set; }
        public DateTime? CreatedByDatetime { get; set; }
        public int? LastModifiedById { get; set; }
        public DateTime? LastModifiedDatetime { get; set; }
        public string? HrNumber { get; set; }
        public string? Availability { get; set; }
        public int? PartialEngagementTypeId { get; set; }
        public int? NoofHoursworking { get; set; }
        public long? JddumpId { get; set; }
        public bool? IsCreatedByClient { get; set; }
        public bool? IsActive { get; set; }
        public decimal? TalentCostCalcPercentage { get; set; }
        public bool IsAdHocHr { get; set; }
        public bool IsEmailSend { get; set; }
        public long? AcceptedById { get; set; }
        public DateTime? AcceptedByDateTime { get; set; }
        public int? IsAccepted { get; set; }
        public bool IsManaged { get; set; }
        public string? DeleteHrreason { get; set; }
        public string? NotAcceptedHrreason { get; set; }
        public int? AdhocPassBy { get; set; }
        public DateTime? AdhocPassDate { get; set; }
        public bool? IsHiringLimited { get; set; }
        public bool IsPoolHr { get; set; }
        public int? DeleteHrreasonId { get; set; }
        public int? DeleteType { get; set; }
        public int? TrAccepted { get; set; }
        public string? OnHoldRemark { get; set; }
        public string? LossRemark { get; set; }
        public int? AmSalesPersonId { get; set; }
        public int? NbdSalesPersonId { get; set; }
        public string? Bqlink { get; set; }
        public string? DiscoveryCall { get; set; }
        public decimal? Dppercentage { get; set; }
        public bool IsHrtypeDp { get; set; }
        public string? AboutCompanyDesc { get; set; }
        public long? DealId { get; set; }
        public DateTime? LastActivityDate { get; set; }
        public bool? OnHoldReminderFlag { get; set; }
        public bool? IsPartnerHr { get; set; }
        public long? ChildCompanyId { get; set; }
        public long? ChildContactId { get; set; }
        public long? PreviousHiringRequestId { get; set; }
    }
}
