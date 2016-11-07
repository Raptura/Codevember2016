using UnityEngine;
using System.Collections;

public class MataMata : Enemy
{
    public override void setup()
    {
        //Generates the Stats for The 
        generateStats(CombatEntity.Job.Ranger, 1);
        combatName = "Mata Mata";
        expGive = 100;
        skills.Add(Skill.SkillName.Attack);
    }
}
