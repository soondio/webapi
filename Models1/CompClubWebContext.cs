using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace WebApplicationLab2.Models1;

public partial class CompClubWebContext : IdentityDbContext<User>
{
    protected readonly IConfiguration Configuration;


    public CompClubWebContext(IConfiguration configuration)
    {
        Configuration = configuration;
    }
    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Computer> Computers { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<FoodOrder> FoodOrders { get; set; }

    public virtual DbSet<Monitor> Monitors { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Processor> Processors { get; set; }

    public virtual DbSet<Ram> Rams { get; set; }

    public virtual DbSet<VideoCard> VideoCards { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-456MSLR;Database=CompClubWeb12;Trusted_Connection=True;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Clients__3213E83FA06422A0");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Balance)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("balance");
            entity.Property(e => e.Bonus).HasColumnName("bonus");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("role");
        });

        modelBuilder.Entity<Computer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Computer__3213E83F0F56BD70");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.MonitorId).HasColumnName("monitor_id");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Priceperhour)
                .HasColumnType("decimal(18, 0)")
                .HasColumnName("priceperhour");
            entity.Property(e => e.ProcessorId).HasColumnName("processor_id");
            entity.Property(e => e.RamId).HasColumnName("ram_id");
            entity.Property(e => e.VideoCardId).HasColumnName("video_card_id");

            entity.HasOne(d => d.Monitor).WithMany(p => p.Computers)
                .HasForeignKey(d => d.MonitorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Computers__monit__300424B4");

            entity.HasOne(d => d.Processor).WithMany(p => p.Computers)
                .HasForeignKey(d => d.ProcessorId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Computers__proce__2E1BDC42");

            entity.HasOne(d => d.Ram).WithMany(p => p.Computers)
                .HasForeignKey(d => d.RamId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Computers__ram_i__30F848ED");

            entity.HasOne(d => d.VideoCard).WithMany(p => p.Computers)
                .HasForeignKey(d => d.VideoCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Computers__video__2F10007B");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Food__3213E83F9FB02013");

            entity.ToTable("Food");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Stock).HasColumnName("stock");
        });

        modelBuilder.Entity<FoodOrder>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__FoodOrde__3213E83F779D8FB8");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.FoodId).HasColumnName("food_id");
            entity.Property(e => e.Price)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("price");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Client).WithMany(p => p.FoodOrders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FoodOrder__clien__33D4B598");

            entity.HasOne(d => d.Food).WithMany(p => p.FoodOrders)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__FoodOrder__food___4222D4EF");
        });

        modelBuilder.Entity<Monitor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Monitors__3213E83FB93D26CF");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3213E83F6D40F189");

            /*entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");*/
            modelBuilder.Entity<Order>()
            .Property(o => o.Id)
            .HasAnnotation("DatabaseGenerated", DatabaseGeneratedOption.Identity);
            entity.Property(e => e.ClientId).HasColumnName("client_id");
            entity.Property(e => e.ComputerId).HasColumnName("computer_id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.EndDate)
                .HasColumnType("datetime")
                .HasColumnName("end_date");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 0)");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__client_i__36B12243");

            entity.HasOne(d => d.Computer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ComputerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__computer__37A5467C");
        });

        modelBuilder.Entity<Processor>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Processo__3213E83F98B2171C");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Ram>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RAMs__3213E83FEF962F2E");

            entity.ToTable("RAMs");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<VideoCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__VideoCar__3213E83F1F580B0D");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
