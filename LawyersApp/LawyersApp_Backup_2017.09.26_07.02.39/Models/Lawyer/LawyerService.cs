using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Lawyer
{
    public class LawyerService
    {

        private LawyersEntities entities;

        public LawyerService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<LawyerViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Lawyer_Table
                .Select(db => new LawyerViewModel
                {
                    LawyerID = db.LawyerID,
                    LawyerName = db.LawyerName,
                    LawyerPhone = db.LawyerPhone,
                    LawyerAddress = db.LawyerAddress,




                });
        }
        public void Create(LawyerViewModel db)
        {
            var entity = new Lawyer_Table();

            entity.LawyerName = db.LawyerName;
            entity.LawyerPhone = db.LawyerPhone;
            entity.LawyerAddress = db.LawyerAddress;
            entities.Lawyer_Table.Add(entity);
            entities.SaveChanges();

            db.LawyerID = entity.LawyerID;
        }

        public void Update(LawyerViewModel db)
        {
            var entity = new Lawyer_Table();

            entity.LawyerID = db.LawyerID;
            entity.LawyerName = db.LawyerName;
            entity.LawyerPhone = db.LawyerPhone;
            entity.LawyerAddress = db.LawyerAddress;



            entities.Lawyer_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(LawyerViewModel db)
        {
            var entity = new Lawyer_Table();

            entity.LawyerID = db.LawyerID;

            entities.Lawyer_Table.Attach(entity);

            entities.Lawyer_Table.Remove(entity);

            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}