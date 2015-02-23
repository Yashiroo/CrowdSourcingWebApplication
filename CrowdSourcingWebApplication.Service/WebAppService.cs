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

        

        public int[] GetEndusersStatsPer6Months(List<object> endusers)
        {
	        int[] months = new int[12]; 
            
            foreach(EndUser user in endusers)
            {
                int month = user.SubscriptionDate.Month;
                months[month] += 1;

            }

            return months;
        }


        public object[] GetIdeasPerCategoryPer6Months(IEnumerable<Idea> ideas, IEnumerable<Category> categories)
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
