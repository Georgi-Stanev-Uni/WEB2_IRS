using System.ComponentModel.DataAnnotations;

namespace IRS.Models
{
    public class Manager
    {
        [Key]
        public string ID {  get; set; }
        public string Name { get; set; }
        public virtual List<Waiter> Waiters { get; set; }
        public virtual List<Cook> Cooks { get; set; }
        public virtual List<Host> Hosts { get; set; }
        public virtual List<Deliverer> Deliverers { get; set; }

        public Manager()
        {
            Waiters = new List<Waiter>();
            Cooks = new List<Cook>();
            Hosts = new List<Host>();
            Deliverers = new List<Deliverer>();
        }

        public Manager( string id, string name)
        {
            ID = id;
            Name = name;
            Waiters = new List<Waiter>();
            Cooks = new List<Cook>();
            Hosts = new List<Host>();
            Deliverers= new List<Deliverer>();
        }
    }
}
