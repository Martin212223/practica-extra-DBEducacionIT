using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    [Table("Planilla")]
    public class Planilla
    {
        [Key]
        public int IDPlanilla { get; set; }

        public int IDCarrera { get; set; }

        [ForeignKey("IDCarrera")]
        public Carrera Carrera { get; set; }

        public int IDMateria { get; set; }

        [ForeignKey("IDMateria")]
        public Materia Materia { get; set; }

        public int IDProfesor { get; set; }

        [ForeignKey("IDProfesor")]
        public Profesor Profesor { get; set; }

        public int IDCurso { get; set; }

        [ForeignKey("IDCurso")]
        public Curso Curso { get; set; }

        [Column(TypeName = "date")]
        public DateTime Fecha { get; set; }

        public List<Detalle> Detalle { get; set; }
    }
}
