using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.AwarenessWorkshops
{
    public class AwarenessWorkshopsService
    {

        private LawyersEntities entities;

        public AwarenessWorkshopsService(LawyersEntities entities)
        {
            this.entities = entities;
        }
        public IEnumerable<AwarenessWorkshopsViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.AwarenessWorkshops_Table
                .Select(db => new AwarenessWorkshopsViewModel
                {
                    AwarenessID = db.AwarenessID,
                    AwarenessName = db.AwarenessName,
                    AwarenessDate = db.AwarenessDate.HasValue ? db.AwarenessDate.Value : default(DateTime),
                    TotalHours = db.TotalHours,
                    TotalBeneficiaries = db.TotalBeneficiaries,
                    Males = db.Males,
                    Females = db.Females,
                    Boy=db.Boy,
                    Girl=db.Girl,
                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },
                    
                    ProjectID = db.ProjectID,

                });
        }
        public void Create(AwarenessWorkshopsViewModel db)
        {
            var entity = new AwarenessWorkshops_Table();

            entity.AwarenessName = db.AwarenessName;
            entity.AwarenessDate = (DateTime)db.AwarenessDate.Date;

            entity.TotalBeneficiaries = db.TotalBeneficiaries;
            entity.TotalHours = db.TotalHours;

            entity.Males = db.Males;
            entity.Females = db.Females;
            entity.Boy = db.Boy;
            entity.Girl = db.Girl;

            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            entities.AwarenessWorkshops_Table.Add(entity);
            entities.SaveChanges();

            db.AwarenessID = entity.AwarenessID;
        }

        public void Update(AwarenessWorkshopsViewModel db)
        {
            var entity = new AwarenessWorkshops_Table();

            entity.AwarenessID = db.AwarenessID;
            entity.AwarenessName = db.AwarenessName;
            entity.AwarenessDate = (DateTime)db.AwarenessDate.Date;
            entity.TotalHours = db.TotalHours;

            entity.TotalBeneficiaries = db.TotalBeneficiaries;
            entity.Males = db.Males;
            entity.Females = db.Females;
            entity.Boy = db.Boy;
            entity.Girl = db.Girl;

            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            entities.AwarenessWorkshops_Table.Attach(entity);

            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(AwarenessWorkshopsViewModel db)
        {
            var entity = new AwarenessWorkshops_Table();

            entity.AwarenessID = db.AwarenessID;

            entities.AwarenessWorkshops_Table.Attach(entity);

            entities.AwarenessWorkshops_Table.Remove(entity);

            entities.SaveChanges();
        }

      

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}