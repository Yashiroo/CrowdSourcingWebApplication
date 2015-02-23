using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcingWebApplication.Domain.Entities
{
    public class BaseUser
    {
        [Key]
        public int BaseuserId { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(15)]
        public string Username { get; set; }
        [Required(AllowEmptyStrings = false)]
        [StringLength(30)]
        public string Email { get; set; }

        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
        public string Country { get; set; }
        public string Role { get; set; }
        public DateTime SubscriptionDate { get; set; }
        public string ImagePath { get; set; }
        public bool enabled { get; set; }
    }
}
