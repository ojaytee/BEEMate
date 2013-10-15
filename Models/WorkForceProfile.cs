using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EEMate.BEEMateService;

namespace EEMate.Models
{
    public static class WorkForceProfile
    {
        public enum EmployeeMovementType
        {
            Recruitment = 1,
            Promotion,
            Termination
        }

        public static WorkforceProfileDetails GenerateEmployeeWorkforceProfile(EmployeeDetails[] employees,
            bool? disabled = null, bool? coreFunction = null, int? movementType = null)
        {
            var wFP = new WorkforceProfileDetails();
            var disabledEmployees = employees.AsQueryable();
            if (disabled.HasValue)
            {
                disabledEmployees = employees.AsQueryable().Where(e => e.Disabled);
            }
            if (coreFunction.HasValue)
            {
                disabledEmployees = employees.AsQueryable().Where(e => e.CoreFunction == coreFunction.Value);
            }

            if (movementType.HasValue)
            {
                switch ((EmployeeMovementType) movementType.Value)
                {
                    case EmployeeMovementType.Recruitment:
                        disabledEmployees = employees.AsQueryable().Where(e => e.StartDate > DateTime.Now.AddMonths(12));
                        break;
                    case EmployeeMovementType.Promotion:
                        disabledEmployees = employees.AsQueryable().Where(e => e.StartDate > DateTime.Now.AddMonths(12));
                        break;
                    case EmployeeMovementType.Termination:
                        disabledEmployees = employees.AsQueryable().Where(e => e.EndDate > DateTime.Now.AddMonths(12));
                        break;
                    default:
                        break;
                }
            }
            wFP.TopManMaleAfrican =
                disabledEmployees.Count(e => e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 0);
            wFP.TopManMaleColoured =
                disabledEmployees.Count(e => e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 0);
            wFP.TopManMaleIndian =
                disabledEmployees.Count(e => e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 0);
            wFP.TopManFemaleWhite =
                disabledEmployees.Count(e => e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 0);
            wFP.TopManFemaleAfrican =
                disabledEmployees.Count(e => !e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 0);
            wFP.TopManFemaleColoured =
                disabledEmployees.Count(e => !e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 0);
            wFP.TopManFemaleIndian =
                disabledEmployees.Count(e => !e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 0);
            wFP.TopManFemaleWhite =
                disabledEmployees.Count(e => !e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 0);
            wFP.TopManForeignMale =
                disabledEmployees.Count(e => e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 0);
            wFP.TopManForeignFemale =
                disabledEmployees.Count(e => !e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 0);
            wFP.TopManTotals = disabledEmployees.Count(e => e.OccupationalLevel == 0);

            wFP.SeniorManMaleAfrican =
                disabledEmployees.Count(e => e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 1);
            wFP.SeniorManMaleColoured =
                disabledEmployees.Count(e => e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 1);
            wFP.SeniorManMaleIndian =
                disabledEmployees.Count(e => e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 1);
            wFP.SeniorManMaleWhite =
                disabledEmployees.Count(e => e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 1);
            wFP.SeniorManFemaleAfrican =
                disabledEmployees.Count(e => !e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 1);
            wFP.SeniorManFemaleColoured =
                disabledEmployees.Count(e => !e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 1);
            wFP.SeniorManFemaleIndian =
                disabledEmployees.Count(e => !e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 1);
            wFP.SeniorManFemaleWhite =
                disabledEmployees.Count(e => !e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 1);
            wFP.SeniorManForeignMale =
                disabledEmployees.Count(e => e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 1);
            wFP.SeniorManForeignFemale =
                disabledEmployees.Count(e => !e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 1);
            wFP.SeniorManTotals = disabledEmployees.Count(e => e.OccupationalLevel == 1);

            wFP.ProfMidManMaleAfrican =
                disabledEmployees.Count(e => e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 2);
            wFP.ProfMidManMaleColoured =
                disabledEmployees.Count(e => e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 2);
            wFP.ProfMidManMaleIndian =
                disabledEmployees.Count(e => e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 2);
            wFP.ProfMidManMaleWhite =
                disabledEmployees.Count(e => e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 2);
            wFP.ProfMidManFemaleAfrican =
                disabledEmployees.Count(e => !e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 2);
            wFP.ProfMidManFemaleColoured =
                disabledEmployees.Count(e => !e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 2);
            wFP.ProfMidManFemaleIndian =
                disabledEmployees.Count(e => !e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 2);
            wFP.ProfMidManFemaleWhite =
                disabledEmployees.Count(e => !e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 2);
            wFP.ProfMidManForeignMale =
                disabledEmployees.Count(e => e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 2);
            wFP.ProfMidManForeignFemale =
                disabledEmployees.Count(e => !e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 2);
            wFP.ProfMidManTotals = disabledEmployees.Count(e => e.OccupationalLevel == 2);

            wFP.SemiSkilledMaleAfrican =
                disabledEmployees.Count(e => e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 4);
            wFP.SemiSkilledMaleColoured =
                disabledEmployees.Count(e => e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 4);
            wFP.SemiSkilledMaleIndian =
                disabledEmployees.Count(e => e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 4);
            wFP.SemiSkilledMaleWhite =
                disabledEmployees.Count(e => e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 4);
            wFP.SemiSkilledFemaleAfrican =
                disabledEmployees.Count(e => !e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 4);
            wFP.SemiSkilledFemaleColoured =
                disabledEmployees.Count(e => !e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 4);
            wFP.SemiSkilledFemaleIndian =
                disabledEmployees.Count(e => !e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 4);
            wFP.SemiSkilledFemaleWhite =
                disabledEmployees.Count(e => !e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 4);
            wFP.SemiSkilledForeignMale =
                disabledEmployees.Count(e => e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 4);
            wFP.SemiSkilledForeignFemale =
                disabledEmployees.Count(e => !e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 4);
            wFP.SemiSkilledTotals = disabledEmployees.Count(e => e.OccupationalLevel == 4);

            wFP.SkilledTechMaleAfrican =
                disabledEmployees.Count(e => e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 3);
            wFP.SkilledTechMaleColoured =
                disabledEmployees.Count(e => e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 3);
            wFP.SkilledTechMaleIndian =
                disabledEmployees.Count(e => e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 3);
            wFP.SkilledTechMaleWhite =
                disabledEmployees.Count(e => e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 3);
            wFP.SkilledTechFemaleAfrican =
                disabledEmployees.Count(e => !e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 3);
            wFP.SkilledTechFemaleColoured =
                disabledEmployees.Count(e => !e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 3);
            wFP.SkilledTechFemaleIndian =
                disabledEmployees.Count(e => !e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 3);
            wFP.SkilledTechFemaleWhite =
                disabledEmployees.Count(e => !e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 3);
            wFP.SkilledTechForeignMale =
                disabledEmployees.Count(e => e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 3);
            wFP.SkilledTechForeignFemale =
                disabledEmployees.Count(e => !e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 3);
            wFP.SkilledTechTotals = disabledEmployees.Count(e => e.OccupationalLevel == 3);

            wFP.UnskilledMaleAfrican =
                disabledEmployees.Count(e => e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 5);
            wFP.UnskilledMaleColoured =
                disabledEmployees.Count(e => e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 5);
            wFP.UnskilledMaleIndian =
                disabledEmployees.Count(e => e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 5);
            wFP.UnskilledMaleWhite =
                disabledEmployees.Count(e => e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 5);
            wFP.UnskilledFemaleAfrican =
                disabledEmployees.Count(e => !e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 5);
            wFP.UnskilledFemaleColoured =
                disabledEmployees.Count(e => !e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 5);
            wFP.UnskilledFemaleIndian =
                disabledEmployees.Count(e => !e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 5);
            wFP.UnskilledFemaleWhite =
                disabledEmployees.Count(e => !e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 5);
            wFP.UnskilledForeignMale =
                disabledEmployees.Count(e => e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 5);
            wFP.UnskilledForeignFemale =
                disabledEmployees.Count(e => !e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 5);
            wFP.UnskilledTotals = disabledEmployees.Count(e => e.OccupationalLevel == 5);

            wFP.TempMaleAfrican =
                disabledEmployees.Count(e => e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 6);
            wFP.TempMaleColoured =
                disabledEmployees.Count(e => e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 6);
            wFP.TempMaleIndian =
                disabledEmployees.Count(e => e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 6);
            wFP.TempMaleWhite =
                disabledEmployees.Count(e => e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 6);
            wFP.TempFemaleAfrican =
                disabledEmployees.Count(e => !e.Gender && e.Race == 0 && e.Citizenship == 1 && e.OccupationalLevel == 6);
            wFP.TempFemaleColoured =
                disabledEmployees.Count(e => !e.Gender && e.Race == 1 && e.Citizenship == 1 && e.OccupationalLevel == 6);
            wFP.TempFemaleIndian =
                disabledEmployees.Count(e => !e.Gender && e.Race == 2 && e.Citizenship == 1 && e.OccupationalLevel == 6);
            wFP.TempFemaleWhite =
                disabledEmployees.Count(e => !e.Gender && e.Race == 3 && e.Citizenship == 1 && e.OccupationalLevel == 6);
            wFP.TempForeignMale =
                disabledEmployees.Count(e => e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 6);
            wFP.TempForeignFemale =
                disabledEmployees.Count(e => !e.Gender && e.Citizenship == 2 && e.OccupationalLevel == 6);
            wFP.TempTotals = disabledEmployees.Count(e => e.OccupationalLevel == 6);

            wFP.TotalPermanentMaleAfrican =
                disabledEmployees.Count(e => e.Gender && e.Race == 0 && e.Citizenship == 1 && e.CurrentlyEmployeed);
            wFP.TotalPermanentMaleColoured =
                disabledEmployees.Count(e => e.Gender && e.Race == 1 && e.Citizenship == 1 && e.CurrentlyEmployeed);
            wFP.TotalPermanentMaleIndian =
                disabledEmployees.Count(e => e.Gender && e.Race == 2 && e.Citizenship == 1 && e.CurrentlyEmployeed);
            wFP.TotalPermanentMaleWhite =
                disabledEmployees.Count(e => e.Gender && e.Race == 3 && e.Citizenship == 1 && e.CurrentlyEmployeed);
            wFP.TotalPermanentFemaleAfrican =
                disabledEmployees.Count(e => !e.Gender && e.Race == 0 && e.Citizenship == 1 && e.CurrentlyEmployeed);
            wFP.TotalPermanentFemaleColoured =
                disabledEmployees.Count(e => !e.Gender && e.Race == 1 && e.Citizenship == 1 && e.CurrentlyEmployeed);
            wFP.TotalPermanentFemaleIndian =
                disabledEmployees.Count(e => !e.Gender && e.Race == 2 && e.Citizenship == 1 && e.CurrentlyEmployeed);
            wFP.TotalPermanentFemaleWhite =
                disabledEmployees.Count(e => !e.Gender && e.Race == 3 && e.Citizenship == 1 && e.CurrentlyEmployeed);
            wFP.TotalPermanentForeignMale =
                disabledEmployees.Count(e => e.Gender && e.Citizenship == 2 && e.CurrentlyEmployeed);
            wFP.TotalPermanentForeignFemale =
                disabledEmployees.Count(e => !e.Gender && e.Citizenship == 2 && e.CurrentlyEmployeed);
            wFP.TotalPermanentTotals = disabledEmployees.Count(e => e.CurrentlyEmployeed);

            wFP.GrandTotalMaleAfrican = disabledEmployees.Count(e => e.Gender && e.Race == 0 && e.Citizenship == 1);
            wFP.GrandTotalMaleColoured = disabledEmployees.Count(e => e.Gender && e.Race == 1 && e.Citizenship == 1);
            wFP.GrandTotalMaleIndian = disabledEmployees.Count(e => e.Gender && e.Race == 2 && e.Citizenship == 1);
            wFP.GrandTotalMaleWhite = disabledEmployees.Count(e => e.Gender && e.Race == 3 && e.Citizenship == 1);
            wFP.GrandTotalFemaleAfrican = disabledEmployees.Count(e => !e.Gender && e.Race == 0 && e.Citizenship == 1);
            wFP.GrandTotalFemaleColoured = disabledEmployees.Count(e => !e.Gender && e.Race == 1 && e.Citizenship == 1);
            wFP.GrandTotalFemaleIndian = disabledEmployees.Count(e => !e.Gender && e.Race == 2 && e.Citizenship == 1);
            wFP.GrandTotalFemaleWhite = disabledEmployees.Count(e => !e.Gender && e.Race == 3 && e.Citizenship == 1);
            wFP.GrandTotalForeignMale = disabledEmployees.Count(e => e.Gender && e.Citizenship == 2);
            wFP.GrandTotalForeignFemale = disabledEmployees.Count(e => !e.Gender && e.Citizenship == 2);
            wFP.GrandTotalTotals = disabledEmployees.Count();


            return wFP;
        }
    }
}