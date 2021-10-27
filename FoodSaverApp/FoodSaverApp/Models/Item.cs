using System;

namespace FoodSaverApp.Models
{
    public class Item
    {

        public int id { get; set; }
        public string name { get; set; }
        public string expDate { get; set; }


        public Item(int id, string name, string expDate)
        {
            this.id = id;
            this.name = name;
            this.expDate = expDate;


        }
    }
}