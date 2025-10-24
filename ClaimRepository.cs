using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CLAIM
{
    public static class ClaimRepository
    {
        private static List<Claim> claims = new List<Claim>();

        public static IEnumerable<Claim> GetAll() => claims;

        public static IEnumerable<Claim> GetByStatus(ClaimStatus status)
            => claims.Where(c => c.Status == status);

        public static void Add(Claim claim)
        {
            claims.Add(claim);
            EventHub.RaiseClaimChanged(claim);
        }

        public static void Update(Claim claim)
        {
            var index = claims.FindIndex(c => c.Id == claim.Id);
            if (index >= 0)
            {
                claims[index] = claim;
                EventHub.RaiseClaimChanged(claim);
            }
        }
    }
}
