using LawyersApp.Models.Foreignkey;
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
                    TypeOfCaseID = db.TypeOfCase_ID,
                    TypeOfCase = db.TypeOfCaseName,
                    IssuesTypeID = db.IssuesTypeID,
                    IssuesType = new IssuesTypeForeingKey()
                    {
                        IssuesTypeID = db.IssuesType_Table.IssuesTypeID,
                        IssuesTypename = db.IssuesType_Table.IssuesTypename,
                    },

                  



                });
        }
        public void Create(TypeOfCaseViewModel db)
        {
            var entity = new TypeOfCase_Table();

            entity.TypeOfCaseName = db.TypeOfCase;
            entity.IssuesTypeID = db.IssuesTypeID;
            entities.TypeOfCase_Table.Add(entity);
            entities.SaveChanges();

            db.TypeOfCaseID = entity.TypeOfCase_ID;
        }

        public void Update(TypeOfCaseViewModel db)
        {
            var entity = new TypeOfCase_Table();

            entity.TypeOfCase_ID = db.TypeOfCaseID;
            entity.IssuesTypeID = db.IssuesTypeID;

            entity.TypeOfCaseName = db.TypeOfCase;
          


            entities.TypeOfCase_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(TypeOfCaseViewModel db)
        {
            var entity = new TypeOfCase_Table();

            entity.TypeOfCase_ID = db.TypeOfCaseID;

            entities.TypeOfCase_Table.Attach(entity);

            entities.TypeOfCase_Table.Remove(entity);

            entities.SaveChanges();
        }
        public IEnumerable<IssuesTypeForeingKey> GetIssuesType()
        {
            //  هنا كمان   تم التعديل على حالة المستخدم 
            return entities.IssuesType_Table
                .Select(user => new IssuesTypeForeingKey
                {
                    IssuesTypeID = user.IssuesTypeID,
                    IssuesTypename = user.IssuesTypename,
                                        
                });
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}