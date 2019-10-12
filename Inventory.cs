using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RPGame
{
    class Inventory
    {
        public List<Slot> InventoryArray { get; set; }

        public Inventory(int capacity)
        {
            if (capacity > 0)
            {
                InventoryArray = new List<Slot>();
                for (int i = 0; i < capacity; i++)
                {
                    InventoryArray.Add(new Slot());
                }
            }
        }

        public bool AddItem(Item item, int count)
        {
            bool added = false;

            if (item != null && count > 0)
            {
                for (int i = 0; i < InventoryArray.Count; i++)
                {
                    if (InventoryArray[i].item == null)
                    {
                        InventoryArray[i].item = item;
                        InventoryArray[i].count = count;
                        added = true;
                        break;
                    }
                    else
                    if (InventoryArray[i].item == item && item.stack)
                    {
                        InventoryArray[i].count += count;
                        added = true;
                        break;
                    }
                }
            }
            return added;
        }

        /*public bool AddItem(int id, int count)
        {
            bool added = false;
            
            if (id >= 0 && id < Game. )

            return added;
        }*/

        public class Slot
        {

            public Item item { get; set; }
            public int count { get; set; }

        }
    }
}
