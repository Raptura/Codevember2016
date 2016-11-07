using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public static class Skill
{
    public enum SkillName
    {
        Inspect,
        Attack,
        Fire
    }

    public static void useSkill(SkillName sk, CombatEntity user, CombatEntity target)
    {
        if (sk == SkillName.Attack)
        {
            int damage = calculateDamage(user, target);

            List<string> text = new List<string>();
            text.Add(user.combatName + " attacked " + target.combatName);
            text.Add(user.combatName + " did " + damage + " points of damage");

            GameObject.FindObjectOfType<TextManager>().addToQueue(text.ToArray());

            CombatInstance instance = GameObject.FindObjectOfType<CombatInstance>();
            target.processDamage(instance, damage); //actually process the damage to the target
        }
        else if (sk == SkillName.Inspect)
        {
            List<string> text = new List<string>();
            text.Add(user.combatName + " inspected " + target.combatName);
            GameObject.FindObjectOfType<TextManager>().addToQueue(text.ToArray());
            CombatEntity.displayStats(target, GameObject.FindObjectOfType<TextManager>());
        }
    }

    /// <summary>
    /// Basic Attack Formula
    /// </summary>
    /// <param name="user">The user</param>
    /// <param name="target">The target</param>
    /// <returns></returns>
    private static int calculateDamage(CombatEntity user, CombatEntity target)
    {
        int rand = Random.Range(user.negRange, user.posRange);
        int damage = 0;
        if (user.job == CombatEntity.Job.Warrior || user.job == CombatEntity.Job.Ranger)
            damage = user.ATK + rand - target.DEF;
        else if (user.job == CombatEntity.Job.Mage)
            damage = user.SPE + rand - target.RES;

        damage = damage <= 0 ? 0 : damage;
        return damage;
    }
}
