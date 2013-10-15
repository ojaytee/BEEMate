using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using EEMate.Models;

namespace EEMate.Controllers
{
    public class ChartController : Controller
    {
        //
        // GET: /Chart/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult CharterHelp()
        {
            var service = new BEEMateService.BEEMateSoapClient();
           var employeeWorkforceProfile = service.EmployeeWorkforceProfile(service.GetAuthenticationToken("john@beemate.co.za", "Bee1234"), 1, 9, 2012);

            new Chart(width: 500, height: 300)

                .AddTitle("Workforce Profile")

                .AddSeries(chartType: "column",

                    xValue: new[] { "Executive Directors","Non-Executive Directors","Senior Managers","Middle Managers","Junior Managers","Semi-skilled","Unskilled","Temps"},

                    yValues: new[] { employeeWorkforceProfile.TopManTotals, employeeWorkforceProfile.TotalPermanentTotals, employeeWorkforceProfile.SeniorManTotals, employeeWorkforceProfile.ProfMidManTotals, employeeWorkforceProfile.SkilledTechTotals, employeeWorkforceProfile.SemiSkilledTotals, employeeWorkforceProfile.UnskilledTotals, employeeWorkforceProfile.TempTotals })

                .Write("bmp");

            return null;
        }
    }
}
