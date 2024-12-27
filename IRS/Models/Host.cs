using System.ComponentModel.DataAnnotations;

namespace IRS.Models
{
    public class Host
    {
        [Key]
        public string ID {  get; set; }
        public string Name { get; set; }
        public virtual List<Table> Sector {  get; set; }
        public  virtual List<ToGoOrder>ToGoOrders { get; set; }

        public Host()
        {
            Sector=new List<Table>();
            ToGoOrders=new List<ToGoOrder>();
        }
        public Host(string id, string name)
        {
            ID = id; 
            Name = name;
            Sector = new List<Table>();
            ToGoOrders= new List<ToGoOrder>();
        }
    }
}
