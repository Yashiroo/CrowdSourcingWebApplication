using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrowdSourcingWebApplication.Domain.Entities;
namespace CrowdSourcingWebApplication.Service
{
    public class WebAppService
    {

        

        public int[] GetEndusersStatsThisYear(List<object> endusers)
        {
	        int[] months = new int[12];
            
            foreach(EndUser user in endusers)
            {
                if (user.SubscriptionDate.Year == DateTime.Now.Year)
                {
                    int month = user.SubscriptionDate.Month - 1;
                    months[month] += 1;
                }
            }

            return months;
        }

        public int[] GetEndusersStatsLastYear(List<object> endusers)
        {
            int[] months = new int[12];

            foreach (EndUser user in endusers)
            {
                if (user.SubscriptionDate.Year == DateTime.Now.Year -1)
                {
                    int month = user.SubscriptionDate.Month - 1;
                    months[month] += 1;
                }
            }

            return months;
        }

        public object[] GetIdeasPerCategoryTotal(IEnumerable<Idea> ideas, IEnumerable<Category> categories)
        {
            int i = 0;
            string[] catNames = new string[categories.Count()];
            int[] catVals = new int[categories.Count()];
            foreach(Category category in categories)
            {
                catNames[i] = category.Title;
                foreach(Idea idea in ideas)
                {
                    if (idea.CategoryId == category.CategoryId)
                        catVals[i] += 1;
                }
                i++;
            }

            object[] multi = new object[2];
            multi[0] = catNames;
            multi[1] = catVals;


            return multi;
        }






    }
}
