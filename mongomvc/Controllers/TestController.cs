using mongomvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mongomvc.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public PartialViewResult GetTest()
        {
            var test = new TestModel();
            test.Name = "Alex";
            test.CurrentTime = DateTime.Now;             

            return PartialView("_partView", test);
        }
    }
}