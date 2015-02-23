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
                EndUser e10 = new EndUser(new DateTime(2015,2,2));
                endusers.Add(e10);
                EndUser e11 = new EndUser(new DateTime(2015,2,2));
                endusers.Add(e11);
                EndUser e12 = new EndUser(new DateTime(2015,2,2));
                endusers.Add(e12);
                EndUser e13 = new EndUser(new DateTime(2015,2,2));
                endusers.Add(e13);
                EndUser e14 = new EndUser(new DateTime(2015,2,2));
                endusers.Add(e14);
                EndUser e15 = new EndUser(new DateTime(2015,2,2));
                endusers.Add(e15);
                EndUser e16 = new EndUser(new DateTime(2015,3,2));
                endusers.Add(e16);
                EndUser e17 = new EndUser(new DateTime(2015,3,2));
                endusers.Add(e17);
                EndUser e18 = new EndUser(new DateTime(2015,3,2));
                endusers.Add(e18);
                EndUser e19 = new EndUser(new DateTime(2015,4,2));
                endusers.Add(e19);
                EndUser e20 = new EndUser(new DateTime(2015,4,2));
                endusers.Add(e20);
                EndUser e21 = new EndUser(new DateTime(2015,4,2));
                endusers.Add(e21);
                EndUser e22 = new EndUser(new DateTime(2015,5,2));
                endusers.Add(e22);
                EndUser e23 = new EndUser(new DateTime(2015,5,2));
                endusers.Add(e23);
                EndUser e24 = new EndUser(new DateTime(2015,6,2));
                endusers.Add(e24);
                EndUser e25 = new EndUser(new DateTime(2015,6,2));
                endusers.Add(e25);
                

                EndUser e26 = new EndUser(new DateTime(2014, 8, 2));
                endusers.Add(e26);
                EndUser e27 = new EndUser(new DateTime(2014, 8, 2));
                endusers.Add(e27);
                EndUser e28 = new EndUser(new DateTime(2014, 8, 2));
                endusers.Add(e28);
                EndUser e29 = new EndUser(new DateTime(2014, 9, 2));
                endusers.Add(e29);
                EndUser e30 = new EndUser(new DateTime(2014, 9, 2));
                endusers.Add(e30);
                EndUser e31 = new EndUser(new DateTime(2014, 9, 2));
                endusers.Add(e31);
                EndUser e32 = new EndUser(new DateTime(2014, 9, 2));
                endusers.Add(e32);
                EndUser e33 = new EndUser(new DateTime(2014, 9, 2));
                endusers.Add(e33);
                EndUser e34 = new EndUser(new DateTime(2014, 11, 2));
                endusers.Add(e34);
                EndUser e35 = new EndUser(new DateTime(2014, 11, 2));
                endusers.Add(e35);
                EndUser e36 = new EndUser(new DateTime(2014, 11, 2));
                endusers.Add(e36);
                EndUser e37 = new EndUser(new DateTime(2014, 11, 2));
                endusers.Add(e37);
                EndUser e38 = new EndUser(new DateTime(2014, 11, 2));
                endusers.Add(e38);
                EndUser e39 = new EndUser(new DateTime(2014, 12, 2));
                endusers.Add(e39);
                EndUser e40 = new EndUser(new DateTime(2014, 12, 2));
                endusers.Add(e40);
                EndUser e41 = new EndUser(new DateTime(2014, 12, 2));
                endusers.Add(e41);
                EndUser e42 = new EndUser(new DateTime(2014, 12, 2));
                endusers.Add(e42);
                EndUser e43 = new EndUser(new DateTime(2014, 12, 2));
                endusers.Add(e43);
                


            //END OF GENERATION USERS


        }
            
        	


        // GET: Tenants
        //[Route("Admin/Panel")]
        public ActionResult Index()
        {
            IdeaHandler handler = new IdeaHandler();
            IEnumerable<Idea> ideas = handler.RetrieveIdeas(tenant.Email);
            LogHandler lhandler = new LogHandler();
            IEnumerable<Log> logs = lhandler.GetLogsForTenant(tenant.Email);
            logs = logs.OrderByDescending(x => x.EventDate);

            Session["logs"] = logs;
            Session["numusers"] = endusers.Count;
            Session["totalideas"] = ideas.Count();
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
                    ViewBag.glyphicon = "glyphicon-remove";
                    ViewBag.error = "has-error";
                    ViewBag.existing = "This category already exists. Please try typing in a new category.";
                    return View();
                }
                LogHandler lhandler = new LogHandler();
                Log log = new Log();
                log.EventDate = DateTime.Now;
                log.TenantMail = tenant.Email;
                log.EventType = "Category";
                log.Event = "You have added the category : "+category.Title;
                lhandler.AddLog(log);
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
            int[] thisyear = service.GetEndusersStatsThisYear(endusers);
            int[] lastyear = service.GetEndusersStatsLastYear(endusers);
            Session["thisyear"] = thisyear;
            Session["last"] = lastyear;

            CategoryHandler chandler = new CategoryHandler();
            categories = chandler.GetCategory(tenant.Email);
            IdeaHandler handler = new IdeaHandler();
            IEnumerable<Idea> ideas = handler.RetrieveIdeas(tenant.Email);
            

            object[] results2 = service.GetIdeasPerCategoryTotal(ideas, categories);
            string[] catNames = (string[])results2[0];
            int[] catVals = (int[])results2[1];
            Session["multi"] = results2;
            Session["catnames"] = catNames;
            Session["catvals"] = catVals;
            return View();
        }
    }
}
