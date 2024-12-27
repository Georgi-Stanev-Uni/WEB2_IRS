using IRS.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IRS.Models
{
    public class Table
    {
        [Key]
        public string ID { get; set; }
        public TableStatus Status { get; set; }
        [ForeignKey("Order")]
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }

        public Table()
        {
        }
        public Table(string id,TableStatus status )
        {
            ID = id;
            Status = status;
            Order = new Order();
        }
    }
}
