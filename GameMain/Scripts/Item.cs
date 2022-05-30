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
        public Actor owner;

        public Item(DRItem dRItem, Actor actor, int num = 1)
        {
            id = dRItem.Id;
            this.num = num;
            this.dRItem = dRItem;
            this.owner = actor;
        }
    }
}
