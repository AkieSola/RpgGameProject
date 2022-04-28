using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillConfig
{
    public int SkillId { get; set; }
    public int SkillType { get; set; }
    public int AnimationId { get; set; }
    public string IconName { get; set; }
    public string EffectName { get; set; }
    public float Distance { get; set; }
    public int BaseDamage1 { get; set; }
    public int BaseDamage2 { get; set; }
    public float Damage1SpellAtkAdd { get; set; }
    public float Damage2SpellAtkAdd { get; set; }
    public float Damage1AtkAdd { get; set; }
    public float Damage2AtkAdd { get; set; }
    public int HpConsume;
    public int SpConsume;
}
