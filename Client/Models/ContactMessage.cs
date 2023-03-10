using System.ComponentModel.DataAnnotations;

namespace Client.Models;


public class ContactMessage
{
    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string FirstName { get; set; } = String.Empty;

    [Required]
    [MinLength(1)]
    [MaxLength(50)]
    public string LastName { get; set; } = String.Empty;

    [Required] [EmailAddress] public string Email { get; set; } = String.Empty;
    [Required]
    [MinLength(20, ErrorMessage = "Message cannot be shorter than 20 characters")]
    [MaxLength(500, ErrorMessage = "Message cannot be longer than 500 characters")]
    public string Message { get; set; } = String.Empty;
}