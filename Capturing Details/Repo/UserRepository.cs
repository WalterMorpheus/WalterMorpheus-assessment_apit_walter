using Microsoft.EntityFrameworkCore;
using Repo.Data;
using Repo.Data.Models;
using Repo.Interface;
using System.Collections.Generic;

namespace Repo
{
    public class UserRepository : IUserRepository
    {
        public ClientDbContext _context { get; }

        public UserRepository(ClientDbContext context)
        {
            _context = context;
        }
        public List<UsersPerLocation> GetUsersPerLocation()
        {
            var usersPerLocation = new List<UsersPerLocation>();

            var list = from locations in _context.Location
                       select new
                       {
                           Location = locations.Name,
                           UserCount = _context.SystemUser.Where(x => x.LocationId == locations.Id)
                                                         .Select(x => x.Number)
                                                         .FirstOrDefault()
                       };

            if (list.Any())
            {
                usersPerLocation = list.Select(item => new UsersPerLocation { Location = item.Location, UserCount = item.UserCount }).ToList();
            }

            return usersPerLocation;
        }

        public List<ClientsCreatedPerDate> ClientsCreatedPerDate()
        {
            var createdPerDates = new List<ClientsCreatedPerDate>();

            var list = _context.SystemUser.Select(x => x.DateRegistered).Distinct().ToList();

            if (list.Any()) 
            {
                foreach (var date in list)
                {
                    var count = _context.SystemUser.Where(x => x.DateRegistered == date).Sum(x=>x.Number);
                }
            }

            return createdPerDates;
        }
    }
}
