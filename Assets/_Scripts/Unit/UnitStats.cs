using System.Collections.Generic;
using UnityEngine;

public class UnitStats : ITakeDamage
{
    public Types.UnitType unitType;
    public Types.UnitClass unitClass;

    public List<Types.UnitClass> unitClassList;

    public int maxHp;
    public int hp;
    public int overHp;

    public Damage damage;

    public Armor armor;

    public float speed;

    public bool isDead { get; private set; } = false;

    private Unit unit;

    public UnitStats(Unit unit)
    {
        this.unit = unit;

        HandleStart();
    }

    public void HandleStart()
    {
        StatsSO stats = unit.defaultStats;
        hp = stats.maxHp;
        maxHp = stats.maxHp;
        overHp = stats.overHp;
        unitType = stats.unitType;
        unitClassList = stats.unitClassList;

        armor = new Armor
        {
            slashingArmour = stats.slashingArmour,
            piercingArmour = stats.piercingArmour,
            magicalArmour = stats.magicalArmour,
        };

        damage = new Damage
        {
            damageType = stats.damageType,
            baseDamage = stats.baseDamage,
            bonusDamage = stats.bonusDamage,
            range = stats.range,
            attackSpeed = stats.attackSpeed
        };
        speed = stats.speed;

    }

    public void TakeDamage(float damage, Types.Damage damageType, Types.UnitClass dealerClass, Types.UnitType dealerType)
    {
        float actualDamage = damage;
        switch (damageType)
        {
            case Types.Damage.slashing:
                actualDamage -= armor.slashingArmour;
                break;
            case Types.Damage.piercing:
                actualDamage -= armor.piercingArmour;
                break;
            case Types.Damage.magical:
                actualDamage -= armor.magicalArmour;
                break;
        }

        actualDamage = Mathf.Max(1, actualDamage);

        hp = (int)(hp - damage);
        if (hp <= 0)
        {
            isDead = true;
        }
    }
}


