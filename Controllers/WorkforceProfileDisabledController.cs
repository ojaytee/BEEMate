using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EEMate.BEEMateService;
using EEMate.Models;

namespace EEMate.Controllers
{
    public class WorkforceProfileDisabledController : Controller
    {
        //
        // GET: /WorkforceProfileDisabled/

        public ActionResult Index()
        {
            var service = new BEEMateService.BEEMateSoapClient();
            var employees = service.EmployeeListAll(service.GetAuthenticationToken("john@beemate.co.za", "Bee1234"), 1, 9, 2012);

            var employeeWorkforceProfile = WorkForceProfile.GenerateEmployeeWorkforceProfile(employees);
            return View(employeeWorkforceProfile);
        }


    }
}
