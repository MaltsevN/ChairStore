using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Abstract;
using Domain.Entities;
using Domain.Concrete;

namespace Domain.Concrete
{
    public class EFChairRepository : IChairRepository
    {
        EFDBContext context = new EFDBContext();
        public IEnumerable<Chair> Chairs
        {
            get
            {
                return context.Chairs;
            }
        }
    }
}
