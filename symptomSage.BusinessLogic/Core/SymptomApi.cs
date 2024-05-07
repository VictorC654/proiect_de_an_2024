using System;
using System.Collections.Generic;
using System.Linq;
using symptomSage.BusinessLogic.DBModel;
using symptomSage.Domain.Entities.Symptoms;



namespace symptomSage.BusinessLogic.Core
{
    public class SymptomApi : MedicineApi
    {

        internal SRegisterResp SRegisterAction(SRegisterData data)
        {
            SDbTable insert = new SDbTable()
            {
                Name = data.Name,
                Category = data.Category,
                AddedDate = DateTime.Now,
            };
            int result;

            using (var db = new SymptomContext())
            {
                db.Symptoms.Add(insert);
                result = db.SaveChanges();
            }
            if (result == 0)
            {
                return new SRegisterResp()
                {
                    Status = false,
                    StatusMsg = "Datele nu au putut fi salvate"
                };
            }
            return new SRegisterResp()
            {
                Status = true
            };
        }
        internal SymptomsListResp SymptomListAction()
        {
            List<SDbTable> result;

            using (var db = new SymptomContext())
            {
                result = db.Symptoms.ToList();
            }

            var symptoms = new List<SymptomsListData>();

            foreach (var s in result)
            {
                symptoms.Add(new SymptomsListData
                {
                    Id = s.Id,
                    Name = s.Name,
                    Category = s.Category,
                    AddedDate = s.AddedDate
                });
            }

            int nrOfSymptoms = result.Count;
            
            return new SymptomsListResp() { 
                Symptoms = symptoms,
                Status = true,                     
                StatusMsg = "Success",
                nrOfSymptoms = nrOfSymptoms,
            };
        }
        
        internal SymptomsDetailsResp SymptomDetailsAction(int symptomId)
        {
            SDbTable result;

            using (var db = new SymptomContext())
            {
                result = db.Symptoms.FirstOrDefault(b => b.Id == symptomId);
            }
            
            var symptom = new SymptomsDetailsData()
            {
                Id = result.Id,
                Name = result.Name,
                Category = result.Category,
                AddedDate = result.AddedDate,
            };
            
            
            return new SymptomsDetailsResp() { 
                Symptom = symptom,
                Status = true,                     
                StatusMsg = "Success"
            };
        }
    }
}