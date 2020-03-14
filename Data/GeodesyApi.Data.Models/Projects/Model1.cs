/*namespace GeodesyApi.Data.Models.Projects
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using Microsoft.EntityFrameworkCore;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
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
                .WithRequired(e => e.Projects)
                .HasForeignKey(e => e.projectId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Projects>()
                .HasMany(e => e.ProjectUpdates)
                .WithRequired(e => e.Projects)
                .HasForeignKey(e => e.Pid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectUpdates>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<ProjectUpdates>()
                .HasMany(e => e.Layers)
                .WithRequired(e => e.ProjectUpdates)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectUpdates>()
                .HasMany(e => e.NonGeometricData)
                .WithRequired(e => e.ProjectUpdates)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ProjectUpdates>()
                .HasMany(e => e.ProjectMap)
                .WithRequired(e => e.ProjectUpdates)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Stable>()
                .Property(e => e.DataTable)
                .IsUnicode(false);

            modelBuilder.Entity<Stable>()
                .Property(e => e.Geom)
                .IsUnicode(false);

            modelBuilder.Entity<Stable>()
                .Property(e => e.KeyValue)
                .IsUnicode(false);
        }
    }
}
*/