using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Advocacyactivities
{
    public class AdvocacyactivitiesService
    {


        private LawyersEntities entities;

        public AdvocacyactivitiesService(LawyersEntities entities)
        {
            this.entities = entities;
        }
        public IEnumerable<AdvocacyactivitiesViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Advocacyactivities_Table
                .Select(db => new AdvocacyactivitiesViewModel
                {
                    AdvocacyactivitiesID = db.AdvocacyactivitiesID,
                    Name = db.Name,
                    AdvocacyDate = db.AdvocacyDate.HasValue ? db.AdvocacyDate.Value : default(DateTime),
                    executingagency = db.executingagency,
                    beneficiary = db.beneficiary,
                    GeographicArea = db.GeographicArea,
                    url = db.url,
                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },

                    ProjectID = db.ProjectID,

                });
        }
        public void Create(AdvocacyactivitiesViewModel db)
        {
            var entity = new Advocacyactivities_Table();

            entity.Name = db.Name;
            entity.AdvocacyDate = (DateTime)db.AdvocacyDate.Date;

            entity.executingagency = db.executingagency;
            entity.beneficiary = db.beneficiary;
            entity.GeographicArea = db.GeographicArea;
            entity.url = db.url;
           

            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            entities.Advocacyactivities_Table.Add(entity);
            entities.SaveChanges();

            db.AdvocacyactivitiesID = entity.AdvocacyactivitiesID;
        }

        public void Update(AdvocacyactivitiesViewModel db)
        {
            var entity = new Advocacyactivities_Table();

            entity.AdvocacyactivitiesID = db.AdvocacyactivitiesID;
            entity.Name = db.Name;
            entity.AdvocacyDate = (DateTime)db.AdvocacyDate.Date;

            entity.executingagency = db.executingagency;
            entity.beneficiary = db.beneficiary;
            entity.GeographicArea = db.GeographicArea;
            entity.url = db.url;

            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            entities.Advocacyactivities_Table.Attach(entity);

            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(AdvocacyactivitiesViewModel db)
        {
            var entity = new Advocacyactivities_Table();

            entity.AdvocacyactivitiesID = db.AdvocacyactivitiesID;

            entities.Advocacyactivities_Table.Attach(entity);

            entities.Advocacyactivities_Table.Remove(entity);

            entities.SaveChanges();
        }



        public void Dispose()
        {
            entities.Dispose();
        }
    }
}