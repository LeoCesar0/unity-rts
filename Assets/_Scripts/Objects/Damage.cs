


public class Damage
{
    public Types.Damage damageType;
    public float baseDamage;
    public float bonusDamage;

     public float attackDamage
    {
        get { return baseDamage + bonusDamage; }
    }

    public float range;

    public float attackSpeed;


}