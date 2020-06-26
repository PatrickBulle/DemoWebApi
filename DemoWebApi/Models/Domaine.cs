using System;
using System.Collections.Generic;
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
        // La valeur par défaut est délégue à la base de données
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public DateTime DateCreation { get; set; }

        [Column("dmaj", TypeName = "TimeStamp")]
        [DataType(DataType.DateTime)]
        // La valeur par défaut est délégue à la base de données
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public DateTime DateMiseAJour { get; set; }

        [Column("cosu")]
        // La valeur par défaut est délégue à la base de données
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        public Char CodeSupression { get; set; }
    }
}
