using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Profesor")]
    public class Profesor
    {
        [Key]
        public int IDProfesor { get; set; }

        public int IDLocalidad { get; set; }

        [ForeignKey("IDLocalidad")]
        public Localidad Localidad { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Nombre { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(50)]
        [Required]
        public string Apellido { get; set; }

        public List<Planilla> Planilla { get; set; }
    }
}
