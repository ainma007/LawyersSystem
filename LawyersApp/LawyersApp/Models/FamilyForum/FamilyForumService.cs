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


        public IEnumerable<FamilyWatchViewModel> ReadWatch()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.FamilyWatch_Table
                .Select(db => new FamilyWatchViewModel
                {
                    FamilyWatchID=db.FamilyWatchID,
                   
                    Date = db.Date.HasValue ? db.Date.Value : default(DateTime),
                    timeFrom = db.timeFrom.HasValue ? db.timeFrom.Value : default(DateTime),
                    TimeTo = db.TimeTo.HasValue ? db.TimeTo.Value : default(DateTime),
                    Attendees = db.Attendees,
                    HoursAttendance = db.HoursAttendance.HasValue ? db.HoursAttendance.Value : default(DateTime),
                    hourDeparture = db.hourDeparture.HasValue ? db.hourDeparture.Value : default(DateTime),

                    CustodialAttendees = db.CustodialAttendees,
                    CustodialHoursAttendance = db.CustodialHoursAttendance.HasValue ? db.CustodialHoursAttendance.Value : default(DateTime),
                    CustodialhourDeparture = db.CustodialhourDeparture.HasValue ? db.CustodialhourDeparture.Value : default(DateTime),
                    Specialist = db.Specialist,
                    Notes = db.Notes,
                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },

                    FamilyForumID = db.FamilyForumID,
                });
        }

        public void CreateWatch(FamilyWatchViewModel db)
        {
            var entity = new FamilyWatch_Table();

            
            entity.Date = (DateTime)db.Date.Date;
            entity.timeFrom = (DateTime)db.timeFrom;
            entity.TimeTo = (DateTime)db.TimeTo;
            entity.Attendees = db.Attendees;
            entity.HoursAttendance = (DateTime)db.HoursAttendance;
            entity.hourDeparture = (DateTime)db.hourDeparture;
            entity.CustodialAttendees = db.CustodialAttendees;
            entity.CustodialHoursAttendance = (DateTime)db.CustodialHoursAttendance;
            entity.CustodialhourDeparture = (DateTime)db.CustodialhourDeparture;
            entity.Specialist = db.Specialist;
            entity.Notes = db.Notes;
            entity.UserID = db.UserID;
            entity.FamilyForumID = db.FamilyForumID;
            entities.FamilyWatch_Table.Add(entity);
            entities.SaveChanges();

            db.FamilyWatchID = entity.FamilyWatchID;
        }
        public void UpdateWatch(FamilyWatchViewModel db)
        {
            var entity = new FamilyWatch_Table();
            entity.FamilyWatchID = db.FamilyWatchID;
            entity.FamilyForumID = db.FamilyForumID;
            entity.Date = (DateTime)db.Date;
            entity.timeFrom = (DateTime)db.timeFrom;
            entity.TimeTo = (DateTime)db.TimeTo;
            entity.Attendees = db.Attendees;
            entity.HoursAttendance = (DateTime)db.HoursAttendance;
            entity.hourDeparture = (DateTime)db.hourDeparture;
            entity.CustodialAttendees = db.CustodialAttendees;
            entity.CustodialHoursAttendance = (DateTime)db.CustodialHoursAttendance;
            entity.CustodialhourDeparture = (DateTime)db.CustodialhourDeparture;
            entity.Specialist = db.Specialist;
            entity.Notes = db.Notes;
            entity.UserID = db.UserID;
            
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void DestroyWatch(FamilyWatchViewModel db)
        {
            var entity = new FamilyWatch_Table();

            entity.FamilyWatchID = db.FamilyWatchID;

            entities.FamilyWatch_Table.Attach(entity);

            entities.FamilyWatch_Table.Remove(entity);

            entities.SaveChanges();
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}