using UnityEngine;
using System.Collections;

public class EnemyField : MonoBehaviour
{

    public Enemy enemyScript;

    // Use this for initialization
    void Start()
    {
        enemyScript = new SkellIvy();
        enemyScript.setup();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyScript.isDead)
            Destroy(this.gameObject);

    }
}
