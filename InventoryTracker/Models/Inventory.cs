using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.IO;
using System.Linq;

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
            revenueMadeFromDeletedItems = 0;
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

        ///<summary> Returns a general report as a string </summary>
        public string GenerateReport() {
            StringBuilder sb = new StringBuilder();
            if (items.Count == 0) {
                sb.AppendLine("Inventory is empty!\n");
            } else {
                for (int i = 0; i < items.Count; ++i) {
                    sb.AppendLine(items[i].Name);
                    sb.AppendLine("↳ " + items[i].Quantity + " in stock");
                    sb.AppendLine("↳ " + items[i].Cost.ToString("C") + " per unit");
                    sb.AppendLine("↳ Value of " + (items[i].Cost * items[i].Quantity).ToString("C") + "\n");
                }
            }
            sb.AppendLine(string.Format("Total Value: {0:C}", GetTotalValue()));
            sb.AppendLine(string.Format("Total Revenue: {0:C}", GetTotalRevenue()));
            return sb.ToString();
        }

        ///<summary> Returns a quantitative analysis report as a string </summary>
        public string QuantityAnalysis() {
            if (items.Count == 0) {
                return "Inventory is empty!";
            }

            StringBuilder sbTotal = new StringBuilder();
            StringBuilder sbOverOptimal = new StringBuilder();
            StringBuilder sbOptimal = new StringBuilder();
            StringBuilder sbUnderOptimal = new StringBuilder();
            bool hasOverOptimal = false;
            bool hasOptimal = false;
            bool hasUnderOptimal = false;

            sbOverOptimal.AppendLine("-- Items with quantity above their optimal quantity --");
            sbOptimal.AppendLine("-- Items with quantity equal to their optimal quantity --");
            sbUnderOptimal.AppendLine("-- Items with quantity under their optimal quantity --");

            for (int i = 0; i < items.Count; ++i) {
                if (items[i].Quantity > items[i].OptimalQuantity) {
                    hasOverOptimal = true;
                    sbOverOptimal.AppendLine(items[i].Name);
                    sbOverOptimal.AppendLine("↳ Quantity: " + items[i].Quantity);
                    sbOverOptimal.AppendLine("↳ Optimal Quantity: " + items[i].OptimalQuantity);
                    sbOverOptimal.AppendLine("↳ Difference: " + (items[i].Quantity - items[i].OptimalQuantity) + "\n");
                } else if (items[i].Quantity < items[i].OptimalQuantity) {
                    hasUnderOptimal = true;
                    sbUnderOptimal.AppendLine(items[i].Name);
                    sbUnderOptimal.AppendLine("↳ Quantity: " + items[i].Quantity);
                    sbUnderOptimal.AppendLine("↳ Optimal Quantity: " + items[i].OptimalQuantity);
                    sbUnderOptimal.AppendLine("↳ Difference: " + (items[i].Quantity - items[i].OptimalQuantity) + "\n");
                } else {
                    hasOptimal = true;
                    sbOptimal.AppendLine(items[i].Name);
                    sbOptimal.AppendLine("↳ Quantity: " + items[i].Quantity);
                    sbOptimal.AppendLine("↳ Optimal Quantity: " + items[i].OptimalQuantity);
                    sbOptimal.AppendLine("↳ Difference: " + (items[i].Quantity - items[i].OptimalQuantity) + "\n");
                }
            }

            if (hasOverOptimal)
                sbTotal.Append(sbOverOptimal + "\n");
            if (hasOptimal)
                sbTotal.Append(sbOptimal + "\n");
            if (hasUnderOptimal)
                sbTotal.Append(sbUnderOptimal);
            return sbTotal.ToString();
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

        ///<summary> Sort inventory items and return them </summary>
        public List<Item> SortItems(bool asc, Func<Item, IComparable> getProp) {
            return asc ? Sorter.sort(items, getProp) : Sorter.sortDesc(items, getProp);
        }
    }
}