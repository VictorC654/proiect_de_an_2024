using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace symptomSage.Domain.Entities.Doctors
{
    public class DDbTable
    {
        [Key]
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Category { get; set; }
        
        public string Desc { get; set; }
        
        [DataType(DataType.DateTime)] public Nullable<DateTime> AddedDate { get; set; }
    }
}