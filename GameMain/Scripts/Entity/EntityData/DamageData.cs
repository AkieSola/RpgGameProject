using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageData
{
    private Vector3 m_Position;
    private int m_Damage;
    private E_DamageType m_DamageType;

    public DamageData(int Damage, Vector3 Position, E_DamageType damageType)
    {
        m_Damage = Damage;
        m_Position = Position;
        m_DamageType = damageType;
    }

    public Vector3 Position { get => m_Position;}
    public int Damage { get => m_Damage;}
    public E_DamageType DamageType { get => m_DamageType;}
}
