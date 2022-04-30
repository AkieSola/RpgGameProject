using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum E_SkillType
{
    /// <summary>
    /// 选择型
    /// </summary>
    Select = 1,
    /// <summary>
    /// 指向型
    /// </summary>
    Arrow = 2,
    /// <summary>
    /// 范围型
    /// </summary>
    Range = 3,
    /// <summary>
    /// 只以自己为目标
    /// </summary>
    Normal = 4
}

public enum E_DamageType
{
    /// <summary>
    /// 物理
    /// </summary>
    Physics = 1,
    /// <summary>
    /// 法术
    /// </summary>
    Spell = 2,

}

namespace RPGGame {
    public interface ISkillLogic
    {
        public void Launch(SkillConfig skillConfig, Actor Target, Vector3 poa);
        public void Clear(SkillConfig skillConfig, Actor Target, Vector3 poa);
    }
}
