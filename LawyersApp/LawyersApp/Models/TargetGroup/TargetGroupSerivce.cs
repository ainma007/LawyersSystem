using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.WebPages.Html;

namespace LawyersApp.Models.TargetGroup
{
    public class TargetGroupSerivce
    {

        private LawyersEntities entities;

        public TargetGroupSerivce(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<TargetGroupViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.TargetGroup_Table
                .Select(user => new TargetGroupViewModel
                {
                    TargetGroupID = user.TargetGroupID,
                    TargetGroupName = user.TargetGroupName,
                   


                });
        }
        public void Create(TargetGroupViewModel user)
        {
            var entity = new TargetGroup_Table();

            entity.TargetGroupName = user.TargetGroupName;
           
            entities.TargetGroup_Table.Add(entity);
            entities.SaveChanges();

            user.TargetGroupID = entity.TargetGroupID;
        }

        public void Update(TargetGroupViewModel user)
        {
            var entity = new TargetGroup_Table();

            entity.TargetGroupID = user.TargetGroupID;
            entity.TargetGroupName = user.TargetGroupName;
          



            entities.TargetGroup_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(TargetGroupViewModel user)
        {
           
                var entity = new TargetGroup_Table();

                entity.TargetGroupID = user.TargetGroupID;
                entities.TargetGroup_Table.Attach(entity);
                entities.TargetGroup_Table.Remove(entity);
                entities.SaveChanges();
         
        }
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}