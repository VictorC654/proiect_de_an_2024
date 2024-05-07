using System;
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
    }
}