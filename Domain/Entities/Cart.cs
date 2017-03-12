using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class CartLine
    {
        public Chair Chair { get; set; }
        public int Quantity { get; set; }
    }
    public class Cart
    {
        private List<CartLine> lineCollection = new List<CartLine>();
        public void AddItem(Chair chair, int quantity)
        {
            CartLine line = lineCollection
                .Where(g => g.Chair.ChairId == chair.ChairId)
                .FirstOrDefault();

            if (line == null)
            {
                lineCollection.Add(new CartLine
                {
                    Chair =chair,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Chair chair)
        {
            lineCollection.RemoveAll(l => l.Chair.ChairId == chair.ChairId);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Chair.Price * e.Quantity);

        }
        public void Clear()
        {
            lineCollection.Clear();
        }

        public IEnumerable<CartLine> Lines
        {
            get { return lineCollection; }
        }
    }
}
