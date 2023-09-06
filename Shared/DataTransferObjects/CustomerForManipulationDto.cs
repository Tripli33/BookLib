using System.ComponentModel.DataAnnotations;
using Entities.Models;

namespace Shared.DataTransferObjects;

public abstract class CustomerForManipulationDto
{
    [Required(ErrorMessage = "Customer first name is a required field.")]
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "The first name is can't contain special symbols")]
    [MaxLength(15, ErrorMessage = "Maximum length for the customer first name is 15 characters.")]
    [MinLength(3, ErrorMessage = "Minimum length for the customer first name is 15 characters.")]
    public string FirstName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Customer last name is a required field.")]
    [RegularExpression("^[a-zA-Z0-9]*$", ErrorMessage = "The last name is can't contain special symbols")]
    [MaxLength(15, ErrorMessage = "Maximum length for the customer last name is 15 characters.")]
    [MinLength(3, ErrorMessage = "Minimum length for the customer last name is 15 characters.")]
    public string LastName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Customer email is a required field.")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; } = string.Empty;
    [Required(ErrorMessage = "Customer contact number is a required field.")]
    [DataType(DataType.PhoneNumber)]
    public string ContactNumber { get; set; } = String.Empty;
    [Required(ErrorMessage = "Customer contact number is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the customer last name is 15 characters.")]
    [MinLength(7, ErrorMessage = "Minimum length for the customer last name is 15 characters.")]
    public string Address { get; set; } = string.Empty;
}