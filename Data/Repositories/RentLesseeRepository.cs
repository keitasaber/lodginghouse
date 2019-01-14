using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IRentLesseeRepository : IRepositoryBase<RentLessee>
    {

    }
    public class RentLesseeRepository : RepositoryBase<RentLessee>, IRentLesseeRepository
    {
        public RentLesseeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
