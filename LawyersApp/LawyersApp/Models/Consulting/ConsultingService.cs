using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Consulting
{
    public class ConsultingService
    {
        private LawyersEntities entities;

        public ConsultingService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<ConsultingViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Consulting_Table
                .Select(db => new ConsultingViewModel
                {
                    ConsultingID = db.ConsultingID,
                   
                    ConsultingDate = db.ConsultingDate.HasValue ? db.ConsultingDate.Value : default(DateTime),
                    Beneficiaries_ID = db.Beneficiaries_ID,
                    BeneficiariesIDNumber = db.Beneficiaries_Table.BeneficiariesIDNumber,

                    BeneficiariesName = db.Beneficiaries_Table.BeneficiariesName,
                    Gender = db.Beneficiaries_Table.Gender_Table.GenderName,
                    Beneficiaries = new BeneficiariesForeignkey()
                    {
                        Beneficiaries_ID = db.Beneficiaries_Table.Beneficiaries_ID,
                        BeneficiariesName = db.Beneficiaries_Table.BeneficiariesName,
                        BeneficiariesGender = db.Beneficiaries_Table.Gender_Table.GenderName,
                        BeneficiariesPhone = db.Beneficiaries_Table.BeneficiariesPhone
                    },

                    Governorate_ID = db.Governorate_ID,

                    Governorate = new GovernorateForeignkey()
                    {
                        Governorate_ID = db.Governorate_Table.Governorate_ID,
                        Governorate_Name = db.Governorate_Table.Governorate_Name,
                    },

                    Area_ID = db.Area_ID,

                    Area = new AreaForeignkey()
                    {
                        Area_ID = db.Area_Table.Area_ID,
                        Area_Name = db.Area_Table.Area_Name,
                    },
                    BeneficiariesAge =db.BeneficiariesAge,
                    CounselingRequired = db.CounselingRequired,
                    CounselingRendered = db.CounselingRendered,
                   CounselingStatus = db.CounselingStatus,



                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },

                    IssuesTypeID = db.IssuesTypeID,

                    IssuesType = new IssuesTypeForeingKey()
                    {
                        IssuesTypeID = db.IssuesType_Table.IssuesTypeID,
                        IssuesTypename = db.IssuesType_Table.IssuesTypename,
                    },
                    TypeOfCaseID = db.TypeOfCaseID,

                    TypeOfCase = new TypeOfCaseForeignkey()
                    {
                        TypeOfCaseID = db.TypeOfCase_Table.TypeOfCase_ID,
                        TypeOfCase = db.TypeOfCase_Table.TypeOfCaseName,
                    },

                    ProjectID =db.ProjectID
                });

        }
        public void Create(ConsultingViewModel db)
        {
            var entity = new Consulting_Table();

            
            entity.ConsultingDate = (DateTime)db.ConsultingDate.Date;
            entity.Beneficiaries_ID = db.Beneficiaries_ID;
            var q = entities.Beneficiaries_Table.Where(p => p.Beneficiaries_ID == db.Beneficiaries_ID).SingleOrDefault();
            db.BeneficiariesIDNumber = q.BeneficiariesIDNumber;

            db.BeneficiariesName = q.BeneficiariesName;
            db.Gender = q.Gender_Table.GenderName;
            entity.Area_ID = db.Area_ID;
            entity.BeneficiariesAge = db.BeneficiariesAge;
            entity.Governorate_ID = db.Governorate_ID;

            entity.CounselingRequired = HttpUtility.HtmlDecode(db.CounselingRequired);
            entity.CounselingRendered = HttpUtility.HtmlDecode(db.CounselingRendered);
            entity.CounselingStatus = db.CounselingStatus;
            entity.TypeOfCaseID = db.TypeOfCaseID;
            entity.IssuesTypeID = db.IssuesTypeID;
            entity.ProjectID = db.ProjectID;
            entity.UserID = db.UserID;
            entities.Consulting_Table.Add(entity);
            entities.SaveChanges();

            db.ConsultingID = entity.ConsultingID;
        }

        public void Update(ConsultingViewModel db)
        {
            var entity = new Consulting_Table();
            entity.ConsultingID = db.ConsultingID;

          
            entity.ConsultingDate = (DateTime)db.ConsultingDate.Date;
            entity.Beneficiaries_ID = db.Beneficiaries_ID;
            var q = entities.Beneficiaries_Table.Where(p => p.Beneficiaries_ID == db.Beneficiaries_ID).SingleOrDefault();
            db.BeneficiariesIDNumber = q.BeneficiariesIDNumber;
            db.BeneficiariesName = q.BeneficiariesName;
            db.Gender = q.Gender_Table.GenderName;
            entity.Area_ID = db.Area_ID;
            entity.BeneficiariesAge = db.BeneficiariesAge;
            entity.Governorate_ID = db.Governorate_ID;
            entity.CounselingRequired = HttpUtility.HtmlDecode(db.CounselingRequired);
            entity.CounselingRendered = HttpUtility.HtmlDecode(db.CounselingRendered);
            entity.CounselingStatus = db.CounselingStatus;
            entity.TypeOfCaseID = db.TypeOfCaseID;
            entity.IssuesTypeID = db.IssuesTypeID;
            entity.ProjectID = db.ProjectID;
            entity.UserID = db.UserID;
            entities.Consulting_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ConsultingViewModel db)
        {
            var entity = new Consulting_Table();

            entity.ConsultingID = db.ConsultingID;

            entities.Consulting_Table.Attach(entity);

            entities.Consulting_Table.Remove(entity);

            entities.SaveChanges();
        }


        public IEnumerable<IssuesTypeForeingKey> GetIssuesType()
        {
            return entities.IssuesType_Table.Select(province => new IssuesTypeForeingKey
            {
                IssuesTypeID = province.IssuesTypeID,
                IssuesTypename = province.IssuesTypename


            });
        }

        public IEnumerable<TypeOfCaseForeignkey> GetTypeOfCase( int IssuesTypeID)
        {
            return entities.TypeOfCase_Table.Where(m => m.IssuesTypeID == IssuesTypeID).Select(province => new TypeOfCaseForeignkey
            {
                TypeOfCaseID = province.TypeOfCase_ID,
                TypeOfCase = province.TypeOfCaseName


            });
        }

    
        public void Dispose()
        {
            entities.Dispose();
        }

    }
}