﻿using System;
using System.Collections.Generic;
using System.Linq;
using symptomSage.BusinessLogic.DBModel;
using symptomSage.Domain.Entities.Doctors;

namespace symptomSage.BusinessLogic.Core
{
    public class DoctorApi
    {
        internal DRegisterResp DRegisterAction(DRegisterData data)
        {
            DDbTable insert = new DDbTable()
            {
                Name = data.Name,
                Category = data.Category,
                Desc = data.Desc,
                AddedDate = DateTime.Now,
            };
            
            int result;
            using (var db = new DoctorContext())
            {
                db.Doctors.Add(insert);
                result = db.SaveChanges();
            }
            if (result == 0)
            {
                return new DRegisterResp()
                {
                    Status = false,
                    StatusMsg = "Datele nu au putut fi salvate"
                };
            }
            return new DRegisterResp()
            {
                Status = true
            };
        }

        internal DListResp DListAction()
        {
            List<DDbTable> result;
            
            using (var db = new DoctorContext())
            {
                result = db.Doctors.ToList();
            }

            var doctors = new List<DListData>();

            foreach (var d in result)
            {
                doctors.Add(new DListData()
                {
                    Id = d.Id,
                    Name = d.Name,
                    Category = d.Category,
                    Desc = d.Desc,
                });
            }

            int nrOfDoctors = result.Count;
            
            return new DListResp() { 
                Doctors = doctors,
                Status = true,                     
                StatusMsg = "Success",
                nrOfDoctors = nrOfDoctors,
            };
        }
        internal DDeleteResp DDeleteAction(int doctorId)
        {
            using (var db = new DoctorContext())
            {
                var doctorToBeDeleted= db.Doctors.SingleOrDefault(b => b.Id == doctorId);
                if (doctorToBeDeleted != null)
                {
                    db.Doctors.Remove(doctorToBeDeleted);
                    db.SaveChanges();
                }
            }
            return new DDeleteResp()
            {
                status = true,
            };
        }
        internal DDetailsResp DDetailsAction(int doctorId)
        {
            DDbTable result;
            
            using (var db = new DoctorContext())
            {
                result = db.Doctors.FirstOrDefault(b => b.Id == doctorId);
            }
            
            var doctor = new DDetailsData()
            {
                id = result.Id,
                Name = result.Name,
                Desc = result.Desc,
                Category = result.Category,
            };
            
            
            return new DDetailsResp() { 
                Doctor = doctor,
                status = true,                     
            };
        }

        internal DEditResp DEditAction(DEditData data)
        {
            DDbTable result;
            int doctorId = data.id;
            using (var db = new DoctorContext())
            {
                result = db.Doctors.FirstOrDefault(b => b.Id == doctorId);
                if (result != null)
                {
                    result.Name = data.Name;
                    result.Desc = data.Desc;
                    result.Category = data.Category;
                    db.SaveChanges();
                }
            }
            return new DEditResp()
            {
                status = true,
            };
        }
    }
}