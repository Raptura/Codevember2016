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

    public abstract void die();
}
