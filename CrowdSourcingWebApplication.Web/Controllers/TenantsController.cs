using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CrowdSourcingWebApplication.Domain.Entities;


namespace CrowdSourcingWebApplication.Web.Controllers
{
    public class TenantsController : Controller
    {
        BaseUser tenant;
        Category category;
        Log log;
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
        [Route("/Admin/Panel")]
        public ActionResult Index()
        {

            return View(tenant);
        }

        // GET: Tenants/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }


    }
}
