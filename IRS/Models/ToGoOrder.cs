using System.ComponentModel.DataAnnotations;

namespace IRS.Models
{
    public class ToGoOrder
    {
        [Key]
        public string ID {  get; set; }
        public double Price {  get; set; }
        public string ReceiverName { get; set; }
        public string ReceiverAddress {  get; set; }
        public  int ReceiverPhoneNumber {  get; set; }
        public virtual List<Cook> Cooks { get; set; }
        public virtual List<Product> Products { get; set; }

        public ToGoOrder()
        {
            Cooks = new List<Cook>();
            Products = new List<Product>();

        }
        public ToGoOrder(string id,double price, string receierName, string receiverAddress, int receiverPhoneNumber)
        {
            ID = id;
            Price = price;
            ReceiverName = receierName;
            ReceiverAddress = receiverAddress;
            ReceiverPhoneNumber = receiverPhoneNumber;
            Cooks = new List<Cook>();
            Products = new List<Product>();

        }
    }
}
