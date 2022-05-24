using GameFramework;
using GameFramework.Event;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class UseForm : UGuiForm
    {
        [SerializeField]
        Button YesBtn;
        [SerializeField]
        Button NoBtn;
        [SerializeField]
        Text InfoText;

        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            Item item = userData as Item;

            YesBtn.GetComponentInChildren<Text>().text = "是";
            NoBtn.GetComponentInChildren<Text>().text = "否";
            NoBtn.onClick.AddListener(() => { GameEntry.UI.CloseUIForm(this); });

            if (item != null) 
            {
                switch (item.dRItem.Type) 
                {
                    case 1:
                        InfoText.text = "是否使用道具？";
                        break;
                    case 2:
                        InfoText.text = "是否更换装备？";
                        YesBtn.onClick.AddListener(() => 
                        {
                                GameEntry.Event.Fire(UpdateEquipInfo.EventId, UpdateEquipInfo.Create(item.dRItem));
                                GameEntry.UI.CloseUIForm(this);
                            }
                        ); 
                        break;
                }
            }
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            YesBtn.onClick.RemoveAllListeners();
            NoBtn.onClick.RemoveAllListeners();
            base.OnClose(isShutdown, userData);
        }
    }

    public class UpdateEquipInfo : GameEventArgs
    {
        public static readonly int EventId = typeof(UpdateEquipInfo).GetHashCode();
        public override int Id 
        {
            get 
            { 
                return EventId; 
            }
        }

        public DRItem dRItem;

        public static UpdateEquipInfo Create(DRItem dRItem) 
        {
            UpdateEquipInfo e = ReferencePool.Acquire<UpdateEquipInfo>();
            e.dRItem = dRItem;
            return e;
        }

        public override void Clear()
        {
            dRItem = null;
        }
    }
}
