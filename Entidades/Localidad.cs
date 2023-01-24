using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Localidad")]
    public class Localidad
    {
        [Key]
        public int IDLocalidad { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        public List<Profesor> Profesor { get; set; }

        public List<Estudiante> Estudiante { get; set; }
    }
}
