using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Models
{
    public enum Sexe
    {
        Femelle = 2,
        Male = 1
    }

    [Table("bovin")]
    public class Bovin : Domaine
    {
        [Column("copaip")]
        [Required]
        [MaxLength(2)]
        public string CodePays { get; set; }

        [Column("nunati")]
        [Required]
        [MaxLength(12)]
        public string NumeroNational { get; set; }

        [Column("nobovi")]
        [MaxLength(10)]
        public string Nom { get; set; }

        [Column("sexbov")]
        [Required]
        [MaxLength(1)]
        public Sexe Sexe { get; set; }
        
        public Race Race{ get; set; }
    }
}
