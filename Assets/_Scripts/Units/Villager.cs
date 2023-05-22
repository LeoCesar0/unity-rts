
public class Villager : Unit
{
    // Start is called before the first frame update
    public int wood = 0;
    public int stone = 0;
    public int food = 0;
    public int gold = 0;


    protected override void Start()
    {
        // Call the setup method
        base.Start();
        // Setup();
    }

    // The setup method is abstract, so it must be overridden in a subclass
    // protected override void Setup()
    // {

    // }

    public void DepositResourcesToPlayer()
    {

    }

    public void GatherResources(Types.ResourceType resourceType, int amount)
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

}
