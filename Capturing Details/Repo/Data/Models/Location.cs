using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repo.Data.Models
{
    [Table("Locations")]
    public class Location
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
    }
}
