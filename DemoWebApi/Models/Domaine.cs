using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Models
{
    public abstract class Domaine
    {

        [Column("dcre", TypeName = "Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateCreation { get; set; } = DateTime.Today;

        [Column("dmaj", TypeName = "TimeStamp")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateMiseAJour { get; set; }

        [Column("cosu")]
        [Required]
        [StringLength(1)]
        public string CodeSupression { get; set; } = "0";
    }
}
