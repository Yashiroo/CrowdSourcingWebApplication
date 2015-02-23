using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcingWebApplication.Domain.Entities
{
    [DataContract]
    public class Category
    {
        [Key]
        [DataMember]
        public int CategoryId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public string TenantMail { get; set; }

    }
}
