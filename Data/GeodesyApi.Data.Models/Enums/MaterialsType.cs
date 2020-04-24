using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GeodesyApi.Data.Models.Enums
{
    public enum MaterialsType
    {
        [Display(Name = "Лекции")]
        Lab = 1,

        [Display(Name = "Упражнения")]
        Exercise = 2,

        [Display(Name = "Тестове")]
        Test = 3,

        [Display(Name = "Изисквания за заверка")]
        CertificationRequirements = 4,

        [Display(Name = "Публикации")]
        Publication = 5,

        [Display(Name = "Конспекти")]
        Questionnaire = 6,

        [Display(Name = "Информационни")]
        Information = 7,

        [Display(Name = "Курсови задачи")]
        Coursework = 8,

        [Display(Name = "Други")]
        Others = 9,



    }
}
