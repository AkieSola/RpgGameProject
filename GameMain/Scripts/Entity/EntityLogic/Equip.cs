using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RPGGame
{
    public enum EquipType 
    {
        none = 0,
        weapon = 1,
        helmet = 2,
        breastplate = 3,
        gardebras = 4,
        cuisse = 5,
        ring = 6
    }
    public abstract class Equip : Entity
    {
        protected EquipType m_EquipType;
    }
}
