using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame
{
    public class BagForm : UGuiForm
    {
        [SerializeField]
        BagItemCell cell;
        [SerializeField]
        GameObject content;
        [SerializeField]
        Toggle tog1;
        [SerializeField]
        Toggle tog2;
        [SerializeField]
        Text title;
        [SerializeField]
        Button closeBtn;

        Dictionary<int, Item> ItemDic;
        List<GameObject> ItemObjList;
        protected override void OnOpen(object userData)
        {
            base.OnOpen(userData);
            ItemObjList = new List<GameObject>();

            ItemDic = userData as Dictionary<int,Item>;

            title.text = "背包";

            closeBtn.onClick.AddListener(()=> { GameEntry.UI.CloseUIForm(this); });

            tog1.onValueChanged.AddListener((b) => 
            {
                if (b) 
                {
                    ShowItemByType(1);
                }
                else
                {
                    ShowItemByType(2);
                }
            });

            tog1.GetComponentInChildren<Text>().text = "消耗道具";
            tog2.GetComponentInChildren<Text>().text = "装备道具";
            tog1.isOn = true;
            ShowItemByType(1);
        }

        public void UpdateItemDic(Dictionary<int, Item> dic) 
        {
            ItemDic.Clear();
            ItemDic = dic;
        }

        public void ShowItemByType(int Type) 
        {
            switch (Type) 
            {
                case 1:
                    ClearItem();
                    if (ItemDic != null)
                    {
                        foreach (Item item in ItemDic.Values)
                        {
                            if (item.dRItem.Type == 1)
                            {
                                BagItemCell bgItem = Instantiate<BagItemCell>(cell);
                                bgItem.gameObject.SetActive(true);
                                bgItem.transform.SetParent(content.transform, false);
                                ItemObjList.Add(bgItem.gameObject);
                                bgItem.UpdateInfo(item);
                            }
                        }
                    }
                    break;
                case 2:
                    ClearItem();
                    if (ItemDic != null)
                    {
                        foreach (Item item in ItemDic.Values)
                        {
                            if (item.dRItem.Type == 2)
                            {
                                BagItemCell bgItem = Instantiate<BagItemCell>(cell);
                                bgItem.gameObject.SetActive(true);
                                bgItem.transform.SetParent(content.transform, false);
                                ItemObjList.Add(bgItem.gameObject);
                                bgItem.UpdateInfo(item);
                            }
                        }
                    }
                    break;
            }
        }

        public void ClearItem() 
        {
            foreach(var obj in ItemObjList) 
            {
                Destroy(obj.gameObject);
            }

            ItemObjList.Clear();
        }

        protected override void OnClose(bool isShutdown, object userData)
        {
            ClearItem();
            tog1.onValueChanged.RemoveAllListeners();
            tog2.onValueChanged.RemoveAllListeners();
            closeBtn.onClick.RemoveAllListeners();

            base.OnClose(isShutdown, userData);
        }
    }
}
