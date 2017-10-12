using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.FamilyForum
{
    public class FamilyForumService
    {

        private LawyersEntities entities;

        public FamilyForumService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<FamilyForumViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.FamilyForum_Table
                .Select(db => new FamilyForumViewModel
                {
                    FamilyForumID = db.FamilyForumID,
                    ViewingDate = db.ViewingDate.HasValue ? db.ViewingDate.Value : default(DateTime),
                    ApplicantName = db.ApplicantName,
                    ApplicantPhone = db.ApplicantPhone,
                    ApplicantSocialStatus = db.ApplicantSocialStatus,
                    ApplicantAddress = db.ApplicantAddress,
                    CustodialName = db.CustodialName,
                    CustodialPhone = db.CustodialPhone,
                    CustodialSocialStatus = db.CustodialSocialStatus,
                    CustodialAddress = db.CustodialAddress,
                    ChildrenNumberMale = db.ChildrenNumberMale,
                    ChildrenNumberFemale = db.ChildrenNumberFemale,
                    CaseType = db.CaseType,
                    ViewingHours = db.ViewingHours,
                    ViewingPlace = db.ViewingPlace,
                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },
                    ProjectID = db.ProjectID,

                });
        }
        public void Create(FamilyForumViewModel db)
        {
            var entity = new FamilyForum_Table();

            entity.ViewingDate = (DateTime)db.ViewingDate.Date;
            entity.ApplicantName = db.ApplicantName;
            entity.ApplicantPhone = db.ApplicantPhone;
            entity.ApplicantSocialStatus = db.ApplicantSocialStatus;
            entity.ApplicantAddress = db.ApplicantAddress;
            entity.CustodialName = db.CustodialName;
            entity.CustodialPhone = db.CustodialPhone;
            entity.CustodialSocialStatus = db.CustodialSocialStatus;
            entity.CustodialAddress = db.CustodialAddress;
            entity.ChildrenNumberMale = db.ChildrenNumberMale;
            entity.ChildrenNumberFemale = db.ChildrenNumberFemale;            
            entity.CaseType = db.CaseType;
            entity.ViewingHours = db.ViewingHours;
            entity.ViewingPlace = db.ViewingPlace;
            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            entities.FamilyForum_Table.Add(entity);
            entities.SaveChanges();

            db.FamilyForumID = entity.FamilyForumID;
        }

        public void Update(FamilyForumViewModel db)
        {
            var entity = new FamilyForum_Table();

            entity.FamilyForumID = db.FamilyForumID;
            entity.ViewingDate = (DateTime)db.ViewingDate.Date;
            entity.ApplicantName = db.ApplicantName;
            entity.ApplicantPhone = db.ApplicantPhone;
            entity.ApplicantSocialStatus = db.ApplicantSocialStatus;
            entity.ApplicantAddress = db.ApplicantAddress;
            entity.CustodialName = db.CustodialName;
            entity.CustodialPhone = db.CustodialPhone;
            entity.CustodialSocialStatus = db.CustodialSocialStatus;
            entity.CustodialAddress = db.CustodialAddress;
            entity.ChildrenNumberMale = db.ChildrenNumberMale;

            entity.ChildrenNumberFemale = db.ChildrenNumberFemale;
            entity.CaseType = db.CaseType;
            entity.ViewingHours = db.ViewingHours;
            entity.ViewingPlace = db.ViewingPlace;
            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            

            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(FamilyForumViewModel db)
        {
            var entity = new FamilyForum_Table();

            entity.FamilyForumID = db.FamilyForumID;

            entities.FamilyForum_Table.Attach(entity);

            entities.FamilyForum_Table.Remove(entity);

            entities.SaveChanges();
        }

      

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}