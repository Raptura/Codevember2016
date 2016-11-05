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
        CombatEntity.displayStats(playerScript, FindObjectOfType<TextManager>());

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.anyKeyDown) {
            Attack attack = new Attack();
            attack.useSkill(playerScript, FindObjectOfType<MataMata>().enemyScript);
        }

    }
}
