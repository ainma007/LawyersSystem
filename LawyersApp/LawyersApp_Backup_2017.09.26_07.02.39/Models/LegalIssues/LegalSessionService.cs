using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.LegalIssues
{
    public class LegalSessionService
    {
        private LawyersEntities entities;

        public LegalSessionService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<LegalSessionViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.LegalSession_Table
                .Select(db => new LegalSessionViewModel
                {
                    SessionsID = db.SessionsID,
                    SessionsNumber = db.SessionsNumber,
                    SessionsDate = db.SessionsDate.HasValue ? db.SessionsDate.Value : default(DateTime),

                    Sessions_Decision = db.Sessions_Decision,
                    LegalIssuesID = db.LegalIssuesID,
                    UserID = db.UserID,                                          

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },


                });
        }
        public void Create(LegalSessionViewModel db)
        {
            var entity = new LegalSession_Table();

            entity.SessionsNumber = db.SessionsNumber;
            entity.SessionsDate = (DateTime)db.SessionsDate.Date;
            entity.Sessions_Decision = db.Sessions_Decision;
            entity.LegalIssuesID = db.LegalIssuesID;
            entity.UserID = db.UserID;
            entities.LegalSession_Table.Add(entity);
            entities.SaveChanges();

            db.SessionsID = entity.SessionsID;
        }

        public void Update(LegalSessionViewModel db)
        {
            var entity = new LegalSession_Table();
            entity.SessionsID = db.SessionsID;

            entity.SessionsNumber = db.SessionsNumber;
            entity.SessionsDate = (DateTime)db.SessionsDate.Date;
            entity.Sessions_Decision = db.Sessions_Decision;
            entity.LegalIssuesID = db.LegalIssuesID;
            entity.UserID = db.UserID;


            entities.LegalSession_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(LegalSessionViewModel db)
        {
            var entity = new LegalSession_Table();

            entity.SessionsID = db.SessionsID;

            entities.LegalSession_Table.Attach(entity);

            entities.LegalSession_Table.Remove(entity);

            entities.SaveChanges();
        }

        public IEnumerable<UsersForeignkey> GetUsers()
        {
            return entities.Users_Table.Select(province => new UsersForeignkey
            {
                UserID = province.UserID,
                FullName = province.FullName


            });
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}