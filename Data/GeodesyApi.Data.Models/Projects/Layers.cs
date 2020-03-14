namespace GeodesyApi.Data.Models.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Layers
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Key]
        [StringLength(50)]
        public string LayerId { get; set; }

        [StringLength(50)]
        public string LayerName { get; set; }

        [StringLength(1050)]
        public string Description { get; set; }

        [StringLength(50)]
        public string BBox { get; set; }

        [StringLength(50)]
        public string Crs { get; set; }

        [StringLength(50)]
        public string Source { get; set; }

        public int MId { get; set; }

        public int Scale { get; set; }

        public int UId { get; set; }

        public virtual ProjectUpdates ProjectUpdates { get; set; }
    }
}
