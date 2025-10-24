using System;
using System.Security.Claims;

namespace CLAIM
{
    public static class EventHub
    {
        public static event Action<Claim> ClaimChanged;

        public static void RaiseClaimChanged(Claim claim)
        {
            ClaimChanged?.Invoke(claim);
        }
    }
}
