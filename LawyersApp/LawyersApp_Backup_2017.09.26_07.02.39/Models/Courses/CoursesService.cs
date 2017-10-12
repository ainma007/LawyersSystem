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

        public IEnumerable<CoursesViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Courses_Table
                .Select(db => new CoursesViewModel
                {
                    CoursesID = db.CoursesID,
                    CoursesNumber = db.CoursesNumber,
                    CoursesStartDate = db.CoursesStartDate.HasValue ? db.CoursesStartDate.Value : default(DateTime),
                    CoursesEndDate = db.CoursesEndDate.HasValue ? db.CoursesEndDate.Value : default(DateTime),
                    CoursesSummary = db.CoursesSummary,
                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },


              

        });
        }
        public void Create(CoursesViewModel db)
        {
            var entity = new Courses_Table();

            entity.CoursesNumber = db.CoursesNumber;
            entity.CoursesStartDate = (DateTime)db.CoursesStartDate.Date;

            entity.CoursesEndDate = (DateTime)db.CoursesEndDate.Date;
            entity.CoursesSummary = HttpUtility.HtmlDecode(db.CoursesSummary);
            entity.UserID = db.UserID;

            entities.Courses_Table.Add(entity);
            entities.SaveChanges();

            db.CoursesID = entity.CoursesID;
        }

        public void Update(CoursesViewModel db)
        {
            var entity = new Courses_Table();

            entity.CoursesID = db.CoursesID;
            entity.CoursesNumber = db.CoursesNumber;
            entity.CoursesStartDate = (DateTime)db.CoursesStartDate.Date;

            entity.CoursesEndDate = (DateTime)db.CoursesEndDate.Date;

            entity.UserID = db.UserID;

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

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}