using UnityEngine;
using System.Collections;

public abstract class Enemy : CombatEntity
{

    public override void processDamage(int dmg)
    {
        health -= dmg;

        //TODO: Display Combat Text

        if (health == 0)
            die();
    }

    public abstract void die();

    public static Enemy createEnemy(Enemy enemy, CombatEntity.Job job, int level)
    {
        switch (job)
        {
            case Job.Mage:
                enemy.maxHealth = Random.Range(10 * level, 15 * level);
                enemy.maxSpecial = Random.Range(10 * level, 12 * level);
                enemy.ATK = Random.Range(1, 4) + Random.Range(1 * level, 2 * level);
                enemy.SPE = Random.Range(5, 6) + Random.Range(3 * level, 5 * level);
                enemy.RES = Random.Range(3, 4) + Random.Range(3 * level, 5 * level);
                enemy.DEF = Random.Range(1, 3) + Random.Range(1 * level, 2 * level);
                break;
            case Job.Warrior:
                enemy.maxHealth = Random.Range(14 * level, 19 * level);
                enemy.maxSpecial = Random.Range(4 * level, 10 * level);
                enemy.ATK = Random.Range(4, 5) + Random.Range(6 * level, 8 * level);
                enemy.SPE = Random.Range(1, 2) + Random.Range(1 * level, 2 * level);
                enemy.RES = Random.Range(1, 3) + Random.Range(1 * level, 2 * level);
                enemy.DEF = Random.Range(3, 4) + Random.Range(2 * level, 4 * level);
                break;
            case Job.Ranger:
                enemy.maxHealth = Random.Range(13 * level, 15 * level);
                enemy.maxSpecial = Random.Range(7 * level, 10 * level);
                enemy.ATK = Random.Range(3, 4) + Random.Range(3 * level, 5 * level);
                enemy.SPE = Random.Range(2, 3) + Random.Range(3 * level, 5 * level);
                enemy.RES = Random.Range(2, 3) + Random.Range(3 * level, 5 * level);
                enemy.DEF = Random.Range(3, 4) + Random.Range(3 * level, 5 * level);
                break;
        }
        enemy.health = enemy.maxHealth;
        enemy.special = enemy.maxSpecial;

        return enemy;
    }
}
