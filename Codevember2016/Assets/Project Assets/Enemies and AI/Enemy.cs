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

    public void die()
    {
        string[] text = new string[1];
        text[0] = combatName + " was defeated";

        GameObject.FindObjectOfType<TextManager>().addToQueue(text);
    }

    public static Enemy createEnemy(CombatEntity.Job job, int level)
    {
        Enemy enemy = new Enemy();
        enemy.level = level;
        switch (job)
        {
            case Job.Mage:
                enemy.maxHealth = Random.Range(10 * level, 15 * level);
                enemy.maxSpecial = Random.Range(10 * level, 12 * level);
                enemy.ATK = Random.Range(1 * level, 2 * level);
                enemy.SPE = Random.Range(3 * level, 5 * level);
                enemy.RES = Random.Range(3 * level, 5 * level);
                enemy.DEF = Random.Range(1 * level, 2 * level);
                break;
            case Job.Warrior:
                enemy.maxHealth = Random.Range(14 * level, 19 * level);
                enemy.maxSpecial = Random.Range(4 * level, 10 * level);
                enemy.ATK = Random.Range(6 * level, 8 * level);
                enemy.SPE = Random.Range(1 * level, 2 * level);
                enemy.RES = Random.Range(1 * level, 2 * level);
                enemy.DEF = Random.Range(2 * level, 4 * level);
                enemy.negRange += Random.Range(-2 * level, 2 * level);
                enemy.posRange += Random.Range(1 * level, 3 * level);
                break;
            case Job.Ranger:
                enemy.maxHealth = Random.Range(13 * level, 15 * level);
                enemy.maxSpecial = Random.Range(7 * level, 10 * level);
                enemy.ATK = Random.Range(2 * level, 4 * level);
                enemy.SPE = Random.Range(2 * level, 4 * level);
                enemy.RES = Random.Range(1 * level, 3 * level);
                enemy.DEF = Random.Range(1 * level, 3 * level);
                enemy.negRange += Random.Range(-1 * level, 2 * level);
                enemy.posRange += Random.Range(2 * level, 3 * level);
                break;
        }
        enemy.health = enemy.maxHealth;
        enemy.special = enemy.maxSpecial;

        return enemy;
    }
}
