namespace GeodesyApi.Data.Models.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("ProjectMap")]
    public partial class ProjectMap
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string ProjectId { get; set; }

        [Required]
        [StringLength(50)]
        public string MapName { get; set; }

        [StringLength(50)]
        public string Crs { get; set; }

        public int Scale { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string BBox { get; set; }

        [Column(TypeName = "text")]
        public string Description { get; set; }

        public int PId { get; set; }

        [StringLength(200)]
        public string MapFile { get; set; }

        public int UId { get; set; }

        public virtual ProjectUpdates ProjectUpdates { get; set; }
    }
}
