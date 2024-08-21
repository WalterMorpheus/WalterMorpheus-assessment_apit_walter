using Repo.Data.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Capturing_Details.Models
{
    public class CaptureViewModel
    {
        [Required(ErrorMessage = "Name is required.")]
        public string? ClienName { get; set; }
        [Required(ErrorMessage = "The Date of Registration is required.")]
        [DataType(DataType.Date)]
        public DateTime DateRegistered { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "The number is required.")]
        public int Number { get; set; }
        [Required(ErrorMessage = "The location is required.")]
        public int LocationId { get; set; }
        public List<Location>? Locations { get; set; }
        public NotificationViewModel? Notification { get; set; }
    }
}

