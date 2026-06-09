using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PM_API.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "T_NET_DATACENTER",
                columns: table => new
                {
                    ID_DATACENTER = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    SETOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    STATUS_DATACENTER = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_DATACENTER", x => x.ID_DATACENTER);
                });

            migrationBuilder.CreateTable(
                name: "T_NET_FUNCIONARIO",
                columns: table => new
                {
                    ID_FUNCIONARIO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    NM_FUNCIONARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    EMAIL_FUNCIONARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    TEL_FUNCIONARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    CARGO_FUNCIONARIO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_FUNCIONARIO", x => x.ID_FUNCIONARIO);
                });

            migrationBuilder.CreateTable(
                name: "T_NET_TIPO_ALERTA",
                columns: table => new
                {
                    ID_TIPO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TIPO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    NIVEL_ALERTA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    DESCRICAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_TIPO_ALERTA", x => x.ID_TIPO);
                });

            migrationBuilder.CreateTable(
                name: "T_NET_SENSOR",
                columns: table => new
                {
                    ID_SENSOR = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    TIPO_SENSOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    UNIDADE_MEDIDA = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    ATIVIDADE_SENSOR = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FK_ID_DATACENTER = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    DataCenterId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_SENSOR", x => x.ID_SENSOR);
                    table.ForeignKey(
                        name: "FK_T_NET_SENSOR_T_NET_DATACENTER_DataCenterId",
                        column: x => x.DataCenterId,
                        principalTable: "T_NET_DATACENTER",
                        principalColumn: "ID_DATACENTER");
                });

            migrationBuilder.CreateTable(
                name: "T_NET_ALERTA",
                columns: table => new
                {
                    ID_ALERTA = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DT_ALERTA = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    FK_ID_FUNCIONARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FK_ID_SENSOR = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    TipoAlertaId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    SensorId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_ALERTA", x => x.ID_ALERTA);
                    table.ForeignKey(
                        name: "FK_T_NET_ALERTA_T_NET_SENSOR_SensorId",
                        column: x => x.SensorId,
                        principalTable: "T_NET_SENSOR",
                        principalColumn: "ID_SENSOR");
                    table.ForeignKey(
                        name: "FK_T_NET_ALERTA_T_NET_TIPO_ALERTA_TipoAlertaId",
                        column: x => x.TipoAlertaId,
                        principalTable: "T_NET_TIPO_ALERTA",
                        principalColumn: "ID_TIPO");
                });

            migrationBuilder.CreateTable(
                name: "T_NET_MANUTENCAO",
                columns: table => new
                {
                    ID_MANUTENCAO = table.Column<int>(type: "NUMBER(10)", nullable: false)
                        .Annotation("Oracle:Identity", "START WITH 1 INCREMENT BY 1"),
                    DT_MANUTENCAO = table.Column<DateTime>(type: "TIMESTAMP(7)", nullable: false),
                    TIPO_MANUTENCAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    STATUS_MANUTENCAO = table.Column<string>(type: "NVARCHAR2(2000)", nullable: false),
                    FK_ID_FUNCIONARIO = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FK_ID_ALERTA = table.Column<int>(type: "NUMBER(10)", nullable: false),
                    FuncionarioId = table.Column<int>(type: "NUMBER(10)", nullable: true),
                    AlertaId = table.Column<int>(type: "NUMBER(10)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_T_NET_MANUTENCAO", x => x.ID_MANUTENCAO);
                    table.ForeignKey(
                        name: "FK_T_NET_MANUTENCAO_T_NET_ALERTA_AlertaId",
                        column: x => x.AlertaId,
                        principalTable: "T_NET_ALERTA",
                        principalColumn: "ID_ALERTA");
                    table.ForeignKey(
                        name: "FK_T_NET_MANUTENCAO_T_NET_FUNCIONARIO_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalTable: "T_NET_FUNCIONARIO",
                        principalColumn: "ID_FUNCIONARIO");
                });

            migrationBuilder.CreateIndex(
                name: "IX_T_NET_ALERTA_SensorId",
                table: "T_NET_ALERTA",
                column: "SensorId");

            migrationBuilder.CreateIndex(
                name: "IX_T_NET_ALERTA_TipoAlertaId",
                table: "T_NET_ALERTA",
                column: "TipoAlertaId");

            migrationBuilder.CreateIndex(
                name: "IX_T_NET_MANUTENCAO_AlertaId",
                table: "T_NET_MANUTENCAO",
                column: "AlertaId");

            migrationBuilder.CreateIndex(
                name: "IX_T_NET_MANUTENCAO_FuncionarioId",
                table: "T_NET_MANUTENCAO",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_T_NET_SENSOR_DataCenterId",
                table: "T_NET_SENSOR",
                column: "DataCenterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "T_NET_MANUTENCAO");

            migrationBuilder.DropTable(
                name: "T_NET_ALERTA");

            migrationBuilder.DropTable(
                name: "T_NET_FUNCIONARIO");

            migrationBuilder.DropTable(
                name: "T_NET_SENSOR");

            migrationBuilder.DropTable(
                name: "T_NET_TIPO_ALERTA");

            migrationBuilder.DropTable(
                name: "T_NET_DATACENTER");
        }
    }
}
