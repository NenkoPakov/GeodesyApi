
/*
namespace GeodesyApi.Data.Models.Projects
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public partial class ProjectsDbContext : DbContext
    {
        public ProjectsDbContext()
            : base()
        {
        }

        public virtual DbSet<HistorycalData> HistorycalData { get; set; }
        public virtual DbSet<Layers> Layers { get; set; }
        public virtual DbSet<MapLayers> MapLayers { get; set; }
        public virtual DbSet<NonGeometricData> NonGeometricData { get; set; }
        public virtual DbSet<ProjectMap> ProjectMap { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<ProjectUpdates> ProjectUpdates { get; set; }
        public virtual DbSet<Stable> Stable { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HistorycalData>()
                .Property(e => e.ObjectType)
                .IsUnicode(false);

            modelBuilder.Entity<HistorycalData>()
                .Property(e => e.ObjectName)
                .IsUnicode(false);

            modelBuilder.Entity<HistorycalData>()
                .Property(e => e.ObjectContent)
                .IsUnicode(false);

            modelBuilder.Entity<HistorycalData>()
                .Property(e => e.ParentObject)
                .IsUnicode(false);

            modelBuilder.Entity<Layers>()
                .Property(e => e.LayerId)
                .IsUnicode(false);

            modelBuilder.Entity<Layers>()
                .Property(e => e.LayerName)
                .IsUnicode(false);

            modelBuilder.Entity<Layers>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Layers>()
                .Property(e => e.BBox)
                .IsUnicode(false);

            modelBuilder.Entity<Layers>()
                .Property(e => e.Crs)
                .IsUnicode(false);

            modelBuilder.Entity<Layers>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<NonGeometricData>()
                .Property(e => e.Uri)
                .IsUnicode(false);

            modelBuilder.Entity<NonGeometricData>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<NonGeometricData>()
                .Property(e => e.FileName)
                .IsUnicode(false);

            modelBuilder.Entity<NonGeometricData>()
                .Property(e => e.Format)
                .IsUnicode(false);

            modelBuilder.Entity<NonGeometricData>()
                .Property(e => e.Source)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectMap>()
                .Property(e => e.ProjectId)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectMap>()
                .Property(e => e.MapName)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectMap>()
                .Property(e => e.Crs)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectMap>()
                .Property(e => e.BBox)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectMap>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectMap>()
                .Property(e => e.MapFile)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.ProjectId)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.ParentId)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.ProjectDatabase)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .Property(e => e.GeoJson)
                .IsUnicode(false);

            modelBuilder.Entity<Projects>()
                .HasMany(e => e.NonGeometricData)
                .WithOne(e => e.Projects).IsRequired()
                .HasForeignKey(e => e.ProjectId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Projects>()
                .HasMany(e => e.ProjectUpdates)
                .WithOne(e => e.Projects).IsRequired()
                .HasForeignKey(e => e.PId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectUpdates>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectUpdates>()
                .HasMany(e => e.Layers)
                .WithOne(e => e.ProjectUpdates).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectUpdates>()
                .HasMany(e => e.NonGeometricData)
                .WithOne(e => e.ProjectUpdates).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProjectUpdates>()
                .HasMany(e => e.ProjectMaps)
                .WithOne(e => e.ProjectUpdates).IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Stable>()
                .Property(e => e.DataTable)
                .IsUnicode(false);

            modelBuilder.Entity<Stable>()
                .Property(e => e.Geometry)
                .IsUnicode(false);

            modelBuilder.Entity<Stable>()
                .Property(e => e.KeyValue)
                .IsUnicode(false);
        }
    }
}
*/