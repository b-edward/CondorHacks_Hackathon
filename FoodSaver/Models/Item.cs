using System;

namespace FoodSaver.Models
{
    /*
     *      This class will track each food item
     */
    public class Item
    {
        public string Id { get; set; }
        public string Food { get; set; }
        public string ExpirationDate { get; set; }
        public string ExpirationTime { get; set; }
    }
}               
  