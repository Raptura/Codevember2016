using UnityEngine;
using System.Collections;

public class CharacterControl : MonoBehaviour
{

    Player playerScript;

    // Use this for initialization
    void Start()
    {
        playerScript = Player.createPlayer(CombatEntity.Job.Ranger);

        for (int i = 0; i < 40; i++)
        {
            CombatEntity.debugStats(playerScript);
            playerScript.EXP = playerScript.NEEDED_EXP;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
