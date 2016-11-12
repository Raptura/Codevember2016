using UnityEngine;
using System.Collections;

public class SkellIvy : Enemy
{
    public override void setup()
    {
        //Generates the Stats for The 
        generateStats(CombatEntity.Job.Ranger, 1);
        combatName = "SkellIvy";
        expGive = 100;
        skills.Add(Skill.SkillName.Attack);
    }
}
