using Microsoft.EntityFrameworkCore;
using Repo.Data;
using Repo.Data.Models;
using Repo.Interface;
using System.Collections.Generic;
using static System.Runtime.InteropServices.JavaScript.JSType;

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

            var list = _context.Location.Select(x => x.Id).ToList();

            if (list.Any())
            {
                foreach (var locationId in list)
                {
                    var count = _context.SystemUser.Where(x => x.LocationId == locationId).Sum(x => x.Number);
                    usersPerLocation.Add(new UsersPerLocation { Location = _context.Location.FirstOrDefault(x=>x.Id == locationId)!.Name, UserCount = count });
                }
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
                    createdPerDates.Add(new ClientsCreatedPerDate { DateRegistered = date,UserCount = count });
                }
            }

            return createdPerDates;
        }
    }
}
