using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DemoWebApi.Models
{
    [Table("cheptel")]
    public class Cheptel : Domaine
    {
        [Column("copach")]
        [Required]
        [MaxLength(2)]
        public string CodePays { get; set; }

        [Column("nuchep")]
        [Required]
        [MaxLength(10)]
        public string Numero { get; set; }

        [Column("sicivi")]
        [Required]
        [MaxLength(20)]
        public string RaisonSociale { get; set; }


        [Column("noraso")]
        [Required]
        [MaxLength(50)]
        public string Nom { get; set; }

        public Detenteur Detenteur { get; set; }

        public List<Bovin> Bovins { get; set; }
    }
}
