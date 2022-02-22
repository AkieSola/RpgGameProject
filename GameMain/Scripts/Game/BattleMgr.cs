using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleMgr : MonoBehaviour
{
    private List<Actor> battleActors;
    private Dictionary<int, Actor> camp1Dic;
    private Dictionary<int, Actor> camp2Dic;

    private Actor m_CurActor;
    private int m_CurActorIndex;

    public void OnInit(List<Actor> actors)
    {
        battleActors = actors;
        
        lineSort();
    }

    // Start is called before the first frame update
    void Start()
    {   
    }

    public bool CheckBattleEnd()
    {
        if(camp1Dic.Count == 0 || camp2Dic.Count == 0)
        {
            return true;
        }

        return false;
    }

    private void ShiftToNextActor() 
    { 
        if(m_CurActorIndex == battleActors.Count - 1)
        {
            m_CurActorIndex = 0;
        }
        else
        {
            m_CurActorIndex++;
        }

        m_CurActor = battleActors[m_CurActorIndex];
    }

    private void EndBattle()
    {

    }

    void FindTaget() 
    {
    }

    void RunToTarget() 
    { 
    }

    void LaunchAttack() 
    { 
    }

    void lineSort()
    {
        battleActors.Sort();
    }

    //IEnumerator WaitForTakeDamage()
    //{

    //}
    // Update is called once per frame
    void Update()
    {
        
    }
}
