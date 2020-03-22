namespace GeodesyApi.Data
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Threading;
    using System.Threading.Tasks;
    using GeodesyApi.Data;
    using GeodesyApi.Data.Common.Models;
    using GeodesyApi.Data.Models.Projects;
    using GeodesyApi.Data.Models;

    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        private static readonly MethodInfo SetIsDeletedQueryFilterMethod =
            typeof(ApplicationDbContext).GetMethod(
                nameof(SetIsDeletedQueryFilter),
                BindingFlags.NonPublic | BindingFlags.Static);

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Setting> Settings { get; set; }

        public virtual DbSet<HistorycalData> HistorycalData { get; set; }

        public virtual DbSet<Layers> Layers { get; set; }

        public virtual DbSet<MapLayers> MapLayers { get; set; }

        public virtual DbSet<NonGeometricData> NonGeometricData { get; set; }

        public virtual DbSet<ProjectMap> ProjectMap { get; set; }

        public virtual DbSet<Projects> Projects { get; set; }

        public virtual DbSet<ProjectUpdates> ProjectUpdates { get; set; }

        public virtual DbSet<Stable> Stable { get; set; }

        public virtual DbSet<Material> Materials { get; set; }

        public virtual DbSet<Library> Libraries { get; set; }

        public virtual DbSet<News> News { get; set; }

        public virtual DbSet<Comment> Comments { get; set; }

        public override int SaveChanges() => SaveChanges(true);

        public override int SaveChanges(bool acceptAllChangesOnSuccess)
        {
            ApplyAuditInfoRules();
            return base.SaveChanges(acceptAllChangesOnSuccess);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default) =>
            SaveChangesAsync(true, cancellationToken);

        public override Task<int> SaveChangesAsync(
            bool acceptAllChangesOnSuccess,
            CancellationToken cancellationToken = default)
        {
            ApplyAuditInfoRules();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            {
                builder.Entity<HistorycalData>()
                    .Property(e => e.ObjectType)
                    .IsUnicode(false);

                builder.Entity<HistorycalData>()
                    .Property(e => e.ObjectName)
                    .IsUnicode(false);

                builder.Entity<HistorycalData>()
                    .Property(e => e.ObjectContent)
                    .IsUnicode(false);

                builder.Entity<HistorycalData>()
                    .Property(e => e.ParentObject)
                    .IsUnicode(false);

                builder.Entity<Layers>()
                    .Property(e => e.LayerId)
                    .IsUnicode(false);

                builder.Entity<Layers>()
                    .Property(e => e.LayerName)
                    .IsUnicode(false);

                builder.Entity<Layers>()
                    .Property(e => e.Description)
                    .IsUnicode(false);

                builder.Entity<Layers>()
                    .Property(e => e.BBox)
                    .IsUnicode(false);

                builder.Entity<Layers>()
                    .Property(e => e.Crs)
                    .IsUnicode(false);

                builder.Entity<Layers>()
                    .Property(e => e.Source)
                    .IsUnicode(false);

                builder.Entity<NonGeometricData>()
                    .Property(e => e.Uri)
                    .IsUnicode(false);

                builder.Entity<NonGeometricData>()
                    .Property(e => e.Description)
                    .IsUnicode(false);

                builder.Entity<NonGeometricData>()
                    .Property(e => e.FileName)
                    .IsUnicode(false);

                builder.Entity<NonGeometricData>()
                    .Property(e => e.Format)
                    .IsUnicode(false);

                builder.Entity<NonGeometricData>()
                    .Property(e => e.Source)
                    .IsUnicode(false);

                builder.Entity<ProjectMap>()
                    .Property(e => e.ProjectId)
                    .IsUnicode(false);

                builder.Entity<ProjectMap>()
                    .Property(e => e.MapName)
                    .IsUnicode(false);

                builder.Entity<ProjectMap>()
                    .Property(e => e.Crs)
                    .IsUnicode(false);

                builder.Entity<ProjectMap>()
                    .Property(e => e.BBox)
                    .IsUnicode(false);

                builder.Entity<ProjectMap>()
                    .Property(e => e.Description)
                    .IsUnicode(false);

                builder.Entity<ProjectMap>()
                    .Property(e => e.MapFile)
                    .IsUnicode(false);

                builder.Entity<Projects>()
                    .Property(e => e.ProjectId)
                    .IsUnicode(false);

                builder.Entity<Projects>()
                    .Property(e => e.ParentId)
                    .IsUnicode(false);

                builder.Entity<Projects>()
                    .Property(e => e.ProjectDatabase)
                    .IsUnicode(false);

                builder.Entity<Projects>()
                    .Property(e => e.Description)
                    .IsUnicode(false);

                builder.Entity<Projects>()
                    .Property(e => e.GeoJson)
                    .IsUnicode(false);

                builder.Entity<Projects>()
                    .HasMany(e => e.NonGeometricData)
                    .WithOne(e => e.Projects).IsRequired()
                    .HasForeignKey(e => e.ProjectId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<Projects>()
                    .HasMany(e => e.ProjectUpdates)
                    .WithOne(e => e.Projects).IsRequired()
                    .HasForeignKey(e => e.PId)
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<ProjectUpdates>()
                    .Property(e => e.Status)
                    .IsUnicode(false);

                builder.Entity<ProjectUpdates>()
                    .HasMany(e => e.Layers)
                    .WithOne(e => e.ProjectUpdates).IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<ProjectUpdates>()
                    .HasMany(e => e.NonGeometricData)
                    .WithOne(e => e.ProjectUpdates).IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<ProjectUpdates>()
                    .HasMany(e => e.ProjectMaps)
                    .WithOne(e => e.ProjectUpdates).IsRequired()
                    .OnDelete(DeleteBehavior.Restrict);

                builder.Entity<Stable>()
                    .Property(e => e.DataTable)
                    .IsUnicode(false);

                builder.Entity<Stable>()
                    .Property(e => e.Geometry)
                    .IsUnicode(false);

                builder.Entity<Stable>()
                    .Property(e => e.KeyValue)
                    .IsUnicode(false);




                builder.Entity<Material>()
                   .HasOne(e => e.Author)
                   .WithMany(a => a.Materials)
                   .HasForeignKey(n => n.AuthorId)
                   .OnDelete(DeleteBehavior.Restrict);

            }



            // Needed for Identity models configuration
            base.OnModelCreating(builder);

            ConfigureUserIdentityRelations(builder);

            EntityIndexesConfiguration.Configure(builder);

            var entityTypes = builder.Model.GetEntityTypes().ToList();

            // Set global query filter for not deleted entities only
            var deletableEntityTypes = entityTypes
                .Where(et => et.ClrType != null && typeof(IDeletableEntity).IsAssignableFrom(et.ClrType));
            foreach (var deletableEntityType in deletableEntityTypes)
            {
                var method = SetIsDeletedQueryFilterMethod.MakeGenericMethod(deletableEntityType.ClrType);
                method.Invoke(null, new object[] { builder });
            }

            // Disable cascade delete
            var foreignKeys = entityTypes
                .SelectMany(e => e.GetForeignKeys().Where(f => f.DeleteBehavior == DeleteBehavior.Cascade));
            foreach (var foreignKey in foreignKeys)
            {
                foreignKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        private static void SetIsDeletedQueryFilter<T>(ModelBuilder builder)
            where T : class, IDeletableEntity
        {
            builder.Entity<T>().HasQueryFilter(e => !e.IsDeleted);
        }

        // Applies configurations
        private void ConfigureUserIdentityRelations(ModelBuilder builder)
             => builder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

        private void ApplyAuditInfoRules()
        {
            var changedEntries = this.ChangeTracker
                .Entries()
                .Where(e =>
                    e.Entity is IAuditInfo &&
                    (e.State == EntityState.Added || e.State == EntityState.Modified));

            foreach (var entry in changedEntries)
            {
                var entity = (IAuditInfo)entry.Entity;
                if (entry.State == EntityState.Added && entity.CreatedOn == default)
                {
                    entity.CreatedOn = DateTime.UtcNow;
                }
                else
                {
                    entity.ModifiedOn = DateTime.UtcNow;
                }
            }
        }
    }
}
