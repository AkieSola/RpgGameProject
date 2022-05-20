using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class Item
    {
        public int id;
        public int num;
        public DRItem dRItem;

        public Item(DRItem dRItem, int num = 1) 
        {
            id = dRItem.Id;
            this.num = num;
            this.dRItem = dRItem;
        }
    }
}
