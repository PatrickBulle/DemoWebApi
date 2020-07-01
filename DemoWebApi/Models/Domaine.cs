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

        /// <summary>
        /// Date de création
        /// </summary>
        [Column("dcre", TypeName = "Date")]
        [DataType(DataType.Date)]
        [Required]
        public DateTime DateCreation { get; set; } = DateTime.Today;

        /// <summary>
        /// Date de la dernière modification
        /// </summary>
        [Column("dmaj", TypeName = "TimeStamp")]
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime DateMiseAJour { get; set; }

        /// <summary>
        /// Code de suppression logique (0 actif, 1 inactif)
        /// </summary>
        [Column("cosu")]
        [Required]
        [StringLength(1)]
        public string CodeSupression { get; set; } = "0";
    }
}
