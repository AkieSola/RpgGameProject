using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffContainer : MonoBehaviour
{
    LinkedList<Buff> buffList;
    

    public void BuffContainerEffect()
    {
        LinkedListNode<Buff> curNode = buffList.First;
        while (curNode != null)
        {
            Buff buff = curNode.Value;
            buff.BuffEffect();
            buff.duringTurn -= 1;
            if (buff.duringTurn <= 0)
            {
                LinkedListNode<Buff> nextNode = curNode.Next;
                buff.BuffFinish();
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
        buffList.AddFirst(buff);
    }

    public void RemoveBuff(Buff buff)
    {
        buffList.Remove(buff);
    }

    public void ClearBuff()
    {
        buffList.Clear();
    }
    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
