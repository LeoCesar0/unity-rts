using UnityEngine;

public class UnitAttack : MonoBehaviour
{
    public int baseDamage;
    public int bonusDamage;
    public int damage;
    public float range;
    public float speed;
    public float attackSpeed;
    private UnitStats stats;

    private bool started = false;

    private void Start()
    {
    }

    public void HandleStart(StatsSO data)
    {

        baseDamage = data.baseDamage;
        bonusDamage = data.bonusDamage;
        range = data.range;
        speed = data.speed;
        attackSpeed = data.attackSpeed;

        started = true;
    }

    private void Update()
    {
        if (!started) return;
    }


}
