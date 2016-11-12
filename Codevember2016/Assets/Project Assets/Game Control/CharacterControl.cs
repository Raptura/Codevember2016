using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{

    Player playerScript;
    CombatInstance instance;
    private float speed = 3.0f;

    // Use this for initialization
    void Start()
    {
        playerScript = Player.createPlayer(CombatEntity.Job.Ranger);
        playerScript.combatName = "Raptura";
        instance = FindObjectOfType<CombatInstance>();
    }

    // Update is called once per frame
    void Update()
    {
        //enterCombat(FindObjectOfType<EnemyField>().enemyScript);
        if (!instance.inCombat)
            checkMovement();
    }

    void OnTriggerEnter2D(Collider2D coll)
    {
        Debug.Log("Triggered");
        if (coll.gameObject.GetComponent<EnemyField>())
        {
            enterCombat(coll.gameObject.GetComponent<EnemyField>().enemyScript);
        }
    }

    void enterCombat(Enemy target)
    {
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

    void checkMovement()
    {
        if (Input.GetKey(KeyCode.W))
            transform.Translate(Vector2.up * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.A))
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.S))
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        if (Input.GetKey(KeyCode.D))
            transform.Translate(Vector2.right * speed * Time.deltaTime);


    }
}
