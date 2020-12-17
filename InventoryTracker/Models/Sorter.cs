using System;
using System.Collections.Generic;
using System.Linq;


namespace InventoryTracker.Models {
    public static class Sorter {
        ///<summary> Sorts an item list based on a given property </summary>
        public static List<Item> sort(List<Item> items, Func<Item, IComparable> getProp) {
            if(items != null && items.Count > 0) 
                items = items.OrderBy(item => getProp(item)).ToList();
            return items;
        }

        ///<summary> Sorts an item list based on a given property in reverse </summary>
        public static List<Item> sortDesc(List<Item> items, Func<Item, IComparable> getProp) {
            if (items != null && items.Count > 0)
                items = items.OrderByDescending(item => getProp(item)).ToList();
            return items;
        }
    }
}