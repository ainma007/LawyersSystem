using LawyersApp.Models;
using LawyersApp.Models.Report;
using LawyersApp.Models.TargetGroup;
using LawyersApp.Models.TypeOfCase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace LawyersApp.Controllers
{
    public class ReportCoustomController : Controller
    {
      
        int H = 0;// GET: ReportCoustom
        public ActionResult ReoprtViewr(string projectid, ReportViewModel tb)
        {
            Session["Projectid"] = int.Parse(projectid.ToString());
            H = int.Parse(Session["Projectid"].ToString());

            #region(الجزئية الاولى في التابل)
            TotalLegalIssuesIDCount(tb.StartDate,tb.EndDatetDate);
            TotalLegalIssuesIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalIssuesIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalIssuesIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalIssuesIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);
            //
            TotalSystemicIssuesIDCount(tb.StartDate, tb.EndDatetDate);
            TotalSystemicIssuesIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicIssuesIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicIssuesIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicIssuesIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);

            TotalLegalConsultingIDCount(tb.StartDate, tb.EndDatetDate);
            TotalLegalConsultingIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalConsultingIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalConsultingIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalConsultingIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);
            //
            TotalSystemicConsultingIDCount(tb.StartDate, tb.EndDatetDate);
            TotalSystemicConsultingIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicConsultingIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicConsultingIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicConsultingIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);
            //
            TotalLegalOrderIDCount(tb.StartDate, tb.EndDatetDate);
            TotalLegalOrderIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalOrderIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalOrderIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalOrderIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);
            //
            TotalSystemicOrderIDCount(tb.StartDate, tb.EndDatetDate);
            TotalSystemicOrderIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicOrderIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicOrderIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicOrderIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);
            //
            TotalLegalMediationIDCount(tb.StartDate, tb.EndDatetDate);
            TotalLegalMediationIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalMediationIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalMediationIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalLegalMediationIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);
            //
            TotalSystemicMediationIDCount(tb.StartDate, tb.EndDatetDate);
            TotalSystemicMediationIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicMediationIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicMediationIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalSystemicMediationIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);
            //
            TotalDiligence1MediationIDCount(tb.StartDate, tb.EndDatetDate);

            TotalDiligence1MediationIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalDiligence1MediationIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalDiligence1MediationIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalDiligence1MediationIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);
            //
            TotalDiligence2MediationIDCount(tb.StartDate, tb.EndDatetDate);
            TotalDiligence2MediationIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalDiligence2MediationIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalDiligence2MediationIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalDiligence2MediationIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);
            //
            TotalDiligence3MediationIDCount(tb.StartDate, tb.EndDatetDate);
            TotalDiligence3MediationIDMaleUp18Count(tb.StartDate, tb.EndDatetDate);
            TotalDiligence3MediationIDFemalUP18Count(tb.StartDate, tb.EndDatetDate);
            TotalDiligence3MediationIDMaleUNder18Count(tb.StartDate, tb.EndDatetDate);
            TotalDiligence3MediationIDFemalUNder18Count(tb.StartDate, tb.EndDatetDate);
            #endregion
            GetLegalIsuee(tb.StartDate,tb.EndDatetDate);
            GetSystemicIsuee(tb.StartDate, tb.EndDatetDate);
            GetCourses(tb.StartDate, tb.EndDatetDate);
            GetTrainingTotalMales(tb.StartDate, tb.EndDatetDate);
            GetTrainingTotalFemales(tb.StartDate, tb.EndDatetDate);
            AwarenessWorkshopsCount(tb.StartDate, tb.EndDatetDate);
            AwarenesTotalHours(tb.StartDate, tb.EndDatetDate);
            AwarenessTotalBeneficiaries(tb.StartDate, tb.EndDatetDate);
            AwarenessMales(tb.StartDate, tb.EndDatetDate);
            AwarenessFemales(tb.StartDate, tb.EndDatetDate);
            AwarenessBoy(tb.StartDate, tb.EndDatetDate);
            AwarenessGirl(tb.StartDate, tb.EndDatetDate);
            GetTotalArbitration(tb.StartDate, tb.EndDatetDate);
            GetTotalAdvocacyactivities(tb.StartDate, tb.EndDatetDate);
            GetTotalVersions(tb.StartDate, tb.EndDatetDate);
            GetTotalMedia1(tb.StartDate, tb.EndDatetDate);
            GetTotalMedia2(tb.StartDate, tb.EndDatetDate);
            return View(tb);
        }
        private TypeOfCaseService TypeOfCaseService;
        private TargetGroupSerivce TargetGroupSerivce;
        public ReportCoustomController()
        {
            TypeOfCaseService = new TypeOfCaseService(new LawyersEntities());
            TargetGroupSerivce = new TargetGroupSerivce(new LawyersEntities());
        }

        #region(الأرشيف الاساسي)
        #region(الاجمالي لتحصيل القضايا الشرعية)
        public int TotalLegalIssuesIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalIssuesIDCount = (from m in entities.LegalIssues_Table.Where(p => p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date ) select new { m.LegalIssuesID }).Count();
            return ViewBag.TotalLegalIssuesIDCount;

        }
        public int TotalLegalIssuesIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalIssuesIDMaleUp18Count = (from m in entities.LegalIssues_Table.Where(p => p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date  && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.LegalIssuesID }).Count();
            return ViewBag.TotalLegalIssuesIDMaleUp18Count;

        }
        public int TotalLegalIssuesIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalIssuesIDFemalUP18Count = (from m in entities.LegalIssues_Table.Where(p => p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date  && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.LegalIssuesID }).Count();
            return ViewBag.TotalLegalIssuesIDFemalUP18Count;

        }
        public int TotalLegalIssuesIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalIssuesIDMaleUNder18Count = (from m in entities.LegalIssues_Table.Where(p => p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date  && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.LegalIssuesID }).Count();
            return ViewBag.TotalLegalIssuesIDMaleUNder18Count;

        }
        public int TotalLegalIssuesIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalIssuesIDFemalUNder18Count = (from m in entities.LegalIssues_Table.Where(p => p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date  && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.LegalIssuesID }).Count();
            return ViewBag.TotalLegalIssuesIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل القضايا النظامية)
        public int TotalSystemicIssuesIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicIssuesIDCount = (from m in entities.SystemicIssuesInProject_Table.Where(p => p.ProjectID == H && p.SetInProjectDate >= date1.Date && p.SetInProjectDate <= date2.Date) select new { m.SystemicIssuesID }).Count();
            return ViewBag.TotalSystemicIssuesIDCount;

        }
        public int TotalSystemicIssuesIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicIssuesIDMaleUp18Count = (from m in entities.SystemicIssuesInProject_Table.Where(p => p.ProjectID == H && p.SetInProjectDate >= date1.Date && p.SetInProjectDate <= date2.Date && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==1 && p.SystemicIssues_Table.BeneficiariesAge >= 18) select new { m.SystemicIssuesID }).Count();
            return ViewBag.TotalSystemicIssuesIDMaleUp18Count;

        }
        public int TotalSystemicIssuesIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicIssuesIDFemalUP18Count = (from m in entities.SystemicIssuesInProject_Table.Where(p => p.ProjectID == H && p.SetInProjectDate >= date1.Date && p.SetInProjectDate <= date2.Date && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==2 && p.SystemicIssues_Table.BeneficiariesAge >= 18) select new { m.SystemicIssuesID }).Count();
            return ViewBag.TotalSystemicIssuesIDFemalUP18Count;

        }
        public int TotalSystemicIssuesIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicIssuesIDMaleUNder18Count = (from m in entities.SystemicIssuesInProject_Table.Where(p => p.ProjectID == H && p.SetInProjectDate >= date1.Date && p.SetInProjectDate <= date2.Date && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==1 && p.SystemicIssues_Table.BeneficiariesAge < 18) select new { m.SystemicIssuesID }).Count();
            return ViewBag.TotalSystemicIssuesIDMaleUNder18Count;

        }
        public int TotalSystemicIssuesIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicIssuesIDFemalUNder18Count = (from m in entities.SystemicIssuesInProject_Table.Where(p => p.ProjectID == H && p.SetInProjectDate >= date1.Date && p.SetInProjectDate <= date2.Date && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==2 && p.SystemicIssues_Table.BeneficiariesAge < 18) select new { m.SystemicIssuesID }).Count();
            return ViewBag.TotalSystemicIssuesIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الاستشارات الشرعية)
        public int TotalLegalConsultingIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalConsultingIDCount = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date  && p.IssuesTypeID == 2) select new { m.ConsultingID }).Count();
            return ViewBag.TotalLegalConsultingIDCount;

        }
        public int TotalLegalConsultingIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalConsultingIDMaleUp18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date  && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalLegalConsultingIDMaleUp18Count;

        }
        public int TotalLegalConsultingIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalConsultingIDFemalUP18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date  && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalLegalConsultingIDFemalUP18Count;

        }
        public int TotalLegalConsultingIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalConsultingIDMaleUNder18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date  && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalLegalConsultingIDMaleUNder18Count;

        }
        public int TotalLegalConsultingIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalConsultingIDFemalUNder18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date  && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalLegalConsultingIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الاستشارات النظامية)
        public int TotalSystemicConsultingIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicConsultingIDCount = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date  && p.IssuesTypeID == 1) select new { m.ConsultingID }).Count();
            return ViewBag.TotalSystemicConsultingIDCount;

        }
        public int TotalSystemicConsultingIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicConsultingIDMaleUp18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date  && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalSystemicConsultingIDMaleUp18Count;

        }
        public int TotalSystemicConsultingIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicConsultingIDFemalUP18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date  && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalSystemicConsultingIDFemalUP18Count;

        }
        public int TotalSystemicConsultingIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicConsultingIDMaleUNder18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date  && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalSystemicConsultingIDMaleUNder18Count;

        }
        public int TotalSystemicConsultingIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicConsultingIDFemalUNder18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date  && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalSystemicConsultingIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الطللبات الشرعية)
        public int TotalLegalOrderIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalOrderIDCount = (from m in entities.Order_Table.Where(p =>p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date && p.IssuesTypeID == 2) select new { m.OrderID }).Count();
            return ViewBag.TotalLegalOrderIDCount;

        }
        public int TotalLegalOrderIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalOrderIDMaleUp18Count = (from m in entities.Order_Table.Where(p =>p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.OrderID }).Count();
            return ViewBag.TotalLegalOrderIDMaleUp18Count;

        }
        public int TotalLegalOrderIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalOrderIDFemalUP18Count = (from m in entities.Order_Table.Where(p =>p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.OrderID }).Count();
            return ViewBag.TotalLegalOrderIDFemalUP18Count;

        }
        public int TotalLegalOrderIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalOrderIDMaleUNder18Count = (from m in entities.Order_Table.Where(p =>p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.OrderID }).Count();
            return ViewBag.TotalLegalOrderIDMaleUNder18Count;

        }
        public int TotalLegalOrderIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalOrderIDFemalUNder18Count = (from m in entities.Order_Table.Where(p =>p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.OrderID }).Count();
            return ViewBag.TotalLegalOrderIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الطللبات النظامية)
        public int TotalSystemicOrderIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicOrderIDCount = (from m in entities.Order_Table.Where(p =>p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date && p.IssuesTypeID == 1) select new { m.OrderID }).Count();
            return ViewBag.TotalSystemicOrderIDCount;

        }
        public int TotalSystemicOrderIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicOrderIDMaleUp18Count = (from m in entities.Order_Table.Where(p =>p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.OrderID }).Count();
            return ViewBag.TotalSystemicOrderIDMaleUp18Count;

        }
        public int TotalSystemicOrderIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicOrderIDFemalUP18Count = (from m in entities.Order_Table.Where(p =>p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.OrderID }).Count();
            return ViewBag.TotalSystemicOrderIDFemalUP18Count;

        }
        public int TotalSystemicOrderIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicOrderIDMaleUNder18Count = (from m in entities.Order_Table.Where(p =>p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.OrderID }).Count();
            return ViewBag.TotalSystemicOrderIDMaleUNder18Count;

        }
        public int TotalSystemicOrderIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicOrderIDFemalUNder18Count = (from m in entities.Order_Table.Where(p =>p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.OrderID }).Count();
            return ViewBag.TotalSystemicOrderIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الوساطة شرعي)
        public int TotalLegalMediationIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalMediationIDCount = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.IssuesTypeID == 2) select new { m.MediationID }).Count();
            return ViewBag.TotalLegalMediationIDCount;

        }
        public int TotalLegalMediationIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalMediationIDMaleUp18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalLegalMediationIDMaleUp18Count;

        }
        public int TotalLegalMediationIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalMediationIDFemalUP18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalLegalMediationIDFemalUP18Count;

        }
        public int TotalLegalMediationIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalMediationIDMaleUNder18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalLegalMediationIDMaleUNder18Count;

        }
        public int TotalLegalMediationIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalMediationIDFemalUNder18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalLegalMediationIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الوساطة النظامية)
        public int TotalSystemicMediationIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicMediationIDCount = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.IssuesTypeID == 1) select new { m.MediationID }).Count();
            return ViewBag.TotalSystemicMediationIDCount;

        }
        public int TotalSystemicMediationIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicMediationIDMaleUp18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalSystemicMediationIDMaleUp18Count;

        }
        public int TotalSystemicMediationIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicMediationIDFemalUP18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalSystemicMediationIDFemalUP18Count;

        }
        public int TotalSystemicMediationIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicMediationIDMaleUNder18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalSystemicMediationIDMaleUNder18Count;

        }
        public int TotalSystemicMediationIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicMediationIDFemalUNder18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalSystemicMediationIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الوساطة بجهود محامي)
        public int TotalDiligence1MediationIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence1MediationIDCount = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 1) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence1MediationIDCount;

        }
        public int TotalDiligence1MediationIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence1MediationIDMaleUp18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence1MediationIDMaleUp18Count;

        }
        public int TotalDiligence1MediationIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence1MediationIDFemalUP18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence1MediationIDFemalUP18Count;

        }
        public int TotalDiligence1MediationIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence1MediationIDMaleUNder18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence1MediationIDMaleUNder18Count;

        }
        public int TotalDiligence1MediationIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence1MediationIDFemalUNder18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence1MediationIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الوساطة بجهود عشائر الاصلاح)
        public int TotalDiligence2MediationIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence2MediationIDCount = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 2) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence2MediationIDCount;

        }
        public int TotalDiligence2MediationIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence2MediationIDMaleUp18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence2MediationIDMaleUp18Count;

        }
        public int TotalDiligence2MediationIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence2MediationIDFemalUP18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence2MediationIDFemalUP18Count;

        }
        public int TotalDiligence2MediationIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence2MediationIDMaleUNder18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence2MediationIDMaleUNder18Count;

        }
        public int TotalDiligence2MediationIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence2MediationIDFemalUNder18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence2MediationIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الوساطة بجهود الاثنين معاً)
        public int TotalDiligence3MediationIDCount(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence3MediationIDCount = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 3) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence3MediationIDCount;

        }
        public int TotalDiligence3MediationIDMaleUp18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence3MediationIDMaleUp18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 3 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence3MediationIDMaleUp18Count;

        }
        public int TotalDiligence3MediationIDFemalUP18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence3MediationIDFemalUP18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 3 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence3MediationIDFemalUP18Count;

        }
        public int TotalDiligence3MediationIDMaleUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence3MediationIDMaleUNder18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 3 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence3MediationIDMaleUNder18Count;

        }
        public int TotalDiligence3MediationIDFemalUNder18Count(DateTime date1, DateTime date2)
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence3MediationIDFemalUNder18Count = (from m in entities.Mediation_Table.Where(p =>p.ProjectID == H && p.MediationDate>= date1.Date && p.MediationDate<= date2.Date && p.DiligenceTypeID == 3 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence3MediationIDFemalUNder18Count;

        }
        #endregion



        #endregion
        #region(القضايا الشرعية)
        #region(تحصيل تمثيل القضايا الشرعية)
        public int GetTotalLegalissuesMaleUp18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.LegalIssues_Table

                       where p.TypeOfCaseID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge >= 18

                       select p.LegalIssuesID).Count();
            return LST;

        }
        public int GetTotalLegalissuesMaleUnder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.LegalIssues_Table

                       where p.TypeOfCaseID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge < 18

                       select p.LegalIssuesID).Count();
            return LST;

        }
        public int GetTotalLegalissuesFemalUp18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.LegalIssues_Table

                       where p.TypeOfCaseID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge >= 18
                       select p.LegalIssuesID).Count();
            return LST;

        }
        public int GetTotalLegalissuesFemalUnder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.LegalIssues_Table

                       where p.TypeOfCaseID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge < 18
                       select p.LegalIssuesID).Count();
            return LST;

        }
        #endregion

        #region(تحصيل استشارات القضايا الشرعية)
        public int GettotalLegalConsultingMaleUP18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                       && p.IssuesTypeID == 2
                     && p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge >= 18

                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalLegalConsultingMaleUNder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                        && p.IssuesTypeID == 2
                     && p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge < 18

                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalLegalConsultingFemaleUP18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                        && p.IssuesTypeID == 2
                     && p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge >= 18
                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalLegalConsultingFemaleUNder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                       && p.IssuesTypeID == 2
                     && p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge < 18
                       select p.ConsultingID).Count();
            return LST;

        }
        #endregion

        #region(تحصيل طلبات القضايا الشرعية)
        public int GetTotalLegalOrderMaleUp18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                       && p.IssuesTypeID == 2
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge >= 18

                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalLegalOrderMaleUnder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                       && p.IssuesTypeID == 2
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge < 18

                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalLegalOrderFemalUp18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                       && p.IssuesTypeID == 2
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge >= 18
                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalLegalOrderFemalUnder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                       && p.IssuesTypeID == 2
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge < 18
                       select p.OrderID).Count();
            return LST;

        }
        #endregion
        public void GetLegalIsuee(DateTime date1, DateTime date2)
        {
            LawyersEntities enties = new LawyersEntities();
            enties = new LawyersEntities();
            var q = TypeOfCaseService.Read().Where(e => e.IssuesTypeID == 2);
            List<ReportViewModel> ls = new List<ReportViewModel>();
            foreach (var item in q)
            {

                ls.Add(new ReportViewModel()
                {
                    typeOfCaseLegal = item.TypeOfCase,
                    totalLegalissuesMaleUP18 = GetTotalLegalissuesMaleUp18(item.TypeOfCaseID,date1,date2),
                    totalLegalissuesFemaleUP18 = GetTotalLegalissuesFemalUp18(item.TypeOfCaseID,date1,date2),
                    totalLegalissuesMaleUNder18 = GetTotalLegalissuesMaleUnder18(item.TypeOfCaseID,date1,date2),
                    totalLegalissuesFemaleUNder18 = GetTotalLegalissuesFemalUnder18(item.TypeOfCaseID,date1,date2),
                    totalLegalConsultingMaleUP18 = GettotalLegalConsultingMaleUP18(item.TypeOfCaseID,date1,date2),
                    totalLegalConsultingFemaleUP18 = GettotalLegalConsultingFemaleUP18(item.TypeOfCaseID,date1,date2),
                    totalLegalConsultingMaleUNder18 = GettotalLegalConsultingMaleUNder18(item.TypeOfCaseID,date1,date2),
                    totalLegalConsultingFemaleUNder18 = GettotalLegalConsultingFemaleUNder18(item.TypeOfCaseID,date1,date2),
                    totalLegalOrderMaleUP18 = GetTotalLegalOrderMaleUp18(item.TypeOfCaseID,date1,date2),
                    totalLegalOrderFemaleUP18 = GetTotalLegalOrderFemalUp18(item.TypeOfCaseID,date1,date2),
                    totalLegalOrderMaleUNder18 = GetTotalLegalOrderMaleUnder18(item.TypeOfCaseID,date1,date2),
                    totalLegalOrderFemaleUNder18 = GetTotalLegalOrderFemalUnder18(item.TypeOfCaseID,date1,date2)

                });

            }
            ViewBag.TotalIssue = ls;
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion


        #region(القضايا النظامية)
        #region(تحصيل تمثيل القضايا النظامية)
        public int GetTotalSystemicIssuesMaleUp18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.SystemicIssuesInProject_Table

                       where p.SystemicIssues_Table.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.SetInProjectDate >= date1.Date && p.SetInProjectDate <= date2.Date
                     && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==1
                     && p.SystemicIssues_Table.BeneficiariesAge >= 18

                       select p.SystemicIssuesID).Count();
            return LST;

        }
        public int GetTotalSystemicIssuesMaleUnder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.SystemicIssuesInProject_Table

                       where p.SystemicIssues_Table.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.SetInProjectDate >= date1.Date && p.SetInProjectDate <= date2.Date
                     && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==1
                     && p.SystemicIssues_Table.BeneficiariesAge < 18

                       select p.SystemicIssuesID).Count();
            return LST;

        }
        public int GetTotalSystemicIssuesFemalUp18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.SystemicIssuesInProject_Table

                       where p.SystemicIssues_Table.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.SetInProjectDate >= date1.Date && p.SetInProjectDate <= date2.Date
                     && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==2
                     && p.SystemicIssues_Table.BeneficiariesAge >= 18
                       select p.SystemicIssuesID).Count();
            return LST;

        }
        public int GetTotalSystemicIssuesFemalUnder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.SystemicIssuesInProject_Table

                       where p.SystemicIssues_Table.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.SetInProjectDate >= date1.Date && p.SetInProjectDate <= date2.Date
                     && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==2
                     && p.SystemicIssues_Table.BeneficiariesAge < 18
                       select p.SystemicIssuesID).Count();
            return LST;

        }
        #endregion

        #region(تحصيل استشارات القضايا النظامية)
        public int GettotalSystemicConsultingMaleUP18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                       && p.IssuesTypeID == 1
                     && p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge >= 18

                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalSystemicConsultingMaleUNder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                        && p.IssuesTypeID == 1
                     && p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge < 18

                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalSystemicConsultingFemaleUP18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                        && p.IssuesTypeID == 1
                     && p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge >= 18
                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalSystemicConsultingFemaleUNder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                       && p.IssuesTypeID == 1
                     && p.ProjectID == H && p.ConsultingDate >= date1.Date && p.ConsultingDate <= date2.Date
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge < 18
                       select p.ConsultingID).Count();
            return LST;

        }
        #endregion

        #region(تحصيل طلبات القضايا النظامية)
        public int GetTotalSystemicOrderMaleUp18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                      && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                        && p.IssuesTypeID == 1
                      && p.Beneficiaries_Table.GenderID==1
                      && p.BeneficiariesAge >= 18

                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalSystemicOrderMaleUnder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                     && p.IssuesTypeID == 1
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge < 18

                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalSystemicOrderFemalUp18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                     && p.IssuesTypeID == 1
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge >= 18
                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalSystemicOrderFemalUnder18(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H && p.DateOfCase >= date1.Date && p.DateOfCase <= date2.Date
                     && p.IssuesTypeID == 1
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge < 18
                       select p.OrderID).Count();
            return LST;

        }
        #endregion
        public void GetSystemicIsuee(DateTime date1, DateTime date2)
        {
            var q = TypeOfCaseService.Read().Where(e => e.IssuesTypeID == 1);
            List<ReportViewModel> ls = new List<ReportViewModel>();
            foreach (var item in q)
            {

                ls.Add(new ReportViewModel()
                {
                    typeOfCaseSystemic = item.TypeOfCase,
                    totalSystemicissuesMaleUP18 = GetTotalSystemicIssuesMaleUp18(item.TypeOfCaseID, date1, date2),
                    totalSystemicissuesFemaleUP18 = GetTotalSystemicIssuesFemalUp18(item.TypeOfCaseID, date1, date2),
                    totalSystemicissuesMaleUNder18 = GetTotalSystemicIssuesMaleUnder18(item.TypeOfCaseID, date1, date2),
                    totalSystemicissuesFemaleUNder18 = GetTotalSystemicIssuesFemalUnder18(item.TypeOfCaseID, date1, date2),
                    totalSystemicConsultingMaleUP18 = GettotalSystemicConsultingMaleUP18(item.TypeOfCaseID, date1, date2),
                    totalSystemicConsultingFemaleUP18 = GettotalSystemicConsultingFemaleUP18(item.TypeOfCaseID, date1, date2),
                    totalSystemicConsultingMaleUNder18 = GettotalSystemicConsultingMaleUNder18(item.TypeOfCaseID, date1, date2),
                    totalSystemicConsultingFemaleUNder18 = GettotalSystemicConsultingFemaleUNder18(item.TypeOfCaseID, date1, date2),
                    totalSystemicOrderMaleUP18 = GetTotalSystemicOrderMaleUp18(item.TypeOfCaseID, date1, date2),
                    totalSystemicOrderFemaleUP18 = GetTotalSystemicOrderFemalUp18(item.TypeOfCaseID, date1, date2),
                    totalSystemicOrderMaleUNder18 = GetTotalSystemicOrderMaleUnder18(item.TypeOfCaseID, date1, date2),
                    totalSystemicOrderFemaleUNder18 = GetTotalSystemicOrderFemalUnder18(item.TypeOfCaseID, date1, date2),


                });

            }
            ViewBag.Systemicissues = ls;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region(الجلسات وورش التوعية)
        public int AwarenessWorkshopsCount(DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            ViewBag.AwarenessWorkshopsCount = (from m in entities.AwarenessWorkshops_Table.Where(p => p.ProjectID == H && p.AwarenessDate >= date1.Date && p.AwarenessDate <= date2.Date) select new { m.AwarenessID }).Count();
            return ViewBag.AwarenessWorkshopsCount;

        }

        private int AwarenesTotalHours(DateTime date1, DateTime date2)
        {
            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenesTotalHour = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H && c.AwarenessDate >= date1.Date && c.AwarenessDate <= date2.Date)
                                     .Select(i => i.TotalHours.Value).Sum();
                }
                return ViewBag.AwarenesTotalHour;
            }
            catch (Exception)
            {

                return ViewBag.AwarenesTotalHour = 0;
            }


        }

        private int AwarenessTotalBeneficiaries(DateTime date1, DateTime date2)
        {

            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenessTotalBeneficiaries = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H && c.AwarenessDate >= date1.Date && c.AwarenessDate <= date2.Date)
                                     .Select(i => i.TotalBeneficiaries.Value).Sum();
                }
                return ViewBag.AwarenessTotalBeneficiaries;
            }
            catch (Exception)
            {

                return ViewBag.AwarenessTotalBeneficiaries = 0;
            }


        }

        private int AwarenessMales(DateTime date1, DateTime date2)
        {
            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenessMales = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H && c.AwarenessDate >= date1.Date && c.AwarenessDate <= date2.Date)
                                     .Select(i => i.Males.Value).Sum();
                }
                return ViewBag.AwarenessMales;
            }
            catch (Exception)
            {

                return ViewBag.AwarenessMales = 0;
            }


        }

        private int AwarenessFemales(DateTime date1, DateTime date2)
        {
            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenessFemales = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H && c.AwarenessDate >= date1.Date && c.AwarenessDate <= date2.Date)
                                     .Select(i => i.Females.Value).Sum();
                }
                return ViewBag.AwarenessFemales;
            }
            catch (Exception)
            {

                return ViewBag.AwarenessFemales = 0;
            }



        }

        private int AwarenessBoy(DateTime date1, DateTime date2)
        {
            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenessBoy = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H && c.AwarenessDate >= date1.Date && c.AwarenessDate <= date2.Date)
                                     .Select(i => i.Boy.Value).Sum();
                }
                return ViewBag.AwarenessBoy;
            }
            catch (Exception)
            {

                return ViewBag.AwarenessBoy = 0;
            }


        }

        private int AwarenessGirl(DateTime date1, DateTime date2)
        {
            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenessGirls = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H && c.AwarenessDate >= date1.Date && c.AwarenessDate <= date2.Date)
                                     .Select(i => i.Girl.Value).Sum();
                }
                return ViewBag.AwarenessGirls;
            }
            catch (Exception)
            {

                return ViewBag.AwarenessGirls = 0;
            }


        }

        #endregion

        #region(التدريبات)

        public int GetTotalCourses(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H && p.CoursesStartDate >= date1.Date && p.CoursesStartDate <= date2.Date
                       select p.CoursesID).Count();
            return LST;

        }
        public int GetTotalCoursesTrainingHours(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H && p.CoursesStartDate >= date1.Date && p.CoursesStartDate <= date2.Date
                       select p.TrainingHours).Sum();
            try
            {
                return LST.Value;
            }
            catch (Exception)
            {

                return 0;
            }


        }
        public int GetTotalCoursesTotalSessions(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H && p.CoursesStartDate >= date1.Date && p.CoursesStartDate <= date2.Date
                       select p.TotalSessions).Sum();
            try
            {
                return LST.Value;
            }
            catch (Exception)
            {

                return 0;
            }


        }

        public int GetTotalCoursesTotalBeneficiaries(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H && p.CoursesStartDate >= date1.Date && p.CoursesStartDate <= date2.Date
                       select p.TotalBeneficiaries).Sum();
            try
            {
                return LST.Value;
            }
            catch (Exception)
            {

                return 0;
            }


        }

        public int GetTotalCoursesTotalMales(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H && p.CoursesStartDate >= date1.Date && p.CoursesStartDate <= date2.Date
                       select p.Males).Sum();
            try
            {
                ViewBag.GetTotalCoursesTotalMales = LST;
                return LST.Value;
            }
            catch (Exception)
            {

                return 0;
            }


        }

        public int GetTotalCoursesTotalFemales(int ID, DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H && p.CoursesStartDate >= date1.Date && p.CoursesStartDate <= date2.Date
                       select p.Females).Sum();
            try
            {
                ViewBag.GetTotalCoursesTotalFemales = LST;
                return LST.Value;
            }
            catch (Exception)
            {

                return 0;
            }


        }

        public int GetTrainingTotalMales(DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            ViewBag.GetTotalCoursesTotalMales = (from p in entities.Courses_Table

                                                 where
                        p.ProjectID == H && p.CoursesStartDate >= date1.Date && p.CoursesStartDate <= date2.Date
                                                 select p.Males).Sum();
            try
            {

                return ViewBag.GetTotalCoursesTotalMales;
            }
            catch (Exception)
            {

                return ViewBag.GetTotalCoursesTotalMales = 0;
            }


        }

        public int GetTrainingTotalFemales(DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            ViewBag.GetTotalCoursesTotalFemales = (from p in entities.Courses_Table

                                                   where
                          p.ProjectID == H && p.CoursesStartDate >= date1.Date && p.CoursesStartDate <= date2.Date
                                                   select p.Females).Sum();
            try
            {

                return ViewBag.GetTotalCoursesTotalFemales;
            }
            catch (Exception)
            {

                return ViewBag.GetTotalCoursesTotalFemales = 0;
            }


        }
        public void GetCourses(DateTime date1, DateTime date2)
        {
            LawyersEntities enties = new LawyersEntities();
            enties = new LawyersEntities();
            var q = TargetGroupSerivce.Read();
            List<ReportViewModel> ls = new List<ReportViewModel>();
            foreach (var item in q)
            {

                ls.Add(new ReportViewModel()
                {
                    TargetGroup = item.TargetGroupName,
                    TotalCours = GetTotalCourses(item.TargetGroupID,date1,date2),
                    CoursTotalSessions = int.Parse(GetTotalCoursesTotalSessions(item.TargetGroupID, date1, date2).ToString()),
                    CoursTrainingHours = int.Parse(GetTotalCoursesTrainingHours(item.TargetGroupID, date1, date2).ToString()),
                    CoursTotalBeneficiaries = int.Parse(GetTotalCoursesTotalBeneficiaries(item.TargetGroupID, date1, date2).ToString()),
                    CoursMales = int.Parse(GetTotalCoursesTotalMales(item.TargetGroupID, date1, date2).ToString()),
                    CoursFemales = int.Parse(GetTotalCoursesTotalFemales(item.TargetGroupID, date1, date2).ToString()),

                });

            }
            ViewBag.Cours = ls;

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region()
        public int GetTotalArbitration(DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Arbitration_Table

                       where
                       p.ProjectID == H && p.ArbitrationDate >= date1.Date && p.ArbitrationDate <= date2.Date
                       select p.ArbitrationID).Count();
            return ViewBag.GetTotalArbitration = LST;

        }

        public int GetTotalAdvocacyactivities(DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Advocacyactivities_Table

                       where
                       p.ProjectID == H && p.AdvocacyDate >= date1.Date && p.AdvocacyDate <= date2.Date
                       select p.AdvocacyactivitiesID).Count();
            return ViewBag.GetTotalAdvocacyactivities = LST;

        }
        public int GetTotalVersions(DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Versions_Table

                       where
                       p.ProjectID == H && p.VersionsDate >= date1.Date && p.VersionsDate <= date2.Date
                       select p.ProjectID).Count();
            return ViewBag.GetTotalVersions = LST;

        }
        public int GetTotalMedia1(DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Media_Table

                       where
                       p.ProjectID == H && p.MediaDate >= date1.Date && p.MediaDate <= date2.Date
                       && p.MediaTypeID == 1
                       select p.MediaID).Count();
            return ViewBag.GetTotalMedia1 = LST;

        }

        public int GetTotalMedia2(DateTime date1, DateTime date2)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Media_Table

                       where
                       p.ProjectID == H && p.MediaDate >= date1.Date && p.MediaDate <= date2.Date
                       && p.MediaTypeID == 2
                       select p.MediaID).Count();
            return ViewBag.GetTotalMedia2 = LST;

        }


        #endregion
    }
}