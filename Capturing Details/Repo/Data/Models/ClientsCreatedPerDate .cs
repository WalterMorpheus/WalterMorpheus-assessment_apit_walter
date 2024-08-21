using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repo.Data.Models
{
    public class ClientsCreatedPerDate
    {
        public DateOnly DateRegistered { get; set; }
        public int UserCount { get; set; }
    }
}
