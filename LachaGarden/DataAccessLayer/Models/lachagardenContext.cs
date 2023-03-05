using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataAccessLayer.Models
{
    public partial class lachagardenContext : DbContext
    {
        public lachagardenContext()
        {
        }

        public lachagardenContext(DbContextOptions<lachagardenContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Area> Areas { get; set; }
        public virtual DbSet<Building> Buildings { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Garden> Gardens { get; set; }
        public virtual DbSet<GardenPackage> GardenPackages { get; set; }
        public virtual DbSet<PackageType> PackageTypes { get; set; }
        public virtual DbSet<Request> Requests { get; set; }
        public virtual DbSet<Result> Results { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Room> Rooms { get; set; }
        public virtual DbSet<Technical> Technicals { get; set; }
        public virtual DbSet<Tree> Trees { get; set; }
        public virtual DbSet<TreeCare> TreeCares { get; set; }
        public virtual DbSet<TreeType> TreeTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =quangnketchup\\SQLEXPRESS; database = lachagarden;uid=sa;pwd=Quienvi204;MultipleActiveResultSets=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Area>(entity =>
            {
                entity.ToTable("Area");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NameArea).HasMaxLength(50);
            });

            modelBuilder.Entity<Building>(entity =>
            {
                entity.ToTable("Building");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AreaId).HasColumnName("AreaID");

                entity.Property(e => e.NameBuilding).HasMaxLength(50);

                entity.HasOne(d => d.Area)
                    .WithMany(p => p.Buildings)
                    .HasForeignKey(d => d.AreaId)
                    .HasConstraintName("FK_Building_Area");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.ToTable("Customer");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.FullName).HasMaxLength(50);

                entity.Property(e => e.Gmail).HasMaxLength(50);

                entity.Property(e => e.Phone).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Customers)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Customer_Role");
            });

            modelBuilder.Entity<Garden>(entity =>
            {
                entity.ToTable("Garden");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.GardenPackageId).HasColumnName("GardenPackageID");

                entity.HasOne(d => d.GardenPackage)
                    .WithMany(p => p.Gardens)
                    .HasForeignKey(d => d.GardenPackageId)
                    .HasConstraintName("FK_Garden_GardenPackage");

                entity.HasOne(d => d.IdNavigation)
                    .WithOne(p => p.Garden)
                    .HasForeignKey<Garden>(d => d.Id)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Garden_Room");
            });

            modelBuilder.Entity<GardenPackage>(entity =>
            {
                entity.ToTable("GardenPackage");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NamePack).HasMaxLength(100);

                entity.Property(e => e.PackageTypeId).HasColumnName("PackageTypeID");

                entity.HasOne(d => d.PackageType)
                    .WithMany(p => p.GardenPackages)
                    .HasForeignKey(d => d.PackageTypeId)
                    .HasConstraintName("FK_GardenPackage_PackageType");
            });

            modelBuilder.Entity<PackageType>(entity =>
            {
                entity.ToTable("PackageType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NamePackageType).HasMaxLength(50);
            });

            modelBuilder.Entity<Request>(entity =>
            {
                entity.ToTable("Request");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GardenId).HasColumnName("GardenID");

                entity.HasOne(d => d.Garden)
                    .WithMany(p => p.Requests)
                    .HasForeignKey(d => d.GardenId)
                    .HasConstraintName("FK_Request_Garden");
            });

            modelBuilder.Entity<Result>(entity =>
            {
                entity.ToTable("Result");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.DateReport).HasColumnType("datetime");

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.TreeCareId).HasColumnName("TreeCareID");

                entity.HasOne(d => d.TreeCare)
                    .WithMany(p => p.Results)
                    .HasForeignKey(d => d.TreeCareId)
                    .HasConstraintName("FK_Result_TreeCare");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(50);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.ToTable("Room");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.BuildingId).HasColumnName("BuildingID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.RoomNumber).HasMaxLength(50);

                entity.HasOne(d => d.Building)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.BuildingId)
                    .HasConstraintName("FK_Room_Building");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Rooms)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Room_Customer");
            });

            modelBuilder.Entity<Technical>(entity =>
            {
                entity.ToTable("Technical");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Gmail).HasMaxLength(50);

                entity.Property(e => e.NameTech).HasMaxLength(50);

                entity.Property(e => e.Phone).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Technicals)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_Technical_Role");
            });

            modelBuilder.Entity<Tree>(entity =>
            {
                entity.ToTable("Tree");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.GardenPackageId).HasColumnName("GardenPackageID");

                entity.Property(e => e.NameTree).HasMaxLength(50);

                entity.Property(e => e.TreeTypeId).HasColumnName("TreeTypeID");

                entity.HasOne(d => d.GardenPackage)
                    .WithMany(p => p.Trees)
                    .HasForeignKey(d => d.GardenPackageId)
                    .HasConstraintName("FK_Tree_GardenPackage");

                entity.HasOne(d => d.TreeType)
                    .WithMany(p => p.Trees)
                    .HasForeignKey(d => d.TreeTypeId)
                    .HasConstraintName("FK_Tree_TreeType");
            });

            modelBuilder.Entity<TreeCare>(entity =>
            {
                entity.ToTable("TreeCare");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.RequestId).HasColumnName("RequestID");

                entity.Property(e => e.TechnicalId).HasColumnName("TechnicalID");

                entity.HasOne(d => d.Request)
                    .WithMany(p => p.TreeCares)
                    .HasForeignKey(d => d.RequestId)
                    .HasConstraintName("FK_TreeCare_Request");

                entity.HasOne(d => d.Technical)
                    .WithMany(p => p.TreeCares)
                    .HasForeignKey(d => d.TechnicalId)
                    .HasConstraintName("FK_TreeCare_Technical");
            });

            modelBuilder.Entity<TreeType>(entity =>
            {
                entity.ToTable("TreeType");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.NameTreeType).HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
