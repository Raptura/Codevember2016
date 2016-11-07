using UnityEngine;
using System.Collections;

public class EnemyField : MonoBehaviour
{

    public Enemy enemyScript;

    // Use this for initialization
    void Start()
    {
        enemyScript = new MataMata();
        enemyScript.setup();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
