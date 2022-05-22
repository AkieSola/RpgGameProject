using GameFramework;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class ItemUseMgr
    {
        public static void UseItem(Item item, Actor actor)
        {
            if(item != null && item.num > 0) 
            {
                switch (item.dRItem.Type) 
                {
                    case 1:
                        DRConsumeItem dRConsumeItem = GameEntry.DataTable.GetDataTable<DRConsumeItem>().GetDataRow(item.dRItem.SubId);
                        if(dRConsumeItem != null) 
                        {
                            switch (dRConsumeItem.PropType) 
                            {
                                case 1: //»Ö¸´ÉúÃüÖµ
                                    actor.ActorData.HP += dRConsumeItem.Value;
                                    break;
                                case 2: //»Ö¸´SP
                                    actor.ActorData.SP += dRConsumeItem.Value;
                                    break;
                            }
                        }

                        break;
                }
                
            }
        }
    }

    public class UpdateItem : GameFrameworkEventArgs
    {
        public override void Clear()
        {
            throw new System.NotImplementedException();
        }
    }
}
