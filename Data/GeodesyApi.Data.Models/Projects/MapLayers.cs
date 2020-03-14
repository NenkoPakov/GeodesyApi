namespace GeodesyApi.Data.Models.Projects
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class MapLayers
    {
        public int Id { get; set; }

        public int MId { get; set; }

        public int LId { get; set; }
    }
}
