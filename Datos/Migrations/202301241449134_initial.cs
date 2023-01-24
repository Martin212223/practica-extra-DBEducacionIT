namespace Datos.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Carrera",
                c => new
                    {
                        IDCarrera = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDCarrera);
            
            CreateTable(
                "dbo.Plan",
                c => new
                    {
                        IDPlan = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        IDCarrera = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDPlan)
                .ForeignKey("dbo.Carrera", t => t.IDCarrera, cascadeDelete: false)
                .Index(t => t.IDCarrera);
            
            CreateTable(
                "dbo.Planilla",
                c => new
                    {
                        IDPlanilla = c.Int(nullable: false, identity: true),
                        IDCarrera = c.Int(nullable: false),
                        IDMateria = c.Int(nullable: false),
                        IDProfesor = c.Int(nullable: false),
                        IDCurso = c.Int(nullable: false),
                        Fecha = c.DateTime(nullable: false, storeType: "date"),
                    })
                .PrimaryKey(t => t.IDPlanilla)
                .ForeignKey("dbo.Carrera", t => t.IDCarrera, cascadeDelete: false)
                .ForeignKey("dbo.Curso", t => t.IDCurso, cascadeDelete: false)
                .ForeignKey("dbo.Profesor", t => t.IDProfesor, cascadeDelete: false)
                .ForeignKey("dbo.Materia", t => t.IDMateria, cascadeDelete: false)
                .Index(t => t.IDCarrera)
                .Index(t => t.IDMateria)
                .Index(t => t.IDProfesor)
                .Index(t => t.IDCurso);
            
            CreateTable(
                "dbo.Curso",
                c => new
                    {
                        IDCurso = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDCurso);
            
            CreateTable(
                "dbo.Detalle",
                c => new
                    {
                        IDDetalle = c.Int(nullable: false, identity: true),
                        IDPlanilla = c.Int(nullable: false),
                        IDEstado = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDDetalle)
                .ForeignKey("dbo.Estado", t => t.IDEstado, cascadeDelete: false)
                .ForeignKey("dbo.Planilla", t => t.IDPlanilla, cascadeDelete: false)
                .Index(t => t.IDPlanilla)
                .Index(t => t.IDEstado);
            
            CreateTable(
                "dbo.Estado",
                c => new
                    {
                        IDEstado = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDEstado);
            
            CreateTable(
                "dbo.Evaluacion",
                c => new
                    {
                        IDEvaluacion = c.Int(nullable: false, identity: true),
                        IDTipo = c.Int(nullable: false),
                        IDEstudiante = c.Int(nullable: false),
                        IDDetalle = c.Int(nullable: false),
                        Nota = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.IDEvaluacion)
                .ForeignKey("dbo.Detalle", t => t.IDDetalle, cascadeDelete: false)
                .ForeignKey("dbo.Estudiante", t => t.IDEstudiante, cascadeDelete: false)
                .ForeignKey("dbo.Tipo", t => t.IDTipo, cascadeDelete: false)
                .Index(t => t.IDTipo)
                .Index(t => t.IDEstudiante)
                .Index(t => t.IDDetalle);
            
            CreateTable(
                "dbo.Estudiante",
                c => new
                    {
                        IDEstudiante = c.Int(nullable: false, identity: true),
                        IDLocalidad = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                        Telefono = c.String(nullable: false, maxLength: 50, unicode: false),
                        Calle = c.String(nullable: false, maxLength: 50, unicode: false),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.IDEstudiante)
                .ForeignKey("dbo.Localidad", t => t.IDLocalidad, cascadeDelete: false)
                .Index(t => t.IDLocalidad);
            
            CreateTable(
                "dbo.Localidad",
                c => new
                    {
                        IDLocalidad = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDLocalidad);
            
            CreateTable(
                "dbo.Profesor",
                c => new
                    {
                        IDProfesor = c.Int(nullable: false, identity: true),
                        IDLocalidad = c.Int(nullable: false),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                        Apellido = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDProfesor)
                .ForeignKey("dbo.Localidad", t => t.IDLocalidad, cascadeDelete: false)
                .Index(t => t.IDLocalidad);
            
            CreateTable(
                "dbo.Tipo",
                c => new
                    {
                        IDTipo = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDTipo);
            
            CreateTable(
                "dbo.Materia",
                c => new
                    {
                        IDMateria = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.IDMateria);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Planilla", "IDMateria", "dbo.Materia");
            DropForeignKey("dbo.Detalle", "IDPlanilla", "dbo.Planilla");
            DropForeignKey("dbo.Evaluacion", "IDTipo", "dbo.Tipo");
            DropForeignKey("dbo.Planilla", "IDProfesor", "dbo.Profesor");
            DropForeignKey("dbo.Profesor", "IDLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Estudiante", "IDLocalidad", "dbo.Localidad");
            DropForeignKey("dbo.Evaluacion", "IDEstudiante", "dbo.Estudiante");
            DropForeignKey("dbo.Evaluacion", "IDDetalle", "dbo.Detalle");
            DropForeignKey("dbo.Detalle", "IDEstado", "dbo.Estado");
            DropForeignKey("dbo.Planilla", "IDCurso", "dbo.Curso");
            DropForeignKey("dbo.Planilla", "IDCarrera", "dbo.Carrera");
            DropForeignKey("dbo.Plan", "IDCarrera", "dbo.Carrera");
            DropIndex("dbo.Profesor", new[] { "IDLocalidad" });
            DropIndex("dbo.Estudiante", new[] { "IDLocalidad" });
            DropIndex("dbo.Evaluacion", new[] { "IDDetalle" });
            DropIndex("dbo.Evaluacion", new[] { "IDEstudiante" });
            DropIndex("dbo.Evaluacion", new[] { "IDTipo" });
            DropIndex("dbo.Detalle", new[] { "IDEstado" });
            DropIndex("dbo.Detalle", new[] { "IDPlanilla" });
            DropIndex("dbo.Planilla", new[] { "IDCurso" });
            DropIndex("dbo.Planilla", new[] { "IDProfesor" });
            DropIndex("dbo.Planilla", new[] { "IDMateria" });
            DropIndex("dbo.Planilla", new[] { "IDCarrera" });
            DropIndex("dbo.Plan", new[] { "IDCarrera" });
            DropTable("dbo.Materia");
            DropTable("dbo.Tipo");
            DropTable("dbo.Profesor");
            DropTable("dbo.Localidad");
            DropTable("dbo.Estudiante");
            DropTable("dbo.Evaluacion");
            DropTable("dbo.Estado");
            DropTable("dbo.Detalle");
            DropTable("dbo.Curso");
            DropTable("dbo.Planilla");
            DropTable("dbo.Plan");
            DropTable("dbo.Carrera");
        }
    }
}
