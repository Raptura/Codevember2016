using UnityEngine;
using System.Collections;

public class MataMata : MonoBehaviour {

    public Enemy enemyScript;

    // Use this for initialization
    void Start () {
        //Generates the Stats for The 
        enemyScript = Enemy.createEnemy(CombatEntity.Job.Ranger, 1);
        enemyScript.combatName = "Mata Mata";
        CombatEntity.displayStats(enemyScript, GameObject.FindObjectOfType<TextManager>());
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
