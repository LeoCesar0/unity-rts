using System.Collections.Generic;
using UnityEngine;

public class UnitStats : MonoBehaviour
{
    public Types.UnitType unitType;
    public Types.UnitClass unitClass;

    public List<Types.UnitClass> unitClassList;

    public int hp;
    public int overHp;
    public int slashingArmour;
    public int piercingArmour;
    public int magicalArmour;
    public Types.Damage damageType;
    public int baseDamage;
    public int bonusDamage;
    public int damage;
    public float range;
    public float speed;
    public float attackSpeed;

    public bool isDead = false;

    public void HandleStart(StatsSO stats)
    {
        hp = stats.maxHp;
        overHp = stats.overHp;
        unitType = stats.unitType;
        // unitClass = stats.unitClass;
        unitClassList = stats.unitClassList;
        slashingArmour = stats.slashingArmour;
        piercingArmour = stats.piercingArmour;
        magicalArmour = stats.magicalArmour;
        damageType = stats.damageType;
        baseDamage = stats.baseDamage;
        bonusDamage = stats.bonusDamage;
        range = stats.range;
        speed = stats.speed;
        attackSpeed = stats.attackSpeed;
    }

    private void Update()
    {

    }

    void TakeDamage(int damage)
    {
        hp = hp - damage;
        if (hp <= 0)
        {
            OnDie();
        }

    }

    void OnDie()
    {
        isDead = true;
    }


}


