using Repo.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Interface
{
    public interface IUserRepository
    {
        List<UsersPerLocation> GetUsersPerLocation();
        List<ClientsCreatedPerDate> ClientsCreatedPerDate();
    }
}
