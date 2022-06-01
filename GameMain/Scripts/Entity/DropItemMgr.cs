using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class DropItemMgr : MonoBehaviour
    {
        [SerializeField]
        private List<int> dropItemIdList = new List<int>();
        public Player target;
        float k = 5;
        float F;
        float Distance;
        private void Update()
        {
            if (target != null)
            {
                Distance = Vector3.Distance(this.transform.position, target.transform.position);
                F = k / Distance* Distance* Distance;

                this.transform.position += (target.transform.position - transform.position).normalized * F * Time.deltaTime;
                if (Vector3.Distance(transform.position, target.transform.position) < 0.2f)
                {
                    Player player = target.transform.GetComponent<Player>();
                    if (player != null)
                    {
                       player.PickItem(dropItemIdList);
                       Destroy(this.gameObject);
                    }
                }
            }
        }

        public void ItemPick(Player target)
        {
            this.target = target;
        }

        public void DropSet(List<int> dropList) 
        {
            dropItemIdList = dropList;
        }

        private void OnDestroy()
        {
            this.target = null;
        }
    }
}
