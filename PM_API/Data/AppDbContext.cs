using Challenge_PM.Models;
using Microsoft.EntityFrameworkCore;

namespace Challenge_PM.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Alerta> Alertas { get; set; }

        public DbSet<DataCenter> DataCenters { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Manutencao> Manutencoes { get; set; }

        public DbSet<Sensor> Sensores { get; set; }

        public DbSet<TipoAlerta> TipoAlertas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Alerta>().ToTable("T_NET_ALERTA");
            modelBuilder.Entity<Alerta>().Property(a => a.Id).HasColumnName("ID_ALERTA");
            modelBuilder.Entity<Alerta>().Property(a => a.DataAlerta).HasColumnName("DT_ALERTA");
            modelBuilder.Entity<Alerta>().Property(a => a.Tipo_Id).HasColumnName("FK_ID_FUNCIONARIO");
            modelBuilder.Entity<Alerta>().Property(a => a.Sensor_Id).HasColumnName("FK_ID_SENSOR");

            modelBuilder.Entity<DataCenter>().ToTable("T_NET_DATACENTER");
            modelBuilder.Entity<DataCenter>().Property(dc => dc.Id).HasColumnName("ID_DATACENTER");
            modelBuilder.Entity<DataCenter>().Property(dc => dc.Setor).HasColumnName("SETOR");
            modelBuilder.Entity<DataCenter>().Property(dc => dc.StatusDatacenter).HasColumnName("STATUS_DATACENTER");

            modelBuilder.Entity<Funcionario>().ToTable("T_NET_FUNCIONARIO");
            modelBuilder.Entity<Funcionario>().Property(f => f.Id).HasColumnName("ID_FUNCIONARIO");
            modelBuilder.Entity<Funcionario>().Property(f => f.Nome).HasColumnName("NM_FUNCIONARIO");
            modelBuilder.Entity<Funcionario>().Property(f => f.Email).HasColumnName("EMAIL_FUNCIONARIO");
            modelBuilder.Entity<Funcionario>().Property(f => f.Telefone).HasColumnName("TEL_FUNCIONARIO");
            modelBuilder.Entity<Funcionario>().Property(f => f.CargoFuncionario).HasColumnName("CARGO_FUNCIONARIO");

            modelBuilder.Entity<Manutencao>().ToTable("T_NET_MANUTENCAO");
            modelBuilder.Entity<Manutencao>().Property(M => M.Id).HasColumnName("ID_MANUTENCAO");
            modelBuilder.Entity<Manutencao>().Property(M => M.DataManutencao).HasColumnName("DT_MANUTENCAO");
            modelBuilder.Entity<Manutencao>().Property(M => M.TipoManutencao).HasColumnName("TIPO_MANUTENCAO");
            modelBuilder.Entity<Manutencao>().Property(M => M.StatusManutencao).HasColumnName("STATUS_MANUTENCAO");
            modelBuilder.Entity<Manutencao>().Property(M => M.Funcionario_Id).HasColumnName("FK_ID_FUNCIONARIO");
            modelBuilder.Entity<Manutencao>().Property(M => M.Alerta_Id).HasColumnName("FK_ID_ALERTA");

            modelBuilder.Entity<Sensor>().ToTable("T_NET_SENSOR");
            modelBuilder.Entity<Sensor>().Property(s => s.Id).HasColumnName("ID_SENSOR");
            modelBuilder.Entity<Sensor>().Property(s => s.TipoSensor).HasColumnName("TIPO_SENSOR");
            modelBuilder.Entity<Sensor>().Property(s => s.UnidadeMedida).HasColumnName("UNIDADE_MEDIDA");
            modelBuilder.Entity<Sensor>().Property(s => s.AtividadeSensor).HasColumnName("ATIVIDADE_SENSOR");
            modelBuilder.Entity<Sensor>().Property(s => s.DataCenter_Id).HasColumnName("FK_ID_DATACENTER");

            modelBuilder.Entity<TipoAlerta>().ToTable("T_NET_TIPO_ALERTA");
            modelBuilder.Entity<TipoAlerta>().Property(tp => tp.Id).HasColumnName("ID_TIPO");
            modelBuilder.Entity<TipoAlerta>().Property(tp => tp.Tipo).HasColumnName("TIPO");
            modelBuilder.Entity<TipoAlerta>().Property(tp => tp.Nivel_alerta).HasColumnName("NIVEL_ALERTA");
            modelBuilder.Entity<TipoAlerta>().Property(tp => tp.Descricao).HasColumnName("DESCRICAO");

            base.OnModelCreating(modelBuilder);
        }
    }
}