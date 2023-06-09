
public class Villager : Unit
{
    // Start is called before the first frame update
    public int wood = 0;
    public int stone = 0;
    public int food = 0;
    public int gold = 0;

    private Types.VillagerTasks currentTask = Types.VillagerTasks.idle;

    protected override void Start()
    {
        // Call the setup method
        base.Start();
        // Setup();
    }

    public void DepositResourcesToPlayer()
    {

    }

    public void GetResource(Types.ResourceType resourceType, int amount)
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


    public void SetVillagerTask(Types.VillagerTasks task){
        currentTask = task;
    }


}
