using Data.Infrastructure;
using Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repositories
{
    public interface IPersonPerRoomRepository: IRepositoryBase<PersonPerRoom>
    {

    }
    public class PersonPerRoomRepository : RepositoryBase<PersonPerRoom>, IPersonPerRoomRepository
    {
        public PersonPerRoomRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
