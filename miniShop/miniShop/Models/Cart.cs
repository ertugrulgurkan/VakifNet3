using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace miniShop.Models
{
    public class Cart
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public void ClearAll()
        {
            CartItems.Clear();
        }

        public void RemoveFromCart(int id)
        {
            CartItems.RemoveAll(p => p.Product.Id == id);
        }

        public decimal CartTotal()
        {
            return CartItems.Sum(p => (p.Product.Price.Value * 1 - (decimal)p.Product.Discount) * p.Quantity);
        }

        public void AddItem(Product product, int quantity)
        {
            var existing = CartItems.Find(c => c.Product.Id == product.Id);
            if (existing!=null)
            {
                existing.Quantity += quantity;
            }
            else
            {
                CartItems.Add(new CartItem { Product = product, Quantity = quantity });
            }
        }

    }
}
