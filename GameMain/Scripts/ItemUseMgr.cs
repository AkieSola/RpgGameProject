using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class ItemUseMgr
    {
        public static void UseItem(Item item)
        {
            Actor actor = item.owner;
            if(item != null && item.num > 0) 
            {
                switch (item.dRItem.Type) 
                {
                    //消耗道具
                    case 1:
                        DRConsumeItem dRConsumeItem = GameEntry.DataTable.GetDataTable<DRConsumeItem>().GetDataRow(item.dRItem.SubId);
                        if(dRConsumeItem != null) 
                        {
                            switch (dRConsumeItem.SubId) 
                            {
                                //瞬时恢复类道具
                                case 1: 
                                    switch (dRConsumeItem.PropType)
                                    {
                                        case 1: //恢复生命值
                                            actor.RecoverHP(dRConsumeItem.Value);
                                            break;
                                        case 2: //恢复SP
                                            actor.ConsumeSP(-dRConsumeItem.Value);
                                            break;
                                    }
                                break;
                            }
                            item.num -= 1;
                            GameEntry.Event.Fire(null, RemoveItemEventArgs.Create(item));
                        }
                        
                        break;
                }
                
            }
        }
    }

    public class RemoveItemEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(RemoveItemEventArgs).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public List<Item> itemList;
        public int Type;

        public static RemoveItemEventArgs Create(Item item) 
        {
            RemoveItemEventArgs e = ReferencePool.Acquire<RemoveItemEventArgs>();
            e.itemList = new List<Item>() { item };
            e.Type = item.dRItem.Type;

            return e;
        }

        public override void Clear()
        {
            Type = 0;
            itemList.Clear();
            itemList = null;
        }
    }

    public class AddItemEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(RemoveItemEventArgs).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public List<Item> itemList;

        public static AddItemEventArgs Create(List<Item> itemList)
        {
            AddItemEventArgs e = ReferencePool.Acquire<AddItemEventArgs>();
            e.itemList = itemList;

            return e;
        }

        public override void Clear()
        {
            itemList.Clear();
            itemList = null;
        }
    }
}
