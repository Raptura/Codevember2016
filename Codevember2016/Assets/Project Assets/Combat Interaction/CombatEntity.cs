﻿using UnityEngine;
using System.Collections;

public abstract class CombatEntity
{

    //Typical Stats
    private int _health;
    public int health
    {
        get { return _health; }
        protected set
        {
            if (value <= 0)
            {
                _health = 0;
            }
            else if (value >= maxHealth)
            {
                _health = maxHealth;
            }
            else {
                _health = value;
            }
        }
    }
    public int maxHealth { get; protected set; }
    public int special { get; protected set; }
    public int maxSpecial { get; protected set; }

    public int level { get; protected set; }
    public int ATK { get; protected set; }
    public int SPE { get; protected set; }
    public int RES { get; protected set; }
    public int DEF { get; protected set; }

    public enum Job
    {
        Warrior,
        Mage,
        Ranger
    }
    public Job job;

    //Variables that are specific to the Skill Stat
    public int negRange { get; set; } //This is a negative value
    public int posRange { get; set; } //This is the positive value

    public string SKILL { get { return negRange + " - " + posRange; } }

    public abstract void processDamage(int dmg);

    public static void debugStats(CombatEntity entity)
    {
        Debug.Log(
        "Level: " + entity.level + "\t" +
        "Class: " + entity.job.ToString() + "\t" +
        "Max Health: " + entity.maxHealth + "\t" +
        "Max Special: " + entity.maxSpecial + "\t" +
        "ATK: " + entity.ATK + "\t" +
        "SPE: " + entity.SPE + "\t" +
        "DEF: " + entity.DEF + "\t" +
        "RES: " + entity.RES);
    }

}