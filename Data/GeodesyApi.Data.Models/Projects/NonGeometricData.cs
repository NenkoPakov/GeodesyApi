namespace GeodesyApi.Data.Models.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("NonGeometricData")]
    public partial class NonGeometricData
    {
        public int Id { get; set; }

        [Required]
        [StringLength(1050)]
        public string Uri { get; set; }

        [Required]
        [StringLength(1050)]
        public string Description { get; set; }

        [StringLength(50)]
        public string FileName { get; set; }

        [StringLength(50)]
        public string Format { get; set; }

        [StringLength(50)]
        public string Source { get; set; }

        public int ProjectId { get; set; }

        public int UId { get; set; }

        public virtual Projects Projects { get; set; }

        public virtual ProjectUpdates ProjectUpdates { get; set; }
    }
}
