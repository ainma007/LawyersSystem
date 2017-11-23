using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Courses
{
    public class CoursesService
    {
        private LawyersEntities entities;

        public CoursesService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        private static IEnumerable<CoursesViewModel> GetOrders()
        {
            var entities = new LawyersEntities();
            return entities.Courses_Table
              .Select(db => new CoursesViewModel
              {
                  CoursesID = db.CoursesID,
                  CoursesName = db.CoursesName,
                  CoursesStartDate = db.CoursesStartDate.HasValue ? db.CoursesStartDate.Value : default(DateTime),
                  CoursesEndDate = db.CoursesEndDate.HasValue ? db.CoursesEndDate.Value : default(DateTime),
                  TotalSessions = db.TotalSessions,
                  TrainingHours = db.TrainingHours,
                  TotalBeneficiaries = db.TotalBeneficiaries,
                  Males = db.Males,
                  Females = db.Females,
                  UserID = db.UserID,

                  Users = new UsersForeignkey()
                  {
                      UserID = db.Users_Table.UserID,
                      FullName = db.Users_Table.FullName,
                  },
                  TargetGroupID = db.TargetGroupID,

                  TargetGroup = new TargetGroupFroingKey()
                  {
                      TargetGroupID = db.TargetGroup_Table.TargetGroupID,
                      TargetGroupName = db.TargetGroup_Table.TargetGroupName,
                  },

                  ProjectID = db.ProjectID,

              });
        }

        public IEnumerable<CoursesViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Courses_Table
                .Select(db => new CoursesViewModel
                {
                    CoursesID = db.CoursesID,
                    CoursesName = db.CoursesName,
                    CoursesStartDate = db.CoursesStartDate.HasValue ? db.CoursesStartDate.Value : default(DateTime),
                    CoursesEndDate = db.CoursesEndDate.HasValue ? db.CoursesEndDate.Value : default(DateTime),
                    TotalSessions = db.TotalSessions,
                    TrainingHours = db.TrainingHours,
                    TotalBeneficiaries = db.TotalBeneficiaries,
                    Males = db.Males,
                    Females = db.Females,
                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },
                    TargetGroupID = db.TargetGroupID,

                    TargetGroup = new TargetGroupFroingKey()
                    {
                        TargetGroupID = db.TargetGroup_Table.TargetGroupID,
                        TargetGroupName = db.TargetGroup_Table.TargetGroupName,
                    },

                    ProjectID = db.ProjectID,

                });
        }
        public void Create(CoursesViewModel db)
        {
            var entity = new Courses_Table();

            entity.CoursesName = db.CoursesName;
            entity.CoursesStartDate = (DateTime)db.CoursesStartDate.Date;

            entity.CoursesEndDate = (DateTime)db.CoursesEndDate.Date;
            entity.TotalBeneficiaries = db.TotalBeneficiaries;
            entity.TrainingHours = db.TrainingHours;
            entity.TotalSessions = db.TotalSessions;
            entity.Males = db.Males;
            entity.Females = db.Females;
            entity.UserID = db.UserID;
            entity.TargetGroupID = db.TargetGroupID;
            entity.ProjectID = db.ProjectID;
            entities.Courses_Table.Add(entity);
            entities.SaveChanges();

            db.CoursesID = entity.CoursesID;
        }

        public void Update(CoursesViewModel db)
        {
            var entity = new Courses_Table();

            entity.CoursesID = db.CoursesID;
            entity.CoursesName = db.CoursesName;
            entity.CoursesStartDate = (DateTime)db.CoursesStartDate.Date;

            entity.CoursesEndDate = (DateTime)db.CoursesEndDate.Date;
            entity.TrainingHours = db.TrainingHours;
            entity.TotalSessions = db.TotalSessions;
            entity.TotalBeneficiaries = db.TotalBeneficiaries;
            entity.Males = db.Males;
            entity.Females = db.Females;
            entity.UserID = db.UserID;
            entity.TargetGroupID = db.TargetGroupID;
            entity.ProjectID = db.ProjectID;
            entities.Courses_Table.Attach(entity);

            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(CoursesViewModel db)
        {
            var entity = new Courses_Table();

            entity.CoursesID = db.CoursesID;

            entities.Courses_Table.Attach(entity);

            entities.Courses_Table.Remove(entity);

            entities.SaveChanges();
        }

        public IEnumerable<TargetGroupFroingKey> GetTargetGroup()
        {
            return entities.TargetGroup_Table.Select(province => new TargetGroupFroingKey
            {
                TargetGroupID = province.TargetGroupID,
                TargetGroupName = province.TargetGroupName


            });
        }
    
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}