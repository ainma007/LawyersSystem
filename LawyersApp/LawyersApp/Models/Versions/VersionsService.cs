using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Versions
{
    public class VersionsService
    {

        private LawyersEntities entities;

        public VersionsService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<VersionsViewModel> Read()
        {
            return entities.Versions_Table
                .Select(db => new VersionsViewModel
                {
                    VersionsID = db.VersionsID,
                    VersionsName = db.VersionsName,
                    VersionsDate = db.VersionsDate.HasValue ? db.VersionsDate.Value : default(DateTime),
                    PartnerName = db.PartnerName,
                    VersionsNumbers = db.VersionsNumbers,
                    TypesOfCopies = db.TypesOfCopies,
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
        public void Create(VersionsViewModel db)
        {
            var entity = new Versions_Table();

            entity.VersionsName = db.VersionsName;
            entity.VersionsDate = (DateTime)db.VersionsDate.Date;
            entity.PartnerName = db.PartnerName;
            entity.VersionsNumbers = db.VersionsNumbers;
            entity.TypesOfCopies = db.TypesOfCopies;
            entity.url = db.url;
            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            entities.Versions_Table.Add(entity);
            entities.SaveChanges();

            db.VersionsID = entity.VersionsID;
        }

        public void Update(VersionsViewModel db)
        {
            var entity = new Versions_Table();
            entity.VersionsID = db.VersionsID;

            entity.VersionsName = db.VersionsName;
            entity.VersionsDate = (DateTime)db.VersionsDate.Date;
            entity.PartnerName = db.PartnerName;
            entity.VersionsNumbers = db.VersionsNumbers;
            entity.TypesOfCopies = db.TypesOfCopies;
            entity.url = db.url;
            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            entities.Versions_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(VersionsViewModel db)
        {
            var entity = new Versions_Table();

            entity.VersionsID = db.VersionsID;

            entities.Versions_Table.Attach(entity);

            entities.Versions_Table.Remove(entity);

            entities.SaveChanges();
        }

      

        public void Dispose()
        {
            entities.Dispose();
        }

    }
}