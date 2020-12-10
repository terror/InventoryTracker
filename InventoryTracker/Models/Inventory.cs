using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryTracker.Models {
    public class Inventory {
        ///<summary> Total cost of all items in the inventory. </summary>
        private double value = 0;

        ///<summary> Total money made from selling items from the inventory. </summary>
        private double revenue = 0;

        ///<summary> List of all items in the inventory. </summary>
        private List<Item> items;

        ///<summary> Generates an inventory with an empty list of items. </summary>
        public Inventory()
        {
            items = new List<Item>();
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

        ///<summary> DESCRIPTION BLABLABLA </summary>
        public string GenerateReport()
        {
            throw new NotImplementedException("yeet");
        }

        ///<summary> DESCRIPTION BLABLABLA </summary>
        public void AddItems(List<Item> newItems)
        {
            // just add to items list. dont forget update value
            throw new NotImplementedException("yeet");
        }

        ///<summary> DESCRIPTION BLABLABLA </summary>
        public void SellItems(List<Item> soldItems)
        {
            // just remove form list.dont forget update revenue
            throw new NotImplementedException("yeet");
        }
    }
}
