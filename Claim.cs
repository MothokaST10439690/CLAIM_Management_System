using System;
using System.Collections.Generic;

namespace CLAIM
{
    public enum ClaimStatus { Submitted, Verified, Approved, Rejected }

    public class Claim
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string LecturerName { get; set; }
        public string Month { get; set; }
        public int Year { get; set; }
        public int HoursWorked { get; set; }
        public decimal HourlyRate { get; set; } = 50m;
        public decimal TotalAmount => HoursWorked * HourlyRate;
        
        public string Notes { get; set; }
        public ClaimStatus Status { get; set; } = ClaimStatus.Submitted;
        public string VerifiedBy { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime SubmissionDate { get; set; } = DateTime.Now;
        public List<string> Documents { get; set; } = new List<string>();
        public string UploadedDocument { get; set; }
    }
}
