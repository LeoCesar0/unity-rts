using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{

    [SerializeField] Types.ResourceType resourceType;
    [SerializeField] float initialAmount = 20f;

    float resourceAmount;

    Rigidbody rigidbody;

    float gatherRate = 1f;

    private List<Villager> VillagersSentToGather = new List<Villager>();
    // private List<Villager> villagersInTouch = new List<Villager>();

    void Start()
    {
        resourceAmount = initialAmount;
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (resourceAmount <= 0)
        {
            Destroy(gameObject);
        }

        foreach (Villager vill in VillagersSentToGather)
        {
            HandleVillageGatherOnUpdate(vill);
        }
    }

    void HandleVillageGatherOnUpdate(Villager vill)
    {

    }

    void HandleUnitMovement(Villager vill)
    {
        Unit unit = vill.GetComponent<Unit>();

        if (vill.isGathering)
        {
            unit.unitMovement.navMeshAgent.isStopped = true;
        }
        else
        {
            unit.unitMovement.navMeshAgent.SetDestination(transform.position);
        }
    }

    public void SendToGatherResource(Villager vill)
    {
        VillagersSentToGather.Add(vill);
        ManageVillagerTask(vill);
        HandleUnitMovement(vill);
    }

    private IEnumerator GatherResource(Villager vill)
    {
        vill.SetIsGathering(true);

        float villGatherRate = GetVillagerGatherRate(vill);

        while (VillagersSentToGather.Contains(vill) && resourceAmount > 0)
        {
            float gatherDelay = 1f;
            yield return new WaitForSeconds(gatherDelay); 

            float amountGathered = gatherRate * villGatherRate;

            if (vill.isGathering)
            {
                vill.GatherResource(resourceType, amountGathered);
                resourceAmount -= amountGathered;
            }

            if (resourceAmount <= 0)
            {
                Destroy(gameObject);
            }
        }

        vill.SetIsGathering(false);
    }


    void ManageVillagerTask(Villager vill)
    {
        switch (resourceType)
        {
            case Types.ResourceType.food:
                vill.SetVillagerTask(Types.VillagerTasks.gatherFood);
                break;
            case Types.ResourceType.wood:
                vill.SetVillagerTask(Types.VillagerTasks.gatherWood);
                break;
            case Types.ResourceType.stone:
                vill.SetVillagerTask(Types.VillagerTasks.gatherStone);
                break;
            case Types.ResourceType.gold:
                vill.SetVillagerTask(Types.VillagerTasks.gatherGold);
                break;
            default:
                vill.SetVillagerTask(Types.VillagerTasks.idle);
                break;
        }

    }

    private void OnCollisionEnter(Collision other)
    {
        Villager vill = other.collider.GetComponent<Villager>();

        if (vill && VillagersSentToGather.Contains(vill))
        {
            vill.SetIsGathering(true);
            StartCoroutine(GatherResource(vill));
            // villagersInTouch.Add(vill);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        Villager vill = other.collider.GetComponent<Villager>();
        // villagersInTouch.Contains(vill)
        if (vill && vill.isGathering && VillagersSentToGather.Contains(vill))
        {
            // villagersInTouch.Remove(vill);
            vill.SetIsGathering(false);
            HandleUnitMovement(vill);
        }
    }


    private float GetVillagerGatherRate(Villager vill)
    {
        float villGatherRate = 1f;

        switch (resourceType)
        {
            case Types.ResourceType.food:
                villGatherRate = vill.foodGatherRate;
                break;
            case Types.ResourceType.wood:
                villGatherRate = vill.woodGatherRate;
                break;
            case Types.ResourceType.stone:
                villGatherRate = vill.stoneGatherRate;
                break;
            case Types.ResourceType.gold:
                villGatherRate = vill.goldGatherRate;
                break;
            default:
                villGatherRate = 1f;
                break;
        }
        return villGatherRate;
    }

}
