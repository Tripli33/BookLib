using System.ComponentModel.DataAnnotations;

namespace Entities.Enums;

public enum Genre
{
    [Display(Name = "Without genre")]
    WithoutGenre,
    Action,
    Adventure,
    Comedy,
    Drama,
    Fantasy,
    Horror,
    Mystery,
    Romance,
    [Display(Name = "Science fiction")]
    ScienceFiction,
    Thriller,
    Western
}