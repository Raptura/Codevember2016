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
        //enterCombat(FindObjectOfType<EnemyField>().enemyScript);
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.GetComponent<EnemyField>())
        {
            enterCombat(coll.gameObject.GetComponent<EnemyField>().enemyScript);
        }
    }

    void enterCombat(Enemy target)
    {
        CombatInstance instance = FindObjectOfType<CombatInstance>();
        if (!instance.enemies.Contains(target) && target != null)
        {
            instance.enemies.Add(target);
            instance.player = playerScript;
            if (!instance.inCombat)
            {
                instance.inCombat = true;
                instance.StartCoroutine("combatQueue");
            }
        }
    }
}
