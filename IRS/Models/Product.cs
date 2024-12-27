using IRS.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace IRS.Models
{
    public class Product
    {

        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }
        public double Price {  get; set; }
        public ProductAvailability Availability { get; set; }
        public virtual List<StorageItem> Items { get; set; }

        public Product()
        {
            Items = new List<StorageItem>();
        }
        public Product( string id, string name, string discripion,string type, double price, ProductAvailability availability)
        {
            ID = id;
            Name = name;
            Description = discripion;
            Type = type;
            Price = price;
            Availability = availability;
            Items = new List<StorageItem>();
        }

    }
}
