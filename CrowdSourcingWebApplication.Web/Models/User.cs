using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrowdSourcingWebApplication.Web.Models
{
    public class User
    {
        [Key]
        public string displayName { get; set; }
        public string givenName { get; set; }
        public string surname { get; set; }
        public string mailNickname { get; set; }
        public string userPrincipalName { get; set; }
        public passwordProfile passwordProfile { get; set; }
    }
}