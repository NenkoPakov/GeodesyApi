namespace GeodesyApi.Data.Models.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Stable")]
    public partial class Stable
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string DataTable { get; set; }

        [Column(TypeName = "text")]
        public string Geometry { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string KeyValue { get; set; }

        public int ObjectId { get; set; }
    }
}
