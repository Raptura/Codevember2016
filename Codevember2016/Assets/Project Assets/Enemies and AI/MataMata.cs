using UnityEngine;
using System.Collections;

public class MataMata : MonoBehaviour {

    public Enemy enemyScript;

    // Use this for initialization
    void Start () {
        //Generates the Stats for The 
        enemyScript = Enemy.createEnemy(CombatEntity.Job.Ranger, 1);
        enemyScript.combatName = "Mata Mata";
        enemyScript.expGive = 100;
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
