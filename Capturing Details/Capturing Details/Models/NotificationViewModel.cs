using System.ComponentModel.DataAnnotations;

namespace Capturing_Details.Models
{
    public class NotificationViewModel
    {
        [Required]
        public bool Show { get; set; } = false;
        [Required]
        public string? Title { get; set; } = string.Empty;
        [Required]
        public string? Message { get; set; } = string.Empty;
    }
}
