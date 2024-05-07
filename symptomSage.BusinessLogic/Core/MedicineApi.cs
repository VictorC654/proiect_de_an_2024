using System;
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
    }
}