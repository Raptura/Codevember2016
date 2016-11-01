using UnityEngine;
using System.Collections;

public abstract class Enemy : CombatEntity {

    public override void processDamage(int dmg)
    {
        health -= dmg;

        //TODO: Display Combat Text

        if (health == 0)
            die();
    }


    protected override int calculateDamage(CombatEntity target)
    {
        int rand = Random.Range(negRange, posRange);
        int power = 0;
        if (job == Job.Warrior || job == Job.Ranger)
            power = ATK;
        else if (job == Job.Mage)
            power = SPE;

        return power + rand - target.DEF;
    }

    public abstract void die();
}
