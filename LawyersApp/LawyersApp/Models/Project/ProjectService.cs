using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Project
{
    public class ProjectService
    {
       
            private LawyersEntities entities;

            public ProjectService(LawyersEntities entities)
            {
                this.entities = entities;
            }
        public IEnumerable<ProjectViewModel> Read()
        {
            return entities.Project_Table.Select(db => new ProjectViewModel
            {
                ProjectID = db.ProjectID,
                ProjectName = db.ProjectName,

                StartData = db.StartData.HasValue ? db.StartData.Value : default(DateTime),
                EndDate= db.EndDate.HasValue ? db.EndDate.Value : default(DateTime),
                Status = db.Status,

               
                

                
             
            });
        }

        public IEnumerable<ProjectUserViewModel> UserDread()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.ProjectControl_Table
                .Where(e => e.Project_Table.Status == true && e.Status == true)
                .Select(db => new ProjectUserViewModel
                {
                    ProjectControlID = db.ProjectControlID,
                    UserID = db.UserID,
                    ProjectID = db.ProjectID,
                    ProjectName = db.Project_Table.ProjectName,
                    StartData = db.Project_Table.StartData.HasValue ? db.Project_Table.StartData.Value : default(DateTime),
                    EndDate = db.Project_Table.EndDate.HasValue ? db.Project_Table.EndDate.Value : default(DateTime),
                    Status = db.Status,


                });
        }
        public void Create(ProjectViewModel db)
        {
            var entity = new Project_Table();
            entity.ProjectName = db.ProjectName;
            entity.StartData = (DateTime)db.StartData.Date;
            entity.EndDate = (DateTime)db.EndDate.Date;
            entity.Status = db.Status;
           
            entities.Project_Table.Add(entity);
            entities.SaveChanges();

            db.ProjectID = entity.ProjectID;
        }

        public void Update(ProjectViewModel db)
        {
            var entity = new Project_Table();
            entity.ProjectID = db.ProjectID;
            entity.ProjectName = db.ProjectName;
            entity.StartData = (DateTime)db.StartData.Date;
            entity.EndDate = (DateTime)db.EndDate.Date;
            entity.Status = db.Status;
            entities.Project_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ProjectViewModel db)
        {
            var entity = new Project_Table();

            entity.ProjectID = db.ProjectID;

            entities.Project_Table.Attach(entity);

            entities.Project_Table.Remove(entity);

            entities.SaveChanges();
        }
    }
}