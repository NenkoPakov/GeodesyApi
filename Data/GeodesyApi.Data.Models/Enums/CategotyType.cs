using System.ComponentModel.DataAnnotations;

namespace GeodesyApi.Data.Models.Enums
{
    public enum CategotyType
    {
        [Display(Name = "Материали и тестове")]
        MaterialsAndTests = 1,

        [Display(Name = "Новини и събития")]
        News = 2,

        [Display(Name = "Контакти")]
        Contacts = 3,
    }
}