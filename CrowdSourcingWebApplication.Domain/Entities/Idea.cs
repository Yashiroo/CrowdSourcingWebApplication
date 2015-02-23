using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcingWebApplication.Domain.Entities
{
    public class Idea
    {
        [Key]
        public int IdeaId { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Subject { get; set; }
        public DateTime DatePosted { get; set; }
        [DefaultValue(0)]
        public int Score { get; set; }
        public string State { get; set; }
        [Required(AllowEmptyStrings = false)]
        [DataType(DataType.MultilineText)]
        public string Text { get; set; }
        public string prize { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public virtual IEnumerable<Comment> Comments { get; set; }

        public string WriterMail { get; set; }
        public string TenanMail { get; set; }


    }
}
