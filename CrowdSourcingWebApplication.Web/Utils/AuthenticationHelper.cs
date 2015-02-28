using Microsoft.Azure.ActiveDirectory.GraphClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.WebPages;

namespace CrowdSourcingWebApplication.Web.Utils
{
    public class AuthenticationHelper
    {
        public static string token;

        /// <summary>
        ///     Async task to acquire token for Application.
        /// </summary>
        /// <returns>Async Token for application.</returns>
        public static async Task<string> AcquireTokenAsync()
        {
            if (token == null || token.IsEmpty())
            {
                throw new Exception("Authorization Required.");
            }
            return token;
        }

        /// <summary>
        ///     Get Active Directory Client for Application.
        /// </summary>
        /// <returns>ActiveDirectoryClient for Application.</returns>
        public static ActiveDirectoryClient GetActiveDirectoryClient()
        {
            Uri baseServiceUri = new Uri(Constants.ResourceUrl);
            ActiveDirectoryClient activeDirectoryClient =
                new ActiveDirectoryClient(new Uri(baseServiceUri, Constants.TenantId),
                    async () => await AcquireTokenAsync());
            return activeDirectoryClient;
        }
    }
}