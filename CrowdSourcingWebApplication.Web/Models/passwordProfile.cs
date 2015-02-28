using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace CrowdSourcingWebApplication.Web.Models
{
   public class passwordProfile
    {
       public bool forceChangePasswordNextLogin { get; set; }
       [DataType(DataType.Password)]
       public string password { get; set; }
    }
}
