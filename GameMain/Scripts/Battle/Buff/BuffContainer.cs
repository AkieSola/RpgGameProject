using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public class BuffContainer
    {
        LinkedList<Buff> buffList;
        Actor Owner;

        public BuffContainer(Actor Owner)
        {
            buffList = new LinkedList<Buff>();
            this.Owner = Owner;
        }


        public void BuffContainerEffect()
        {
            LinkedListNode<Buff> curNode = buffList.First;
            while (curNode != null)
            {
                Buff buff = curNode.Value;
                buff.BuffEffect(Owner);
                buff.duringTurn -= 1;
                if (buff.duringTurn <= 0)
                {
                    LinkedListNode<Buff> nextNode = curNode.Next;
                    buff.BuffFinish(Owner);
                    buffList.Remove(curNode);
                    curNode = nextNode;
                }
                else
                {
                    curNode = curNode.Next;
                }
            }
        }

        public void AddBuff(Buff buff)
        {
            buff.BuffStart(Owner);
            buffList.AddFirst(buff);
        }

        public void RemoveBuff(Buff buff)
        {
            buff.BuffFinish(Owner);
            buffList.Remove(buff);
        }

        public void ClearBuff()
        {
            buffList.Clear();
        }
    }
}
