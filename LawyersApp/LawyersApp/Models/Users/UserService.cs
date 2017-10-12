using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Users
{
    public class UserService
    {
        private LawyersEntities entities;

        public UserService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<UserViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Users_Table
                .Select(user => new UserViewModel
                {
                    UserID = user.UserID,
                    FullName = user.FullName,
                    Username = user.UserName,
                    Password = user.Password,
                    UserType = user.UserType,
                    userstatus = user.Status,


                });
        }
        public void Create(UserViewModel user)
        {
            var entity = new Users_Table();

            entity.FullName = user.FullName;
            entity.UserName = user.Username;
            entity.Password = user.Password;
            entity.UserType = user.UserType;

            entity.Status = user.userstatus;
            entities.Users_Table.Add(entity);
            entities.SaveChanges();

            user.UserID = entity.UserID;
        }

        public void Update(UserViewModel user)
        {
            var entity = new Users_Table();

            entity.UserID = user.UserID;
            entity.FullName = user.FullName;
            entity.UserName = user.Username;
            entity.Password = user.Password;
            entity.UserType = user.UserType;

            entity.Status = user.userstatus;



            entities.Users_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(UserViewModel user)
        {
            var entity = new Users_Table();

            entity.UserID = user.UserID;
            entities.Users_Table.Attach(entity);
            entities.Users_Table.Remove(entity);
            entities.SaveChanges();
        }

        public void Dispose()
        {
            entities.Dispose();
        }
    }
}