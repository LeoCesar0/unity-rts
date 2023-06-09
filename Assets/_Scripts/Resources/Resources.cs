using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resources : MonoBehaviour
{

    [SerializeField] Types.ResourceType resourceType;
    [SerializeField] float initialAmount = 200f;

    Rigidbody rigidbody;

    float collectRate = 1f;

    private List<Villager> villagersCollecting = new List<Villager>();
    private List<Villager> villagersInTouch = new List<Villager>();

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {

        foreach (Villager vill in villagersCollecting)
        {
            ManageVillagerOnUpdate(vill);
        }

    }

    

    void ManageVillagerOnUpdate(Villager vill)
    {
        bool isAtResource = false;


    }

    void HandleUnitMovement(Villager vill)
    {
        bool unitIsInTouch = villagersInTouch.Contains(vill);
        Unit unit = vill.GetComponent<Unit>();
        unit.unitMovement.navMeshAgent.SetDestination(transform.position);
    }

    void CollectResource(Villager vill)
    {
        villagersCollecting.Add(vill);
        ManagerVillagerTask(vill);

        HandleUnitMovement(vill);
    }



    void ManagerVillagerTask(Villager vill)
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

        if (vill)
        {
            villagersInTouch.Add(vill);
        }
    }
    private void OnCollisionExit(Collision other)
    {
        Villager vill = other.collider.GetComponent<Villager>();

        if (vill && villagersInTouch.Contains(vill))
        {
            villagersInTouch.Remove(vill);
        }
    }

}
