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
        //TODO: Base Stat increases based on random element and Job
        Debug.Log("Level Up!");
        int oldHealth = maxHealth;
        int oldSpecial = maxSpecial;
        int oldAtk = ATK;
        int oldSpe = SPE;
        int oldRes = RES;
        int oldDef = DEF;

        if (job == CombatEntity.Job.Warrior) {
            maxHealth += Random.Range(5, 10);
            maxSpecial += Random.Range(2, 4);
            ATK += Random.Range(6, 8);
            SPE += Random.Range(1, 2);
            RES += Random.Range(1, 2);
            DEF += Random.Range(2, 4);
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
        else if (job == CombatEntity.Job.Ranger)
        {
            maxHealth += Random.Range(4, 9);
            maxSpecial += Random.Range(2, 4);
            ATK += Random.Range(3, 5);
            SPE += Random.Range(3, 5);
            RES += Random.Range(3, 5);
            DEF += Random.Range(3, 5);
        }

        level++;

    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
