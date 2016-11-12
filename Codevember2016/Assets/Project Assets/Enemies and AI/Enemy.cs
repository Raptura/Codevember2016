using UnityEngine;
using System.Collections;

public class Enemy : CombatEntity
{
    public override void processDamage(CombatInstance instance, int dmg)
    {
        health -= dmg;

        //TODO: Display Combat Text

        if (health == 0)
        {
            instance.expGive += expGive;
            instance.enemies.Remove(this);
            die();
        }
    }

    public int expGive;

    public virtual void die()
    {
        string[] text = new string[1];
        text[0] = combatName + " was defeated";

        GameObject.FindObjectOfType<TextManager>().addToQueue(text);
        isDead = true;
    }

    public void generateStats(CombatEntity.Job job, int level)
    {
        this.level = level;
        switch (job)
        {
            case Job.Mage:
                maxHealth = Random.Range(10 * level, 15 * level);
                maxSpecial = Random.Range(10 * level, 12 * level);
                ATK = Random.Range(1 * level, 2 * level);
                SPE = Random.Range(3 * level, 5 * level);
                RES = Random.Range(3 * level, 5 * level);
                DEF = Random.Range(1 * level, 2 * level);
                break;
            case Job.Warrior:
                maxHealth = Random.Range(14 * level, 19 * level);
                maxSpecial = Random.Range(4 * level, 10 * level);
                ATK = Random.Range(6 * level, 8 * level);
                SPE = Random.Range(1 * level, 2 * level);
                RES = Random.Range(1 * level, 2 * level);
                DEF = Random.Range(2 * level, 4 * level);
                negRange += Random.Range(-2 * level, 2 * level);
                posRange += Random.Range(1 * level, 3 * level);
                break;
            case Job.Ranger:
                maxHealth = Random.Range(13 * level, 15 * level);
                maxSpecial = Random.Range(7 * level, 10 * level);
                ATK = Random.Range(2 * level, 4 * level);
                SPE = Random.Range(2 * level, 4 * level);
                RES = Random.Range(1 * level, 3 * level);
                DEF = Random.Range(1 * level, 3 * level);
                negRange += Random.Range(-1 * level, 2 * level);
                posRange += Random.Range(2 * level, 3 * level);
                break;
        }
        health = maxHealth;
        special = maxSpecial;
    }

    /// <summary>
    /// Used to Setup Stats
    /// </summary>
    public virtual void setup()
    {

    }

    public virtual void chooseSkill(CombatInstance instance)
    {
        Skill.SkillName randomSkill;
        int choice = Random.Range(0, skills.Count);
        randomSkill = skills.ToArray()[choice];

        Skill.useSkill(randomSkill, this, instance.player);
    }

}
