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
                    ConsultingNumber = db.ConsultingNumber,
                    ConsultingDate = db.ConsultingDate.HasValue ? db.ConsultingDate.Value : default(DateTime),

                    ConsultantName = db.ConsultantName,
                    CounselingRequired = db.CounselingRequired,
                    CounselingRendered = db.CounselingRendered,
                    ConsultingProvider = db.ConsultingProvider,
                   CounselingStatus = db.CounselingStatus,



                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },


                });
        }
        public void Create(ConsultingViewModel db)
        {
            var entity = new Consulting_Table();

            entity.ConsultingNumber = db.ConsultingNumber;
            entity.ConsultingDate = (DateTime)db.ConsultingDate.Date;
            entity.ConsultantName = db.ConsultantName;
            entity.CounselingRequired = HttpUtility.HtmlDecode(db.CounselingRequired);
            entity.CounselingRendered = HttpUtility.HtmlDecode(db.CounselingRendered);
            entity.ConsultingProvider = db.ConsultingProvider;
            entity.CounselingStatus = db.CounselingStatus;
            entity.UserID = db.UserID;
            entities.Consulting_Table.Add(entity);
            entities.SaveChanges();

            db.ConsultingID = entity.ConsultingID;
        }

        public void Update(ConsultingViewModel db)
        {
            var entity = new Consulting_Table();
            entity.ConsultingID = db.ConsultingID;

            entity.ConsultingNumber = db.ConsultingNumber;
            entity.ConsultingDate = (DateTime)db.ConsultingDate.Date;
            entity.ConsultantName = db.ConsultantName;
            entity.CounselingRequired = HttpUtility.HtmlDecode(db.CounselingRequired);
            entity.CounselingRendered = HttpUtility.HtmlDecode(db.CounselingRendered);
            entity.CounselingStatus = db.CounselingStatus;

            entity.CounselingStatus = db.CounselingStatus;
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