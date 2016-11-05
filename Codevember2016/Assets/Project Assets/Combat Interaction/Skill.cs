using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public abstract class Skill
{
    public string name;

    /// <summary>
    /// Calculates the Damage taken
    /// </summary>
    /// <param name="user">The combat entity that initiated the skill </param>
    /// <param name="target">The target that will recieve damage </param>
    /// <returns></returns>
    protected abstract int calculateDamage(CombatEntity user, CombatEntity target);

    /// <summary>
    /// The Method that handles anything that happens when the skill is used
    /// </summary>
    protected abstract void onSkillUse(CombatEntity user, CombatEntity target);

    public void useSkill(CombatEntity user, CombatEntity target)
    {
        onSkillUse(user, target); //Do any kind of effects nessacary
    }
}

public class Attack : Skill
{
    protected override int calculateDamage(CombatEntity user, CombatEntity target)
    {
        int rand = Random.Range(user.negRange, user.posRange);
        int power = 0;
        if (user.job == CombatEntity.Job.Warrior || user.job == CombatEntity.Job.Ranger)
            power = user.ATK;
        else if (user.job == CombatEntity.Job.Mage)
            power = user.SPE;

        return power + rand - target.DEF;
    }

    protected override void onSkillUse(CombatEntity user, CombatEntity target)
    {
        int damage = calculateDamage(user, target);
        damage = damage <= 0 ? 0 : damage;

        List<string> text = new List<string>();
        text.Add(user.combatName + "Attacked " + target.combatName);
        text.Add(user.combatName + "Did " + damage +" Points of Damage");

        GameObject.FindObjectOfType<TextManager>().addToQueue(text.ToArray());

        target.processDamage(damage); //actually process the damage to the target
    }
}

/// <summary>
/// Fire Skill:
/// Magician Job Only
/// </summary>
public class Fire : Skill
{
    public static bool damaging = true;

    protected override int calculateDamage(CombatEntity user, CombatEntity target)
    {
        //TODO: Balance the Fire skill's Formula
        int power = (int)Mathf.Round(user.SPE * 1.15f);
        return power - target.RES;
    }

    protected override void onSkillUse(CombatEntity user, CombatEntity target)
    {

    }
}
