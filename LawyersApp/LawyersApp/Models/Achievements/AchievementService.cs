using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Achievements
{
    public class AchievementService
    {
        private LawyersEntities entities;

        public AchievementService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<AchievementsViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Achievements_Table
                .Select(db => new AchievementsViewModel
                {
                    AchievementID = db.AchievementID,

                    AchievementsDate = db.AchievementsDate.HasValue ? db.AchievementsDate.Value : default(DateTime),
                    AchievementsName = db.AchievementsName,
                    AchievementsAbstract = db.AchievementsAbstract,
                    url = db.url,
                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },

                   
                    ProjectID = db.ProjectID
                });

        }
        public void Create(AchievementsViewModel db)
        {
            var entity = new Achievements_Table();


            entity.AchievementsDate = (DateTime)db.AchievementsDate.Date;
            entity.AchievementsName = db.AchievementsName;
            entity.AchievementsAbstract = HttpUtility.HtmlDecode(db.AchievementsAbstract);
            entity.url = db.url;
            entity.ProjectID = db.ProjectID;
            entity.UserID = db.UserID;
            entities.Achievements_Table.Add(entity);
            entities.SaveChanges();

            db.AchievementID = entity.AchievementID;
        }

        public void Update(AchievementsViewModel db)
        {
            var entity = new Achievements_Table();
            entity.AchievementID = db.AchievementID;
            entity.AchievementsDate = (DateTime)db.AchievementsDate.Date;
            entity.AchievementsName = db.AchievementsName;
            entity.AchievementsAbstract = HttpUtility.HtmlDecode(db.AchievementsAbstract);
            entity.url = db.url;
            entity.ProjectID = db.ProjectID;
            entity.UserID = db.UserID;
            entities.Achievements_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(AchievementsViewModel db)
        {
            var entity = new Achievements_Table();

            entity.AchievementID = db.AchievementID;

            entities.Achievements_Table.Attach(entity);

            entities.Achievements_Table.Remove(entity);

            entities.SaveChanges();
        }


        

     

      
        public void Dispose()
        {
            entities.Dispose();
        }


    }
}