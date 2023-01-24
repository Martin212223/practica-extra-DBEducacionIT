using Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos.Data
{
    public class DBEducacionITContext : DbContext
    {
        public DBEducacionITContext() : base("KeyDB") { }

        public DbSet<Carrera> Carrera { get; set; }

        public DbSet<Curso> Curso { get; set; }

        public DbSet<Detalle> Detalle { get; set; }

        public DbSet<Estado> Estado { get; set; }

        public DbSet<Estudiante> Estudiante { get; set; }

        public DbSet<Evaluacion> Evaluacion { get; set; }

        public DbSet<Localidad> Localidad { get; set; }

        public DbSet<Materia> Materia { get; set; }

        public DbSet<Plan> Plan { get; set; }

        public DbSet<Planilla> Planilla { get; set; }

        public DbSet<Profesor> Profesor { get; set; }

        public DbSet<Tipo> Tipo { get; set; }
    }
}
