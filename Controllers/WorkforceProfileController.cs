using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EEMate.BEEMateService;
using EEMate.Models;

namespace EEMate.Controllers
{
    public class WorkforceProfileController : Controller
    {
        //
        // GET: /WorkforceProfile/

        public ActionResult Index(bool? disabled = null, bool? coreFunction = null,int? movementType = null)
        {
            var service = new BEEMateService.BEEMateSoapClient();
            ViewBag.PageHeader = "Workforce Profile";
            var employeeWorkforceProfile = new WorkforceProfileDetails();
            if (disabled.HasValue || coreFunction.HasValue)
            {
                var employees = service.EmployeeListAll(service.GetAuthenticationToken("john@beemate.co.za", "Bee1234"), 1, 9, 2012);

                employeeWorkforceProfile = WorkForceProfile.GenerateEmployeeWorkforceProfile(employees,disabled, coreFunction);
                ViewBag.PageHeader += string.Format(" - {0}",
                    (disabled.HasValue
                        ? "Disabled"
                        : (coreFunction.Value ? "Core Functions" : "Support Functions")));
            }
            else if (movementType.HasValue)
            {
                var employees = service.EmployeeListAll(service.GetAuthenticationToken("john@beemate.co.za", "Bee1234"), 1, 9, 2012);

                employeeWorkforceProfile = WorkForceProfile.GenerateEmployeeWorkforceProfile(employees, disabled, coreFunction, movementType);

                ViewBag.PageHeader += string.Format(" - {0}", ((WorkForceProfile.EmployeeMovementType)movementType.Value).ToString());
               //switch ((WorkForceProfile.EmployeeMovementType) movementType.Value)
               // {
               //     case WorkForceProfile.EmployeeMovementType.Recruitment:
               //         ViewBag.PageHeader += string.Format(" - Recruitment");
               //         break;
               //     case WorkForceProfile.EmployeeMovementType.Promotion:
               //         ViewBag.PageHeader += string.Format(" - Recruitment");
               //         break;
               //     case WorkForceProfile.EmployeeMovementType.Termination:
               //         break;
               //     default:
               //         break;
               // }            
            }

            else
            {
            employeeWorkforceProfile = service.EmployeeWorkforceProfile(service.GetAuthenticationToken("john@beemate.co.za", "Bee1234"), 1, 9, 2012);
            }
            return View(employeeWorkforceProfile);
        }

    }
}
