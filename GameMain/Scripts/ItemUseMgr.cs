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
                            GameEntry.Event.Fire(null, UpdateItemEventArgs.Create(item));
                        }
                        
                        break;
                }
                
            }
        }
    }

    public class UpdateItemEventArgs : GameEventArgs
    {
        public static readonly int EventId = typeof(UpdateItemEventArgs).GetHashCode();
        public override int Id
        {
            get
            {
                return EventId;
            }
        }

        public Item item;

        public static UpdateItemEventArgs Create(Item item) 
        {
            UpdateItemEventArgs e = ReferencePool.Acquire<UpdateItemEventArgs>();
            e.item = item;
            return e;
        }

        public override void Clear()
        {
            item = null;
        }
    }
}
