using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryTracker.Models {
    class Item {
        private int quantity;
        private double cost;
        private int optimalQuantity;

        public Item(int quantity, double cost, int optimalQuantity, string category, string supplier, string location) {
            this.quantity = quantity;
            this.cost = cost;
            this.optimalQuantity = optimalQuantity;
            Category = category;
            Supplier = supplier;
            Location = location;
        }

        public int Quantity {
            get { return quantity; }
            set {
                if (value < 0) 
                    throw new ArgumentException("Quantity cannot be less than 0.");
                quantity = value;
            }
        }

        public double Cost {
            get { return cost; }
            set {
                if (value < 0)
                    throw new ArgumentException("Cost cannot be less than 0.");
                cost = value;
            }
        }

        public int OptimalQuantity {
            get { return optimalQuantity; }
            set {
                if (value < 0) 
                    throw new ArgumentException("Optimal Quantity cannot be less than 0.");
                quantity = value;
            }
        }

        public string Supplier { get; set; }
        public string Category { get; set; }
        public string Location { get; set; }
    }
}
