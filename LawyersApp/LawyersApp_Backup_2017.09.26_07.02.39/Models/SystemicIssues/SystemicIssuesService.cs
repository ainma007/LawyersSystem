using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.SystemicIssues
{
    public class SystemicIssuesService
    {
        private LawyersEntities entities;

        public SystemicIssuesService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<SystemicIssuesViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.SystemicIssues_Table
                .Select(db => new SystemicIssuesViewModel
                {
                    SystemicIssuesID = db.SystemicIssuesID,
                    CenterNumber = db.CenterNumber,
                    CourtsNumber = db.CourtsNumber,
                    DateOfCase = db.DateOfCase.HasValue ? db.DateOfCase.Value : default(DateTime),
                    DepositDate = db.DepositDate.HasValue ? db.DepositDate.Value : default(DateTime),

                    ClientName = db.ClientName,
                    ClientIDNumber = db.ClientIDNumber,
                    ClientPhone = db.ClientPhone,
                    ClientAddress = db.ClientAddress,
                    AdversaryName = db.AdversaryName,
                    AdversaryIDNumber = db.AdversaryIDNumber,
                    AdversaryPhone = db.AdversaryPhone,
                    AdversaryAddress = db.AdversaryAddress,
                    TypeOfCaseID = db.TypeOfCaseID,

                    TypeOfCase = new TypeOfCaseForeignkey()
                    {
                        TypeOfCaseID = db.TypeOfCase_Table.TypeOfCaseID,
                        TypeOfCase = db.TypeOfCase_Table.TypeOfCase,
                    },

                    CourtsID = db.CourtsID,

                    Courts = new CourtsForeignkey()
                    {
                        CourtsID = db.Courts_Table.CourtsID,
                        CourtsName = db.Courts_Table.CourtsName,
                    },

                    LawyerID = db.LawyerID,

                    Lawyer = new LawyerForeignkey()
                    {
                        LawyerID = db.Lawyer_Table.LawyerID,
                        LawyerName = db.Lawyer_Table.LawyerName,
                    },

                    DateOfClosure = db.DateOfClosure.HasValue ? db.DateOfClosure.Value : default(DateTime),


                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },


                });
        }
        public void Create(SystemicIssuesViewModel db)
        {
            var entity = new SystemicIssues_Table();

            entity.CenterNumber = db.CenterNumber;
            entity.CourtsNumber = db.CourtsNumber;
            entity.DateOfCase = (DateTime)db.DateOfCase.Date;
            entity.DepositDate = (DateTime)db.DepositDate.Date;
            entity.ClientName = db.ClientName;
            entity.ClientIDNumber = db.ClientIDNumber;
            entity.ClientPhone = db.ClientPhone;
            entity.ClientAddress = db.ClientAddress;
            entity.AdversaryName = db.AdversaryName;
            entity.AdversaryIDNumber = db.AdversaryIDNumber;
            entity.AdversaryPhone = db.AdversaryPhone;
            entity.AdversaryAddress = db.AdversaryAddress;
            entity.TypeOfCaseID = db.TypeOfCaseID;
            entity.CourtsID = db.CourtsID;
            entity.LawyerID = db.LawyerID;
            entity.DateOfClosure = (DateTime)db.DateOfClosure.Date;
            entity.UserID = db.UserID;
            entities.SystemicIssues_Table.Add(entity);
            entities.SaveChanges();

            db.SystemicIssuesID = entity.SystemicIssuesID;
        }

        public void Update(SystemicIssuesViewModel db)
        {
            var entity = new SystemicIssues_Table();

            entity.SystemicIssuesID = db.SystemicIssuesID;
            entity.CenterNumber = db.CenterNumber;
            entity.CourtsNumber = db.CourtsNumber;
            entity.DateOfCase = (DateTime)db.DateOfCase.Date;
            entity.DepositDate = (DateTime)db.DepositDate.Date;
            entity.ClientName = db.ClientName;
            entity.ClientIDNumber = db.ClientIDNumber;
            entity.ClientPhone = db.ClientPhone;
            entity.ClientAddress = db.ClientAddress;
            entity.AdversaryName = db.AdversaryName;
            entity.AdversaryIDNumber = db.AdversaryIDNumber;
            entity.AdversaryPhone = db.AdversaryPhone;
            entity.AdversaryAddress = db.AdversaryAddress;
            entity.TypeOfCaseID = db.TypeOfCaseID;
            entity.CourtsID = db.CourtsID;
            entity.LawyerID = db.LawyerID;
            entity.DateOfClosure = (DateTime)db.DateOfClosure.Date;
            entity.UserID = db.UserID;


            entities.SystemicIssues_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(SystemicIssuesViewModel db)
        {
            var entity = new SystemicIssues_Table();

            entity.SystemicIssuesID = db.SystemicIssuesID;

            entities.SystemicIssues_Table.Attach(entity);

            entities.SystemicIssues_Table.Remove(entity);

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

        public IEnumerable<LawyerForeignkey> GetLawyer()
        {
            return entities.Lawyer_Table.Select(province => new LawyerForeignkey
            {
                LawyerID = province.LawyerID,
                LawyerName = province.LawyerName


            });
        }

        public IEnumerable<TypeOfCaseForeignkey> GetTypeOfCase()
        {
            return entities.TypeOfCase_Table.Select(province => new TypeOfCaseForeignkey
            {
                TypeOfCaseID = province.TypeOfCaseID,
                TypeOfCase = province.TypeOfCase


            });
        }

        public IEnumerable<CourtsForeignkey> GetCourts()
        {
            return entities.Courts_Table.Select(province => new CourtsForeignkey
            {
                CourtsID = province.CourtsID,
                CourtsName = province.CourtsName


            });
        }


        public void Dispose()
        {
            entities.Dispose();
        }


    }
}