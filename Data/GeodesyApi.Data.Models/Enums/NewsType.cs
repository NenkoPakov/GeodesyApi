using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Data.Models.Enums
{
    public enum NewsType
    {
        [Display(Name = "Закупуване на нови инстрименти")]
        BuyingNewTools = 1,

        [Display(Name = "Срещи")]
        Meetings = 2,

        [Display(Name = "Практики")]
        Practice = 3,
    }
}
