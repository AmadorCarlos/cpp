namespace CPP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class enablemigrations : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Citas",
                c => new
                    {
                        citaId = c.Int(nullable: false, identity: true),
                        fechaCita = c.DateTime(nullable: false),
                        idPaciente = c.Int(nullable: false),
                        idMedico = c.Int(nullable: false),
                        idConsulta = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.citaId)
                .ForeignKey("dbo.Consultas", t => t.idConsulta)
                .ForeignKey("dbo.Medicos", t => t.idMedico)
                .ForeignKey("dbo.Pacientes", t => t.idPaciente)
                .Index(t => t.idPaciente)
                .Index(t => t.idMedico)
                .Index(t => t.idConsulta);
            
            CreateTable(
                "dbo.Consultas",
                c => new
                    {
                        consultaId = c.Int(nullable: false, identity: true),
                        fechaConsulta = c.DateTime(nullable: false),
                        idPaciente = c.Int(nullable: false),
                        idMedico = c.Int(nullable: false),
                        idExamen = c.Int(nullable: false),
                        diagnostico = c.String(nullable: false, maxLength: 250, unicode: false),
                        IdTratamiento = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.consultaId)
                .ForeignKey("dbo.Examenes", t => t.idExamen)
                .ForeignKey("dbo.Medicos", t => t.idMedico)
                .ForeignKey("dbo.Pacientes", t => t.idPaciente)
                .ForeignKey("dbo.Tratamientos", t => t.IdTratamiento)
                .Index(t => t.idPaciente)
                .Index(t => t.idMedico)
                .Index(t => t.idExamen)
                .Index(t => t.IdTratamiento);
            
            CreateTable(
                "dbo.Examenes",
                c => new
                    {
                        examenId = c.Int(nullable: false, identity: true),
                        pacienteId = c.Int(nullable: false),
                        fecha = c.DateTime(nullable: false),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                        tipo = c.String(nullable: false, maxLength: 250, unicode: false),
                        resultado = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.examenId)
                .ForeignKey("dbo.Pacientes", t => t.pacienteId)
                .Index(t => t.pacienteId);
            
            CreateTable(
                "dbo.Pacientes",
                c => new
                    {
                        pacienteId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                        apellido = c.String(nullable: false, maxLength: 250, unicode: false),
                        fechaNac = c.DateTime(nullable: false),
                        idSexo = c.Int(nullable: false),
                        cedula = c.String(nullable: false, maxLength: 250, unicode: false),
                        idOcupacion = c.Int(nullable: false),
                        telefono = c.String(nullable: false, maxLength: 250, unicode: false),
                        idEstadoCivil = c.Int(nullable: false),
                        idDepartamento = c.Int(nullable: false),
                        idMunicipio = c.Int(nullable: false),
                        idTipoSangre = c.Int(nullable: false),
                        domicilio = c.String(nullable: false, maxLength: 250, unicode: false),
                        observaciones = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.pacienteId)
                .ForeignKey("dbo.Departamentos", t => t.idDepartamento)
                .ForeignKey("dbo.EstadosCiviles", t => t.idEstadoCivil)
                .ForeignKey("dbo.Municipios", t => t.idMunicipio)
                .ForeignKey("dbo.OcupacionesPaciente", t => t.idOcupacion)
                .ForeignKey("dbo.Sexo", t => t.idSexo)
                .ForeignKey("dbo.TiposdeSangre", t => t.idTipoSangre)
                .Index(t => t.idSexo)
                .Index(t => t.idOcupacion)
                .Index(t => t.idEstadoCivil)
                .Index(t => t.idDepartamento)
                .Index(t => t.idMunicipio)
                .Index(t => t.idTipoSangre);
            
            CreateTable(
                "dbo.Departamentos",
                c => new
                    {
                        departamentoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.departamentoId);
            
            CreateTable(
                "dbo.EstadosCiviles",
                c => new
                    {
                        estadoCivilId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.estadoCivilId);
            
            CreateTable(
                "dbo.Municipios",
                c => new
                    {
                        municipioId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.municipioId);
            
            CreateTable(
                "dbo.OcupacionesPaciente",
                c => new
                    {
                        ocupacionId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.ocupacionId);
            
            CreateTable(
                "dbo.Sexo",
                c => new
                    {
                        sexoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.sexoId);
            
            CreateTable(
                "dbo.TiposdeSangre",
                c => new
                    {
                        tipoSangreId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.tipoSangreId);
            
            CreateTable(
                "dbo.Medicos",
                c => new
                    {
                        medicoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                        apellido = c.String(nullable: false, maxLength: 250, unicode: false),
                        especialidad = c.String(nullable: false, maxLength: 250, unicode: false),
                        codigoMinsa = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.medicoId);
            
            CreateTable(
                "dbo.Tratamientos",
                c => new
                    {
                        tratamientoId = c.Int(nullable: false, identity: true),
                        descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        idPaciente = c.Int(nullable: false),
                        idMedico = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.tratamientoId)
                .ForeignKey("dbo.Medicos", t => t.idMedico)
                .ForeignKey("dbo.Pacientes", t => t.idPaciente)
                .Index(t => t.idPaciente)
                .Index(t => t.idMedico);
            
            CreateTable(
                "dbo.Enfermedades",
                c => new
                    {
                        enfermedadId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                        caracterizacion = c.String(nullable: false, maxLength: 250, unicode: false),
                        pacienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.enfermedadId)
                .ForeignKey("dbo.Pacientes", t => t.pacienteId)
                .Index(t => t.pacienteId);
            
            CreateTable(
                "dbo.EspecialidadesDoctor",
                c => new
                    {
                        especialidadId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.especialidadId);
            
            CreateTable(
                "dbo.Facturas",
                c => new
                    {
                        facturaId = c.Int(nullable: false, identity: true),
                        pacienteId = c.Int(nullable: false),
                        medicoId = c.Int(nullable: false),
                        servicioId = c.Int(nullable: false),
                        descripcion = c.String(nullable: false, maxLength: 250, unicode: false),
                        total = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.facturaId)
                .ForeignKey("dbo.Medicos", t => t.medicoId)
                .ForeignKey("dbo.Pacientes", t => t.pacienteId)
                .ForeignKey("dbo.Servicios", t => t.servicioId)
                .Index(t => t.pacienteId)
                .Index(t => t.medicoId)
                .Index(t => t.servicioId);
            
            CreateTable(
                "dbo.Servicios",
                c => new
                    {
                        servicioId = c.Int(nullable: false, identity: true),
                        nombre = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.servicioId);
            
            CreateTable(
                "dbo.Familiar",
                c => new
                    {
                        familiarId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                        apellido = c.String(nullable: false, maxLength: 250, unicode: false),
                        cedula = c.String(nullable: false, maxLength: 250, unicode: false),
                        pacienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.familiarId)
                .ForeignKey("dbo.Pacientes", t => t.pacienteId)
                .Index(t => t.pacienteId);
            
            CreateTable(
                "dbo.HistorialesClinicos",
                c => new
                    {
                        historialId = c.Int(nullable: false, identity: true),
                        idPaciente = c.Int(nullable: false),
                        idEnfermedad = c.Int(nullable: false),
                        idMedicamento = c.Int(nullable: false),
                        idTratamiento = c.Int(nullable: false),
                        idCita = c.Int(nullable: false),
                        observaciones = c.String(maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.historialId)
                .ForeignKey("dbo.Citas", t => t.idCita)
                .ForeignKey("dbo.Enfermedades", t => t.idEnfermedad)
                .ForeignKey("dbo.Medicamentos", t => t.idMedicamento)
                .ForeignKey("dbo.Pacientes", t => t.idPaciente)
                .ForeignKey("dbo.Tratamientos", t => t.idTratamiento)
                .Index(t => t.idPaciente)
                .Index(t => t.idEnfermedad)
                .Index(t => t.idMedicamento)
                .Index(t => t.idTratamiento)
                .Index(t => t.idCita);
            
            CreateTable(
                "dbo.Medicamentos",
                c => new
                    {
                        medicamentoId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                        dosis = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.medicamentoId);
            
            CreateTable(
                "dbo.TiposExamen",
                c => new
                    {
                        tipoExamenId = c.Int(nullable: false, identity: true),
                        nombre = c.String(nullable: false, maxLength: 250, unicode: false),
                    })
                .PrimaryKey(t => t.tipoExamenId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.HistorialesClinicos", "idTratamiento", "dbo.Tratamientos");
            DropForeignKey("dbo.HistorialesClinicos", "idPaciente", "dbo.Pacientes");
            DropForeignKey("dbo.HistorialesClinicos", "idMedicamento", "dbo.Medicamentos");
            DropForeignKey("dbo.HistorialesClinicos", "idEnfermedad", "dbo.Enfermedades");
            DropForeignKey("dbo.HistorialesClinicos", "idCita", "dbo.Citas");
            DropForeignKey("dbo.Familiar", "pacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Facturas", "servicioId", "dbo.Servicios");
            DropForeignKey("dbo.Facturas", "pacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Facturas", "medicoId", "dbo.Medicos");
            DropForeignKey("dbo.Enfermedades", "pacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Citas", "idPaciente", "dbo.Pacientes");
            DropForeignKey("dbo.Citas", "idMedico", "dbo.Medicos");
            DropForeignKey("dbo.Citas", "idConsulta", "dbo.Consultas");
            DropForeignKey("dbo.Consultas", "IdTratamiento", "dbo.Tratamientos");
            DropForeignKey("dbo.Tratamientos", "idPaciente", "dbo.Pacientes");
            DropForeignKey("dbo.Tratamientos", "idMedico", "dbo.Medicos");
            DropForeignKey("dbo.Consultas", "idPaciente", "dbo.Pacientes");
            DropForeignKey("dbo.Consultas", "idMedico", "dbo.Medicos");
            DropForeignKey("dbo.Consultas", "idExamen", "dbo.Examenes");
            DropForeignKey("dbo.Examenes", "pacienteId", "dbo.Pacientes");
            DropForeignKey("dbo.Pacientes", "idTipoSangre", "dbo.TiposdeSangre");
            DropForeignKey("dbo.Pacientes", "idSexo", "dbo.Sexo");
            DropForeignKey("dbo.Pacientes", "idOcupacion", "dbo.OcupacionesPaciente");
            DropForeignKey("dbo.Pacientes", "idMunicipio", "dbo.Municipios");
            DropForeignKey("dbo.Pacientes", "idEstadoCivil", "dbo.EstadosCiviles");
            DropForeignKey("dbo.Pacientes", "idDepartamento", "dbo.Departamentos");
            DropIndex("dbo.HistorialesClinicos", new[] { "idCita" });
            DropIndex("dbo.HistorialesClinicos", new[] { "idTratamiento" });
            DropIndex("dbo.HistorialesClinicos", new[] { "idMedicamento" });
            DropIndex("dbo.HistorialesClinicos", new[] { "idEnfermedad" });
            DropIndex("dbo.HistorialesClinicos", new[] { "idPaciente" });
            DropIndex("dbo.Familiar", new[] { "pacienteId" });
            DropIndex("dbo.Facturas", new[] { "servicioId" });
            DropIndex("dbo.Facturas", new[] { "medicoId" });
            DropIndex("dbo.Facturas", new[] { "pacienteId" });
            DropIndex("dbo.Enfermedades", new[] { "pacienteId" });
            DropIndex("dbo.Tratamientos", new[] { "idMedico" });
            DropIndex("dbo.Tratamientos", new[] { "idPaciente" });
            DropIndex("dbo.Pacientes", new[] { "idTipoSangre" });
            DropIndex("dbo.Pacientes", new[] { "idMunicipio" });
            DropIndex("dbo.Pacientes", new[] { "idDepartamento" });
            DropIndex("dbo.Pacientes", new[] { "idEstadoCivil" });
            DropIndex("dbo.Pacientes", new[] { "idOcupacion" });
            DropIndex("dbo.Pacientes", new[] { "idSexo" });
            DropIndex("dbo.Examenes", new[] { "pacienteId" });
            DropIndex("dbo.Consultas", new[] { "IdTratamiento" });
            DropIndex("dbo.Consultas", new[] { "idExamen" });
            DropIndex("dbo.Consultas", new[] { "idMedico" });
            DropIndex("dbo.Consultas", new[] { "idPaciente" });
            DropIndex("dbo.Citas", new[] { "idConsulta" });
            DropIndex("dbo.Citas", new[] { "idMedico" });
            DropIndex("dbo.Citas", new[] { "idPaciente" });
            DropTable("dbo.TiposExamen");
            DropTable("dbo.Medicamentos");
            DropTable("dbo.HistorialesClinicos");
            DropTable("dbo.Familiar");
            DropTable("dbo.Servicios");
            DropTable("dbo.Facturas");
            DropTable("dbo.EspecialidadesDoctor");
            DropTable("dbo.Enfermedades");
            DropTable("dbo.Tratamientos");
            DropTable("dbo.Medicos");
            DropTable("dbo.TiposdeSangre");
            DropTable("dbo.Sexo");
            DropTable("dbo.OcupacionesPaciente");
            DropTable("dbo.Municipios");
            DropTable("dbo.EstadosCiviles");
            DropTable("dbo.Departamentos");
            DropTable("dbo.Pacientes");
            DropTable("dbo.Examenes");
            DropTable("dbo.Consultas");
            DropTable("dbo.Citas");
        }
    }
}
