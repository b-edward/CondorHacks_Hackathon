using System;

namespace FoodSaver.Models
{
    public class Item
    {
        public Guid ItemId { get; set; }
        public string Food { get; set; }
        public string ExpirationDate { get; set; }
    }
}