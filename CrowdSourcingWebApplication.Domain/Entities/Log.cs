using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcingWebApplication.Domain.Entities
{
    public class Log
    {
        [Key]
        public int LogId { get; set; }
        // public DateTime LogDate { get; set; } // moved to event date
        public DateTime EventDate { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Event { get; set; }
        public string EventType { get; set; }
        public string TenantMail { get; set; }
    }
}
