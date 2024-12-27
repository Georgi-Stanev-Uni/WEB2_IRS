using System.ComponentModel.DataAnnotations;

namespace IRS.Models
{
    public class Waiter
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public bool OnWork {  get; set; }
        public virtual List<Table> Sector { get; set; }
        public virtual List<Order> Orders { get; set; }

        public Waiter() 
        { 
            Sector= new List<Table>();
            Orders= new List<Order>();
        }

        public Waiter(string id, string name, bool onWork)
        {
            
            ID = id;
            Name = name;
            OnWork = onWork;
            Sector = new List<Table>();
            Orders=new List<Order>();
        }
    }
}
