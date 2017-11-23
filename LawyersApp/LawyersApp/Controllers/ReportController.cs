using LawyersApp.Models;
using LawyersApp.Models.TypeOfCase;
using LawyersApp.Models.Report;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LawyersApp.Models.LegalIssues;
using LawyersApp.Models.TargetGroup;
using LawyersApp.Models.Attributes;
using System.Net;
using System.IO;

namespace LawyersApp.Controllers
{
    [SessionTimeout]
  
    public class ReportController : Controller
    {
       public int H = 0;

        // GET: Report
        [HttpGet]
        public ActionResult Report(string projectid)
        {
            Session["Projectid"] = int.Parse(projectid.ToString());
            H = int.Parse(Session["Projectid"].ToString());

            GetSystemicIsuee();
            GetLegalIsuee();
            GetCourses();
            GetTrainingTotalMales();
         GetTrainingTotalFemales();
            #region(ورش التوعية)
            AwarenessWorkshopsCount();
            AwarenesTotalHours();
            AwarenessTotalBeneficiaries();
            AwarenessMales();
            AwarenessFemales();
            AwarenessBoy();
            AwarenessGirl();

            #endregion
            TotalLegalIssuesIDCount();
            TotalLegalIssuesIDMaleUp18Count();
            TotalLegalIssuesIDMaleUNder18Count();
            TotalLegalIssuesIDFemalUP18Count();
            TotalLegalIssuesIDFemalUNder18Count();

            TotalSystemicIssuesIDCount();
            TotalSystemicIssuesIDMaleUp18Count();
            TotalSystemicIssuesIDFemalUP18Count();
            TotalSystemicIssuesIDMaleUNder18Count();
            TotalSystemicIssuesIDFemalUNder18Count();

            TotalLegalConsultingIDCount();
            TotalLegalConsultingIDMaleUp18Count();
            TotalLegalConsultingIDFemalUP18Count();
            TotalLegalConsultingIDMaleUNder18Count();
            TotalLegalConsultingIDFemalUNder18Count();
            //
            TotalSystemicConsultingIDCount();
            TotalSystemicConsultingIDMaleUp18Count();
            TotalSystemicConsultingIDFemalUP18Count();
            TotalSystemicConsultingIDMaleUNder18Count();
            TotalSystemicConsultingIDFemalUNder18Count();
            //
            TotalLegalOrderIDCount();
            TotalLegalOrderIDMaleUp18Count();
            TotalLegalOrderIDFemalUP18Count();
            TotalLegalOrderIDMaleUNder18Count();
            TotalLegalOrderIDFemalUNder18Count();
            //
            TotalSystemicOrderIDCount();
            TotalSystemicOrderIDMaleUp18Count();
            TotalSystemicOrderIDFemalUP18Count();
            TotalSystemicOrderIDMaleUNder18Count();
            TotalSystemicOrderIDFemalUNder18Count();
            //
            TotalLegalMediationIDCount();
            TotalLegalMediationIDMaleUp18Count();
            TotalLegalMediationIDFemalUP18Count();
            TotalLegalMediationIDMaleUNder18Count();
            TotalLegalMediationIDFemalUNder18Count();
            //
            TotalSystemicMediationIDCount();
            TotalSystemicMediationIDMaleUp18Count();
            TotalSystemicMediationIDFemalUP18Count();
            TotalSystemicMediationIDMaleUNder18Count();
            TotalSystemicMediationIDFemalUNder18Count();
            //
            TotalDiligence1MediationIDCount();

            TotalDiligence1MediationIDMaleUp18Count();
            TotalDiligence1MediationIDFemalUP18Count();
            TotalDiligence1MediationIDMaleUNder18Count();
            TotalDiligence1MediationIDFemalUNder18Count();
            //
            TotalDiligence2MediationIDCount();
            TotalDiligence2MediationIDMaleUp18Count();
            TotalDiligence2MediationIDFemalUP18Count();
            TotalDiligence2MediationIDMaleUNder18Count();
            TotalDiligence2MediationIDFemalUNder18Count();
            //
            TotalDiligence3MediationIDCount();
            TotalDiligence3MediationIDMaleUp18Count();
            TotalDiligence3MediationIDFemalUP18Count();
            TotalDiligence3MediationIDMaleUNder18Count();
            TotalDiligence3MediationIDFemalUNder18Count();

            //
            GetTotalArbitration();
            GetTotalAdvocacyactivities();
            GetTotalVersions();
            GetTotalMedia1();
            GetTotalMedia2();

           
            return View();
        }
        private TypeOfCaseService TypeOfCaseService;
        private TargetGroupSerivce TargetGroupSerivce;
        public ReportController()
        {
            TypeOfCaseService = new TypeOfCaseService(new LawyersEntities());
            TargetGroupSerivce= new TargetGroupSerivce(new LawyersEntities());
        }

     
        #region(الأرشيف الاساسي)
        #region(الاجمالي لتحصيل القضايا الشرعية)
        public int TotalLegalIssuesIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalIssuesIDCount = (from m in entities.LegalIssues_Table.Where(p => p.ProjectID == H) select new { m.LegalIssuesID }).Count();
            return ViewBag.TotalLegalIssuesIDCount;

        }
        public int TotalLegalIssuesIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalIssuesIDMaleUp18Count = (from m in entities.LegalIssues_Table.Where(p => p.ProjectID == H && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge>=18) select new { m.LegalIssuesID }).Count();
            return ViewBag.TotalLegalIssuesIDMaleUp18Count;

        }
        public int TotalLegalIssuesIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalIssuesIDFemalUP18Count = (from m in entities.LegalIssues_Table.Where(p => p.ProjectID == H && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.LegalIssuesID }).Count();
            return ViewBag.TotalLegalIssuesIDFemalUP18Count;

        }
        public int TotalLegalIssuesIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalIssuesIDMaleUNder18Count = (from m in entities.LegalIssues_Table.Where(p => p.ProjectID == H && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.LegalIssuesID }).Count();
            return ViewBag.TotalLegalIssuesIDMaleUNder18Count;

        }
        public int TotalLegalIssuesIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalIssuesIDFemalUNder18Count = (from m in entities.LegalIssues_Table.Where(p => p.ProjectID == H && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.LegalIssuesID }).Count();
            return ViewBag.TotalLegalIssuesIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل القضايا النظامية)
        public int TotalSystemicIssuesIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicIssuesIDCount = (from m in entities.SystemicIssuesInProject_Table.Where(p => p.ProjectID == H) select new { m.SystemicIssuesID }).Count();
            return ViewBag.TotalSystemicIssuesIDCount;

        }
        public int TotalSystemicIssuesIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicIssuesIDMaleUp18Count = (from m in entities.SystemicIssuesInProject_Table.Where(p => p.ProjectID == H && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==1 && p.SystemicIssues_Table.BeneficiariesAge >= 18) select new { m.SystemicIssuesID }).Count();
            return ViewBag.TotalSystemicIssuesIDMaleUp18Count;

        }
        public int TotalSystemicIssuesIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicIssuesIDFemalUP18Count = (from m in entities.SystemicIssuesInProject_Table.Where(p => p.ProjectID == H && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==2 && p.SystemicIssues_Table.BeneficiariesAge >= 18) select new { m.SystemicIssuesID }).Count();
            return ViewBag.TotalSystemicIssuesIDFemalUP18Count;

        }
        public int TotalSystemicIssuesIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicIssuesIDMaleUNder18Count = (from m in entities.SystemicIssuesInProject_Table.Where(p => p.ProjectID == H && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==1 && p.SystemicIssues_Table.BeneficiariesAge < 18) select new { m.SystemicIssuesID }).Count();
            return ViewBag.TotalSystemicIssuesIDMaleUNder18Count;

        }
        public int TotalSystemicIssuesIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicIssuesIDFemalUNder18Count = (from m in entities.SystemicIssuesInProject_Table.Where(p => p.ProjectID == H && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==2 && p.SystemicIssues_Table.BeneficiariesAge < 18) select new { m.SystemicIssuesID }).Count();
            return ViewBag.TotalSystemicIssuesIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الاستشارات الشرعية)
        public int TotalLegalConsultingIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalConsultingIDCount = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.IssuesTypeID==2) select new { m.ConsultingID }).Count();
            return ViewBag.TotalLegalConsultingIDCount;

        }
        public int TotalLegalConsultingIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalConsultingIDMaleUp18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.IssuesTypeID==2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalLegalConsultingIDMaleUp18Count;

        }
        public int TotalLegalConsultingIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalConsultingIDFemalUP18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.IssuesTypeID==2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalLegalConsultingIDFemalUP18Count;

        }
        public int TotalLegalConsultingIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalConsultingIDMaleUNder18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.IssuesTypeID==2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalLegalConsultingIDMaleUNder18Count;

        }
        public int TotalLegalConsultingIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalConsultingIDFemalUNder18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.IssuesTypeID==2 &&  p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalLegalConsultingIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الاستشارات النظامية)
        public int TotalSystemicConsultingIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicConsultingIDCount = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1) select new { m.ConsultingID }).Count();
            return ViewBag.TotalSystemicConsultingIDCount;

        }
        public int TotalSystemicConsultingIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicConsultingIDMaleUp18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalSystemicConsultingIDMaleUp18Count;

        }
        public int TotalSystemicConsultingIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicConsultingIDFemalUP18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalSystemicConsultingIDFemalUP18Count;

        }
        public int TotalSystemicConsultingIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicConsultingIDMaleUNder18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalSystemicConsultingIDMaleUNder18Count;

        }
        public int TotalSystemicConsultingIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicConsultingIDFemalUNder18Count = (from m in entities.Consulting_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.ConsultingID }).Count();
            return ViewBag.TotalSystemicConsultingIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الطللبات الشرعية)
        public int TotalLegalOrderIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalOrderIDCount = (from m in entities.Order_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 2) select new { m.OrderID }).Count();
            return ViewBag.TotalLegalOrderIDCount;

        }
        public int TotalLegalOrderIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalOrderIDMaleUp18Count = (from m in entities.Order_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.OrderID }).Count();
            return ViewBag.TotalLegalOrderIDMaleUp18Count;

        }
        public int TotalLegalOrderIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalOrderIDFemalUP18Count = (from m in entities.Order_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.OrderID }).Count();
            return ViewBag.TotalLegalOrderIDFemalUP18Count;

        }
        public int TotalLegalOrderIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalOrderIDMaleUNder18Count = (from m in entities.Order_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.OrderID }).Count();
            return ViewBag.TotalLegalOrderIDMaleUNder18Count;

        }
        public int TotalLegalOrderIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalOrderIDFemalUNder18Count = (from m in entities.Order_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.OrderID }).Count();
            return ViewBag.TotalLegalOrderIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الطللبات النظامية)
        public int TotalSystemicOrderIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicOrderIDCount = (from m in entities.Order_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1) select new { m.OrderID }).Count();
            return ViewBag.TotalSystemicOrderIDCount;

        }
        public int TotalSystemicOrderIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicOrderIDMaleUp18Count = (from m in entities.Order_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.OrderID }).Count();
            return ViewBag.TotalSystemicOrderIDMaleUp18Count;

        }
        public int TotalSystemicOrderIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicOrderIDFemalUP18Count = (from m in entities.Order_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.OrderID }).Count();
            return ViewBag.TotalSystemicOrderIDFemalUP18Count;

        }
        public int TotalSystemicOrderIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicOrderIDMaleUNder18Count = (from m in entities.Order_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.OrderID }).Count();
            return ViewBag.TotalSystemicOrderIDMaleUNder18Count;

        }
        public int TotalSystemicOrderIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicOrderIDFemalUNder18Count = (from m in entities.Order_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.OrderID }).Count();
            return ViewBag.TotalSystemicOrderIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الوساطة شرعي)
        public int TotalLegalMediationIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalMediationIDCount = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 2) select new { m.MediationID }).Count();
            return ViewBag.TotalLegalMediationIDCount;

        }
        public int TotalLegalMediationIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalMediationIDMaleUp18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalLegalMediationIDMaleUp18Count;

        }
        public int TotalLegalMediationIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalMediationIDFemalUP18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalLegalMediationIDFemalUP18Count;

        }
        public int TotalLegalMediationIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalMediationIDMaleUNder18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalLegalMediationIDMaleUNder18Count;

        }
        public int TotalLegalMediationIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalLegalMediationIDFemalUNder18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalLegalMediationIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الوساطة النظامية)
        public int TotalSystemicMediationIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicMediationIDCount = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1) select new { m.MediationID }).Count();
            return ViewBag.TotalSystemicMediationIDCount;

        }
        public int TotalSystemicMediationIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicMediationIDMaleUp18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalSystemicMediationIDMaleUp18Count;

        }
        public int TotalSystemicMediationIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicMediationIDFemalUP18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalSystemicMediationIDFemalUP18Count;

        }
        public int TotalSystemicMediationIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicMediationIDMaleUNder18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalSystemicMediationIDMaleUNder18Count;

        }
        public int TotalSystemicMediationIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalSystemicMediationIDFemalUNder18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.IssuesTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalSystemicMediationIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الوساطة بجهود محامي)
        public int TotalDiligence1MediationIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence1MediationIDCount = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 1) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence1MediationIDCount;

        }
        public int TotalDiligence1MediationIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence1MediationIDMaleUp18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence1MediationIDMaleUp18Count;

        }
        public int TotalDiligence1MediationIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence1MediationIDFemalUP18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence1MediationIDFemalUP18Count;

        }
        public int TotalDiligence1MediationIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence1MediationIDMaleUNder18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 1 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence1MediationIDMaleUNder18Count;

        }
        public int TotalDiligence1MediationIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence1MediationIDFemalUNder18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 1 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence1MediationIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الوساطة بجهود عشائر الاصلاح)
        public int TotalDiligence2MediationIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence2MediationIDCount = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 2) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence2MediationIDCount;

        }
        public int TotalDiligence2MediationIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence2MediationIDMaleUp18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence2MediationIDMaleUp18Count;

        }
        public int TotalDiligence2MediationIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence2MediationIDFemalUP18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence2MediationIDFemalUP18Count;

        }
        public int TotalDiligence2MediationIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence2MediationIDMaleUNder18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID ==2 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence2MediationIDMaleUNder18Count;

        }
        public int TotalDiligence2MediationIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence2MediationIDFemalUNder18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 2 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence2MediationIDFemalUNder18Count;

        }
        #endregion

        #region(الاجمالي لتحصيل الوساطة بجهود الاثنين معاً)
        public int TotalDiligence3MediationIDCount()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence3MediationIDCount = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 3) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence3MediationIDCount;

        }
        public int TotalDiligence3MediationIDMaleUp18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence3MediationIDMaleUp18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 3 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence3MediationIDMaleUp18Count;

        }
        public int TotalDiligence3MediationIDFemalUP18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence3MediationIDFemalUP18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 3 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge >= 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence3MediationIDFemalUP18Count;

        }
        public int TotalDiligence3MediationIDMaleUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence3MediationIDMaleUNder18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 3 && p.Beneficiaries_Table.GenderID==1 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence3MediationIDMaleUNder18Count;

        }
        public int TotalDiligence3MediationIDFemalUNder18Count()
        {
            LawyersEntities entities = new LawyersEntities();
            ViewBag.TotalDiligence3MediationIDFemalUNder18Count = (from m in entities.Mediation_Table.Where(p => p.ProjectID == H && p.DiligenceTypeID == 3 && p.Beneficiaries_Table.GenderID==2 && p.BeneficiariesAge < 18) select new { m.MediationID }).Count();
            return ViewBag.TotalDiligence3MediationIDFemalUNder18Count;

        }
        #endregion

        #endregion
        #region(القضايا الشرعية)
        #region(تحصيل تمثيل القضايا الشرعية)
        public int GetTotalLegalissuesMaleUp18( int ID)
        {
            
            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.LegalIssues_Table

                       where p.TypeOfCaseID == ID
                     && p.ProjectID==H
                     &&p.Beneficiaries_Table.GenderID==1
                     &&p.BeneficiariesAge>=18

            select p.LegalIssuesID).Count();
            return LST;

        }
        public int GetTotalLegalissuesMaleUnder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.LegalIssues_Table

                       where p.TypeOfCaseID == ID
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge < 18

                       select p.LegalIssuesID).Count();
            return LST;

        }
        public int GetTotalLegalissuesFemalUp18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.LegalIssues_Table

                       where p.TypeOfCaseID == ID
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge >= 18
                       select p.LegalIssuesID).Count();
            return LST;

        }
        public int GetTotalLegalissuesFemalUnder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.LegalIssues_Table

                       where p.TypeOfCaseID == ID
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge < 18
                       select p.LegalIssuesID).Count();
            return LST;

        }
        #endregion

        #region(تحصيل استشارات القضايا الشرعية)
        public int GettotalLegalConsultingMaleUP18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                       &&p.IssuesTypeID==2
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge >= 18

                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalLegalConsultingMaleUNder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                        && p.IssuesTypeID == 2
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge < 18

                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalLegalConsultingFemaleUP18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                        && p.IssuesTypeID == 2
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge >= 18
                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalLegalConsultingFemaleUNder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                       && p.IssuesTypeID == 2
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge < 18
                       select p.ConsultingID).Count();
            return LST;

        }
        #endregion

        #region(تحصيل طلبات القضايا الشرعية)
        public int GetTotalLegalOrderMaleUp18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H
                       && p.IssuesTypeID == 2
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge >= 18

                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalLegalOrderMaleUnder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H
                       && p.IssuesTypeID == 2
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge < 18

                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalLegalOrderFemalUp18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H
                       && p.IssuesTypeID == 2
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge >= 18
                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalLegalOrderFemalUnder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H
                       && p.IssuesTypeID == 2
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge < 18
                       select p.OrderID).Count();
            return LST;

        }
        #endregion
        public void GetLegalIsuee()
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
                    totalLegalissuesMaleUP18 = GetTotalLegalissuesMaleUp18(item.TypeOfCaseID),
                    totalLegalissuesFemaleUP18 = GetTotalLegalissuesFemalUp18(item.TypeOfCaseID),
                    totalLegalissuesMaleUNder18 = GetTotalLegalissuesMaleUnder18(item.TypeOfCaseID),
                    totalLegalissuesFemaleUNder18 = GetTotalLegalissuesFemalUnder18(item.TypeOfCaseID),
                    totalLegalConsultingMaleUP18 = GettotalLegalConsultingMaleUP18(item.TypeOfCaseID),
                    totalLegalConsultingFemaleUP18 = GettotalLegalConsultingFemaleUP18(item.TypeOfCaseID),
                    totalLegalConsultingMaleUNder18 = GettotalLegalConsultingMaleUNder18(item.TypeOfCaseID),
                    totalLegalConsultingFemaleUNder18 = GettotalLegalConsultingFemaleUNder18(item.TypeOfCaseID),
                    totalLegalOrderMaleUP18 = GetTotalLegalOrderMaleUp18(item.TypeOfCaseID),
                    totalLegalOrderFemaleUP18 = GetTotalLegalOrderFemalUp18(item.TypeOfCaseID),
                    totalLegalOrderMaleUNder18 = GetTotalLegalOrderMaleUnder18(item.TypeOfCaseID),
                    totalLegalOrderFemaleUNder18 = GetTotalLegalOrderFemalUnder18(item.TypeOfCaseID)

                });

            }
            ViewBag.TotalIssue = ls;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion



        #region(القضايا النظامية)
        #region(تحصيل تمثيل القضايا النظامية)
        public int GetTotalSystemicIssuesMaleUp18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.SystemicIssuesInProject_Table

                       where p.SystemicIssues_Table.TypeOfCase_ID == ID
                     && p.ProjectID == H
                     && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==1
                     && p.SystemicIssues_Table.BeneficiariesAge >= 18

                       select p.SystemicIssuesID).Count();
            return LST;

        }
        public int GetTotalSystemicIssuesMaleUnder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.SystemicIssuesInProject_Table

                       where p.SystemicIssues_Table.TypeOfCase_ID == ID
                     && p.ProjectID == H
                     && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==1
                     && p.SystemicIssues_Table.BeneficiariesAge < 18

                       select p.SystemicIssuesID).Count();
            return LST;

        }
        public int GetTotalSystemicIssuesFemalUp18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.SystemicIssuesInProject_Table

                       where p.SystemicIssues_Table.TypeOfCase_ID == ID
                     && p.ProjectID == H
                     && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==2
                     && p.SystemicIssues_Table.BeneficiariesAge >= 18
                       select p.SystemicIssuesID).Count();
            return LST;

        }
        public int GetTotalSystemicIssuesFemalUnder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.SystemicIssuesInProject_Table

                       where p.SystemicIssues_Table.TypeOfCase_ID == ID
                     && p.ProjectID == H
                     && p.SystemicIssues_Table.Beneficiaries_Table.GenderID==2
                     && p.SystemicIssues_Table.BeneficiariesAge < 18
                       select p.SystemicIssuesID).Count();
            return LST;

        }
        #endregion

        #region(تحصيل استشارات القضايا النظامية)
        public int GettotalSystemicConsultingMaleUP18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                       && p.IssuesTypeID == 1
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge >= 18

                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalSystemicConsultingMaleUNder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                        && p.IssuesTypeID == 1
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge < 18

                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalSystemicConsultingFemaleUP18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                        && p.IssuesTypeID == 1
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge >= 18
                       select p.ConsultingID).Count();
            return LST;

        }
        public int GettotalSystemicConsultingFemaleUNder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Consulting_Table

                       where p.TypeOfCaseID == ID
                       && p.IssuesTypeID == 1
                     && p.ProjectID == H
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge < 18
                       select p.ConsultingID).Count();
            return LST;

        }
        #endregion

        #region(تحصيل طلبات القضايا النظامية)
        public int GetTotalSystemicOrderMaleUp18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                      && p.ProjectID == H
                        && p.IssuesTypeID == 1
                      && p.Beneficiaries_Table.GenderID==1
                      && p.BeneficiariesAge >= 18

                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalSystemicOrderMaleUnder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H
                     && p.IssuesTypeID == 1
                     && p.Beneficiaries_Table.GenderID==1
                     && p.BeneficiariesAge < 18

                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalSystemicOrderFemalUp18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H
                     && p.IssuesTypeID == 1
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge >= 18
                       select p.OrderID).Count();
            return LST;

        }
        public int GetTotalSystemicOrderFemalUnder18(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Order_Table

                       where p.TypeOfCase_ID == ID
                     && p.ProjectID == H
                     && p.IssuesTypeID == 1
                     && p.Beneficiaries_Table.GenderID==2
                     && p.BeneficiariesAge < 18
                       select p.OrderID).Count();
            return LST;

        }
        #endregion
        public void GetSystemicIsuee()
        {
            var q = TypeOfCaseService.Read().Where(e => e.IssuesTypeID == 1);
            List<ReportViewModel> ls = new List<ReportViewModel>();
            foreach (var item in q)
            {

                ls.Add(new ReportViewModel()
                {
                    typeOfCaseSystemic = item.TypeOfCase,
                    totalSystemicissuesMaleUP18 = GetTotalSystemicIssuesMaleUp18(item.TypeOfCaseID),
                    totalSystemicissuesFemaleUP18 = GetTotalSystemicIssuesFemalUp18(item.TypeOfCaseID),
                    totalSystemicissuesMaleUNder18 = GetTotalSystemicIssuesMaleUnder18(item.TypeOfCaseID),
                    totalSystemicissuesFemaleUNder18 = GetTotalSystemicIssuesFemalUnder18(item.TypeOfCaseID),
                    totalSystemicConsultingMaleUP18 = GettotalSystemicConsultingMaleUP18(item.TypeOfCaseID),
                    totalSystemicConsultingFemaleUP18 = GettotalSystemicConsultingFemaleUP18(item.TypeOfCaseID),
                    totalSystemicConsultingMaleUNder18 = GettotalSystemicConsultingMaleUNder18(item.TypeOfCaseID),
                    totalSystemicConsultingFemaleUNder18 = GettotalSystemicConsultingFemaleUNder18(item.TypeOfCaseID),
                    totalSystemicOrderMaleUP18 = GetTotalSystemicOrderMaleUp18(item.TypeOfCaseID),
                    totalSystemicOrderFemaleUP18 = GetTotalSystemicOrderFemalUp18(item.TypeOfCaseID),
                    totalSystemicOrderMaleUNder18 = GetTotalSystemicOrderMaleUnder18(item.TypeOfCaseID),
                    totalSystemicOrderFemaleUNder18 = GetTotalSystemicOrderFemalUnder18(item.TypeOfCaseID),


                });

            }
            ViewBag.Systemicissues = ls;
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

        #region(الجلسات وورش التوعية)
        public int AwarenessWorkshopsCount()
        {
          
               LawyersEntities entities = new LawyersEntities();

            ViewBag.AwarenessWorkshopsCount = (from m in entities.AwarenessWorkshops_Table.Where(p=> p.ProjectID==H)  select new { m.AwarenessID }).Count();
            return ViewBag.AwarenessWorkshopsCount;

        }

        private int AwarenesTotalHours()
        {
            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenesTotalHour = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H)
                                     .Select(i => i.TotalHours.Value).Sum();
                }
                return ViewBag.AwarenesTotalHour;
            }
            catch (Exception)
            {

                return ViewBag.AwarenesTotalHour=0;
            }
          

        }

        private int AwarenessTotalBeneficiaries()
        {

            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenessTotalBeneficiaries = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H)
                                     .Select(i => i.TotalBeneficiaries.Value).Sum();
                }
                return ViewBag.AwarenessTotalBeneficiaries;
            }
            catch (Exception)
            {

                return ViewBag.AwarenessTotalBeneficiaries=0;
            }
           

        }

        private int AwarenessMales()
        {
            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenessMales = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H)
                                     .Select(i => i.Males.Value).Sum();
                }
                return ViewBag.AwarenessMales;
            }
            catch (Exception)
            {

                return ViewBag.AwarenessMales = 0;
            }
          

        }

        private int AwarenessFemales()
        {
            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenessFemales = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H)
                                     .Select(i => i.Females.Value).Sum();
                }
                return ViewBag.AwarenessFemales;
            }
            catch (Exception)
            {

              return   ViewBag.AwarenessFemales = 0;
            }

           

        }

        private int AwarenessBoy()
        {
            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenessBoy = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H)
                                     .Select(i => i.Boy.Value).Sum();
                }
                return ViewBag.AwarenessBoy;
            }
            catch (Exception)
            {

                return ViewBag.AwarenessBoy = 0;
            }
           

        }

        private int AwarenessGirl()
        {
            try
            {
                using (LawyersEntities entities = new LawyersEntities())
                {
                    ViewBag.AwarenessGirls = entities.AwarenessWorkshops_Table.Where(c => c.ProjectID == H)
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

        public int GetTotalCourses(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                     where p.TargetGroupID == ID
                     && p.ProjectID == H
                     select p.CoursesID).Count();
            return LST;

        }
        public int GetTotalCoursesTrainingHours(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H
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
        public int GetTotalCoursesTotalSessions(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H
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

        public int GetTotalCoursesTotalBeneficiaries(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H
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

        public int GetTotalCoursesTotalMales(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H
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

        public int GetTotalCoursesTotalFemales(int ID)
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Courses_Table

                       where p.TargetGroupID == ID
                       && p.ProjectID == H
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

        public int GetTrainingTotalMales()
        {

            LawyersEntities entities = new LawyersEntities();

            ViewBag.GetTotalCoursesTotalMales = (from p in entities.Courses_Table

                                                 where
                        p.ProjectID == H
                       select p.Males).Sum();
            try
            {
                
                return ViewBag.GetTotalCoursesTotalMales;
            }
            catch (Exception)
            {

                return ViewBag.GetTotalCoursesTotalMales=0;
            }


        }

        public int GetTrainingTotalFemales()
        {

            LawyersEntities entities = new LawyersEntities();

            ViewBag.GetTotalCoursesTotalFemales = (from p in entities.Courses_Table

                                                 where
                        p.ProjectID == H
                                                 select p.Females).Sum();
            try
            {

                return ViewBag.GetTotalCoursesTotalFemales;
            }
            catch (Exception)
            {

                return ViewBag.GetTotalCoursesTotalFemales= 0;
            }


        }
        public void GetCourses()
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
                    TotalCours = GetTotalCourses(item.TargetGroupID),
                    CoursTotalSessions = int.Parse(GetTotalCoursesTotalSessions(item.TargetGroupID).ToString()),
                    CoursTrainingHours = int.Parse(GetTotalCoursesTrainingHours(item.TargetGroupID).ToString()),
                    CoursTotalBeneficiaries = int.Parse(GetTotalCoursesTotalBeneficiaries(item.TargetGroupID).ToString()),
                    CoursMales = int.Parse(GetTotalCoursesTotalMales(item.TargetGroupID).ToString()),
                    CoursFemales = int.Parse(GetTotalCoursesTotalFemales(item.TargetGroupID).ToString()),

                });

            }
            ViewBag.Cours = ls;
          
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

        #region()
        public int GetTotalArbitration()
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Arbitration_Table

                       where 
                       p.ProjectID == H
                       select p.ArbitrationID).Count();
            return ViewBag.GetTotalArbitration= LST;

        }

        public int GetTotalAdvocacyactivities()
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Advocacyactivities_Table

                       where
                       p.ProjectID == H
                       select p.AdvocacyactivitiesID).Count();
            return ViewBag.GetTotalAdvocacyactivities = LST;

        }
        public int GetTotalVersions()
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Versions_Table

                       where
                       p.ProjectID == H
                       select p.ProjectID).Count();
            return ViewBag.GetTotalVersions = LST;

        }
        public int GetTotalMedia1()
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Media_Table

                       where
                       p.ProjectID == H
                       &&p.MediaTypeID==1
                       select p.MediaID).Count();
            return ViewBag.GetTotalMedia1 = LST;

        }

        public int GetTotalMedia2()
        {

            LawyersEntities entities = new LawyersEntities();

            var LST = (from p in entities.Media_Table

                       where
                       p.ProjectID == H
                       && p.MediaTypeID == 2
                       select p.MediaID).Count();
            return ViewBag.GetTotalMedia2 = LST;

        }


        #endregion


        public void ab()
        {
            LawyersEntities entities = new LawyersEntities();
            var result = from c in entities.Courses_Table
                        
                         group c by c.TargetGroup_Table.TargetGroupName;
            var resutl2 = entities.Courses_Table.GroupBy(c => c.TargetGroup_Table.TargetGroupName);
            List<ReportViewModel> ls = new List<ReportViewModel>();
            foreach (IGrouping <string,Courses_Table>group in result){

                ls.Add(new ReportViewModel() {
                    TargetGroup = group.Key
                
            });

                foreach (Courses_Table c in group)
                {
                    ls.Add(new ReportViewModel()
                    {
                        CoursTrainingHours=c.TrainingHours
                    });
                }
            }
         
            ViewBag.heroo1 = ls;

        }
        public string GetIPAddress()
        {
            string strHostName = System.Net.Dns.GetHostName();
            //IPHostEntry ipHostInfo = Dns.Resolve(Dns.GetHostName()); <-- Obsolete
            IPHostEntry ipHostInfo = Dns.GetHostEntry(strHostName);
            IPAddress ipAddress = ipHostInfo.AddressList[0];

            return ipAddress.ToString();
        }
    }
 

}
