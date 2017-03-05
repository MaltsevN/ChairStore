using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using System.Data.Entity;

namespace Domain.Concrete
{
    public class EFDBContext: DbContext
    {
        public DbSet<Chair> Chairs { get; set; }
    }
}
