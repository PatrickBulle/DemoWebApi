using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Models
{
    [Table("race")]
    public class Race : Domaine
    {
        [Column("corabo")]
        [Required]
        [MaxLength(2)]
        public String CodeRaceBovin { get; set; }

        [Column("libelo")]
        [Required]
        [MaxLength(30)]
        public String Libelle { get; set; }
    }
}
