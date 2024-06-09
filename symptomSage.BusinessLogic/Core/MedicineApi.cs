﻿using System;
using System.Collections.Generic;
using System.Linq;
using symptomSage.BusinessLogic.DBModel;
using symptomSage.Domain.Entities.Medicine;
using symptomSage.Domain.Entities.Symptoms;

namespace symptomSage.BusinessLogic.Core
{
    public class MedicineApi : DoctorApi
    {
        internal MRegisterResp MRegisterAction(MRegisterData data)
        {
            MDbTable insert = new MDbTable()
            {
                Name = data.Name,
                Desc = data.Desc,
                Category = data.Category,
                imagePath = data.imagePath,
                AddedDate = DateTime.Now,
            };
            int result;

            using (var db = new MedicineContext())
            {
                db.Medicine.Add(insert);
                result = db.SaveChanges();
            }
            if (result == 0)
            {
                return new MRegisterResp()
                {
                    Status = false,
                    StatusMsg = "Datele nu au putut fi salvate"
                };
            }
            return new MRegisterResp()
            {
                Status = true
            };
        }

        internal MedicineListResp MListAction()
        {
            List<MDbTable> result;
            
            using (var db = new MedicineContext())
            {
                result = db.Medicine.ToList();
            }

            var medicines = new List<MedicineListData>();
            
            foreach (var s in result)
            {
                medicines.Add(new MedicineListData()
                {
                    Id = s.Id,
                    Name = s.Name,
                    Desc = s.Desc,
                    Category = s.Category,
                    imagePath = s.imagePath,
                    AddedDate = s.AddedDate
                });
            }

            int nrOfMedicines = result.Count;
            
            return new MedicineListResp() { 
                Medicines = medicines,
                Status = true,                     
                nrOfMedicines = nrOfMedicines,
            };
        }
        // internal MedicineDetailsResp MDetailsAction(int medicineId)
        // {
        //     MDbTable result;
        //
        //     using (var db = new MedicineContext())
        //     {
        //         result = db.Medicine.FirstOrDefault(b => b.Id == medicineId);
        //     }
        //     
        //     var medicine = new MedicineDetailsData()
        //     {
        //         Id = result.Id,
        //         Name = result.Name,
        //         Desc = result.Desc,
        //         Category = result.Category,
        //         imagePath = result.imagePath,
        //         AddedDate = result.AddedDate,
        //     };
        //     return new MedicineDetailsResp() { 
        //         Medicine = medicine,
        //         Status = true,                     
        //         StatusMsg = "Success"
        //     };
        // }
        internal MDeleteResp MDeleteAction(int medicineId)
        {
            using (var db = new MedicineContext())
            {
                var medicineToBeDeleted= db.Medicine.SingleOrDefault(b => b.Id == medicineId);
                if (medicineToBeDeleted != null)
                {
                    db.Medicine.Remove(medicineToBeDeleted);
                    db.SaveChanges();
                }
            }
            return new MDeleteResp()
            {
                status = true,
            };
        }

        internal MedicineDetailsResp MedicineDetailsAction(int medicineId)
        {
            MDbTable result;
            using (var db = new MedicineContext())
            {
                result = db.Medicine.FirstOrDefault(b => b.Id == medicineId);
            }

            var medicineToBeEdited = new MedicineDetailsData()
            {
                Name = result.Name,
                Desc = result.Desc,
                Category = result.Category,
            };
            return new MedicineDetailsResp()
            {
                Medicine = medicineToBeEdited,
                Status = true,
            };
        }

        internal MEditResp MedicineEditAction(MEditData data)
        {
            MDbTable result;
            int medicineId = data.id;
            using (var db = new MedicineContext())
            {
                result = db.Medicine.FirstOrDefault(b => b.Id == medicineId);
                if (result != null)
                {
                    result.Name = data.Name;
                    result.Desc = data.Desc;
                    result.Category = data.Category;
                    db.SaveChanges();
                }
            }
            return new MEditResp()
            {
                status = true,
            };
        }
    }
}