using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface ILessorRepository : IRepositoryBase<Lessor>
    {

    }
    public class LessorRepository : RepositoryBase<Lessor>, ILessorRepository
    {
        public LessorRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
