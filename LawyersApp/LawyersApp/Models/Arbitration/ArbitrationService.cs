using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace LawyersApp.Models.Arbitration
{
    public class ArbitrationService
    {
        private LawyersEntities entities;

        public ArbitrationService(LawyersEntities entities)
        {
            this.entities = entities;
        }

        public IEnumerable<ArbitrationViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Arbitration_Table
                .Select(db => new ArbitrationViewModel
                {
                    ArbitrationID = db.ArbitrationID,
                    
                    ArbitrationDate = db.ArbitrationDate.HasValue ? db.ArbitrationDate.Value : default(DateTime),
                    Beneficiaries_ID = db.Beneficiaries_ID,
                    BeneficiariesName = db.Beneficiaries_Table.BeneficiariesName,
                    BeneficiariesIDNumber = db.Beneficiaries_Table.BeneficiariesIDNumber,

                    Gender = db.Beneficiaries_Table.Gender_Table.GenderName,
                    FirstSocialstatus = db.FirstSocialstatus,

                    Beneficiaries = new BeneficiariesForeignkey()
                    {
                        Beneficiaries_ID = db.Beneficiaries_Table.Beneficiaries_ID,
                        BeneficiariesName = db.Beneficiaries_Table.BeneficiariesName,
                        BeneficiariesGender = db.Beneficiaries_Table.Gender_Table.GenderName,
                        BeneficiariesPhone = db.Beneficiaries_Table.BeneficiariesPhone
                    },

                    Governorate_ID = db.Governorate_ID,

                    Governorate = new GovernorateForeignkey()
                    {
                        Governorate_ID = db.Governorate_Table.Governorate_ID,
                        Governorate_Name = db.Governorate_Table.Governorate_Name,
                    },

                    Area_ID = db.Area_ID,

                    Area = new AreaForeignkey()
                    {
                        Area_ID = db.Area_Table.Area_ID,
                        Area_Name = db.Area_Table.Area_Name,
                    },
                    SecondSideName = db.SecondSideName,
                    SecondSideIDNumber = db.SecondSideIDNumber,
                    SecondSidePhone = db.SecondSidePhone,
                    SecondSocialstatus = db.SecondSocialstatus,
                    SecondSideAddress = db.SecondSideAddress,
                    ArbitrationName = db.ArbitrationName,
                    ArbitrationPhone = db.ArbitrationPhone,
                    ArbitrationDecision = db.ArbitrationDecision,



                    UserID = db.UserID,

                    Users = new UsersForeignkey()
                    {
                        UserID = db.Users_Table.UserID,
                        FullName = db.Users_Table.FullName,
                    },

                    ProjectID=db.ProjectID
                });
        }
        public void Create(ArbitrationViewModel db)
        {
            var entity = new Arbitration_Table();

           
            entity.ArbitrationDate = (DateTime)db.ArbitrationDate.Date;
            entity.Beneficiaries_ID = db.Beneficiaries_ID;
            var q = entities.Beneficiaries_Table.Where(p => p.Beneficiaries_ID == db.Beneficiaries_ID).SingleOrDefault();
            db.BeneficiariesIDNumber = q.BeneficiariesIDNumber;
            db.BeneficiariesName = q.BeneficiariesName;
            db.Gender = q.Gender_Table.GenderName;
            entity.Area_ID = db.Area_ID;
            entity.Governorate_ID = db.Governorate_ID;
            entity.FirstSocialstatus = db.FirstSocialstatus;

            entity.SecondSideName = db.SecondSideName;
            entity.SecondSideIDNumber = db.SecondSideIDNumber;
            entity.SecondSidePhone = db.SecondSidePhone;
            entity.SecondSocialstatus = db.SecondSocialstatus;
            entity.SecondSideAddress = db.SecondSideAddress;
            entity.ArbitrationName = db.ArbitrationName;
            entity.ArbitrationPhone = db.ArbitrationPhone;
            entity.ArbitrationDecision = HttpUtility.HtmlDecode(db.ArbitrationDecision);
            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;
            entities.Arbitration_Table.Add(entity);
            entities.SaveChanges();

            db.ArbitrationID = entity.ArbitrationID;
        }

        public void Update(ArbitrationViewModel db)
        {
            var entity = new Arbitration_Table();

            entity.ArbitrationID = db.ArbitrationID;
           
            entity.ArbitrationDate = (DateTime)db.ArbitrationDate.Date;
            entity.Beneficiaries_ID = db.Beneficiaries_ID;
            var q = entities.Beneficiaries_Table.Where(p => p.Beneficiaries_ID == db.Beneficiaries_ID).SingleOrDefault();
            db.BeneficiariesIDNumber = q.BeneficiariesIDNumber;
            db.BeneficiariesName = q.BeneficiariesName;
            db.Gender = q.Gender_Table.GenderName;
            //
            entity.Area_ID = db.Area_ID;
            entity.Governorate_ID = db.Governorate_ID;
            entity.FirstSocialstatus = db.FirstSocialstatus;

            entity.SecondSideName = db.SecondSideName;
            entity.SecondSideIDNumber = db.SecondSideIDNumber;
            entity.SecondSidePhone = db.SecondSidePhone;
            entity.SecondSocialstatus = db.SecondSocialstatus;
            entity.SecondSideAddress = db.SecondSideAddress;
            entity.ArbitrationName = db.ArbitrationName;
            entity.ArbitrationPhone = db.ArbitrationPhone;
            entity.ArbitrationDecision = HttpUtility.HtmlDecode(db.ArbitrationDecision);
            entity.UserID = db.UserID;
            entity.ProjectID = db.ProjectID;


            entities.Arbitration_Table.Attach(entity);
            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(ArbitrationViewModel db)
        {
            var entity = new Arbitration_Table();

            entity.ArbitrationID = db.ArbitrationID;

            entities.Arbitration_Table.Attach(entity);

            entities.Arbitration_Table.Remove(entity);

            entities.SaveChanges();
        }

                
        public void Dispose()
        {
            entities.Dispose();
        }
    }
}