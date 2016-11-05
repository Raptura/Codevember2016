using UnityEngine;
using System.Collections;

public class CombatInstance : MonoBehaviour
{

    public int expGive = 0;
    public bool inCombat;
    public Player player;
    public ArrayList enemies = new ArrayList();

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (enemies.Count == 0 && inCombat)
        {
            string[] text = new string[2];
            text[0] = "All enemies were defeated!";
            text[1] = player.combatName + " gained " + expGive + " EXP!";
            GameObject.FindObjectOfType<TextManager>().addToQueue(text);

            player.EXP += expGive;
            expGive = 0;
            inCombat = false;
        }
    }
}
