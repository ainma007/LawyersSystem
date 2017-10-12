using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.TypeOfCase
{
    public class TypeOfCaseService
    {
        private LawyersEntities entities;

        public TypeOfCaseService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<TypeOfCaseViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.TypeOfCase_Table
                .Select(db => new TypeOfCaseViewModel
                {
                    TypeOfCaseID = db.TypeOfCaseID,
                    TypeOfCase = db.TypeOfCase,
                 


                });
        }
        public void Create(TypeOfCaseViewModel db)
        {
            var entity = new TypeOfCase_Table();

            entity.TypeOfCase = db.TypeOfCase;
            entities.TypeOfCase_Table.Add(entity);
            entities.SaveChanges();

            db.TypeOfCaseID = entity.TypeOfCaseID;
        }

        public void Update(TypeOfCaseViewModel db)
        {
            var entity = new TypeOfCase_Table();

            entity.TypeOfCaseID = db.TypeOfCaseID;
            entity.TypeOfCase = db.TypeOfCase;
          


            entities.TypeOfCase_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(TypeOfCaseViewModel db)
        {
            var entity = new TypeOfCase_Table();

            entity.TypeOfCaseID = db.TypeOfCaseID;

            entities.TypeOfCase_Table.Attach(entity);

            entities.TypeOfCase_Table.Remove(entity);

            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}