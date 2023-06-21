
using UnityEngine;

public class Villager : Unit
{
    // Start is called before the first frame update
    public float wood = 0;
    public float stone = 0;
    public float food = 0;
    public float gold = 0;

    public float woodGatherRate = 1f;
    public float stoneGatherRate = 1f;
    public float foodGatherRate = 1f;
    public float goldGatherRate = 1f;

    public float carryCapacity = 15f;

    private Types.VillagerTasks currentTask = Types.VillagerTasks.idle;

    public bool isGathering { get; private set; } = false;

    protected override void Start()
    {
        // Call the setup method
        base.Start();
        // Setup();
    }

    public void DepositResourcesToPlayer()
    {

    }

    public void GatherResource(Types.ResourceType resourceType, float amount)
    {
        switch (resourceType)
        {
            case Types.ResourceType.wood:
                wood += amount;
                break;
            case Types.ResourceType.stone:
                stone += amount;
                break;
            case Types.ResourceType.food:
                food += amount;
                break;
            case Types.ResourceType.gold:
                gold += amount;
                break;
            default:
                throw new System.ArgumentException("Invalid resource type");
        }
    }


    public void SetVillagerTask(Types.VillagerTasks task)
    {
        currentTask = task;
    }


    public void SetIsGathering(bool active)
    {
        isGathering = active;
    }


    // public void InteractWithUnit(Unit unit){
    //     Debug.Log("INTERACT WITH UNIT VILLAGER");
    //     unitMovement.MoveTo(unit.transform.position);
    // }

}
