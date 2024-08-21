using System.Linq;
using System.Text.Json;
using Repo.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Repo.Data.Seed
{
    public class Seed
    {
        public static async Task Initial(ClientDbContext context)
        {
            await Locations(context);
            await DummyUsers(context);
        }

        private static async Task Locations(ClientDbContext context)
        {
            if (context.Location.Any()) return;

            var locations = new List<Location> 
            {
                new Location {Name = "Kemptopn Park"},
                new Location {Name = "Midrand"},
                new Location {Name = "Pretoria"},
                new Location {Name = "Germiston"}
            };

            foreach (var location in locations)
            {
                context.Location.Add(location);
            }

            await context.SaveChangesAsync();
        }

        private static async Task DummyUsers(ClientDbContext context)
        {
            if (context.SystemUser.Any(x=>x.ClienName == "mtn" || x.ClienName == "cellc")) return;

            var users = new List<SystemUser>
            {
                new SystemUser { ClienName = "mtn",Number = 15,LocationId = 1 ,DateRegistered = DateOnly.FromDateTime(DateTime.Now.AddDays(-32))},
                new SystemUser { ClienName = "cellc",Number = 100,LocationId = 3 ,DateRegistered = DateOnly.FromDateTime(DateTime.Now)}
            };

            foreach (var user in users!)
            {
                context.SystemUser.Add(user);
            }

            await context.SaveChangesAsync();
        }
    }
}
