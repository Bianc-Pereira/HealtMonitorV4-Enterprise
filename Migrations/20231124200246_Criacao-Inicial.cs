using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HealtMonitorV4.Migrations
{
    /// <inheritdoc />
    public partial class CriacaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Endereco",
                columns: table => new
                {
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Rua = table.Column<string>(type: "text", nullable: false),
                    Bairro = table.Column<string>(type: "text", nullable: false),
                    Cidade = table.Column<string>(type: "text", nullable: false),
                    Numero = table.Column<int>(type: "integer", nullable: false),
                    Estado = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Endereco", x => x.Cep);
                });

            migrationBuilder.CreateTable(
                name: "Hospital",
                columns: table => new
                {
                    CodigoHospital = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    NomeHospital = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    Telefone = table.Column<string>(type: "text", nullable: false),
                    Email = table.Column<string>(type: "text", nullable: false),
                    EnderecoCep = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hospital", x => x.CodigoHospital);
                    table.ForeignKey(
                        name: "FK_Hospital_Endereco_EnderecoCep",
                        column: x => x.EnderecoCep,
                        principalTable: "Endereco",
                        principalColumn: "Cep");
                });

            migrationBuilder.CreateTable(
                name: "Paciente",
                columns: table => new
                {
                    IdPaciente = table.Column<string>(type: "text", nullable: false),
                    NomePaciente = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<string>(type: "text", nullable: false),
                    EmailPaciente = table.Column<string>(type: "text", nullable: false),
                    CpfPaciente = table.Column<string>(type: "text", nullable: false),
                    RgPaciente = table.Column<string>(type: "text", nullable: false),
                    CelEmergencia = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: false),
                    EnderecoCep = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paciente", x => x.IdPaciente);
                    table.ForeignKey(
                        name: "FK_Paciente_Endereco_EnderecoCep",
                        column: x => x.EnderecoCep,
                        principalTable: "Endereco",
                        principalColumn: "Cep");
                });

            migrationBuilder.CreateTable(
                name: "Medico",
                columns: table => new
                {
                    IdMedico = table.Column<string>(type: "text", nullable: false),
                    NomeMedico = table.Column<string>(type: "text", nullable: false),
                    DataNascimento = table.Column<string>(type: "text", nullable: false),
                    EmailMedico = table.Column<string>(type: "text", nullable: false),
                    CpfMedico = table.Column<string>(type: "text", nullable: false),
                    CrmMedico = table.Column<string>(type: "text", nullable: false),
                    Cep = table.Column<string>(type: "text", nullable: true),
                    EnderecoCep = table.Column<string>(type: "text", nullable: true),
                    CodigoHospital = table.Column<int>(type: "integer", nullable: true),
                    HospitalCodigoHospital = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medico", x => x.IdMedico);
                    table.ForeignKey(
                        name: "FK_Medico_Endereco_EnderecoCep",
                        column: x => x.EnderecoCep,
                        principalTable: "Endereco",
                        principalColumn: "Cep");
                    table.ForeignKey(
                        name: "FK_Medico_Hospital_HospitalCodigoHospital",
                        column: x => x.HospitalCodigoHospital,
                        principalTable: "Hospital",
                        principalColumn: "CodigoHospital",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consulta",
                columns: table => new
                {
                    CodigoConsulta = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataConsulta = table.Column<string>(type: "text", nullable: false),
                    IdPaciente = table.Column<int>(type: "integer", nullable: false),
                    PacienteIdPaciente = table.Column<string>(type: "text", nullable: false),
                    CrmMedico = table.Column<string>(type: "text", nullable: false),
                    MedicoIdMedico = table.Column<string>(type: "text", nullable: false),
                    CodigoHospital = table.Column<int>(type: "integer", nullable: false),
                    HospitalCodigoHospital = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consulta", x => x.CodigoConsulta);
                    table.ForeignKey(
                        name: "FK_Consulta_Hospital_HospitalCodigoHospital",
                        column: x => x.HospitalCodigoHospital,
                        principalTable: "Hospital",
                        principalColumn: "CodigoHospital",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Medico_MedicoIdMedico",
                        column: x => x.MedicoIdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Consulta_Paciente_PacienteIdPaciente",
                        column: x => x.PacienteIdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prontuario",
                columns: table => new
                {
                    IdProntuario = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    IdPaciente = table.Column<int>(type: "integer", nullable: true),
                    PacienteIdPaciente = table.Column<string>(type: "text", nullable: true),
                    IdMedico = table.Column<int>(type: "integer", nullable: true),
                    MedicoIdMedico = table.Column<string>(type: "text", nullable: true),
                    Prioridade = table.Column<string>(type: "text", nullable: false),
                    TempCorporal = table.Column<string>(type: "text", nullable: false),
                    PressaoArt = table.Column<string>(type: "text", nullable: false),
                    FreqCardiaca = table.Column<string>(type: "text", nullable: false),
                    FreqResp = table.Column<string>(type: "text", nullable: false),
                    SatOxig = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prontuario", x => x.IdProntuario);
                    table.ForeignKey(
                        name: "FK_Prontuario_Medico_MedicoIdMedico",
                        column: x => x.MedicoIdMedico,
                        principalTable: "Medico",
                        principalColumn: "IdMedico");
                    table.ForeignKey(
                        name: "FK_Prontuario_Paciente_PacienteIdPaciente",
                        column: x => x.PacienteIdPaciente,
                        principalTable: "Paciente",
                        principalColumn: "IdPaciente");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_HospitalCodigoHospital",
                table: "Consulta",
                column: "HospitalCodigoHospital");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_MedicoIdMedico",
                table: "Consulta",
                column: "MedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Consulta_PacienteIdPaciente",
                table: "Consulta",
                column: "PacienteIdPaciente");

            migrationBuilder.CreateIndex(
                name: "IX_Hospital_EnderecoCep",
                table: "Hospital",
                column: "EnderecoCep");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_EnderecoCep",
                table: "Medico",
                column: "EnderecoCep");

            migrationBuilder.CreateIndex(
                name: "IX_Medico_HospitalCodigoHospital",
                table: "Medico",
                column: "HospitalCodigoHospital");

            migrationBuilder.CreateIndex(
                name: "IX_Paciente_EnderecoCep",
                table: "Paciente",
                column: "EnderecoCep");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_MedicoIdMedico",
                table: "Prontuario",
                column: "MedicoIdMedico");

            migrationBuilder.CreateIndex(
                name: "IX_Prontuario_PacienteIdPaciente",
                table: "Prontuario",
                column: "PacienteIdPaciente");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consulta");

            migrationBuilder.DropTable(
                name: "Prontuario");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Paciente");

            migrationBuilder.DropTable(
                name: "Hospital");

            migrationBuilder.DropTable(
                name: "Endereco");
        }
    }
}
