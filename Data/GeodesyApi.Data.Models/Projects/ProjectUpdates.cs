namespace GeodesyApi.Data.Models.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Diagnostics.CodeAnalysis;

    public partial class ProjectUpdates
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ProjectUpdates()
        {
            Layers = new HashSet<Layers>();
            NonGeometricData = new HashSet<NonGeometricData>();
            ProjectMaps = new HashSet<ProjectMap>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? LastUpdate { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int PId { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Layers> Layers { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NonGeometricData> NonGeometricData { get; set; }

        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectMap> ProjectMaps { get; set; }

        public virtual Projects Projects { get; set; }
    }
}
