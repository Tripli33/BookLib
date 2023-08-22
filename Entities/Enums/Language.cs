using System.ComponentModel.DataAnnotations;

namespace Entities.Enums;

public enum Language
{
    [Display(Name = "Without language")]
    WithoutLanguage,
    Russian,
    English
}