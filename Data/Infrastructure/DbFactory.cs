using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Infrastructure
{
    public class DbFactory : IDbFactory
    {
        private LodgingHouseDbContext dbContext;

        public void Dispose()
        {
            if (dbContext != null)
            {
                dbContext.Dispose();
            }
        }

        public LodgingHouseDbContext Init()
        {
            return dbContext ?? (dbContext = new LodgingHouseDbContext());
        }
    }
}
