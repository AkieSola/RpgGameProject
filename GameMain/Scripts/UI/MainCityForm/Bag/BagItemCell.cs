using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace RPGGame {
    public class BagItemCell : MonoBehaviour
    {
        [SerializeField]
        private Image itemIcon;
        [SerializeField]
        private Text itemNum;
        [SerializeField]
        private Text ItemName;
        [SerializeField]
        private Text ItemDescription;
        [SerializeField]
        private Button ItemUseBtn;

        public void UpdateInfo(Item item) 
        {
            itemNum.text = item.num.ToString();
            ItemName.text = item.dRItem.Name;
            itemIcon.sprite = Resources.Load<Sprite>("ItemIcon/" + item.dRItem.Icon);

            ItemDescription.text = item.dRItem.Description;
            ItemUseBtn.onClick.AddListener(() => { GameEntry.UI.OpenUIForm(UIFormId.UseForm, item); });
        }
    }
}
