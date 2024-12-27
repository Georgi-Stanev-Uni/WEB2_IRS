using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRS.Models
{
    public class Order
    {
        [Key]
        public string ID { get; set; }
        public double Price { get; set; }

        [ForeignKey("Waiter")]
        public string WaiterID {  get; set; }

        [ForeignKey("Table")]
        public string TableID {  get; set; }
        public virtual List<Product> Products { get; set; }
        public virtual List<Cook> Cooks { get; set; }

        public Order()
        {
            Products = new List<Product>();
            Cooks = new List<Cook>();
        }

        public Order(string id, double price, string waiterID, string tableID)
        {
            ID = id;
            Price = price;
            WaiterID = waiterID;
            TableID = tableID;
            Products = new List<Product>();
            Cooks = new List<Cook>();
        }
    }
}
