using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Models
{
    [Table("detenteur")]
    public class Detenteur : Domaine
    {
        [Column("nudet")]
        [Required]
        [MaxLength(12)]
        public string Numero { get; set; }

        [Required]
        [MaxLength(20)]
        public string Nom { get; set; }

        [MaxLength(20)]
        public string Prenom { get; set; }
        
        public List<Cheptel> Cheptels { get; set; }
    }
}
