using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace SGS.DAL.Scaffold;

public partial class ConfigDbContext : DbContext
{
    public ConfigDbContext()
    {
    }

    public ConfigDbContext(DbContextOptions<ConfigDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tblkpi> Tblkpis { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.\\NANCY;Database=SGS;TrustServerCertificate=True;Trusted_Connection=True");

    public IDbConnection CreateConnection() => new SqlConnection("Server=.\\NANCY;Database=SGS;TrustServerCertificate=True;Trusted_Connection=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tblkpi>(entity =>
        {
            entity.HasKey(e => e.Kpidnum);

            entity.ToTable("TBLKPI");

            entity.Property(e => e.Kpidnum)
                .ValueGeneratedNever()
                .HasColumnName("KPIDNum");
            entity.Property(e => e.Kpidescription)
                .HasMaxLength(150)
                .HasColumnName("KPIDescription");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
