using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Abstract
{
    public interface IChairRepository
    {
        IEnumerable<Chair> Chairs { get; }
        void SaveChair(Chair chair);
        Chair DeleteChair(int chairId);
    }
}
