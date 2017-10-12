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
                    ConsultantName = db.ConsultantName,
                    Gender=db.Gender,
                    Age=db.Age,
                    CounselingRequired = db.CounselingRequired,
                    CounselingRendered = db.CounselingRendered,
                    LawyerID = db.LawyerID,
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
                    ProjectID=db.ProjectID
                });

        }
        public void Create(ConsultingViewModel db)
        {
            var entity = new Consulting_Table();

            
            entity.ConsultingDate = (DateTime)db.ConsultingDate.Date;
            entity.ConsultantName = db.ConsultantName;
            entity.Age = db.Age;
            entity.Gender = db.Gender;

            entity.CounselingRequired = HttpUtility.HtmlDecode(db.CounselingRequired);
            entity.CounselingRendered = HttpUtility.HtmlDecode(db.CounselingRendered);
            entity.LawyerID = db.LawyerID;
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
            entity.ConsultantName = db.ConsultantName;
            entity.Age = db.Age;
            entity.Gender = db.Gender;
            entity.CounselingRequired = HttpUtility.HtmlDecode(db.CounselingRequired);
            entity.CounselingRendered = HttpUtility.HtmlDecode(db.CounselingRendered);
            entity.LawyerID = db.LawyerID;
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

        public IEnumerable<LawyerForeignkey> GetLawyer()
        {
            return entities.Lawyer_Table.Select(province => new LawyerForeignkey
            {
                LawyerID = province.LawyerID,
                LawyerName = province.LawyerName


            });
            
        }
        public void Dispose()
        {
            entities.Dispose();
        }

    }
}