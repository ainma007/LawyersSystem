using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Project
{
    public class ProjectControlSerivce
    {

        private LawyersEntities entities;

        public ProjectControlSerivce(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<ProjectControlViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.ProjectControl_Table
                //.Where( e=> e.Project_Table.Status==true)
                .Select(db => new ProjectControlViewModel
                {
                    ProjectControlID = db.ProjectControlID,
                    UserID = db.UserID,
                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },

                    Project = new ProjectForeignkey()
                    {
                        ProjectID = db.Project_Table.ProjectID,
                        ProjectName = db.Project_Table.ProjectName,
                    },
                    ProjectID = db.ProjectID,
                  
                    Status = db.Status,


                });
        }


      
        public void Create(ProjectControlViewModel db)
        {

            try
            {
                //  تم اضافة هذا الاستعلام لعدم تكرار المشروع للمستخدم
                var project = entities.ProjectControl_Table
                             .Single(i => i.UserID == db.UserID
                                         && i.ProjectID == db.ProjectID);
                db.ProjectControlID = 0;
            }
            catch(Exception)
            {
                var entity = new ProjectControl_Table();

                entity.UserID = db.UserID;
                entity.ProjectID = db.ProjectID;
                entity.Status = db.Status;
                entities.ProjectControl_Table.Add(entity);
                entities.SaveChanges();

                db.ProjectControlID = entity.ProjectControlID;
            }

        }

        public void Update(ProjectControlViewModel db)
        {
            var entity = new ProjectControl_Table();
            entity.ProjectControlID = db.ProjectControlID;
            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            entity.Status = db.Status;



            entities.ProjectControl_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ProjectControlViewModel db)
        {
            var entity = new ProjectControl_Table();

            entity.UserID = db.UserID;
            entities.ProjectControl_Table.Attach(entity);
            entities.ProjectControl_Table.Remove(entity);
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

        public IEnumerable<ProjectForeignkey> GetProject()
        {
            return entities.Project_Table.Select(province => new ProjectForeignkey
            {
                ProjectID = province.ProjectID,
                ProjectName = province.ProjectName


            });
        }

        public void Dispose()
        {
            entities.Dispose();
        }

    }
}