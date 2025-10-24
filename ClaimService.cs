using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CLAIM
{
    public static class ClaimService
    {
        public static void SubmitClaim(Claim claim)
        {
            claim.Status = ClaimStatus.Submitted;
            claim.SubmissionDate = DateTime.Now;
            ClaimRepository.Add(claim);
        }

        public static void VerifyClaim(Claim claim, string coordinatorName)
        {
            if (claim.Status != ClaimStatus.Submitted) return;
            claim.Status = ClaimStatus.Verified;
            claim.VerifiedBy = coordinatorName;
            ClaimRepository.Update(claim);
        }

        public static void ApproveClaim(Claim claim, string managerName)
        {
            if (claim.Status != ClaimStatus.Verified) return;
            claim.Status = ClaimStatus.Approved;
            claim.ApprovedBy = managerName;
            ClaimRepository.Update(claim);
        }

        public static void RejectClaim(Claim claim, string managerName)
        {
            if (claim.Status != ClaimStatus.Verified) return;
            claim.Status = ClaimStatus.Rejected;
            claim.ApprovedBy = managerName;
            ClaimRepository.Update(claim);
        }

        public static void AttachDocuments(Claim claim, List<string> docs)
        {
            claim.Documents.AddRange(docs);
            ClaimRepository.Update(claim);
        }
    }
}
