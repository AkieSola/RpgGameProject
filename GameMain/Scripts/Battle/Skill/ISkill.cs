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

namespace RPGGame {
    public interface ISkill
    {
        public int SkillId { get; set; }

        public int Init(DRSkillConfig dRSkillConfig);
    }
}
