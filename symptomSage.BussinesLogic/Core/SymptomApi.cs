using System.Collections.Generic;
using System.Linq;
using symptomSage.BussinesLogic.DBModel;
using symptomSage.Domain.Entities.Symptoms;
namespace symptomSage.BussinesLogic.Core
{
    public class SymptomApi
    {
        internal SymptomsListResp SymptomListAction(bool isAdmin)
        {
            List<SDbTable> result;

            using (var db = new SymptomContext())
            {
                result = db.Symptoms.ToList();
            }

            var symptoms = new List<SymptomsListData>();

            foreach (var b in result)
            {
                symptoms.Add(new SymptomsListData
                {
                    Id = b.Id,
                    Name = b.Name,
                    Desc = b.Desc,
                    AddedDate = b.AddedDate
                });
            }
            
            return new SymptomsListResp() { 
                Symptoms = symptoms,
                Status = true,                     
                StatusMsg = "Success"
            };
        }
        
        internal SymptomsDetailsResp SymptomDetailsAction(int symptomId)
        {
            SDbTable result;

            using (var db = new SymptomContext())
            {
                result = db.Symptoms.FirstOrDefault(b => b.Id == symptomId);
            }
            
            var symptom = new SymptomDetailsData()
            {
                Id = result.Id,
                Name = result.Name,
                Desc = result.Desc,
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