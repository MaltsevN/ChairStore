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
        public void SaveChair(Chair chair)
        {
            if (chair.ChairId == 0)
                context.Chairs.Add(chair);
            else
            {
                Chair dbEntry = context.Chairs.Find(chair.ChairId);
                if (dbEntry != null)
                {
                    dbEntry.Name = chair.Name;
                    dbEntry.Description = chair.Description;
                    dbEntry.Price = chair.Price;
                    dbEntry.Category = chair.Category;
                    dbEntry.ImageData = chair.ImageData;
                    dbEntry.ImageMimeType = chair.ImageMimeType;
                }
            }
            context.SaveChanges();
        }
        public Chair DeleteChair(int chairId)
        {
            Chair dbEntry = context.Chairs.Find(chairId);
            if(dbEntry != null)
            {
                context.Chairs.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }
}
