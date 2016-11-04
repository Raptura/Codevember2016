using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour {

    Player playerScript;

	// Use this for initialization
	void Start () {
        playerScript = Player.createPlayer(CombatEntity.Job.Ranger);
        CombatEntity.debugStats(playerScript);
        playerScript.EXP = playerScript.NEEDED_EXP;
        CombatEntity.debugStats(playerScript);
        playerScript.EXP = playerScript.NEEDED_EXP;
        CombatEntity.debugStats(playerScript);
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
