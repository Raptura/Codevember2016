using UnityEngine;
using System.Collections;

public abstract class CombatEntity : MonoBehaviour
{

    //Typical Stats
    private int _health;
    public int health
    {
        get { return _health; }
        protected set
        {
            if (value <= 0)
            {
                _health = 0;
            }
            else if (value >= maxHealth)
            {
                _health = maxHealth;
            }
            else {
                _health = value;
            }
        }
    }
    public int maxHealth { get; protected set; }
    public int special { get; protected set; }
    public int maxSpecial { get; protected set; }

    public int level { get; protected set; }
    public int ATK { get; protected set; }
    public int SPE { get; protected set; }
    public int RES { get; protected set; }
    public int DEF { get; protected set; }

    public enum Job
    {
        Warrior,
        Mage,
        Ranger
    }
    public Job job;

    //Variables that are specific to the Skill Stat
    protected int negRange { get; set; } //This is a negative value
    protected int posRange { get; set; } //This is the positive value

    public string SKILL { get { return negRange + " - " + posRange; } }

    public abstract void processDamage(int dmg);

    protected abstract int calculateDamage(CombatEntity target);

}
