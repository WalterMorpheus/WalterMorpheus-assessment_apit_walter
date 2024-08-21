using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo.Data.Models
{
    [Table("SystemUsers")]
    public class SystemUser
    {
        public int Id { get; set; }
        [Required]
        public string? ClienName { get; set; }
        [Required]
        public DateOnly DateRegistered { get; set; }
        [Required]
        public int Number { get; set; }
        [ForeignKey("LocationId")]
        public int LocationId { get; set; }
        public Location? Location { get; set; }
    }
}
