using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CombatInstance : MonoBehaviour
{

    public int expGive = 0;
    public bool inCombat, choosingSkill;
    public Player player;
    public List<Enemy> enemies = new List<Enemy>();
    public TextManager textManager;

    // Use this for initialization
    void Start()
    {
        textManager = GameObject.FindObjectOfType<TextManager>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public IEnumerator combatQueue()
    {
        Debug.Log("Combat Start");
        int turn = 1;
        GameObject.FindObjectOfType<TextManager>().addToQueue("COMBAT START!");
        inCombat = true;

        while (inCombat)
        {
            Debug.Log("Turn " + turn);

            while (textManager.mode != TextManager.ManagerMode.Standby) { yield return null; }

            //Player Turn
            //Wait for Player to pick action
            yield return StartCoroutine(player.chooseSkill(textManager, this));


            if (enemies.Count == 0)
            {
                endCombat();
            }

            //Go through Enemies List
            //Let Enemies pick their actions
            foreach (Enemy e in enemies)
            {
                e.chooseSkill(this);
                while (textManager.mode != TextManager.ManagerMode.Standby) { yield return null; }
            }

            turn++;
            yield return null;
        }

    }

    void endCombat()
    {
        string[] text = new string[2];
        text[0] = "All enemies were defeated!";
        text[1] = player.combatName + " gained " + expGive + " EXP!";
        GameObject.FindObjectOfType<TextManager>().addToQueue(text);

        player.EXP += expGive;
        expGive = 0;
        inCombat = false;
        StopCoroutine("combatQueue");
    }
}
