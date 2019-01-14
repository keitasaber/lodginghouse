using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IAspNetUserRepository : IRepositoryBase<AspNetUser>
    {

    }
    public class AspNetUserRepository : RepositoryBase<AspNetUser>, IAspNetUserRepository
    {
        public AspNetUserRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
