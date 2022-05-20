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

        public void UpdateInfo(Item item) 
        {
            itemNum.text = item.num.ToString();
            ItemName.text = item.dRItem.Name;
            ItemDescription.text = item.dRItem.Description;
        }
    }
}
