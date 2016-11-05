using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{

    Player playerScript;

    // Use this for initialization
    void Start()
    {
        playerScript = Player.createPlayer(CombatEntity.Job.Ranger);
        playerScript.combatName = "Raptura";
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown)
        {
            enterCombat(FindObjectOfType<MataMata>().enemyScript);
            Attack attack = new Attack();
            attack.useSkill(playerScript, FindObjectOfType<MataMata>().enemyScript);
        }

    }

    void enterCombat(Enemy target)
    {
        CombatInstance instance = FindObjectOfType<CombatInstance>();
        if (!instance.enemies.Contains(target))
        {
            instance.enemies.Add(target);
            instance.player = playerScript;
            instance.inCombat = true;
        }
    }
}
