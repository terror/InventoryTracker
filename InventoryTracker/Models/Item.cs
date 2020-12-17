using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryTracker.Models {
    public class Item {
        private static int id_counter = 1;
        private int quantity;
        private int amountSold;
        private string category;
        private string supplier;
        private string location;

        ///<summary> Constructor used only for JSON deserializer. </summary>
        public Item() {
            ID = id_counter++;
        }

        public Item(string name_, double cost_, int optimalQuantity_, string category_, string supplier_, string location_) {
            ID = id_counter++;
            quantity = 0;
            amountSold = 0;
            Name = name_;
            Cost = cost_;
            OptimalQuantity = optimalQuantity_;
            Category = category_;
            Supplier = supplier_;
            Location = location_;
        }

        public int ID { get; }

        public int Quantity {
            get { return quantity; }
            set {
                if (value < 0)
                    throw new ArgumentException("Quantity cannot be less than 0.");
                quantity = value;
            }
        }

        public int AmountSold {
            get { return amountSold; }
            set {
                if (value < 0)
                    throw new ArgumentException("Sold amount cannot be less than 0.");
                amountSold = value;
            }
        }

        public string Name { get; set; }

        public double Cost { get; set; }

        public int OptimalQuantity { get; set; }

        public string Category {
            get { return category; }
            set { category = string.IsNullOrWhiteSpace(value) ? "N/A" : value; }
        }
        public string Supplier {
            get { return supplier; }
            set { supplier = string.IsNullOrWhiteSpace(value) ? "N/A" : value; }
        }
        public string Location {
            get { return location; }
            set { location = string.IsNullOrWhiteSpace(value) ? "N/A" : value; }
        }

        public void UpdateDetails(string name_, double cost_, int optimalQuantity_, string category_, string supplier_, string location_, int quantity_) {
            Name = name_;
            Cost = cost_;
            OptimalQuantity = optimalQuantity_;
            Category = category_;
            Supplier = supplier_;
            Location = location_;
            Quantity = quantity_;
        }

        public void Sell(int amount) {
            Quantity -= amount;
            AmountSold += amount;
        }

        public double GetValue() {
            return Cost * Quantity;
        }

        public double GetRevenue() {
            return Cost * AmountSold;
        }

        public static int NewestID() {
            return id_counter;
        }

        public static void ResetIDCounter() {
            id_counter = 1;
        }

        public static void CheckProperties(string name_, string cost_, string optimalQuantity_) {
            if (string.IsNullOrWhiteSpace(name_))
                throw new ArgumentException("Name cannot be empty.");
            if (!double.TryParse(cost_, out double parsedCost) || parsedCost < 0)
                throw new ArgumentException("Cost must be a valid double and cannot be less than 0.");
            if (Math.Round(parsedCost, 2) != parsedCost)
                throw new ArgumentException("Cost can only have up to two numbers after the decimal point.");
            if (!int.TryParse(optimalQuantity_, out int parsedOptimalQuantity) || parsedOptimalQuantity < 0)
                throw new ArgumentException("Optimal Quantity a must be a valid integer and >= 0.");
        }

        public static void CheckProperties(string name_, string cost_, string optimalQuantity_, string quantity_) {
            CheckProperties(name_, cost_, optimalQuantity_);
            if (!int.TryParse(quantity_, out int parsedQuantity) || parsedQuantity < 0)
                throw new ArgumentException("Quantity must be a valid integer and cannot be less than 0.");
        }
    }
}
