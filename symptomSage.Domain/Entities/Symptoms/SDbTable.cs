using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace symptomSage.Domain.Entities.Symptoms
{
    public class SDbTable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }
        
        public string Category { get; set; }


        [DataType(DataType.DateTime)] public Nullable<DateTime> AddedDate { get; set; }
    }
}