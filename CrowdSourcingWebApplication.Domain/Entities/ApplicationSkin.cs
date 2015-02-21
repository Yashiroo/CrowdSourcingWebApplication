using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcingWebApplication.Domain.Entities
{
    public class ApplicationSkin
    {
        [Key]
        public int ApplicationSkinId { get; set; }
        public string TenantMail { get; set; }

        public string ThemeURL { get; set; }
        public string Slogan { get; set; }
        public string LogoUrl { get; set; }

        public string BaseUrl { get; set; }

    }
}
