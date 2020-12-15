using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryTracker.Models {
    public class Inventory {       
        ///<summary> Total money made from selling items from the inventory</summary>
        private double revenue = 0;

        ///<summary> List of all items in the inventory. </summary>
        private List<Item> items = new List<Item>();

        public double Revenue {
            get {
                return this.revenue;
            }
        }

        ///<summary> DESCRIPTION BLABLABLA </summary>

        public void LoadFile(string fileLocation)
        {
            throw new NotImplementedException("yeet");
        }

        ///<summary> DESCRIPTION BLABLABLA </summary>
        public void SaveFile(string fileLocation)
        {
            throw new NotImplementedException("yeet");
        }

        ///<summary> DESCRIPTION BLABLABLA </summary>
        public void Sort()
        {
            throw new NotImplementedException("yeet");
        }

        ///<summary> Returns a general report as string </summary>
        public string GenerateReport()
        {
            StringBuilder sb = new StringBuilder();

            for(int i = 0; i < this.items.Count; ++i) {
                sb.AppendLine(string.Format("Name: {0}\n Quantity: {1}\n Cost: {2}\n Value: {3}", 
                    items[i].Name, 
                    items[i].Quantity, 
                    items[i].Cost, 
                    items[i].Cost * items[i].Quantity
               ));
            }

            sb.AppendLine("\n--- Shopping List ---");
            for(int i = 0; i < this.items.Count; ++i) {
                if (items[i].Quantity < items[i].OptimalQuantity) 
                    sb.AppendLine(string.Format("Item: {0}, Quantity: {1}, Optimal Quantity: {2} \n", items[i].Name, items[i].Quantity, items[i].OptimalQuantity));
            }

            sb.AppendLine(string.Format("\nTotal Value: {0:c}\n", GetValue()));
            sb.AppendLine(string.Format("Revenue: {0:c}", revenue));

            return sb.ToString();
        }

        ///<summary> Functionality for creating an individual item </summary>
        public List<Item> CreateItem(Item newItem)
        {
            this.items.Add(newItem);
            return this.items;
        }

        ///<summary> Functionality for adding an individual item</summary>
        public void AddItem(string item) {
            for (int i = 0; i < this.items.Count; ++i) { 
                if (items[i].Name == item) { 
                    ++this.items[i].Quantity;
                    return;
                }
            }
        }

        ///<summary> Functionality for selling item(s) </summary>
        public List<Item> SellItems(List<Item> soldItems)
        {
            // Feels weird to have an array of instances of Item for just reducing the qty of Inventory items...
            // Maybe we can make a SoldItem that inherits Items. Only properties would be id and qty to remove.
            var idx = new Dictionary<string, int>();
            for(int i = 0; i < this.items.Count; ++i) 
                idx.Add(this.items[i].Name, i);

            for(int i = 0; i < soldItems.Count; ++i) {
                Item currItem = this.items[idx[soldItems[i].Name]];

                int diff = currItem.Quantity - soldItems[i].Quantity;
                revenue += (currItem.Cost) * diff;

                if(diff == 0) 
                    this.items.RemoveAt(idx[currItem.Name]);
                 else 
                    this.items[idx[currItem.Name]].Quantity = diff;
            }
            return this.items;
        }

        ///<summary> Returns the total value of all the items </summary>         
        public double GetValue() {
            double val = 0;
            for (int i = 0; i < this.items.Count; ++i) 
                val += this.items[i].Cost * this.items[i].Quantity;
            return val;
        }

        ///<summary> Returns an item according to a provided ID </summary>
        public Item GetItemFromID(int id) {
            foreach (Item item in items) {
                if (item.ID == id)
                    return item;
            }
            return null;
        }
    }
}
