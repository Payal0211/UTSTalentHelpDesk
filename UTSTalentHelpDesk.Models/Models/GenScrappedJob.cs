using System;
using System.Collections.Generic;

namespace UTSTalentHelpDesk.Models.Models
{
    public partial class GenScrappedJob
    {
        public long Id { get; set; }
        public long? CompanyId { get; set; }
        public string? JobId { get; set; }
        public string? JobTitle { get; set; }
        public string? Description { get; set; }
        public string? Address { get; set; }
        public string? ApplyUrl { get; set; }
        public string? Availability { get; set; }
        public string? Website { get; set; }
        public string? Responsibilities { get; set; }
        public string? PostedDate { get; set; }
        public DateTime? ScrappedDateTime { get; set; }
        public bool? IsActive { get; set; }
        public string? Location { get; set; }
        public string? ModeOfWorking { get; set; }
        public string? BusinessUnit { get; set; }
        public string? Experience { get; set; }
        public string? TotalPositions { get; set; }
        public string? Skills { get; set; }
        public string? ExperienceAndQualification { get; set; }
        public string? Salary { get; set; }
        public string? JobDetailsUrl { get; set; }
        public string? MinExperience { get; set; }
        public string? MaxExperience { get; set; }
        public string? MinSalary { get; set; }
        public string? MaxSalary { get; set; }
        public string? Currency { get; set; }
        public string? AboutCompany { get; set; }
        public string? Requirement { get; set; }
        public DateTime? LastModifiedByDateTime { get; set; }
        public string? GoodToHaveSkills { get; set; }
    }
}
