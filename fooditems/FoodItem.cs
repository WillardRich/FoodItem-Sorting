using System;
using System.Collections.Generic;
using System.Text;
namespace Mission__3_Assignment
{
    public class FoodItem
    {
        public string FoodName;
        public string Category;
        public int Quantity;
        public string ExpirationDate;
    
    
     public FoodItem(string Name, string Category, int Quantity, string Date)

        {
            this.FoodName = Name;
            this.Category = Category;
            this.Quantity = Quantity;
            this.ExpirationDate = Date;
        }
    }
}
