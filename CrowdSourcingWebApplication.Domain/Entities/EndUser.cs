using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrowdSourcingWebApplication.Domain.Entities
{
    public class EndUser : BaseUser
    {
        public EndUser(DateTime subdate)
        {
            this.SubscriptionDate = subdate;
        }

    }
}
