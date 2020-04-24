using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Data.Models.Enums
{
    public enum NewsGroupType
    {
        [Display(Name = "Новини")]
        News = 1,

        [Display(Name = "Събития")]
        Event = 2,

        [Display(Name = "Препоръчано за студенти")]
        RecommendedForStudents = 3,
    }
}
