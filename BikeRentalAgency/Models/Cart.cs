using BikeAgencyLibrary;
using System.Collections.Generic;
using System.Linq;

namespace SportsStore.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();
        public virtual void AddItem(Bike product, int quantity)
        {
            CartLine line = Lines
            .Where(p => p.Bike.BikeId == product.BikeId)
            .FirstOrDefault();
            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Bike = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Bike product) =>
        Lines.RemoveAll(l => l.Bike.BikeId == product.BikeId);
        public decimal ComputeTotalValue() =>
        Lines.Sum(e => e.RentalRate * e.Quantity);
        public virtual void Clear() => Lines.Clear();
    }
    public class CartLine
    {
        public int CartLineID { get; set; }
        public Bike Bike { get; set; }
        public int Quantity { get; set; }
        public decimal RentalRate { get; set; }
    }
}