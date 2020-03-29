using GeodesyApi.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Web.ViewModels
{
    public class TestViewModel
    {
        [Range(1, int.MaxValue, ErrorMessage = "Select a correct license")]
        public MaterialsType MaterialsType { get; set; }

    }
}
