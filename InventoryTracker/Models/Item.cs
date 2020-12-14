using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryTracker.Models
{
    public class Item
    {
        private static int id_counter = 1;
        private int id;
        private string name;
        private double cost;
        private int optimalQuantity;
        private int quantity;

        public Item(string name_, double cost_, int optimalQuantity_, string supplier_, string category_, string location_)
        {
            id = id_counter++;
            quantity = 0;
            name = name_;
            cost = cost_;
            optimalQuantity = optimalQuantity_;
            Supplier = supplier_;
            Category = category_;
            Location = location_;
        }

        public static int NewestID()
        {
            return id_counter;
        }

        public static void CheckProperties(string name_, string cost_, string optimalQuantity_)
        {
            if (name_ == "")
                throw new ArgumentException("Name cannot be empty.");
            if (!double.TryParse(cost_, out double parsedCost) || parsedCost < 0)
                throw new ArgumentException("Cost must be a valid double and cannot be less than 0.");
            if (!int.TryParse(optimalQuantity_, out int parsedOptimalQuantity) || parsedOptimalQuantity < 0)
                throw new ArgumentException("Optimal Quantity a must be a valid integer and >= 0.");
        }


        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; }
        }

        public string Name
        {
            get { return name; }
        }

        public double Cost
        {
            get { return cost; }
        }

        public int OptimalQuantity
        {
            get { return optimalQuantity; }
        }


        public string Supplier { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
    }
}
