using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Arbitration
{
    public class ArbitrationService
    {
        private LawyersEntities entities;

        public ArbitrationService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<ArbitrationViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Arbitration_Table
                .Select(db => new ArbitrationViewModel
                {
                    ArbitrationID = db.ArbitrationID,
                    ArbitrationNumber = db.ArbitrationNumber,
                    ArbitrationDate = db.ArbitrationDate.HasValue ? db.ArbitrationDate.Value : default(DateTime),
                    FirstSideName = db.FirstSideName,
                    FirstSideIDNumber = db.FirstSideIDNumber,
                    FirstSidePhone = db.FirstSidePhone,
                    FirstSocialstatus = db.FirstSocialstatus,
                    FirstSideAddress = db.FirstSideAddress,
                    SecondSideName = db.SecondSideName,
                    SecondSideIDNumber = db.SecondSideIDNumber,
                    SecondSidePhone = db.SecondSidePhone,
                    SecondSocialstatus = db.SecondSocialstatus,
                    SecondSideAddress = db.SecondSideAddress,
                    ArbitrationName = db.ArbitrationName,
                    ArbitrationPhone = db.ArbitrationPhone,
                    ArbitrationDecision = db.ArbitrationDecision,



                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },

                    ProjectID=db.ProjectID
                });
        }
        public void Create(ArbitrationViewModel db)
        {
            var entity = new Arbitration_Table();

            entity.ArbitrationNumber = db.ArbitrationNumber;
            entity.ArbitrationDate = (DateTime)db.ArbitrationDate.Date;
            entity.FirstSideName = db.FirstSideName;
            entity.FirstSideIDNumber = db.FirstSideIDNumber;
            entity.FirstSidePhone = db.FirstSidePhone;
            entity.FirstSocialstatus = db.FirstSocialstatus;
            entity.FirstSideAddress = db.FirstSideAddress;
            entity.SecondSideName = db.SecondSideName;
            entity.SecondSideIDNumber = db.SecondSideIDNumber;
            entity.SecondSidePhone = db.SecondSidePhone;
            entity.SecondSocialstatus = db.SecondSocialstatus;
            entity.SecondSideAddress = db.SecondSideAddress;
            entity.ArbitrationName = db.ArbitrationName;
            entity.ArbitrationPhone = db.ArbitrationPhone;
            entity.ArbitrationDecision = HttpUtility.HtmlDecode(db.ArbitrationDecision);
            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            entities.Arbitration_Table.Add(entity);
            entities.SaveChanges();

            db.ArbitrationID = entity.ArbitrationID;
        }

        public void Update(ArbitrationViewModel db)
        {
            var entity = new Arbitration_Table();

            entity.ArbitrationID = db.ArbitrationID;
            entity.ArbitrationNumber = db.ArbitrationNumber;
            entity.ArbitrationDate = (DateTime)db.ArbitrationDate.Date;
            entity.FirstSideName = db.FirstSideName;
            entity.FirstSideIDNumber = db.FirstSideIDNumber;
            entity.FirstSidePhone = db.FirstSidePhone;
            entity.FirstSocialstatus = db.FirstSocialstatus;
            entity.FirstSideAddress = db.FirstSideAddress;
            entity.SecondSideName = db.SecondSideName;
            entity.SecondSideIDNumber = db.SecondSideIDNumber;
            entity.SecondSidePhone = db.SecondSidePhone;
            entity.SecondSocialstatus = db.SecondSocialstatus;
            entity.SecondSideAddress = db.SecondSideAddress;
            entity.ArbitrationName = db.ArbitrationName;
            entity.ArbitrationPhone = db.ArbitrationPhone;
            entity.ArbitrationDecision = HttpUtility.HtmlDecode(db.ArbitrationDecision);
            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;


            entities.Arbitration_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ArbitrationViewModel db)
        {
            var entity = new Arbitration_Table();

            entity.ArbitrationID = db.ArbitrationID;

            entities.Arbitration_Table.Attach(entity);

            entities.Arbitration_Table.Remove(entity);

            entities.SaveChanges();
        }

                
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}