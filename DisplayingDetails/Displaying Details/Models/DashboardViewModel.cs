using Repo.Data.Models;

namespace Displaying_Details.Models
{
    public class DashboardViewModel
    {
        public int MaxUserCount { get; set; }
        public List<UsersPerLocation>? UsersPerLocations { get; set; }
        public List<ClientsCreatedPerDate>? ClientsCreatedPerDate { get; set; }
    }
}
