using System.ComponentModel.DataAnnotations;

namespace IRS.Models
{
    public class StorageItem
    {
        [Key]
        public string ID { get; set; }
        public string Name { get; set; }
        public int Count {  get; set; }

        public StorageItem() { }
        public StorageItem(string id, string name, int count)
        {
            ID=id;
            Name = name;
            Count = count;
        }
    }
}
