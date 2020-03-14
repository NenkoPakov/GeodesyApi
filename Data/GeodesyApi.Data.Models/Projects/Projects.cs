namespace GeodesyApi.Data.Models.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Projects
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Projects()
        {
            NonGeometricData = new HashSet<NonGeometricData>();
            ProjectUpdates = new HashSet<ProjectUpdates>();
        }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectId { get; set; }

        [StringLength(50)]
        public string ParentId { get; set; }

        [StringLength(50)]
        public string ProjectDatabase { get; set; }

        [Column(TypeName = "date")]
        public DateTime BeginDate { get; set; }

        public int OwnerId { get; set; }

        public bool Access { get; set; }

        [Required]
        public string Description { get; set; }

        public bool Active { get; set; }

        [Column(TypeName = "text")]
        public string GeoJson { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NonGeometricData> NonGeometricData { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ProjectUpdates> ProjectUpdates { get; set; }
    }
}
