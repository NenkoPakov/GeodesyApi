namespace GeodesyApi.Data.Models.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("HistorycalData")]
    public partial class HistorycalData
    {
        public int id { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int UId { get; set; }

        [Required]
        [StringLength(50)]
        public string ObjectType { get; set; }

        [Required]
        [StringLength(50)]
        public string ObjectName { get; set; }

        public int ObjectId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string ObjectContent { get; set; }

        public bool IsParentActual { get; set; }

        public int ParentId { get; set; }

        [Required]
        [StringLength(50)]
        public string ParentObject { get; set; }
    }
}
