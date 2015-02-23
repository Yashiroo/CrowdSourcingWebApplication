using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdSourcingWebApplication.Domain.Entities;
using System.Net.Http;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using CrowdSourcingWebApplication.Web.Handlers;
using CrowdSourcingWebApplication.Service;


namespace CrowdSourcingWebApplication.Web.Controllers
{
    public class TenantsController : Controller
    {
        BaseUser tenant;
        //Category category;
        //Log log;
        //HttpClient client;
        static IEnumerable<Category> categories;
        List<object> endusers = new List<object>();
        WebAppService service;


        public TenantsController()
        {
            // tenant
            tenant = new Tenant();
            tenant.Email = "tenant@esprit.tn";
            tenant.Country = "Tunisia";
            tenant.Password = "*******";
            tenant.ImagePath = null;
            tenant.SubscriptionDate = DateTime.MinValue;
            tenant.Username = "Lamjed.B";
            tenant.Role = null;
            tenant.enabled = true;

            // GENERATION OF IDEAS AND COMMENTS
            


             //END OF GENERATION OF IDEAS AND COMMENTS


            // GENERATION OF USERS
            
                EndUser e1 = new EndUser(new DateTime(2015,2,2));
                endusers.Add(e1);
            
                EndUser e2 = new EndUser(new DateTime(2015,1,2));
                endusers.Add(e2);
                EndUser e3 = new EndUser(new DateTime(2015,1,2));
                endusers.Add(e3);
                EndUser e4 = new EndUser(new DateTime(2015,1,2));
                endusers.Add(e4);
                EndUser e5 = new EndUser(new DateTime(2015,1,2));
                endusers.Add(e5);
                EndUser e6 = new EndUser(new DateTime(2015,1,2));
                endusers.Add(e6);
                EndUser e7 = new EndUser(new DateTime(2015,1,2));
                endusers.Add(e7);
                EndUser e8 = new EndUser(new DateTime(2015,1,2));
                endusers.Add(e8);
                EndUser e9 = new EndUser(new DateTime(2015,1,2));
                endusers.Add(e9);
                EndUser e10 = new EndUser(new DateTime(2015,3,2));
                endusers.Add(e10);
                EndUser e11 = new EndUser(new DateTime(2015,3,2));
                endusers.Add(e11);
                EndUser e12 = new EndUser(new DateTime(2015,3,2));
                endusers.Add(e12);
                EndUser e13 = new EndUser(new DateTime(2015,3,2));
                endusers.Add(e13);
                EndUser e14 = new EndUser(new DateTime(2015,5,2));
                endusers.Add(e14);
                EndUser e15 = new EndUser(new DateTime(2015,5,2));
                endusers.Add(e15);
                EndUser e16 = new EndUser(new DateTime(2015,5,2));
                endusers.Add(e16);
                EndUser e17 = new EndUser(new DateTime(2015,5,2));
                endusers.Add(e17);
                EndUser e18 = new EndUser(new DateTime(2015,5,2));
                endusers.Add(e18);
                EndUser e19 = new EndUser(new DateTime(2015,5,2));
                endusers.Add(e19);
                EndUser e20 = new EndUser(new DateTime(2015,5,2));
                endusers.Add(e20);
                EndUser e21 = new EndUser(new DateTime(2015,5,2));
                endusers.Add(e21);
                EndUser e22 = new EndUser(new DateTime(2015,6,2));
                endusers.Add(e22);
                EndUser e23 = new EndUser(new DateTime(2015,6,2));
                endusers.Add(e23);
                EndUser e24 = new EndUser(new DateTime(2015,6,2));
                endusers.Add(e24);
                EndUser e25 = new EndUser(new DateTime(2015,6,2));
                endusers.Add(e25);
                


            //END OF GENERATION USERS

            /*
            // category 
            category.CategoryId = 1;
            category.TenantMail = "tenant@esprit.tn";
            category.Title = "Ordering";

            // Log
            log.LogId = 1;
            log.TenantMail = "tenant@esprit.tn";
            log.Event = "Tenant with username Lamjed.B and email tenant@esprit.tn has subscribed";
            log.EventDate = DateTime.Today;
            log.EventType = "Subscription";
             
             */

             




        }
            
        	


        // GET: Tenants
        //[Route("Admin/Panel")]
        public ActionResult Index()
        {
            Session["numusers"] = endusers.Count;
            return View();
            
        }

        // GET: Tenants/Details/5
        [HttpGet]
        public ActionResult TenantDetails()
        {
            
            Session["Tenant"] = tenant;
            return View(tenant);
        }
        


        public ActionResult Templates()
        {
            return View();
        }

        public ActionResult Categories()
        {
            CategoryHandler handler = new CategoryHandler();
            categories = handler.GetCategory(tenant.Email);
            Session["categories"] = categories;
            return View();
        }
        
        [HttpGet]
        public ActionResult AddCategory()
        {
                //Category p = category as Category;
                //Session["Category"] = p;
                //return RedirectToAction("Categories");
                
                return View();
 
        }


        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            if (category.Title != null & category.Title != "")
            {
                CategoryHandler handler = new CategoryHandler();
                category.TenantMail = tenant.Email;
                var code = handler.AddCategory(category);

                if (code == System.Net.HttpStatusCode.NoContent | code == System.Net.HttpStatusCode.NotAcceptable)
                {
                    
                    return View();
                }
                    
                return RedirectToAction("Categories");
            }
                
            return View();

        }




        
        public ActionResult DeleteCategory(int categoryid)
        {
            CategoryHandler handler = new CategoryHandler();
            Category category = null;
            foreach(Category c in categories)
            {
                if (c.CategoryId == categoryid)
                {
                    category = c;
                    
                }
            }
            var code = handler.DeleteCategory(category);
            if (code == System.Net.HttpStatusCode.Accepted)
                return RedirectToAction("Categories");
            else 
                return RedirectToAction("Index");
  
        }





        public ActionResult Statistics()
        {
            
            service = new WebAppService();
            int[] results = service.GetEndusersStatsPer6Months(endusers);
            Session["results"] = results;
            CategoryHandler chandler = new CategoryHandler();
            categories = chandler.GetCategory(tenant.Email);
            IdeaHandler handler = new IdeaHandler();
            IEnumerable<Idea> ideas = handler.RetrieveIdeas(tenant.Email);
            

            object[] results2 = service.GetIdeasPerCategoryPer6Months(ideas, categories);
            string[] catNames = (string[])results2[0];
            int[] catVals = (int[])results2[1];
            Session["multi"] = results2;
            Session["catnames"] = catNames;
            Session["catvals"] = catVals;
            return View();
        }
    }
}
