using LawyersApp.Models.Foreignkey;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LawyersApp.Models.Beneficiaries
{
    public class BeneficiariesService
    {
        private LawyersEntities entities;

        public BeneficiariesService(LawyersEntities entities)
        {
            this.entities = entities;
        }

     
        public IEnumerable<BeneficiariesViewModel> Read()
        {
            // هنا كمان تعديل على حالة المستخدم
            return entities.Beneficiaries_Table
                .Select(db => new BeneficiariesViewModel
                {
                    Beneficiaries_ID = db.Beneficiaries_ID,
                    BeneficiariesIDNumber=db.BeneficiariesIDNumber,
                    BeneficiariesName = db.BeneficiariesName,
                    GenderID = db.GenderID,
                    BeneficiariesPhone = db.BeneficiariesPhone,

                });
        }
        public void Create(BeneficiariesViewModel db)
        {
            var entity = new Beneficiaries_Table();
            entity.BeneficiariesIDNumber = db.BeneficiariesIDNumber;

            entity.BeneficiariesName = db.BeneficiariesName;

            entity.BeneficiariesPhone = db.BeneficiariesPhone;
            entity.GenderID = db.GenderID;
          
            entities.Beneficiaries_Table.Add(entity);
            entities.SaveChanges();

            db.Beneficiaries_ID = entity.Beneficiaries_ID;
        }

        public void Update(BeneficiariesViewModel db)
        {
            var entity = new Beneficiaries_Table();

            entity.Beneficiaries_ID = db.Beneficiaries_ID;
            entity.BeneficiariesIDNumber = db.BeneficiariesIDNumber;

            entity.BeneficiariesName = db.BeneficiariesName;

            entity.BeneficiariesPhone = db.BeneficiariesPhone;
            entity.GenderID = db.GenderID;
            entities.Beneficiaries_Table.Attach(entity);

            entities.Entry(entity).State = EntityState.Modified;
            entities.SaveChanges();
        }

        public void Destroy(BeneficiariesViewModel db)
        {
            var entity = new Beneficiaries_Table();

            entity.Beneficiaries_ID = db.Beneficiaries_ID;

            entities.Beneficiaries_Table.Attach(entity);

            entities.Beneficiaries_Table.Remove(entity);

            entities.SaveChanges();
        }

        public IEnumerable<GenderForeignkey> GetGender()
        {
            return entities.Gender_Table.Select(province => new GenderForeignkey
            {
                GenderID = province.GenderID,
                GenderName = province.GenderName


            });
        }

        public void Dispose()
        {
            entities.Dispose();
        }


    }
}