using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;

namespace InventoryTracker.Models {
    public class Inventory {
        ///<summary> List of all items in the inventory. </summary>
        private List<Item> items = new List<Item>();

        ///<summary> Variable storing all revenue made from items that are no longer in item list. </summary>
        private double revenueMadeFromDeletedItems = 0;

        ///<summary> Functionality for creating an individual item. </summary>
        public List<Item> CreateItem(Item newItem) {
            this.items.Add(newItem);
            return this.items;
        }

        ///<summary> Functionality for deleting an individual item form the inventory. </summary>
        public void DeleteItem(Item item) {
            revenueMadeFromDeletedItems += item.GetRevenue();
            items.Remove(item);
        }

        ///<summary> Functionality for emptying the item list. </summary>
        public void Reset() {
            Item.ResetIDCounter();
            items.Clear();
        }

        ///<summary> Reset inventory and load item list from provided JSON file. </summary>
        public List<Item> LoadFromFile(string fileLocation) {
            Reset();
            items = JsonSerializer.Deserialize<List<Item>>(File.ReadAllText(fileLocation));
            return items;
        }

        ///<summary> Write item list into provided file with JSON format. </summary>
        public void SaveToFile(string fileLocation) {
            File.WriteAllText(fileLocation, JsonSerializer.Serialize(items));
        }

        ///<summary> Returns a general report as string </summary>
        public string GenerateReport() {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < this.items.Count; ++i) {
                sb.AppendLine(string.Format("Name: {0}\n Quantity: {1}\n Cost: {2}\n Value: {3}",
                    items[i].Name,
                    items[i].Quantity,
                    items[i].Cost,
                    items[i].Cost * items[i].Quantity
               ));
            }

            sb.AppendLine("\n--- Shopping List ---");
            for (int i = 0; i < this.items.Count; ++i) {
                if (items[i].Quantity < items[i].OptimalQuantity)
                    sb.AppendLine(string.Format("Item: {0}, Quantity: {1}, Optimal Quantity: {2} \n", items[i].Name, items[i].Quantity, items[i].OptimalQuantity));
            }

            sb.AppendLine(string.Format("\nTotal Value: {0:c}\n", GetTotalValue()));
            sb.AppendLine(string.Format("Revenue: {0:c}", GetTotalRevenue()));

            return sb.ToString();
        }

        ///<summary> Returns an item according to a provided ID </summary>
        public Item GetItemFromID(int id) {
            foreach (Item item in items) {
                if (item.ID == id)
                    return item;
            }
            return null;
        }

        ///<summary> Return cumulative cost of every item in the inventory. </summary>
        public double GetTotalValue() {
            double totalValue = 0;
            foreach (Item item in items) {
                totalValue += item.GetValue();
            }
            return totalValue;
        }

        ///<summary> Return cumulative money made from sold items in the inventory. </summary>
        public double GetTotalRevenue() {
            double totalValue = revenueMadeFromDeletedItems;
            foreach (Item item in items) {
                totalValue += item.GetRevenue();
            }
            return totalValue;
        }

        ///<summary> Returns whether inventory contains any item with a quantity above 0. </summary>
        public bool IsEmpty() {
            foreach (Item item in items) {
                if (item.Quantity > 0) {
                    return false;
                }
            }
            return true;
        }
    }
}