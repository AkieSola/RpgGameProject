using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class DropItemData : MonoBehaviour
    {
        public List<int> dropItemIdList = new List<int>();
        public GameObject target;
        float k = 5;
        float F;
        private void Update()
        {
            if (target != null)
            {
                F = k / 
                Vector3.Distance(this.transform.position, target.transform.position) * 
                Vector3.Distance(this.transform.position, target.transform.position) * 
                Vector3.Distance(this.transform.position, target.transform.position);

                this.transform.position += (target.transform.position - transform.position).normalized * F * Time.deltaTime;
                if (Vector3.Distance(transform.position, target.transform.position) < 0.1f)
                {
                    Actor actor = target.transform.GetComponent<Actor>();
                    if (actor != null)
                    {
                       Destroy(this.gameObject);
                    }
                }
            }
        }

        public void ItemPick(GameObject target)
        {
            this.target = target;
        }

        private void OnDestroy()
        {
            this.target = null;
        }
    }
}
