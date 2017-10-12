using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Mediation
{
    public class MediationService
    {
        private LawyersEntities entities;

        public MediationService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<MediationViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Mediation_Table
                .Select(db => new MediationViewModel
                {
                    MediationID = db.MediationID,
                    MediationDate = db.MediationDate.HasValue ? db.MediationDate.Value : default(DateTime),

                    FirstSideName = db.FirstSideName,
                    FirstSideAge=db.FirstSideAge,
                    FirstSideGender=db.FirstSideGender,
                    FirstSideIDNumber = db.FirstSideIDNumber,
                    FirstSidePhone = db.FirstSidePhone,
                    FirstSocialstatus = db.FirstSocialstatus,
                    FirstSideAddress = db.FirstSideAddress,
                    SecondSideName = db.SecondSideName,
                    SecondSideIDNumber = db.SecondSideIDNumber,
                    SecondSidePhone = db.SecondSidePhone,
                    SecondSocialstatus = db.SecondSocialstatus,
                    SecondSideAddress = db.SecondSideAddress,

                    MediatorName = db.MediatorName,

                    MediatorPhone = db.MediatorPhone,
                    Agreement = db.Agreement,



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


                    DiligenceTypeID = db.DiligenceTypeID,

                    DiligenceType = new DiligenceTypeForeingKey()
                    {
                        DiligenceTypeID = db.DiligenceType_Table.DiligenceTypeID,
                        DiligenceTypeName = db.DiligenceType_Table.DiligenceTypeName,
                    },

                    ProjectID=db.ProjectID
                });
        }
        public void Create(MediationViewModel db)
        {
            var entity = new Mediation_Table();

            entity.MediationDate = (DateTime)db.MediationDate.Date;
            entity.FirstSideName = db.FirstSideName;
            entity.FirstSideGender = db.FirstSideGender;
            entity.FirstSideAge = db.FirstSideAge;
            entity.FirstSideIDNumber = db.FirstSideIDNumber;
            entity.FirstSidePhone = db.FirstSidePhone;
            entity.FirstSocialstatus = db.FirstSocialstatus;
            entity.FirstSideAddress = db.FirstSideAddress;
            entity.SecondSideName = db.SecondSideName;
            entity.SecondSideIDNumber = db.SecondSideIDNumber;
            entity.SecondSidePhone = db.SecondSidePhone;
            entity.SecondSocialstatus = db.SecondSocialstatus;
            entity.SecondSideAddress = db.SecondSideAddress;
            entity.MediatorName = db.MediatorName;
            entity.MediatorPhone = db.MediatorPhone;
            entity.Agreement = HttpUtility.HtmlDecode(db.Agreement);
            entity.UserID = db.UserID;
            entity.IssuesTypeID = db.IssuesTypeID;
            entity.DiligenceTypeID = db.DiligenceTypeID;
            entity.ProjectID = db.ProjectID;
            entities.Mediation_Table.Add(entity);
            entities.SaveChanges();

            db.MediationID = entity.MediationID;
        }

        public void Update(MediationViewModel db)
        {
            var entity = new Mediation_Table();

            entity.MediationID = db.MediationID;
          
            entity.MediationDate = (DateTime)db.MediationDate.Date;
            entity.FirstSideName = db.FirstSideName;
            entity.FirstSideGender = db.FirstSideGender;
            entity.FirstSideAge = db.FirstSideAge;
            entity.FirstSideIDNumber = db.FirstSideIDNumber;
            entity.FirstSidePhone = db.FirstSidePhone;
            entity.FirstSocialstatus = db.FirstSocialstatus;
            entity.FirstSideAddress = db.FirstSideAddress;
            entity.SecondSideName = db.SecondSideName;
            entity.SecondSideIDNumber = db.SecondSideIDNumber;
            entity.SecondSidePhone = db.SecondSidePhone;
            entity.SecondSocialstatus = db.SecondSocialstatus;
            entity.SecondSideAddress = db.SecondSideAddress;
            entity.MediatorName = db.MediatorName;
            entity.MediatorPhone = db.MediatorPhone;
            entity.Agreement = HttpUtility.HtmlDecode(db.Agreement);
            entity.UserID = db.UserID;
            entity.IssuesTypeID = db.IssuesTypeID;
            entity.DiligenceTypeID = db.DiligenceTypeID;
            entity.ProjectID = db.ProjectID;

            entities.Mediation_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(MediationViewModel db)
        {
            var entity = new Mediation_Table();

            entity.MediationID = db.MediationID;

            entities.Mediation_Table.Attach(entity);

            entities.Mediation_Table.Remove(entity);

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

        public IEnumerable<DiligenceTypeForeingKey> GetDiligenceType()
        {
            return entities.DiligenceType_Table.Select(province => new DiligenceTypeForeingKey
            {
                DiligenceTypeID = province.DiligenceTypeID,
                DiligenceTypeName = province.DiligenceTypeName


            });
        }
        public void Dispose()
        {
            entities.Dispose();
        }

    }
}