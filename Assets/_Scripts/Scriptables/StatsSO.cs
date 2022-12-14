using UnityEngine;


[CreateAssetMenu(fileName = "UnitStats", menuName = "RTS Project/UnitStats", order = 0)]
public class StatsSO : ScriptableObject {
    public Types.UnitType unitType;
    public Types.UnitClass unitClass;
    public int maxHp;
    public int overHp;
    public int slashingArmour;
    public int piercingArmour;
    public int magicalArmour;
    public Types.Damage damageType;
    public int baseDamage;
    public int bonusDamage;
    public float range;
    public float speed;
    public float attackSpeed;


}


