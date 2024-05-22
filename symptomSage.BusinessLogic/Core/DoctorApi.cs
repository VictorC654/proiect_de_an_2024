using System;
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
    }
}