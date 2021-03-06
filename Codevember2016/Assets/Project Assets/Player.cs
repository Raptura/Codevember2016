﻿using UnityEngine;

using System.Collections;
using System.Collections.Generic;

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
                else
                {
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

    public override void processDamage(CombatInstance instance, int dmg)
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
            negRange += Random.Range(-2, 2);
            posRange += Random.Range(1, 3);
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
            negRange += Random.Range(-1, 3);
            posRange += Random.Range(3, 5);
        }

        level++;

        string[] text = new string[7];
        text[0] = combatName + " became level " + level + "!";
        text[1] = "Health increased from " + oldHealth + " to " + maxHealth + "!";
        text[2] = "Special increased from " + oldSpecial + " to " + maxSpecial + "!";
        text[3] = "ATK increased from " + oldAtk + " to " + ATK + "!";
        text[4] = "SPE increased from " + oldSpe + " to " + SPE + "!";
        text[5] = "DEF increased from " + oldDef + " to " + DEF + "!";
        text[6] = "RES increased from " + oldRes + " to " + RES + "!";

        GameObject.FindObjectOfType<TextManager>().addToQueue(text);

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
                newPlayer.negRange = Random.Range(-2, 0);
                newPlayer.posRange = Random.Range(0, 3);
                break;
            case Job.Ranger:
                newPlayer.maxHealth = Random.Range(13, 16);
                newPlayer.maxSpecial = Random.Range(7, 11);
                newPlayer.ATK = Random.Range(3, 5);
                newPlayer.SPE = Random.Range(2, 4);
                newPlayer.RES = Random.Range(2, 4);
                newPlayer.DEF = Random.Range(3, 5);
                newPlayer.negRange = Random.Range(-2, 1);
                newPlayer.posRange = Random.Range(2, 4);
                break;
        }
        newPlayer.health = newPlayer.maxHealth;
        newPlayer.special = newPlayer.maxSpecial;

        return newPlayer;
    }


    private enum CombatMenu
    {
        Start,
        Skills,
        Target
    }

    public IEnumerator chooseSkill(TextManager manager, CombatInstance instance)
    {
        bool skillChosen = false;
        CombatMenu currMenu = CombatMenu.Start;

        while (!skillChosen)
        {
            manager.setupMenu(getOptions(currMenu, instance));
            while (manager.mode != TextManager.ManagerMode.Standby) { yield return null; }
            navigateMenu(currMenu, instance, manager.output);
            skillChosen = true;
        }
    }

    private string[] getOptions(CombatMenu menu, CombatInstance instance)
    {
        List<string> result = new List<string>();
        if (menu == CombatMenu.Start)
        {
            result.Add("Attack");
            result.Add("Skill");
            result.Add("Move");
        }
        else if (menu == CombatMenu.Skills)
        {
            foreach (Skill.SkillName skill in skills)
            {
                result.Add(skill.ToString());
            }
        }
        else if (menu == CombatMenu.Target)
        {
            int postFix = 0;
            bool incr = false;

            if (instance.enemies.Count > 1)
            {
                postFix = 1;
                incr = true;
            }

            foreach (Enemy enemy in instance.enemies)
            {
                if (incr)
                    postFix++;

                result.Add(enemy.combatName + (incr ? " " + postFix : ""));
            }
        }

        return result.ToArray();
    }

    private void navigateMenu(CombatMenu menu, CombatInstance instance, int option)
    {

    }

}
