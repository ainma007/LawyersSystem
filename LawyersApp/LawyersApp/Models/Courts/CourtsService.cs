﻿using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Courts
{
    public class CourtsService
    {
        private LawyersEntities entities;

        public CourtsService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<CourtsViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Courts_Table
                .Select(db => new CourtsViewModel
                {
                    CourtsID = db.CourtsID,
                    CourtsName = db.CourtsName,
                    IssuesType = new IssuesTypeForeingKey()
                    {
                        IssuesTypeID = db.IssuesType_Table.IssuesTypeID,
                        IssuesTypename = db.IssuesType_Table.IssuesTypename,
                    },
                    IssuesTypeID=db.IssuesTypeID

                });
        }
        public void Create(CourtsViewModel db)
        {
            var entity = new Courts_Table();

            entity.CourtsName = db.CourtsName;
            entity.IssuesTypeID = db.IssuesTypeID;
            entities.Courts_Table.Add(entity);
            entities.SaveChanges();

            db.CourtsID = entity.CourtsID;
        }

        public void Update(CourtsViewModel db)
        {
            var entity = new Courts_Table();

            entity.CourtsID = db.CourtsID;
            entity.CourtsName = db.CourtsName;
            entity.IssuesTypeID = db.IssuesTypeID;



            entities.Courts_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(CourtsViewModel db)
        {
            var entity = new Courts_Table();

            entity.CourtsID = db.CourtsID;

            entities.Courts_Table.Attach(entity);

            entities.Courts_Table.Remove(entity);

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