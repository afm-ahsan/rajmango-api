using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace RajMango.WebApi.Authorization
{
    /// <summary>
    /// Dynamically creates an authorization policy for any permission string used as a policy name.
    /// This avoids pre-registering every permission as a named policy in AddAuthorization().
    /// </summary>
    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
    {
        private readonly DefaultAuthorizationPolicyProvider _fallback;

        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
        {
            _fallback = new DefaultAuthorizationPolicyProvider(options);
        }

        public Task<AuthorizationPolicy> GetDefaultPolicyAsync() =>
            _fallback.GetDefaultPolicyAsync();

        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync() =>
            _fallback.GetFallbackPolicyAsync();

        public async Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            // Any policy name that contains a dot is treated as a permission string
            if (policyName.Contains('.'))
            {
                var policy = new AuthorizationPolicyBuilder()
                    .RequireAuthenticatedUser()
                    .AddRequirements(new PermissionRequirement(policyName))
                    .Build();
                return policy;
            }

            return await _fallback.GetPolicyAsync(policyName);
        }
    }
}
