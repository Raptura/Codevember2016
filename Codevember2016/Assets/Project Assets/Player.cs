using UnityEngine;
using System.Collections;
public class Player : CombatEntity
{
    private int _exp;
    public int EXP
    {
        get
        {
            return _exp;
        }
        set
        {
            if (value >= 0)
            {
                if (value >= NEEDED_EXP)
                {
                    _exp = 0;
                    levelUp();
                }
                else {
                    _exp = value;
                }
            }
        }
    }
    public int NEEDED_EXP
    {
        get
        {
            switch (level)
            {
                case 1:
                    return 100;
                case 2:
                    return 350;
                case 3:
                    return 600;
                default:
                    return 0;
            }
        }
    }

    public override void processDamage(int dmg)
    {
        health -= dmg;

        //TODO: Display Combat Text

        if (health == 0)
            die();
    }

    protected void die()
    {

    }

    void levelUp()
    {
        Debug.Log("Level Up!");

        //TODO: Increase SKILL (neg, pos) on level up
        int oldHealth = maxHealth;
        int oldSpecial = maxSpecial;
        int oldAtk = ATK;
        int oldSpe = SPE;
        int oldRes = RES;
        int oldDef = DEF;

        if (job == CombatEntity.Job.Warrior)
        {
            maxHealth += Random.Range(5, 11);
            maxSpecial += Random.Range(2, 5);
            ATK += Random.Range(6, 9);
            SPE += Random.Range(1, 3);
            RES += Random.Range(1, 3);
            DEF += Random.Range(3, 6);
        }
        else if (job == CombatEntity.Job.Mage)
        {
            maxHealth += Random.Range(3, 7);
            maxSpecial += Random.Range(3, 6);
            ATK += Random.Range(1, 2);
            SPE += Random.Range(3, 5);
            RES += Random.Range(3, 5);
            DEF += Random.Range(1, 2);
        }
        //TODO: Tweak the Ranger's Growth Stats and Skill Increases
        else if (job == CombatEntity.Job.Ranger)
        {
            maxHealth += Random.Range(4, 10);
            maxSpecial += Random.Range(3, 6);
            ATK += Random.Range(3, 6);
            SPE += Random.Range(2, 5);
            RES += Random.Range(2, 4);
            DEF += Random.Range(2, 4);
        }

        level++;

    }

    public static Player createPlayer(CombatEntity.Job job)
    {
        Player newPlayer = new Player();
        newPlayer.job = job;
        newPlayer.level = 1;
        switch (job)
        {
            case Job.Mage:
                newPlayer.maxHealth = Random.Range(10, 16);
                newPlayer.maxSpecial = Random.Range(10, 13);
                newPlayer.ATK = Random.Range(1, 5);
                newPlayer.SPE = Random.Range(5, 7);
                newPlayer.RES = Random.Range(3, 5);
                newPlayer.DEF = Random.Range(1, 4);
                break;
            case Job.Warrior:
                newPlayer.maxHealth = Random.Range(14, 20);
                newPlayer.maxSpecial = Random.Range(4, 11);
                newPlayer.ATK = Random.Range(4, 6);
                newPlayer.SPE = Random.Range(1, 3);
                newPlayer.RES = Random.Range(1, 3);
                newPlayer.DEF = Random.Range(3, 5);
                break;
            case Job.Ranger:
                newPlayer.maxHealth = Random.Range(13, 16);
                newPlayer.maxSpecial = Random.Range(7, 11);
                newPlayer.ATK = Random.Range(3, 5);
                newPlayer.SPE = Random.Range(2, 4);
                newPlayer.RES = Random.Range(2, 4);
                newPlayer.DEF = Random.Range(3, 5);
                break;
        }
        newPlayer.health = newPlayer.maxHealth;
        newPlayer.special = newPlayer.maxSpecial;

        return newPlayer;
    }
}
