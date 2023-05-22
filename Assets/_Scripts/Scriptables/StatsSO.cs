using UnityEngine;
using System.Collections.Generic;


[CreateAssetMenu(fileName = "UnitStats", menuName = "RTS Project/UnitStats", order = 0)]
public class StatsSO : ScriptableObject {
    public Types.UnitType unitType;
    public List<Types.UnitClass> unitClassList = new List<Types.UnitClass>();
    public int maxHp;
    public int overHp;
    public int slashingArmour;
    public int piercingArmour;
    public int magicalArmour;
    public Types.Damage damageType;
    public float baseDamage;
    public float bonusDamage;
    public float range;
    public float speed;
    public float attackSpeed;


}


